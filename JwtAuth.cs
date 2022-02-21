using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

[assembly: InternalsVisibleTo("JWT_Core_Test_new")]

namespace OutSystems.NssJWT_Core
{

    internal class JwtAuth
    {

        private static RSA CreateRSAProvider(RSAParameters rp, bool useMachineKeystore = false)
        {

            RSACryptoServiceProvider.UseMachineKeyStore = useMachineKeystore;

            RSA rsaCsp = RSACryptoServiceProvider.Create();
            rsaCsp.ImportParameters(rp);
            return rsaCsp;
        }

        public static SigningCredentials CreateSymmetricSigningCredentials(string keyId, string signingAlgorithm, string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new JwtException("Missing key. For signing the token with a symmetric algorithm a key is needed. Leave the signing credentials empty to keep the token unsigned.");
            }

            byte[] keyBytes = Encoding.Default.GetBytes(key);

            if (keyBytes.Length < 16)
            {
                throw new JwtException("Key too short. For signing the token with a symmetric algorithm a key longer than 128 bits is needed. Leave the signing credentials empty to keep the token unsigned.");
            }

            // Generating symmetric key
            var securityKey = new SymmetricSecurityKey(keyBytes)
            {
                KeyId = keyId
            };

            if (!CryptoProviderFactory.Default.IsSupportedAlgorithm(signingAlgorithm, securityKey))
            {
                throw new JwtException("Symmetric algorithm not supported: " + signingAlgorithm);
            }

            return new SigningCredentials(securityKey, signingAlgorithm);
        }

        public static SigningCredentials CreateAsymmetricSigningCredentialsFromModulusExponent(string keyId, string signingAlgorithm, string publicExponent, string privateExponent, string modulus, bool useMachineKeystore)
        {

            RSAParameters rsaParameters;

            rsaParameters = CreateRSAParametersFromModulusExponent(keyId, signingAlgorithm, privateExponent, modulus);

            RSA rsaProvider = CreateRSAProvider(rsaParameters, useMachineKeystore);

            var securityKey = new RsaSecurityKey(rsaProvider)
            {
                KeyId = keyId
            };

            if (!CryptoProviderFactory.Default.IsSupportedAlgorithm(signingAlgorithm, securityKey))
            {
                throw new JwtException("Asymmetric algorithm not supported: " + signingAlgorithm);
            }

            return new SigningCredentials(securityKey, signingAlgorithm);

        }


        public static SigningCredentials CreateAsymmetricSigningCredentialsFromJwk(string jwk)
        {

            JsonWebKey securityKey = JsonWebKey.Create(jwk);

            // Validate if there's a private key to sign the token

            if (securityKey.Kty != "RSA")
            {
                throw new JwtException("Key type " + securityKey.Kty + " is not supported, please provide a JSON Web Key using a RSA algorithm");
            }

            if (!securityKey.HasPrivateKey)
            {
                throw new JwtException("Unable to sign token, given JSON Web Key does not contain a private key");
            }

            

            return new SigningCredentials(securityKey, securityKey.Alg);

        }

        public static SigningCredentials CreateAsymmetricSigningCredentialsFromPem(string keyId, string signingAlgorithm, string privateKey, string privateKeyPassword, bool useMachineKeystore)
        {

            RSAParameters rsaParameters;

            if (privateKey.IndexOf("BEGIN RSA PRIVATE KEY") != -1)
            {
                rsaParameters = CreateRSAParametersFromPKCS5(
                    keyId,
                    signingAlgorithm,
                    privateKey,
                    privateKeyPassword);
            }
            else {
                rsaParameters = CreateRSAParametersFromPKCS8(
                    keyId,
                    signingAlgorithm,
                    privateKey,
                    privateKeyPassword);
            }

            RSA rsaProvider = CreateRSAProvider(rsaParameters, useMachineKeystore);

            var securityKey = new RsaSecurityKey(rsaProvider)
            {
                KeyId = keyId
            };

            if (!CryptoProviderFactory.Default.IsSupportedAlgorithm(signingAlgorithm, securityKey))
            {
                throw new JwtException("Asymmetric algorithm not supported: " + signingAlgorithm);
            }

            return new SigningCredentials(securityKey, signingAlgorithm);

        }

        private static RSAParameters CreateRSAParametersFromPKCS8(string keyId, string signingAlgorithm, string privateKey, string privateKeyPassword)
        {

            // Check if we have only the public key and not the private key to sign the token
            if (string.IsNullOrEmpty(privateKey))
            {
                throw new JwtException("Missing private key. For signing the token with an asymmetric algorithm the private key is needed. Leave the signing credentials empty to keep the token unsigned.");
            }

            PEMPasswordFinder pwf = null;

            if (!String.IsNullOrEmpty(privateKeyPassword))
            {
                pwf = new PEMPasswordFinder(privateKeyPassword);
            }

            RsaPrivateCrtKeyParameters key = null;

            try
            {
                using (var reader = new StringReader(privateKey))
                {
                    key = (RsaPrivateCrtKeyParameters)new PemReader(reader, pwf).ReadObject();
                }
            }
            catch (System.Exception exception)
            {

                throw new JwtException("Unable to open private key. Validate if private key in PEM format and password is correct.", exception);
            }

            if (key == null)
            {
                throw new JwtException("Unable to open private key. Validate if private key in PEM format and password is correct.");
            }

            return DotNetUtilities.ToRSAParameters(key);
            
        }

        private static RSAParameters CreateRSAParametersFromModulusExponent(string keyId, string signingAlgorithm, string privateExponent, string modulus)
        {

            byte[] mBytes = Base64UrlEncoder.DecodeBytes(modulus);
            byte[] eBytes = Base64UrlEncoder.DecodeBytes(privateExponent);



            RsaKeyParameters rsaKeyParameters = new RsaKeyParameters(
                true, 
                new Org.BouncyCastle.Math.BigInteger(mBytes), 
                new Org.BouncyCastle.Math.BigInteger(eBytes));

            return DotNetUtilities.ToRSAParameters(rsaKeyParameters);
        }

        private static RSAParameters CreateRSAParametersFromPKCS5(string keyId, string signingAlgorithm, string privateKey, string privateKeyPassword)
        {
            // Check if we have only the public key and not the private key to sign the token
            if (string.IsNullOrEmpty(privateKey))
            {
                throw new JwtException("Missing private key. For signing the token with an asymmetric algorithm the private key is needed. Leave the signing credentials empty to keep the token unsigned.");
            }

            PEMPasswordFinder pwf = null;

            if (!String.IsNullOrEmpty(privateKeyPassword))
            {
                pwf = new PEMPasswordFinder(privateKeyPassword);
            }

            AsymmetricCipherKeyPair keyPair = null;

            try
            {
                using (var reader = new StringReader(privateKey))
                {
                    keyPair = (AsymmetricCipherKeyPair)new PemReader(reader, pwf).ReadObject();
                }
            }
            catch (System.Exception exception)
            {

                throw new JwtException("Unable to open private key. Validate if private key in PEM format and password is correct.", exception);
            }

            if (keyPair == null)
            {
                throw new JwtException("Unable to open private key. Validate if private key in PEM format and password is correct.");
            }

            return DotNetUtilities.ToRSAParameters((RsaPrivateCrtKeyParameters)keyPair.Private);
        }

        public static SecurityKey CreateSecurityKeyForVerifying(string algorithm, string key, string keyId)
        {
            if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(algorithm))
            {
                return null;
            }
            key = key.Trim();

            // Check if it's a JSON Web Token
            if (key.StartsWith("{") && key.EndsWith("}"))
            {
                var jwk = JsonWebKey.Create(key);

                if (jwk.Kty != "RSA")
                {
                    throw new JwtException("Key type" + jwk.Kty + " is not supported, please provide a JSON Web Key using a RSA algorithm");
                }

                return jwk;

            }
            // Asymmetric PEM key
            else if (algorithm.Contains("RS"))
            {

                RsaKeyParameters rsaKeyParameters = null;

                // Create an RSA only with public key
                try
                {
                    using (var reader = new StringReader(key))
                    {

                        object pemReaderObect = new PemReader(reader).ReadObject();


                        // a key in Pem format should already be a RsaKeyParameters instance
                        rsaKeyParameters = pemReaderObect as RsaKeyParameters;

                        if (rsaKeyParameters == null)
                        {
                            Org.BouncyCastle.X509.X509Certificate x509Certificate = pemReaderObect as Org.BouncyCastle.X509.X509Certificate;

                            // must check if it's a x509 certificate, if so must extract the public key from it
                            if (x509Certificate != null)
                            {
                                rsaKeyParameters = x509Certificate.GetPublicKey() as RsaKeyParameters; 
                            }
                            
                        }
                    }
                }
                catch (System.Exception exception)
                {

                    throw new JwtException("Error opening public key.", exception);
                }

                if (rsaKeyParameters == null)
                {
                    throw new JwtException("Unable to open public key. Validate if key is in PEM format.");
                }

                
                return new RsaSecurityKey(DotNetUtilities.ToRSAParameters(rsaKeyParameters))
                {
                    KeyId = keyId
                };

            }
            // Symmetric key
            else if (algorithm.Contains("HS"))
            {

                return JwtAuth.CreateSymmetricSigningCredentials(
                    keyId,
                    algorithm,
                    key).Key;
            }
            

            //TODO: ECDA encryption


            // No credentials needed
            return null;

        }

        static byte[] FromBase64Url(string base64Url)
        {
            string padded = base64Url.Length % 4 == 0
                ? base64Url : base64Url + "====".Substring(base64Url.Length % 4);
            string base64 = padded.Replace("_", "/")
                                  .Replace("-", "+");
            return Convert.FromBase64String(base64);
        }


    }

    internal class PEMPasswordFinder : IPasswordFinder
    {
        private string pword;
        public PEMPasswordFinder(string password) { pword = password; }
        public char[] GetPassword() { return pword.ToCharArray(); }
    }
}
