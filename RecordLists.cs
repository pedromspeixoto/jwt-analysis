using System;
using System.Data;
using System.Collections;
using System.Runtime.Serialization;
using System.Reflection;
using System.Xml;
using OutSystems.ObjectKeys;
using OutSystems.RuntimeCommon;
using OutSystems.HubEdition.RuntimePlatform;
using OutSystems.HubEdition.RuntimePlatform.Db;
using OutSystems.Internal.Db;
using OutSystems.HubEdition.RuntimePlatform.NewRuntime;

namespace OutSystems.NssJWT_Core {

	/// <summary>
	/// RecordList type <code>RLNameValuePairRecordList</code> that represents a record list of
	///  <code>NameValuePair</code>
	/// </summary>
	[Serializable()]
	public partial class RLNameValuePairRecordList: GenericRecordList<RCNameValuePairRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCNameValuePairRecord GetElementDefaultValue() {
			return new RCNameValuePairRecord("");
		}

		public T[] ToArray<T>(Func<RCNameValuePairRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLNameValuePairRecordList recordlist, Func<RCNameValuePairRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLNameValuePairRecordList(RCNameValuePairRecord[] array) {
			RLNameValuePairRecordList result = new RLNameValuePairRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLNameValuePairRecordList ToList<T>(T[] array, Func <T, RCNameValuePairRecord> converter) {
			RLNameValuePairRecordList result = new RLNameValuePairRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLNameValuePairRecordList FromRestList<T>(RestList<T> restList, Func <T, RCNameValuePairRecord> converter) {
			RLNameValuePairRecordList result = new RLNameValuePairRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLNameValuePairRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLNameValuePairRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLNameValuePairRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLNameValuePairRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = null;
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCNameValuePairRecord> NewList() {
			return new RLNameValuePairRecordList();
		}


	} // RLNameValuePairRecordList

	/// <summary>
	/// RecordList type <code>RLTokenSymmetricSigningCredentialsRecordList</code> that represents a record
	///  list of <code>TokenSymmetricSigningCredentials</code>
	/// </summary>
	[Serializable()]
	public partial class RLTokenSymmetricSigningCredentialsRecordList: GenericRecordList<RCTokenSymmetricSigningCredentialsRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCTokenSymmetricSigningCredentialsRecord GetElementDefaultValue() {
			return new RCTokenSymmetricSigningCredentialsRecord("");
		}

		public T[] ToArray<T>(Func<RCTokenSymmetricSigningCredentialsRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLTokenSymmetricSigningCredentialsRecordList recordlist, Func<RCTokenSymmetricSigningCredentialsRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLTokenSymmetricSigningCredentialsRecordList(RCTokenSymmetricSigningCredentialsRecord[] array) {
			RLTokenSymmetricSigningCredentialsRecordList result = new RLTokenSymmetricSigningCredentialsRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLTokenSymmetricSigningCredentialsRecordList ToList<T>(T[] array, Func <T, RCTokenSymmetricSigningCredentialsRecord> converter) {
			RLTokenSymmetricSigningCredentialsRecordList result = new RLTokenSymmetricSigningCredentialsRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLTokenSymmetricSigningCredentialsRecordList FromRestList<T>(RestList<T> restList, Func <T, RCTokenSymmetricSigningCredentialsRecord> converter) {
			RLTokenSymmetricSigningCredentialsRecordList result = new RLTokenSymmetricSigningCredentialsRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLTokenSymmetricSigningCredentialsRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLTokenSymmetricSigningCredentialsRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLTokenSymmetricSigningCredentialsRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLTokenSymmetricSigningCredentialsRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = null;
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCTokenSymmetricSigningCredentialsRecord> NewList() {
			return new RLTokenSymmetricSigningCredentialsRecordList();
		}


	} // RLTokenSymmetricSigningCredentialsRecordList

	/// <summary>
	/// RecordList type <code>RLTokenAsymmetricSigningCredentialsRecordList</code> that represents a record
	///  list of <code>TokenAsymmetricSigningCredentials</code>
	/// </summary>
	[Serializable()]
	public partial class RLTokenAsymmetricSigningCredentialsRecordList: GenericRecordList<RCTokenAsymmetricSigningCredentialsRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCTokenAsymmetricSigningCredentialsRecord GetElementDefaultValue() {
			return new RCTokenAsymmetricSigningCredentialsRecord("");
		}

		public T[] ToArray<T>(Func<RCTokenAsymmetricSigningCredentialsRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLTokenAsymmetricSigningCredentialsRecordList recordlist, Func<RCTokenAsymmetricSigningCredentialsRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLTokenAsymmetricSigningCredentialsRecordList(RCTokenAsymmetricSigningCredentialsRecord[] array) {
			RLTokenAsymmetricSigningCredentialsRecordList result = new RLTokenAsymmetricSigningCredentialsRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLTokenAsymmetricSigningCredentialsRecordList ToList<T>(T[] array, Func <T, RCTokenAsymmetricSigningCredentialsRecord> converter) {
			RLTokenAsymmetricSigningCredentialsRecordList result = new RLTokenAsymmetricSigningCredentialsRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLTokenAsymmetricSigningCredentialsRecordList FromRestList<T>(RestList<T> restList, Func <T, RCTokenAsymmetricSigningCredentialsRecord> converter) {
			RLTokenAsymmetricSigningCredentialsRecordList result = new RLTokenAsymmetricSigningCredentialsRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLTokenAsymmetricSigningCredentialsRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLTokenAsymmetricSigningCredentialsRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLTokenAsymmetricSigningCredentialsRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLTokenAsymmetricSigningCredentialsRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = null;
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCTokenAsymmetricSigningCredentialsRecord> NewList() {
			return new RLTokenAsymmetricSigningCredentialsRecordList();
		}


	} // RLTokenAsymmetricSigningCredentialsRecordList

	/// <summary>
	/// RecordList type <code>RLTokenPayloadRecordList</code> that represents a record list of
	///  <code>TokenPayload</code>
	/// </summary>
	[Serializable()]
	public partial class RLTokenPayloadRecordList: GenericRecordList<RCTokenPayloadRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCTokenPayloadRecord GetElementDefaultValue() {
			return new RCTokenPayloadRecord("");
		}

		public T[] ToArray<T>(Func<RCTokenPayloadRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLTokenPayloadRecordList recordlist, Func<RCTokenPayloadRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLTokenPayloadRecordList(RCTokenPayloadRecord[] array) {
			RLTokenPayloadRecordList result = new RLTokenPayloadRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLTokenPayloadRecordList ToList<T>(T[] array, Func <T, RCTokenPayloadRecord> converter) {
			RLTokenPayloadRecordList result = new RLTokenPayloadRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLTokenPayloadRecordList FromRestList<T>(RestList<T> restList, Func <T, RCTokenPayloadRecord> converter) {
			RLTokenPayloadRecordList result = new RLTokenPayloadRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLTokenPayloadRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLTokenPayloadRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLTokenPayloadRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLTokenPayloadRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = null;
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCTokenPayloadRecord> NewList() {
			return new RLTokenPayloadRecordList();
		}


	} // RLTokenPayloadRecordList

	/// <summary>
	/// RecordList type <code>RLVerifySignatureOptionsRecordList</code> that represents a record list of
	///  <code>VerifySignatureOptions</code>
	/// </summary>
	[Serializable()]
	public partial class RLVerifySignatureOptionsRecordList: GenericRecordList<RCVerifySignatureOptionsRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCVerifySignatureOptionsRecord GetElementDefaultValue() {
			return new RCVerifySignatureOptionsRecord("");
		}

		public T[] ToArray<T>(Func<RCVerifySignatureOptionsRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLVerifySignatureOptionsRecordList recordlist, Func<RCVerifySignatureOptionsRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLVerifySignatureOptionsRecordList(RCVerifySignatureOptionsRecord[] array) {
			RLVerifySignatureOptionsRecordList result = new RLVerifySignatureOptionsRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLVerifySignatureOptionsRecordList ToList<T>(T[] array, Func <T, RCVerifySignatureOptionsRecord> converter) {
			RLVerifySignatureOptionsRecordList result = new RLVerifySignatureOptionsRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLVerifySignatureOptionsRecordList FromRestList<T>(RestList<T> restList, Func <T, RCVerifySignatureOptionsRecord> converter) {
			RLVerifySignatureOptionsRecordList result = new RLVerifySignatureOptionsRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLVerifySignatureOptionsRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLVerifySignatureOptionsRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLVerifySignatureOptionsRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLVerifySignatureOptionsRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = null;
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCVerifySignatureOptionsRecord> NewList() {
			return new RLVerifySignatureOptionsRecordList();
		}


	} // RLVerifySignatureOptionsRecordList

	/// <summary>
	/// RecordList type <code>RLTokenHeaderRecordList</code> that represents a record list of
	///  <code>TokenHeader</code>
	/// </summary>
	[Serializable()]
	public partial class RLTokenHeaderRecordList: GenericRecordList<RCTokenHeaderRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCTokenHeaderRecord GetElementDefaultValue() {
			return new RCTokenHeaderRecord("");
		}

		public T[] ToArray<T>(Func<RCTokenHeaderRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLTokenHeaderRecordList recordlist, Func<RCTokenHeaderRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLTokenHeaderRecordList(RCTokenHeaderRecord[] array) {
			RLTokenHeaderRecordList result = new RLTokenHeaderRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLTokenHeaderRecordList ToList<T>(T[] array, Func <T, RCTokenHeaderRecord> converter) {
			RLTokenHeaderRecordList result = new RLTokenHeaderRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLTokenHeaderRecordList FromRestList<T>(RestList<T> restList, Func <T, RCTokenHeaderRecord> converter) {
			RLTokenHeaderRecordList result = new RLTokenHeaderRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLTokenHeaderRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLTokenHeaderRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLTokenHeaderRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLTokenHeaderRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = null;
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCTokenHeaderRecord> NewList() {
			return new RLTokenHeaderRecordList();
		}


	} // RLTokenHeaderRecordList
}
