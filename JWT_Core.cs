using System;
using System.Collections;
using System.Data;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using OutSystems.HubEdition.RuntimePlatform;
using OutSystems.RuntimePublic.Db;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Microsoft.IdentityModel.Logging;

namespace OutSystems.NssJWT_Core {

	public class CssJWT_Core: IssJWT_Core {

		/// <summary>
		/// 
		/// </summary>
		public void MssVerifyToken() {
			// TODO: Write implementation for action
		} // MssVerifyToken

        private const string SUBJECT_CLAIM_NAME = "sub";
        private const string TOKENID_CLAIM_NAME = "jti";
        private const string KEYID_CLAIM_NAME = "kid";

        /// <summary>
        /// Created a new token based on the defined claims and signing definitions.
        /// </summary>
        /// <param name="ssSymmetricCredentials">Credentials necessary to sign the token with a symmetric key.</param>
        /// <param name="ssAsymmetricCredentials">Credentials necessary to sign the token with an asymmetric key.</param>
        /// <param name="ssPayload">Complete list of the claims for the token. </param>
        /// <param name="ssShowDebugInformation">Enable returning debug information</param>
        /// <param name="ssPlainToken">Unencoded and formatted JSON of the JSON Web Token.</param>
        /// <param name="ssSignedAndEncodedToken">Encoded and signed JSON Web TOken.</param>
        /// <param name="ssResultMessage">Resulting status message, for additional information.</param>
        public void MssCreateToken(RCTokenSymmetricSigningCredentialsRecord ssSymmetricCredentials, RCTokenAsymmetricSigningCredentialsRecord ssAsymmetricCredentials, RCTokenPayloadRecord ssPayload, bool ssShowDebugInformation, out string ssResultMessage, out string ssPlainToken, out string ssEncodedToken) {

            // Enable showing debug information
            IdentityModelEventSource.ShowPII = ssShowDebugInformation;

            ssPlainToken = "";
            ssEncodedToken = "";
            ssResultMessage = "";

            var tokenDescriptor = new SecurityTokenDescriptor();   

            // Reserved and known claims
            tokenDescriptor.Audience = ssPayload.ssSTTokenPayload.ssAudience;
            tokenDescriptor.Expires = ssPayload.ssSTTokenPayload.ssExpiration;
            tokenDescriptor.IssuedAt = ssPayload.ssSTTokenPayload.ssIssuedAt;
            tokenDescriptor.Issuer = ssPayload.ssSTTokenPayload.ssIssuer;
            tokenDescriptor.NotBefore = ssPayload.ssSTTokenPayload.ssNotBefore;
            tokenDescriptor.Subject = new System.Security.Claims.ClaimsIdentity();

            tokenDescriptor.Subject.AddClaim(
                        new Claim(
                            SUBJECT_CLAIM_NAME,
                            ssPayload.ssSTTokenPayload.ssSubject));

            tokenDescriptor.Subject.AddClaim(
                        new Claim(
                            TOKENID_CLAIM_NAME,
                            ssPayload.ssSTTokenPayload.ssTokenId));

            
            // Custom claims
            if (ssPayload != null)
            {                

                foreach (RCNameValuePairRecord claim in ssPayload.ssSTTokenPayload.ssCustomClaims)
                {
                    // we should only have one jti and kid
                    if (claim.ssSTNameValuePair.ssName == TOKENID_CLAIM_NAME
                        || claim.ssSTNameValuePair.ssName == KEYID_CLAIM_NAME)
                    {
                        // no need to add this claim
                        continue;
                    }

                    tokenDescriptor.Subject.AddClaim(
                        new Claim(
                            claim.ssSTNameValuePair.ssName,
                            claim.ssSTNameValuePair.ssValue));
                }
            }
            


            //Signing and encryption credentials
            tokenDescriptor.SigningCredentials = CreateSigningCredentials(
                ssSymmetricCredentials,
                ssAsymmetricCredentials);

            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                ssPlainToken = tokenHandler.CreateJwtSecurityToken(tokenDescriptor).ToString();
                ssEncodedToken = tokenHandler.CreateEncodedJwt(tokenDescriptor);
            }
            catch (InvalidOperationException e)
            {
                throw new JwtException("Unable to generate token.", e);
            }


            if (tokenDescriptor.SigningCredentials == null)
            {
                ssResultMessage = "No signing credentials were was supplied, token " + ssPayload.ssSTTokenPayload.ssTokenId + " encoded but not signed.";
            }
            else if (!string.IsNullOrEmpty(tokenDescriptor.SigningCredentials.Kid))
            {
                ssResultMessage = "Token " + ssPayload.ssSTTokenPayload.ssTokenId + " signed with key id " + tokenDescriptor.SigningCredentials.Kid + " using algorithm " + tokenDescriptor.SigningCredentials.Algorithm;
            }
            else
            {
                ssResultMessage = "Token  " + ssPayload.ssSTTokenPayload.ssTokenId + " signed using algorithm " + tokenDescriptor.SigningCredentials.Algorithm;
            }

            

        } // MssCreateToken


        private SigningCredentials CreateSigningCredentials(RCTokenSymmetricSigningCredentialsRecord symmetricCredentials, RCTokenAsymmetricSigningCredentialsRecord asymmetricCredentials)
        {


            if (symmetricCredentials != null && !string.IsNullOrEmpty(symmetricCredentials.ssSTTokenSymmetricSigningCredentials.ssAlgorithm))
            {

                return JwtAuth.CreateSymmetricSigningCredentials(
                    symmetricCredentials.ssSTTokenSymmetricSigningCredentials.ssKeyId,
                    symmetricCredentials.ssSTTokenSymmetricSigningCredentials.ssAlgorithm,
                    symmetricCredentials.ssSTTokenSymmetricSigningCredentials.ssKey);
            }
            else if (symmetricCredentials != null && asymmetricCredentials.ssSTTokenAsymmetricSigningCredentials.ssKeyIsJwk)
            {
                // No need to validate algorithm and key id of JWK, the json contains all that information
                return JwtAuth.CreateAsymmetricSigningCredentialsFromJwk(asymmetricCredentials.ssSTTokenAsymmetricSigningCredentials.ssPrivateKey);
            }
            else if (symmetricCredentials != null && !string.IsNullOrEmpty(asymmetricCredentials.ssSTTokenAsymmetricSigningCredentials.ssAlgorithm))
            {
                if (!String.IsNullOrEmpty(asymmetricCredentials.ssSTTokenAsymmetricSigningCredentials.ssPrivateExponent) &&
                !String.IsNullOrEmpty(asymmetricCredentials.ssSTTokenAsymmetricSigningCredentials.ssModulus))
                {
                    return JwtAuth.CreateAsymmetricSigningCredentialsFromModulusExponent(
                        asymmetricCredentials.ssSTTokenAsymmetricSigningCredentials.ssKeyId,
                        asymmetricCredentials.ssSTTokenAsymmetricSigningCredentials.ssAlgorithm,
                        asymmetricCredentials.ssSTTokenAsymmetricSigningCredentials.ssPublicExponent,
                        asymmetricCredentials.ssSTTokenAsymmetricSigningCredentials.ssPrivateExponent,
                        asymmetricCredentials.ssSTTokenAsymmetricSigningCredentials.ssModulus,
                        asymmetricCredentials.ssSTTokenAsymmetricSigningCredentials.ssUseMachineKeystore);
                }
                else
                {
                    return JwtAuth.CreateAsymmetricSigningCredentialsFromPem(
                        asymmetricCredentials.ssSTTokenAsymmetricSigningCredentials.ssKeyId,
                        asymmetricCredentials.ssSTTokenAsymmetricSigningCredentials.ssAlgorithm,
                        asymmetricCredentials.ssSTTokenAsymmetricSigningCredentials.ssPrivateKey,
                        asymmetricCredentials.ssSTTokenAsymmetricSigningCredentials.ssPrivateKeyPassphrase,
                        asymmetricCredentials.ssSTTokenAsymmetricSigningCredentials.ssUseMachineKeystore);
                }
            }
                



            // No credentials needed
            return null;

        }



        /// <summary>
        /// Reads a token encoded in JSON Compact serialized format.
        /// </summary>
        /// <param name="ssVerifySignature">Set to run token signature verification</param>
        /// <param name="ssSignedAndEncodedToken">The input token, enconded in base64</param>
        /// <param name="ssSignatureKey">Key used to verify the token. Secrete key for symmetric algorithms, public key for asymmetric algorithms. </param>
        /// <param name="ssSignatureKeyId">Id assigned to the key used to sign the token</param>
        /// <param name="ssVerifyLifetime"></param>
        /// <param name="ssVerifyIssuer"></param>
        /// <param name="ssIssuer"></param>
        /// <param name="ssVerifyAudience"></param>
        /// <param name="ssAudience"></param>
        /// <param name="ssShowDebugInformation">Enable returning debug information</param>
        /// <param name="ssPayload">Full list of token claims</param>
        /// <param name="ssHasValidToken">result of token verification</param>
        /// <param name="ssPlainToken">Decoded token</param>
        /// <param name="ssResultMessage"></param>
        public void MssReadToken(string ssEncodedToken, bool ssVerifySignature, string ssSignatureKey, string ssSignatureKeyId, bool ssVerifyLifetime, bool ssVerifyIssuer, string ssIssuer, bool ssVerifyAudience, string ssAudience, bool ssShowDebugInformation, out string ssPlainToken, out RCTokenHeaderRecord ssTokenHeader, out RCTokenPayloadRecord ssTokenPayload, out bool ssHasValidToken, out string ssResultMessage) {


            // Enable showing debug information
            IdentityModelEventSource.ShowPII = ssShowDebugInformation;


            var tokenHandler = new JwtSecurityTokenHandler();

            JwtSecurityToken token = tokenHandler.ReadToken(ssEncodedToken) as JwtSecurityToken;
            ssResultMessage = "";

            ssPlainToken = token.ToString();

            SecurityToken tokenOut;


            // Setup Identity.Token claims validation
            if (ssVerifySignature || ssVerifyLifetime || ssVerifyAudience || ssVerifyIssuer)
            {
                // Validate the correct key was used
                if (ssVerifySignature && !String.IsNullOrEmpty(ssSignatureKeyId) && !String.Equals(ssSignatureKeyId,token.Header.Kid))
                {
                    ssHasValidToken = false;
                    ssResultMessage = "Token signed with different key that expedted. Actual: <" + token.Header.Kid + ">, Expected: <" + ssSignatureKeyId + ">";
                }
                else
                {
                    try
                    {

                        tokenHandler.ValidateToken(
                                   ssEncodedToken,
                                   new TokenValidationParameters()
                                   {
                                       ValidateActor = false,
                                       ValidateLifetime = ssVerifyLifetime,
                                       ValidateAudience = ssVerifyAudience,
                                       ValidAudience = ssAudience,
                                       ValidateIssuer = ssVerifyIssuer,
                                       ValidIssuer = ssIssuer,
                                       ValidateIssuerSigningKey = ssVerifySignature,
                                       IssuerSigningKey = JwtAuth.CreateSecurityKeyForVerifying(token.SignatureAlgorithm, ssSignatureKey, ssSignatureKeyId)
                                   },
                                   out tokenOut);



                        ssHasValidToken = true;
                    }
                    catch (JwtException)
                    {
                        // Already is a 
                        throw;
                    }
                    catch (SecurityTokenValidationException exception)
                    {
                        // Handling Validation exceptions as return errors
                        
                        ssHasValidToken = false;
                        ssResultMessage = exception.Message;

                        if (exception.InnerException != null)
                        {
                            ssResultMessage += (" (" + exception.InnerException.Message + ")");
                        }
                     
                    }
                    catch (SecurityTokenException exception)
                    {
                        var message = "Error processing the security token: " + exception.Message;

                        if (exception.InnerException != null)
                        {
                            message += (" (" + exception.InnerException.Message + ")");
                        }

                        throw new JwtException(message, exception);

                    }
                    catch (Exception exception)
                    {
                        var message = "Unexpected error validating the token: " + exception.Message;

                        if (exception.InnerException != null)
                        {
                            message += (" (" + exception.InnerException.Message + ")");
                        }

                        throw new JwtException(message, exception);

                    }
                }
            }
            else
            {
                ssHasValidToken = true;
                ssResultMessage = "No validation performed on token."; 
            }

            // TODO: obtain all audiences, not only the first
            ssTokenPayload = new RCTokenPayloadRecord()
            {
                ssSTTokenPayload = new STTokenPayloadStructure()
                {
                    ssExpiration = token.ValidTo,
                    ssNotBefore = token.ValidFrom,
                    ssIssuer = token.Issuer,
                    ssTokenId = token.Id,                    
                    ssSubject = token.Subject,
                    ssCustomClaims = new RLNameValuePairRecordList()
                }

            };

            ssTokenHeader = new RCTokenHeaderRecord()
            {
                ssSTTokenHeader = new STTokenHeaderStructure()
                {
                    ssKeyId = token.Header.Kid,
                    ssAlgorithm = token.Header.Alg
                }

            };


            foreach (var customClaim in token.Claims)
            {
                // ignore the reserved claims, validated separately
                if (customClaim.Type == "jti" || customClaim.Type == "iss" || customClaim.Type == "sub" 
                    || customClaim.Type == "exp" || customClaim.Type == "nbf")
                {
                    continue;
                }

                // token issue date doesn't seem to be read by the tokenHandler
                // must do it separately

                double iatNumeric;

                if (customClaim.Type == "iat" && double.TryParse(customClaim.Value, out iatNumeric))
                {
                    var time = TimeSpan.FromSeconds(iatNumeric);

                    ssTokenPayload.ssSTTokenPayload.ssIssuedAt = new DateTime(1970, 1, 1) + time;

                    // no need to add this to custom claims
                    continue;
                    
                }

                if(customClaim.Type == "aud")
                {
                    ssTokenPayload.ssSTTokenPayload.ssAudience = customClaim.Value;

                    // no need to add this to custom claims
                    continue;
                }

                ssTokenPayload.ssSTTokenPayload.ssCustomClaims.Add(
                    new RCNameValuePairRecord() {
                        ssSTNameValuePair = new STNameValuePairStructure() {
                            ssName = customClaim.Type,
                            ssValue = customClaim.Value,
                        }
                    });
            }
       
		} // MssReadToken

	} // CssJWT_Core

} // OutSystems.NssJWT_Core

