using System;
using System.Collections;
using System.Data;
using System.Runtime.Serialization;
using System.Reflection;
using System.Xml;
using OutSystems.ObjectKeys;
using OutSystems.RuntimeCommon;
using OutSystems.HubEdition.RuntimePlatform;
using OutSystems.HubEdition.RuntimePlatform.Db;
using OutSystems.Internal.Db;

namespace OutSystems.NssJWT_Core {

	/// <summary>
	/// Structure <code>RCNameValuePairRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCNameValuePairRecord: ISerializable, ITypedRecord<RCNameValuePairRecord> {
		internal static readonly GlobalObjectKey IdNameValuePair = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*b9IdQwmM8KSCTW1lEh2AOw");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("NameValuePair")]
		public STNameValuePairStructure ssSTNameValuePair;


		public static implicit operator STNameValuePairStructure(RCNameValuePairRecord r) {
			return r.ssSTNameValuePair;
		}

		public static implicit operator RCNameValuePairRecord(STNameValuePairStructure r) {
			RCNameValuePairRecord res = new RCNameValuePairRecord(null);
			res.ssSTNameValuePair = r;
			return res;
		}

		public BitArray OptimizedAttributes;

		public RCNameValuePairRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssSTNameValuePair = new STNameValuePairStructure(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = null;
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
				} else {
					ssSTNameValuePair.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = null;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssSTNameValuePair.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCNameValuePairRecord r) {
			this = r;
		}


		public static bool operator == (RCNameValuePairRecord a, RCNameValuePairRecord b) {
			if (a.ssSTNameValuePair != b.ssSTNameValuePair) return false;
			return true;
		}

		public static bool operator != (RCNameValuePairRecord a, RCNameValuePairRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCNameValuePairRecord)) return false;
			return (this == (RCNameValuePairRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssSTNameValuePair.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCNameValuePairRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssSTNameValuePair = new STNameValuePairStructure(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssSTNameValuePair", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssSTNameValuePair' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssSTNameValuePair = (STNameValuePairStructure) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssSTNameValuePair.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssSTNameValuePair.InternalRecursiveSave();
		}


		public RCNameValuePairRecord Duplicate() {
			RCNameValuePairRecord t;
			t.ssSTNameValuePair = (STNameValuePairStructure) this.ssSTNameValuePair.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssSTNameValuePair.ToXml(this, recordElem, "NameValuePair", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "namevaluepair") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".NameValuePair")) variable.Value = ssSTNameValuePair; else variable.Optimized = true;
				variable.SetFieldName("namevaluepair");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			throw new Exception("Method not Supported");
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			throw new Exception("Method not Supported");
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdNameValuePair) {
				return ssSTNameValuePair;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssSTNameValuePair.FillFromOther((IRecord) other.AttributeGet(IdNameValuePair));
		}
		public bool IsDefault() {
			RCNameValuePairRecord defaultStruct = new RCNameValuePairRecord(null);
			if (this.ssSTNameValuePair != defaultStruct.ssSTNameValuePair) return false;
			return true;
		}
	} // RCNameValuePairRecord

	/// <summary>
	/// Structure <code>RCTokenSymmetricSigningCredentialsRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCTokenSymmetricSigningCredentialsRecord: ISerializable, ITypedRecord<RCTokenSymmetricSigningCredentialsRecord> {
		internal static readonly GlobalObjectKey IdTokenSymmetricSigningCredentials = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*GF3CICsSKRQwCXIEJXJv3g");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("TokenSymmetricSigningCredentials")]
		public STTokenSymmetricSigningCredentialsStructure ssSTTokenSymmetricSigningCredentials;


		public static implicit operator STTokenSymmetricSigningCredentialsStructure(RCTokenSymmetricSigningCredentialsRecord r) {
			return r.ssSTTokenSymmetricSigningCredentials;
		}

		public static implicit operator RCTokenSymmetricSigningCredentialsRecord(STTokenSymmetricSigningCredentialsStructure r) {
			RCTokenSymmetricSigningCredentialsRecord res = new RCTokenSymmetricSigningCredentialsRecord(null);
			res.ssSTTokenSymmetricSigningCredentials = r;
			return res;
		}

		public BitArray OptimizedAttributes;

		public RCTokenSymmetricSigningCredentialsRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssSTTokenSymmetricSigningCredentials = new STTokenSymmetricSigningCredentialsStructure(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = null;
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
				} else {
					ssSTTokenSymmetricSigningCredentials.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = null;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssSTTokenSymmetricSigningCredentials.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCTokenSymmetricSigningCredentialsRecord r) {
			this = r;
		}


		public static bool operator == (RCTokenSymmetricSigningCredentialsRecord a, RCTokenSymmetricSigningCredentialsRecord b) {
			if (a.ssSTTokenSymmetricSigningCredentials != b.ssSTTokenSymmetricSigningCredentials) return false;
			return true;
		}

		public static bool operator != (RCTokenSymmetricSigningCredentialsRecord a, RCTokenSymmetricSigningCredentialsRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCTokenSymmetricSigningCredentialsRecord)) return false;
			return (this == (RCTokenSymmetricSigningCredentialsRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssSTTokenSymmetricSigningCredentials.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCTokenSymmetricSigningCredentialsRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssSTTokenSymmetricSigningCredentials = new STTokenSymmetricSigningCredentialsStructure(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssSTTokenSymmetricSigningCredentials", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssSTTokenSymmetricSigningCredentials' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssSTTokenSymmetricSigningCredentials = (STTokenSymmetricSigningCredentialsStructure) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssSTTokenSymmetricSigningCredentials.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssSTTokenSymmetricSigningCredentials.InternalRecursiveSave();
		}


		public RCTokenSymmetricSigningCredentialsRecord Duplicate() {
			RCTokenSymmetricSigningCredentialsRecord t;
			t.ssSTTokenSymmetricSigningCredentials = (STTokenSymmetricSigningCredentialsStructure) this.ssSTTokenSymmetricSigningCredentials.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssSTTokenSymmetricSigningCredentials.ToXml(this, recordElem, "TokenSymmetricSigningCredentials", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "tokensymmetricsigningcredentials") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".TokenSymmetricSigningCredentials")) variable.Value = ssSTTokenSymmetricSigningCredentials; else variable.Optimized = true;
				variable.SetFieldName("tokensymmetricsigningcredentials");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			throw new Exception("Method not Supported");
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			throw new Exception("Method not Supported");
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdTokenSymmetricSigningCredentials) {
				return ssSTTokenSymmetricSigningCredentials;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssSTTokenSymmetricSigningCredentials.FillFromOther((IRecord) other.AttributeGet(IdTokenSymmetricSigningCredentials));
		}
		public bool IsDefault() {
			RCTokenSymmetricSigningCredentialsRecord defaultStruct = new RCTokenSymmetricSigningCredentialsRecord(null);
			if (this.ssSTTokenSymmetricSigningCredentials != defaultStruct.ssSTTokenSymmetricSigningCredentials) return false;
			return true;
		}
	} // RCTokenSymmetricSigningCredentialsRecord

	/// <summary>
	/// Structure <code>RCTokenAsymmetricSigningCredentialsRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCTokenAsymmetricSigningCredentialsRecord: ISerializable, ITypedRecord<RCTokenAsymmetricSigningCredentialsRecord> {
		internal static readonly GlobalObjectKey IdTokenAsymmetricSigningCredentials = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*oHjbZMH5dL3yEWF5fjqrLQ");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("TokenAsymmetricSigningCredentials")]
		public STTokenAsymmetricSigningCredentialsStructure ssSTTokenAsymmetricSigningCredentials;


		public static implicit operator STTokenAsymmetricSigningCredentialsStructure(RCTokenAsymmetricSigningCredentialsRecord r) {
			return r.ssSTTokenAsymmetricSigningCredentials;
		}

		public static implicit operator RCTokenAsymmetricSigningCredentialsRecord(STTokenAsymmetricSigningCredentialsStructure r) {
			RCTokenAsymmetricSigningCredentialsRecord res = new RCTokenAsymmetricSigningCredentialsRecord(null);
			res.ssSTTokenAsymmetricSigningCredentials = r;
			return res;
		}

		public BitArray OptimizedAttributes;

		public RCTokenAsymmetricSigningCredentialsRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssSTTokenAsymmetricSigningCredentials = new STTokenAsymmetricSigningCredentialsStructure(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = null;
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
				} else {
					ssSTTokenAsymmetricSigningCredentials.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = null;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssSTTokenAsymmetricSigningCredentials.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCTokenAsymmetricSigningCredentialsRecord r) {
			this = r;
		}


		public static bool operator == (RCTokenAsymmetricSigningCredentialsRecord a, RCTokenAsymmetricSigningCredentialsRecord b) {
			if (a.ssSTTokenAsymmetricSigningCredentials != b.ssSTTokenAsymmetricSigningCredentials) return false;
			return true;
		}

		public static bool operator != (RCTokenAsymmetricSigningCredentialsRecord a, RCTokenAsymmetricSigningCredentialsRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCTokenAsymmetricSigningCredentialsRecord)) return false;
			return (this == (RCTokenAsymmetricSigningCredentialsRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssSTTokenAsymmetricSigningCredentials.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCTokenAsymmetricSigningCredentialsRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssSTTokenAsymmetricSigningCredentials = new STTokenAsymmetricSigningCredentialsStructure(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssSTTokenAsymmetricSigningCredentials", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssSTTokenAsymmetricSigningCredentials' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssSTTokenAsymmetricSigningCredentials = (STTokenAsymmetricSigningCredentialsStructure) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssSTTokenAsymmetricSigningCredentials.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssSTTokenAsymmetricSigningCredentials.InternalRecursiveSave();
		}


		public RCTokenAsymmetricSigningCredentialsRecord Duplicate() {
			RCTokenAsymmetricSigningCredentialsRecord t;
			t.ssSTTokenAsymmetricSigningCredentials = (STTokenAsymmetricSigningCredentialsStructure) this.ssSTTokenAsymmetricSigningCredentials.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssSTTokenAsymmetricSigningCredentials.ToXml(this, recordElem, "TokenAsymmetricSigningCredentials", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "tokenasymmetricsigningcredentials") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".TokenAsymmetricSigningCredentials")) variable.Value = ssSTTokenAsymmetricSigningCredentials; else variable.Optimized = true;
				variable.SetFieldName("tokenasymmetricsigningcredentials");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			throw new Exception("Method not Supported");
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			throw new Exception("Method not Supported");
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdTokenAsymmetricSigningCredentials) {
				return ssSTTokenAsymmetricSigningCredentials;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssSTTokenAsymmetricSigningCredentials.FillFromOther((IRecord) other.AttributeGet(IdTokenAsymmetricSigningCredentials));
		}
		public bool IsDefault() {
			RCTokenAsymmetricSigningCredentialsRecord defaultStruct = new RCTokenAsymmetricSigningCredentialsRecord(null);
			if (this.ssSTTokenAsymmetricSigningCredentials != defaultStruct.ssSTTokenAsymmetricSigningCredentials) return false;
			return true;
		}
	} // RCTokenAsymmetricSigningCredentialsRecord

	/// <summary>
	/// Structure <code>RCTokenPayloadRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCTokenPayloadRecord: ISerializable, ITypedRecord<RCTokenPayloadRecord> {
		internal static readonly GlobalObjectKey IdTokenPayload = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*eHrEBuS8HyB4C0Azl5r_Fg");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("TokenPayload")]
		public STTokenPayloadStructure ssSTTokenPayload;


		public static implicit operator STTokenPayloadStructure(RCTokenPayloadRecord r) {
			return r.ssSTTokenPayload;
		}

		public static implicit operator RCTokenPayloadRecord(STTokenPayloadStructure r) {
			RCTokenPayloadRecord res = new RCTokenPayloadRecord(null);
			res.ssSTTokenPayload = r;
			return res;
		}

		public BitArray OptimizedAttributes;

		public RCTokenPayloadRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssSTTokenPayload = new STTokenPayloadStructure(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = null;
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
				} else {
					ssSTTokenPayload.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = null;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssSTTokenPayload.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCTokenPayloadRecord r) {
			this = r;
		}


		public static bool operator == (RCTokenPayloadRecord a, RCTokenPayloadRecord b) {
			if (a.ssSTTokenPayload != b.ssSTTokenPayload) return false;
			return true;
		}

		public static bool operator != (RCTokenPayloadRecord a, RCTokenPayloadRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCTokenPayloadRecord)) return false;
			return (this == (RCTokenPayloadRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssSTTokenPayload.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCTokenPayloadRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssSTTokenPayload = new STTokenPayloadStructure(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssSTTokenPayload", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssSTTokenPayload' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssSTTokenPayload = (STTokenPayloadStructure) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssSTTokenPayload.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssSTTokenPayload.InternalRecursiveSave();
		}


		public RCTokenPayloadRecord Duplicate() {
			RCTokenPayloadRecord t;
			t.ssSTTokenPayload = (STTokenPayloadStructure) this.ssSTTokenPayload.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssSTTokenPayload.ToXml(this, recordElem, "TokenPayload", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "tokenpayload") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".TokenPayload")) variable.Value = ssSTTokenPayload; else variable.Optimized = true;
				variable.SetFieldName("tokenpayload");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			throw new Exception("Method not Supported");
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			throw new Exception("Method not Supported");
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdTokenPayload) {
				return ssSTTokenPayload;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssSTTokenPayload.FillFromOther((IRecord) other.AttributeGet(IdTokenPayload));
		}
		public bool IsDefault() {
			RCTokenPayloadRecord defaultStruct = new RCTokenPayloadRecord(null);
			if (this.ssSTTokenPayload != defaultStruct.ssSTTokenPayload) return false;
			return true;
		}
	} // RCTokenPayloadRecord

	/// <summary>
	/// Structure <code>RCVerifySignatureOptionsRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCVerifySignatureOptionsRecord: ISerializable, ITypedRecord<RCVerifySignatureOptionsRecord> {
		internal static readonly GlobalObjectKey IdVerifySignatureOptions = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*keEA1wOVMnYKxVsRjRw6OQ");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("VerifySignatureOptions")]
		public STVerifySignatureOptionsStructure ssSTVerifySignatureOptions;


		public static implicit operator STVerifySignatureOptionsStructure(RCVerifySignatureOptionsRecord r) {
			return r.ssSTVerifySignatureOptions;
		}

		public static implicit operator RCVerifySignatureOptionsRecord(STVerifySignatureOptionsStructure r) {
			RCVerifySignatureOptionsRecord res = new RCVerifySignatureOptionsRecord(null);
			res.ssSTVerifySignatureOptions = r;
			return res;
		}

		public BitArray OptimizedAttributes;

		public RCVerifySignatureOptionsRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssSTVerifySignatureOptions = new STVerifySignatureOptionsStructure(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = null;
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
				} else {
					ssSTVerifySignatureOptions.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = null;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssSTVerifySignatureOptions.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCVerifySignatureOptionsRecord r) {
			this = r;
		}


		public static bool operator == (RCVerifySignatureOptionsRecord a, RCVerifySignatureOptionsRecord b) {
			if (a.ssSTVerifySignatureOptions != b.ssSTVerifySignatureOptions) return false;
			return true;
		}

		public static bool operator != (RCVerifySignatureOptionsRecord a, RCVerifySignatureOptionsRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCVerifySignatureOptionsRecord)) return false;
			return (this == (RCVerifySignatureOptionsRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssSTVerifySignatureOptions.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCVerifySignatureOptionsRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssSTVerifySignatureOptions = new STVerifySignatureOptionsStructure(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssSTVerifySignatureOptions", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssSTVerifySignatureOptions' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssSTVerifySignatureOptions = (STVerifySignatureOptionsStructure) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssSTVerifySignatureOptions.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssSTVerifySignatureOptions.InternalRecursiveSave();
		}


		public RCVerifySignatureOptionsRecord Duplicate() {
			RCVerifySignatureOptionsRecord t;
			t.ssSTVerifySignatureOptions = (STVerifySignatureOptionsStructure) this.ssSTVerifySignatureOptions.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssSTVerifySignatureOptions.ToXml(this, recordElem, "VerifySignatureOptions", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "verifysignatureoptions") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".VerifySignatureOptions")) variable.Value = ssSTVerifySignatureOptions; else variable.Optimized = true;
				variable.SetFieldName("verifysignatureoptions");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			throw new Exception("Method not Supported");
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			throw new Exception("Method not Supported");
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdVerifySignatureOptions) {
				return ssSTVerifySignatureOptions;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssSTVerifySignatureOptions.FillFromOther((IRecord) other.AttributeGet(IdVerifySignatureOptions));
		}
		public bool IsDefault() {
			RCVerifySignatureOptionsRecord defaultStruct = new RCVerifySignatureOptionsRecord(null);
			if (this.ssSTVerifySignatureOptions != defaultStruct.ssSTVerifySignatureOptions) return false;
			return true;
		}
	} // RCVerifySignatureOptionsRecord

	/// <summary>
	/// Structure <code>RCTokenHeaderRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCTokenHeaderRecord: ISerializable, ITypedRecord<RCTokenHeaderRecord> {
		internal static readonly GlobalObjectKey IdTokenHeader = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*Q2oGOx0S1XKjwTNbJ41ZWA");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("TokenHeader")]
		public STTokenHeaderStructure ssSTTokenHeader;


		public static implicit operator STTokenHeaderStructure(RCTokenHeaderRecord r) {
			return r.ssSTTokenHeader;
		}

		public static implicit operator RCTokenHeaderRecord(STTokenHeaderStructure r) {
			RCTokenHeaderRecord res = new RCTokenHeaderRecord(null);
			res.ssSTTokenHeader = r;
			return res;
		}

		public BitArray OptimizedAttributes;

		public RCTokenHeaderRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssSTTokenHeader = new STTokenHeaderStructure(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = null;
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
				} else {
					ssSTTokenHeader.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = null;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssSTTokenHeader.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCTokenHeaderRecord r) {
			this = r;
		}


		public static bool operator == (RCTokenHeaderRecord a, RCTokenHeaderRecord b) {
			if (a.ssSTTokenHeader != b.ssSTTokenHeader) return false;
			return true;
		}

		public static bool operator != (RCTokenHeaderRecord a, RCTokenHeaderRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCTokenHeaderRecord)) return false;
			return (this == (RCTokenHeaderRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssSTTokenHeader.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCTokenHeaderRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssSTTokenHeader = new STTokenHeaderStructure(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssSTTokenHeader", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssSTTokenHeader' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssSTTokenHeader = (STTokenHeaderStructure) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssSTTokenHeader.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssSTTokenHeader.InternalRecursiveSave();
		}


		public RCTokenHeaderRecord Duplicate() {
			RCTokenHeaderRecord t;
			t.ssSTTokenHeader = (STTokenHeaderStructure) this.ssSTTokenHeader.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssSTTokenHeader.ToXml(this, recordElem, "TokenHeader", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "tokenheader") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".TokenHeader")) variable.Value = ssSTTokenHeader; else variable.Optimized = true;
				variable.SetFieldName("tokenheader");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			throw new Exception("Method not Supported");
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			throw new Exception("Method not Supported");
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdTokenHeader) {
				return ssSTTokenHeader;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssSTTokenHeader.FillFromOther((IRecord) other.AttributeGet(IdTokenHeader));
		}
		public bool IsDefault() {
			RCTokenHeaderRecord defaultStruct = new RCTokenHeaderRecord(null);
			if (this.ssSTTokenHeader != defaultStruct.ssSTTokenHeader) return false;
			return true;
		}
	} // RCTokenHeaderRecord
}
