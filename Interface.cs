using System;
using System.Collections;
using System.Data;
using OutSystems.HubEdition.RuntimePlatform;

namespace OutSystems.NssJWT_Core {

	public interface IssJWT_Core {

		/// <summary>
		/// Created a new token based on the defined claims and signing definitions.
		/// If both symmetric and asymmetric signing credentials are passed as input will throw an error, if none of signing credentials are passed the token will be generated but not signed.
		/// </summary>
		/// <param name="ssSymmetricCredentials">Credentials necessary to sign the token with a symmetric key.</param>
		/// <param name="ssAsymmetricCredentials">Credentials necessary to sign the token with an asymmetric key.</param>
		/// <param name="ssPayload">Complete token claims list.</param>
		/// <param name="ssShowDebugInformation"></param>
		/// <param name="ssResultMessage"></param>
		/// <param name="ssPlainToken">Token&apos;s Header and Payload in JSON format, </param>
		/// <param name="ssEncodedToken">Encoded Token. Signing options were passed it will include the signature, if not only the header and payload.</param>
		void MssCreateToken(RCTokenSymmetricSigningCredentialsRecord ssSymmetricCredentials, RCTokenAsymmetricSigningCredentialsRecord ssAsymmetricCredentials, RCTokenPayloadRecord ssPayload, bool ssShowDebugInformation, out string ssResultMessage, out string ssPlainToken, out string ssEncodedToken);

		/// <summary>
		/// Reads a token encoded in JSON Compact serialized format. Returns
		/// </summary>
		/// <param name="ssEncodedToken">The token to be decoded, and verified if needed. </param>
		/// <param name="ssVerifySignature">Indicates if the token&apos;s signature should be verified.</param>
		/// <param name="ssSignatureKey">Key used to verify the token, needed only if VerifySignature is selected. The algorithm is read from the token.
		/// 
		/// For symmetric algorithms will be the secret key, for asymmetric algorithms will be the public key of the keypair.</param>
		/// <param name="ssSignatureKeyId">Id assigned to the key used for signing the token.</param>
		/// <param name="ssVerifyLifetime">Indicates if token&apos;s lifetime should be validated.</param>
		/// <param name="ssVerifyIssuer">Indicates if the token&apos;s issuer should be validated.</param>
		/// <param name="ssIssuer">Issuer to be validated in the token.</param>
		/// <param name="ssVerifyAudience">Indicates the audience should be validated.</param>
		/// <param name="ssAudience">Issuer to be validated in the token.</param>
		/// <param name="ssShowDebugInformation"></param>
		/// <param name="ssPlainToken">Plain text token with the claims in JSON format.</param>
		/// <param name="ssTokenHeader">Structure containing the token header</param>
		/// <param name="ssTokenPayload">Structure containing the token payload, invluding the custom claimsr</param>
		/// <param name="ssHasValidToken">Result of the signature verification.</param>
		/// <param name="ssResultMessage">Should be empty if validation succeeds, if the validation fails should contain the output message.</param>
		void MssReadToken(string ssEncodedToken, bool ssVerifySignature, string ssSignatureKey, string ssSignatureKeyId, bool ssVerifyLifetime, bool ssVerifyIssuer, string ssIssuer, bool ssVerifyAudience, string ssAudience, bool ssShowDebugInformation, out string ssPlainToken, out RCTokenHeaderRecord ssTokenHeader, out RCTokenPayloadRecord ssTokenPayload, out bool ssHasValidToken, out string ssResultMessage);

	} // IssJWT_Core

} // OutSystems.NssJWT_Core
