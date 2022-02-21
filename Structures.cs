using System;
using System.Collections;
using System.Data;
using System.Reflection;
using System.Runtime.Serialization;
using OutSystems.ObjectKeys;
using OutSystems.RuntimeCommon;
using OutSystems.HubEdition.RuntimePlatform;
using OutSystems.HubEdition.RuntimePlatform.Db;
using OutSystems.Internal.Db;

namespace OutSystems.NssJWT_Core {

	/// <summary>
	/// Structure <code>STNameValuePairStructure</code> that represents the Service Studio structure
	///  <code>NameValuePair</code> <p> Description: Name-value pair for a Claim.</p>
	/// </summary>
	[Serializable()]
	public partial struct STNameValuePairStructure: ISerializable, ITypedRecord<STNameValuePairStructure>, ISimpleRecord {
		internal static readonly GlobalObjectKey IdName = GlobalObjectKey.Parse("vpN4uF9vl0+vymUjOgJk6Q*nqNmAMn7KkS6TcelKrPwcg");
		internal static readonly GlobalObjectKey IdValue = GlobalObjectKey.Parse("vpN4uF9vl0+vymUjOgJk6Q*0QuyhnfATkKCMdno1k8Xww");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("Name")]
		public string ssName;

		[System.Xml.Serialization.XmlElement("Value")]
		public string ssValue;


		public BitArray OptimizedAttributes;

		public STNameValuePairStructure(params string[] dummy) {
			OptimizedAttributes = null;
			ssName = "";
			ssValue = "";
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[0];
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
				} else {
				}
			}
			get {
				BitArray[] all = new BitArray[0];
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssName = r.ReadText(index++, "NameValuePair.Name", "");
			ssValue = r.ReadText(index++, "NameValuePair.Value", "");
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
		public void ReadIM(STNameValuePairStructure r) {
			this = r;
		}


		public static bool operator == (STNameValuePairStructure a, STNameValuePairStructure b) {
			if (a.ssName != b.ssName) return false;
			if (a.ssValue != b.ssValue) return false;
			return true;
		}

		public static bool operator != (STNameValuePairStructure a, STNameValuePairStructure b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(STNameValuePairStructure)) return false;
			return (this == (STNameValuePairStructure) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssName.GetHashCode()
				^ ssValue.GetHashCode()
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

		public STNameValuePairStructure(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssName = "";
			ssValue = "";
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssName", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssName' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssName = (string) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
			fieldInfo = objInfo.GetField("ssValue", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssValue' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssValue = (string) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
		}

		public void InternalRecursiveSave() {
		}


		public STNameValuePairStructure Duplicate() {
			STNameValuePairStructure t;
			t.ssName = this.ssName;
			t.ssValue = this.ssValue;
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Structure");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
				fieldName = fieldName.ToLowerInvariant();
			}
			if (detailLevel > 0) {
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".Name")) VarValue.AppendAttribute(recordElem, "Name", ssName, detailLevel, TypeKind.Text); else VarValue.AppendOptimizedAttribute(recordElem, "Name");
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".Value")) VarValue.AppendAttribute(recordElem, "Value", ssValue, detailLevel, TypeKind.Text); else VarValue.AppendOptimizedAttribute(recordElem, "Value");
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "name") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Name")) variable.Value = ssName; else variable.Optimized = true;
			} else if (head == "value") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Value")) variable.Value = ssValue; else variable.Optimized = true;
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
			if (key == IdName) {
				return ssName;
			} else if (key == IdValue) {
				return ssValue;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssName = (string) other.AttributeGet(IdName);
			ssValue = (string) other.AttributeGet(IdValue);
		}
		public bool IsDefault() {
			STNameValuePairStructure defaultStruct = new STNameValuePairStructure(null);
			if (this.ssName != defaultStruct.ssName) return false;
			if (this.ssValue != defaultStruct.ssValue) return false;
			return true;
		}
	} // STNameValuePairStructure

	/// <summary>
	/// Structure <code>STTokenSymmetricSigningCredentialsStructure</code> that represents the Service
	///  Studio structure <code>TokenSymmetricSigningCredentials</code> <p> Description: </p>
	/// </summary>
	[Serializable()]
	public partial struct STTokenSymmetricSigningCredentialsStructure: ISerializable, ITypedRecord<STTokenSymmetricSigningCredentialsStructure>, ISimpleRecord {
		internal static readonly GlobalObjectKey IdAlgorithm = GlobalObjectKey.Parse("vpN4uF9vl0+vymUjOgJk6Q*gR72ie1a_EiwpRFgRhLDhw");
		internal static readonly GlobalObjectKey IdKeyId = GlobalObjectKey.Parse("vpN4uF9vl0+vymUjOgJk6Q*zTDscm1_70m7AFDjblYEYQ");
		internal static readonly GlobalObjectKey IdKey = GlobalObjectKey.Parse("vpN4uF9vl0+vymUjOgJk6Q*FWDko_edTkSIL_5_adsWRg");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("Algorithm")]
		public string ssAlgorithm;

		[System.Xml.Serialization.XmlElement("KeyId")]
		public string ssKeyId;

		[System.Xml.Serialization.XmlElement("Key")]
		public string ssKey;


		public BitArray OptimizedAttributes;

		public STTokenSymmetricSigningCredentialsStructure(params string[] dummy) {
			OptimizedAttributes = null;
			ssAlgorithm = "";
			ssKeyId = "";
			ssKey = "";
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[0];
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
				} else {
				}
			}
			get {
				BitArray[] all = new BitArray[0];
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssAlgorithm = r.ReadText(index++, "TokenSymmetricSigningCredentials.Algorithm", "");
			ssKeyId = r.ReadText(index++, "TokenSymmetricSigningCredentials.KeyId", "");
			ssKey = r.ReadText(index++, "TokenSymmetricSigningCredentials.Key", "");
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
		public void ReadIM(STTokenSymmetricSigningCredentialsStructure r) {
			this = r;
		}


		public static bool operator == (STTokenSymmetricSigningCredentialsStructure a, STTokenSymmetricSigningCredentialsStructure b) {
			if (a.ssAlgorithm != b.ssAlgorithm) return false;
			if (a.ssKeyId != b.ssKeyId) return false;
			if (a.ssKey != b.ssKey) return false;
			return true;
		}

		public static bool operator != (STTokenSymmetricSigningCredentialsStructure a, STTokenSymmetricSigningCredentialsStructure b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(STTokenSymmetricSigningCredentialsStructure)) return false;
			return (this == (STTokenSymmetricSigningCredentialsStructure) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssAlgorithm.GetHashCode()
				^ ssKeyId.GetHashCode()
				^ ssKey.GetHashCode()
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

		public STTokenSymmetricSigningCredentialsStructure(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssAlgorithm = "";
			ssKeyId = "";
			ssKey = "";
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssAlgorithm", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssAlgorithm' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssAlgorithm = (string) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
			fieldInfo = objInfo.GetField("ssKeyId", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssKeyId' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssKeyId = (string) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
			fieldInfo = objInfo.GetField("ssKey", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssKey' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssKey = (string) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
		}

		public void InternalRecursiveSave() {
		}


		public STTokenSymmetricSigningCredentialsStructure Duplicate() {
			STTokenSymmetricSigningCredentialsStructure t;
			t.ssAlgorithm = this.ssAlgorithm;
			t.ssKeyId = this.ssKeyId;
			t.ssKey = this.ssKey;
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Structure");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
				fieldName = fieldName.ToLowerInvariant();
			}
			if (detailLevel > 0) {
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".Algorithm")) VarValue.AppendAttribute(recordElem, "Algorithm", ssAlgorithm, detailLevel, TypeKind.Text); else VarValue.AppendOptimizedAttribute(recordElem, "Algorithm");
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".KeyId")) VarValue.AppendAttribute(recordElem, "KeyId", ssKeyId, detailLevel, TypeKind.Text); else VarValue.AppendOptimizedAttribute(recordElem, "KeyId");
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".Key")) VarValue.AppendAttribute(recordElem, "Key", ssKey, detailLevel, TypeKind.Text); else VarValue.AppendOptimizedAttribute(recordElem, "Key");
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "algorithm") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Algorithm")) variable.Value = ssAlgorithm; else variable.Optimized = true;
			} else if (head == "keyid") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".KeyId")) variable.Value = ssKeyId; else variable.Optimized = true;
			} else if (head == "key") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Key")) variable.Value = ssKey; else variable.Optimized = true;
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
			if (key == IdAlgorithm) {
				return ssAlgorithm;
			} else if (key == IdKeyId) {
				return ssKeyId;
			} else if (key == IdKey) {
				return ssKey;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssAlgorithm = (string) other.AttributeGet(IdAlgorithm);
			ssKeyId = (string) other.AttributeGet(IdKeyId);
			ssKey = (string) other.AttributeGet(IdKey);
		}
		public bool IsDefault() {
			STTokenSymmetricSigningCredentialsStructure defaultStruct = new STTokenSymmetricSigningCredentialsStructure(null);
			if (this.ssAlgorithm != defaultStruct.ssAlgorithm) return false;
			if (this.ssKeyId != defaultStruct.ssKeyId) return false;
			if (this.ssKey != defaultStruct.ssKey) return false;
			return true;
		}
	} // STTokenSymmetricSigningCredentialsStructure

	/// <summary>
	/// Structure <code>STTokenAsymmetricSigningCredentialsStructure</code> that represents the Service
	///  Studio structure <code>TokenAsymmetricSigningCredentials</code> <p> Description: </p>
	/// </summary>
	[Serializable()]
	public partial struct STTokenAsymmetricSigningCredentialsStructure: ISerializable, ITypedRecord<STTokenAsymmetricSigningCredentialsStructure>, ISimpleRecord {
		internal static readonly GlobalObjectKey IdAlgorithm = GlobalObjectKey.Parse("vpN4uF9vl0+vymUjOgJk6Q*iI8h+Couw0SXezREisD3iw");
		internal static readonly GlobalObjectKey IdKeyId = GlobalObjectKey.Parse("vpN4uF9vl0+vymUjOgJk6Q*GsJXnCrj9kydNsTmpEOf1A");
		internal static readonly GlobalObjectKey IdPrivateKey = GlobalObjectKey.Parse("vpN4uF9vl0+vymUjOgJk6Q*l5+vkJj3hE20KbU0CsLbSA");
		internal static readonly GlobalObjectKey IdPrivateKeyPassphrase = GlobalObjectKey.Parse("vpN4uF9vl0+vymUjOgJk6Q*1DAxLW8ZdUGmUEcCvh1Nvw");
		internal static readonly GlobalObjectKey IdKeyIsJwk = GlobalObjectKey.Parse("vpN4uF9vl0+vymUjOgJk6Q*iC_7zNmOtkaRKff7PjlQBA");
		internal static readonly GlobalObjectKey IdModulus = GlobalObjectKey.Parse("vpN4uF9vl0+vymUjOgJk6Q*dM1XWO2VG06FU+OKhd_deQ");
		internal static readonly GlobalObjectKey IdPublicExponent = GlobalObjectKey.Parse("vpN4uF9vl0+vymUjOgJk6Q*Bekev8gpRk2YtgIDIsW+Ag");
		internal static readonly GlobalObjectKey IdPrivateExponent = GlobalObjectKey.Parse("vpN4uF9vl0+vymUjOgJk6Q*zWEbxRR8Bk2w8bgqjlA24w");
		internal static readonly GlobalObjectKey IdUseMachineKeystore = GlobalObjectKey.Parse("vpN4uF9vl0+vymUjOgJk6Q*uCw+pLxKiUC0Q4mDTWhrMw");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("Algorithm")]
		public string ssAlgorithm;

		[System.Xml.Serialization.XmlElement("KeyId")]
		public string ssKeyId;

		[System.Xml.Serialization.XmlElement("PrivateKey")]
		public string ssPrivateKey;

		[System.Xml.Serialization.XmlElement("PrivateKeyPassphrase")]
		public string ssPrivateKeyPassphrase;

		[System.Xml.Serialization.XmlElement("KeyIsJwk")]
		public bool ssKeyIsJwk;

		[System.Xml.Serialization.XmlElement("Modulus")]
		public string ssModulus;

		[System.Xml.Serialization.XmlElement("PublicExponent")]
		public string ssPublicExponent;

		[System.Xml.Serialization.XmlElement("PrivateExponent")]
		public string ssPrivateExponent;

		[System.Xml.Serialization.XmlElement("UseMachineKeystore")]
		public bool ssUseMachineKeystore;


		public BitArray OptimizedAttributes;

		public STTokenAsymmetricSigningCredentialsStructure(params string[] dummy) {
			OptimizedAttributes = null;
			ssAlgorithm = "";
			ssKeyId = "";
			ssPrivateKey = "";
			ssPrivateKeyPassphrase = "";
			ssKeyIsJwk = false;
			ssModulus = "";
			ssPublicExponent = "";
			ssPrivateExponent = "";
			ssUseMachineKeystore = false;
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[0];
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
				} else {
				}
			}
			get {
				BitArray[] all = new BitArray[0];
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssAlgorithm = r.ReadText(index++, "TokenAsymmetricSigningCredentials.Algorithm", "");
			ssKeyId = r.ReadText(index++, "TokenAsymmetricSigningCredentials.KeyId", "");
			ssPrivateKey = r.ReadText(index++, "TokenAsymmetricSigningCredentials.PrivateKey", "");
			ssPrivateKeyPassphrase = r.ReadText(index++, "TokenAsymmetricSigningCredentials.PrivateKeyPassphrase", "");
			ssKeyIsJwk = r.ReadBoolean(index++, "TokenAsymmetricSigningCredentials.KeyIsJwk", false);
			ssModulus = r.ReadText(index++, "TokenAsymmetricSigningCredentials.Modulus", "");
			ssPublicExponent = r.ReadText(index++, "TokenAsymmetricSigningCredentials.PublicExponent", "");
			ssPrivateExponent = r.ReadText(index++, "TokenAsymmetricSigningCredentials.PrivateExponent", "");
			ssUseMachineKeystore = r.ReadBoolean(index++, "TokenAsymmetricSigningCredentials.UseMachineKeystore", false);
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
		public void ReadIM(STTokenAsymmetricSigningCredentialsStructure r) {
			this = r;
		}


		public static bool operator == (STTokenAsymmetricSigningCredentialsStructure a, STTokenAsymmetricSigningCredentialsStructure b) {
			if (a.ssAlgorithm != b.ssAlgorithm) return false;
			if (a.ssKeyId != b.ssKeyId) return false;
			if (a.ssPrivateKey != b.ssPrivateKey) return false;
			if (a.ssPrivateKeyPassphrase != b.ssPrivateKeyPassphrase) return false;
			if (a.ssKeyIsJwk != b.ssKeyIsJwk) return false;
			if (a.ssModulus != b.ssModulus) return false;
			if (a.ssPublicExponent != b.ssPublicExponent) return false;
			if (a.ssPrivateExponent != b.ssPrivateExponent) return false;
			if (a.ssUseMachineKeystore != b.ssUseMachineKeystore) return false;
			return true;
		}

		public static bool operator != (STTokenAsymmetricSigningCredentialsStructure a, STTokenAsymmetricSigningCredentialsStructure b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(STTokenAsymmetricSigningCredentialsStructure)) return false;
			return (this == (STTokenAsymmetricSigningCredentialsStructure) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssAlgorithm.GetHashCode()
				^ ssKeyId.GetHashCode()
				^ ssPrivateKey.GetHashCode()
				^ ssPrivateKeyPassphrase.GetHashCode()
				^ ssKeyIsJwk.GetHashCode()
				^ ssModulus.GetHashCode()
				^ ssPublicExponent.GetHashCode()
				^ ssPrivateExponent.GetHashCode()
				^ ssUseMachineKeystore.GetHashCode()
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

		public STTokenAsymmetricSigningCredentialsStructure(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssAlgorithm = "";
			ssKeyId = "";
			ssPrivateKey = "";
			ssPrivateKeyPassphrase = "";
			ssKeyIsJwk = false;
			ssModulus = "";
			ssPublicExponent = "";
			ssPrivateExponent = "";
			ssUseMachineKeystore = false;
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssAlgorithm", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssAlgorithm' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssAlgorithm = (string) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
			fieldInfo = objInfo.GetField("ssKeyId", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssKeyId' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssKeyId = (string) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
			fieldInfo = objInfo.GetField("ssPrivateKey", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssPrivateKey' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssPrivateKey = (string) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
			fieldInfo = objInfo.GetField("ssPrivateKeyPassphrase", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssPrivateKeyPassphrase' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssPrivateKeyPassphrase = (string) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
			fieldInfo = objInfo.GetField("ssKeyIsJwk", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssKeyIsJwk' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssKeyIsJwk = (bool) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
			fieldInfo = objInfo.GetField("ssModulus", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssModulus' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssModulus = (string) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
			fieldInfo = objInfo.GetField("ssPublicExponent", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssPublicExponent' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssPublicExponent = (string) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
			fieldInfo = objInfo.GetField("ssPrivateExponent", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssPrivateExponent' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssPrivateExponent = (string) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
			fieldInfo = objInfo.GetField("ssUseMachineKeystore", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssUseMachineKeystore' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssUseMachineKeystore = (bool) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
		}

		public void InternalRecursiveSave() {
		}


		public STTokenAsymmetricSigningCredentialsStructure Duplicate() {
			STTokenAsymmetricSigningCredentialsStructure t;
			t.ssAlgorithm = this.ssAlgorithm;
			t.ssKeyId = this.ssKeyId;
			t.ssPrivateKey = this.ssPrivateKey;
			t.ssPrivateKeyPassphrase = this.ssPrivateKeyPassphrase;
			t.ssKeyIsJwk = this.ssKeyIsJwk;
			t.ssModulus = this.ssModulus;
			t.ssPublicExponent = this.ssPublicExponent;
			t.ssPrivateExponent = this.ssPrivateExponent;
			t.ssUseMachineKeystore = this.ssUseMachineKeystore;
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Structure");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
				fieldName = fieldName.ToLowerInvariant();
			}
			if (detailLevel > 0) {
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".Algorithm")) VarValue.AppendAttribute(recordElem, "Algorithm", ssAlgorithm, detailLevel, TypeKind.Text); else VarValue.AppendOptimizedAttribute(recordElem, "Algorithm");
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".KeyId")) VarValue.AppendAttribute(recordElem, "KeyId", ssKeyId, detailLevel, TypeKind.Text); else VarValue.AppendOptimizedAttribute(recordElem, "KeyId");
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".PrivateKey")) VarValue.AppendAttribute(recordElem, "PrivateKey", ssPrivateKey, detailLevel, TypeKind.Text); else VarValue.AppendOptimizedAttribute(recordElem, "PrivateKey");
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".PrivateKeyPassphrase")) VarValue.AppendAttribute(recordElem, "PrivateKeyPassphrase", ssPrivateKeyPassphrase, detailLevel, TypeKind.Text); else VarValue.AppendOptimizedAttribute(recordElem, "PrivateKeyPassphrase");
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".KeyIsJwk")) VarValue.AppendAttribute(recordElem, "KeyIsJwk", ssKeyIsJwk, detailLevel, TypeKind.Boolean); else VarValue.AppendOptimizedAttribute(recordElem, "KeyIsJwk");
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".Modulus")) VarValue.AppendAttribute(recordElem, "Modulus", ssModulus, detailLevel, TypeKind.Text); else VarValue.AppendOptimizedAttribute(recordElem, "Modulus");
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".PublicExponent")) VarValue.AppendAttribute(recordElem, "PublicExponent", ssPublicExponent, detailLevel, TypeKind.Text); else VarValue.AppendOptimizedAttribute(recordElem, "PublicExponent");
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".PrivateExponent")) VarValue.AppendAttribute(recordElem, "PrivateExponent", ssPrivateExponent, detailLevel, TypeKind.Text); else VarValue.AppendOptimizedAttribute(recordElem, "PrivateExponent");
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".UseMachineKeystore")) VarValue.AppendAttribute(recordElem, "UseMachineKeystore", ssUseMachineKeystore, detailLevel, TypeKind.Boolean); else VarValue.AppendOptimizedAttribute(recordElem, "UseMachineKeystore");
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "algorithm") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Algorithm")) variable.Value = ssAlgorithm; else variable.Optimized = true;
			} else if (head == "keyid") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".KeyId")) variable.Value = ssKeyId; else variable.Optimized = true;
			} else if (head == "privatekey") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".PrivateKey")) variable.Value = ssPrivateKey; else variable.Optimized = true;
			} else if (head == "privatekeypassphrase") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".PrivateKeyPassphrase")) variable.Value = ssPrivateKeyPassphrase; else variable.Optimized = true;
			} else if (head == "keyisjwk") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".KeyIsJwk")) variable.Value = ssKeyIsJwk; else variable.Optimized = true;
			} else if (head == "modulus") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Modulus")) variable.Value = ssModulus; else variable.Optimized = true;
			} else if (head == "publicexponent") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".PublicExponent")) variable.Value = ssPublicExponent; else variable.Optimized = true;
			} else if (head == "privateexponent") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".PrivateExponent")) variable.Value = ssPrivateExponent; else variable.Optimized = true;
			} else if (head == "usemachinekeystore") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".UseMachineKeystore")) variable.Value = ssUseMachineKeystore; else variable.Optimized = true;
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
			if (key == IdAlgorithm) {
				return ssAlgorithm;
			} else if (key == IdKeyId) {
				return ssKeyId;
			} else if (key == IdPrivateKey) {
				return ssPrivateKey;
			} else if (key == IdPrivateKeyPassphrase) {
				return ssPrivateKeyPassphrase;
			} else if (key == IdKeyIsJwk) {
				return ssKeyIsJwk;
			} else if (key == IdModulus) {
				return ssModulus;
			} else if (key == IdPublicExponent) {
				return ssPublicExponent;
			} else if (key == IdPrivateExponent) {
				return ssPrivateExponent;
			} else if (key == IdUseMachineKeystore) {
				return ssUseMachineKeystore;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssAlgorithm = (string) other.AttributeGet(IdAlgorithm);
			ssKeyId = (string) other.AttributeGet(IdKeyId);
			ssPrivateKey = (string) other.AttributeGet(IdPrivateKey);
			ssPrivateKeyPassphrase = (string) other.AttributeGet(IdPrivateKeyPassphrase);
			ssKeyIsJwk = (bool) other.AttributeGet(IdKeyIsJwk);
			ssModulus = (string) other.AttributeGet(IdModulus);
			ssPublicExponent = (string) other.AttributeGet(IdPublicExponent);
			ssPrivateExponent = (string) other.AttributeGet(IdPrivateExponent);
			ssUseMachineKeystore = (bool) other.AttributeGet(IdUseMachineKeystore);
		}
		public bool IsDefault() {
			STTokenAsymmetricSigningCredentialsStructure defaultStruct = new STTokenAsymmetricSigningCredentialsStructure(null);
			if (this.ssAlgorithm != defaultStruct.ssAlgorithm) return false;
			if (this.ssKeyId != defaultStruct.ssKeyId) return false;
			if (this.ssPrivateKey != defaultStruct.ssPrivateKey) return false;
			if (this.ssPrivateKeyPassphrase != defaultStruct.ssPrivateKeyPassphrase) return false;
			if (this.ssKeyIsJwk != defaultStruct.ssKeyIsJwk) return false;
			if (this.ssModulus != defaultStruct.ssModulus) return false;
			if (this.ssPublicExponent != defaultStruct.ssPublicExponent) return false;
			if (this.ssPrivateExponent != defaultStruct.ssPrivateExponent) return false;
			if (this.ssUseMachineKeystore != defaultStruct.ssUseMachineKeystore) return false;
			return true;
		}
	} // STTokenAsymmetricSigningCredentialsStructure

	/// <summary>
	/// Structure <code>STTokenPayloadStructure</code> that represents the Service Studio structure
	///  <code>TokenPayload</code> <p> Description: Defines the token payload, with all the claims that tak
	/// e part in a token, both the custom and reserved claims.</p>
	/// </summary>
	[Serializable()]
	public partial struct STTokenPayloadStructure: ISerializable, ITypedRecord<STTokenPayloadStructure>, ISimpleRecord {
		internal static readonly GlobalObjectKey IdTokenId = GlobalObjectKey.Parse("vpN4uF9vl0+vymUjOgJk6Q*mstXtXk4HkOR8Z9+dX0Dhw");
		internal static readonly GlobalObjectKey IdIssuer = GlobalObjectKey.Parse("vpN4uF9vl0+vymUjOgJk6Q*S3NP2EIR40yKv4Tx4iRccA");
		internal static readonly GlobalObjectKey IdSubject = GlobalObjectKey.Parse("vpN4uF9vl0+vymUjOgJk6Q*v1vj1yuDlUO7SEcNAlDyVw");
		internal static readonly GlobalObjectKey IdAudience = GlobalObjectKey.Parse("vpN4uF9vl0+vymUjOgJk6Q*IIJ7OsoAhkSewEsXFYB04Q");
		internal static readonly GlobalObjectKey IdExpiration = GlobalObjectKey.Parse("vpN4uF9vl0+vymUjOgJk6Q*eZT9XQA37U22eKNDhFcLuQ");
		internal static readonly GlobalObjectKey IdNotBefore = GlobalObjectKey.Parse("vpN4uF9vl0+vymUjOgJk6Q*NoLCXjJRHE23wyEtLc9haQ");
		internal static readonly GlobalObjectKey IdIssuedAt = GlobalObjectKey.Parse("vpN4uF9vl0+vymUjOgJk6Q*uP7D7OiixEWn83YMaRkAIA");
		internal static readonly GlobalObjectKey IdCustomClaims = GlobalObjectKey.Parse("vpN4uF9vl0+vymUjOgJk6Q*R0nE75keHU2xBb9G1at77A");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("TokenId")]
		public string ssTokenId;

		[System.Xml.Serialization.XmlElement("Issuer")]
		public string ssIssuer;

		[System.Xml.Serialization.XmlElement("Subject")]
		public string ssSubject;

		[System.Xml.Serialization.XmlElement("Audience")]
		public string ssAudience;

		[System.Xml.Serialization.XmlElement("Expiration")]
		public DateTime ssExpiration;

		[System.Xml.Serialization.XmlElement("NotBefore")]
		public DateTime ssNotBefore;

		[System.Xml.Serialization.XmlElement("IssuedAt")]
		public DateTime ssIssuedAt;

		[System.Xml.Serialization.XmlElement("CustomClaims")]
		public RLNameValuePairRecordList ssCustomClaims;


		public BitArray OptimizedAttributes;

		public STTokenPayloadStructure(params string[] dummy) {
			OptimizedAttributes = null;
			ssTokenId = "";
			ssIssuer = "";
			ssSubject = "";
			ssAudience = "";
			ssExpiration = new DateTime(1900, 1, 1, 0, 0, 0);
			ssNotBefore = new DateTime(1900, 1, 1, 0, 0, 0);
			ssIssuedAt = new DateTime(1900, 1, 1, 0, 0, 0);
			ssCustomClaims = new RLNameValuePairRecordList();
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[0];
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
				} else {
				}
			}
			get {
				BitArray[] all = new BitArray[0];
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssTokenId = r.ReadText(index++, "TokenPayload.TokenId", "");
			ssIssuer = r.ReadText(index++, "TokenPayload.Issuer", "");
			ssSubject = r.ReadText(index++, "TokenPayload.Subject", "");
			ssAudience = r.ReadText(index++, "TokenPayload.Audience", "");
			ssExpiration = r.ReadDateTime(index++, "TokenPayload.Expiration", new DateTime(1900, 1, 1, 0, 0, 0));
			ssNotBefore = r.ReadDateTime(index++, "TokenPayload.NotBefore", new DateTime(1900, 1, 1, 0, 0, 0));
			ssIssuedAt = r.ReadDateTime(index++, "TokenPayload.IssuedAt", new DateTime(1900, 1, 1, 0, 0, 0));
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
		public void ReadIM(STTokenPayloadStructure r) {
			this = r;
		}


		public static bool operator == (STTokenPayloadStructure a, STTokenPayloadStructure b) {
			if (a.ssTokenId != b.ssTokenId) return false;
			if (a.ssIssuer != b.ssIssuer) return false;
			if (a.ssSubject != b.ssSubject) return false;
			if (a.ssAudience != b.ssAudience) return false;
			if (a.ssExpiration != b.ssExpiration) return false;
			if (a.ssNotBefore != b.ssNotBefore) return false;
			if (a.ssIssuedAt != b.ssIssuedAt) return false;
			if (a.ssCustomClaims != b.ssCustomClaims) return false;
			return true;
		}

		public static bool operator != (STTokenPayloadStructure a, STTokenPayloadStructure b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(STTokenPayloadStructure)) return false;
			return (this == (STTokenPayloadStructure) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssTokenId.GetHashCode()
				^ ssIssuer.GetHashCode()
				^ ssSubject.GetHashCode()
				^ ssAudience.GetHashCode()
				^ ssExpiration.GetHashCode()
				^ ssNotBefore.GetHashCode()
				^ ssIssuedAt.GetHashCode()
				^ ssCustomClaims.GetHashCode()
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

		public STTokenPayloadStructure(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssTokenId = "";
			ssIssuer = "";
			ssSubject = "";
			ssAudience = "";
			ssExpiration = new DateTime(1900, 1, 1, 0, 0, 0);
			ssNotBefore = new DateTime(1900, 1, 1, 0, 0, 0);
			ssIssuedAt = new DateTime(1900, 1, 1, 0, 0, 0);
			ssCustomClaims = new RLNameValuePairRecordList();
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssTokenId", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssTokenId' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssTokenId = (string) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
			fieldInfo = objInfo.GetField("ssIssuer", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssIssuer' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssIssuer = (string) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
			fieldInfo = objInfo.GetField("ssSubject", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssSubject' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssSubject = (string) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
			fieldInfo = objInfo.GetField("ssAudience", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssAudience' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssAudience = (string) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
			fieldInfo = objInfo.GetField("ssExpiration", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssExpiration' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssExpiration = (DateTime) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
			fieldInfo = objInfo.GetField("ssNotBefore", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssNotBefore' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssNotBefore = (DateTime) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
			fieldInfo = objInfo.GetField("ssIssuedAt", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssIssuedAt' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssIssuedAt = (DateTime) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
			fieldInfo = objInfo.GetField("ssCustomClaims", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssCustomClaims' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssCustomClaims = (RLNameValuePairRecordList) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssCustomClaims.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssCustomClaims.InternalRecursiveSave();
		}


		public STTokenPayloadStructure Duplicate() {
			STTokenPayloadStructure t;
			t.ssTokenId = this.ssTokenId;
			t.ssIssuer = this.ssIssuer;
			t.ssSubject = this.ssSubject;
			t.ssAudience = this.ssAudience;
			t.ssExpiration = this.ssExpiration;
			t.ssNotBefore = this.ssNotBefore;
			t.ssIssuedAt = this.ssIssuedAt;
			t.ssCustomClaims = (RLNameValuePairRecordList) this.ssCustomClaims.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Structure");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
				fieldName = fieldName.ToLowerInvariant();
			}
			if (detailLevel > 0) {
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".TokenId")) VarValue.AppendAttribute(recordElem, "TokenId", ssTokenId, detailLevel, TypeKind.Text); else VarValue.AppendOptimizedAttribute(recordElem, "TokenId");
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".Issuer")) VarValue.AppendAttribute(recordElem, "Issuer", ssIssuer, detailLevel, TypeKind.Text); else VarValue.AppendOptimizedAttribute(recordElem, "Issuer");
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".Subject")) VarValue.AppendAttribute(recordElem, "Subject", ssSubject, detailLevel, TypeKind.Text); else VarValue.AppendOptimizedAttribute(recordElem, "Subject");
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".Audience")) VarValue.AppendAttribute(recordElem, "Audience", ssAudience, detailLevel, TypeKind.Text); else VarValue.AppendOptimizedAttribute(recordElem, "Audience");
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".Expiration")) VarValue.AppendAttribute(recordElem, "Expiration", ssExpiration, detailLevel, TypeKind.DateTime); else VarValue.AppendOptimizedAttribute(recordElem, "Expiration");
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".NotBefore")) VarValue.AppendAttribute(recordElem, "NotBefore", ssNotBefore, detailLevel, TypeKind.DateTime); else VarValue.AppendOptimizedAttribute(recordElem, "NotBefore");
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".IssuedAt")) VarValue.AppendAttribute(recordElem, "IssuedAt", ssIssuedAt, detailLevel, TypeKind.DateTime); else VarValue.AppendOptimizedAttribute(recordElem, "IssuedAt");
				ssCustomClaims.ToXml(this, recordElem, "CustomClaims", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "tokenid") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".TokenId")) variable.Value = ssTokenId; else variable.Optimized = true;
			} else if (head == "issuer") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Issuer")) variable.Value = ssIssuer; else variable.Optimized = true;
			} else if (head == "subject") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Subject")) variable.Value = ssSubject; else variable.Optimized = true;
			} else if (head == "audience") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Audience")) variable.Value = ssAudience; else variable.Optimized = true;
			} else if (head == "expiration") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Expiration")) variable.Value = ssExpiration; else variable.Optimized = true;
			} else if (head == "notbefore") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".NotBefore")) variable.Value = ssNotBefore; else variable.Optimized = true;
			} else if (head == "issuedat") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".IssuedAt")) variable.Value = ssIssuedAt; else variable.Optimized = true;
			} else if (head == "customclaims") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".CustomClaims")) variable.Value = ssCustomClaims; else variable.Optimized = true;
				variable.SetFieldName("customclaims");
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
			if (key == IdTokenId) {
				return ssTokenId;
			} else if (key == IdIssuer) {
				return ssIssuer;
			} else if (key == IdSubject) {
				return ssSubject;
			} else if (key == IdAudience) {
				return ssAudience;
			} else if (key == IdExpiration) {
				return ssExpiration;
			} else if (key == IdNotBefore) {
				return ssNotBefore;
			} else if (key == IdIssuedAt) {
				return ssIssuedAt;
			} else if (key == IdCustomClaims) {
				return ssCustomClaims;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssTokenId = (string) other.AttributeGet(IdTokenId);
			ssIssuer = (string) other.AttributeGet(IdIssuer);
			ssSubject = (string) other.AttributeGet(IdSubject);
			ssAudience = (string) other.AttributeGet(IdAudience);
			ssExpiration = (DateTime) other.AttributeGet(IdExpiration);
			ssNotBefore = (DateTime) other.AttributeGet(IdNotBefore);
			ssIssuedAt = (DateTime) other.AttributeGet(IdIssuedAt);
			ssCustomClaims = new RLNameValuePairRecordList();
			ssCustomClaims.FillFromOther((IOSList) other.AttributeGet(IdCustomClaims));
		}
		public bool IsDefault() {
			STTokenPayloadStructure defaultStruct = new STTokenPayloadStructure(null);
			if (this.ssTokenId != defaultStruct.ssTokenId) return false;
			if (this.ssIssuer != defaultStruct.ssIssuer) return false;
			if (this.ssSubject != defaultStruct.ssSubject) return false;
			if (this.ssAudience != defaultStruct.ssAudience) return false;
			if (this.ssExpiration != defaultStruct.ssExpiration) return false;
			if (this.ssNotBefore != defaultStruct.ssNotBefore) return false;
			if (this.ssIssuedAt != defaultStruct.ssIssuedAt) return false;
			if (this.ssCustomClaims != null && this.ssCustomClaims.Length != 0) return false;
			return true;
		}
	} // STTokenPayloadStructure

	/// <summary>
	/// Structure <code>STVerifySignatureOptionsStructure</code> that represents the Service Studio
	///  structure <code>VerifySignatureOptions</code> <p> Description: </p>
	/// </summary>
	[Serializable()]
	public partial struct STVerifySignatureOptionsStructure: ISerializable, ITypedRecord<STVerifySignatureOptionsStructure>, ISimpleRecord {
		internal static readonly GlobalObjectKey IdValidateSignature = GlobalObjectKey.Parse("vpN4uF9vl0+vymUjOgJk6Q*suEF0fZb0E6imAHcpcsA2A");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("ValidateSignature")]
		public bool ssValidateSignature;


		public BitArray OptimizedAttributes;

		public STVerifySignatureOptionsStructure(params string[] dummy) {
			OptimizedAttributes = null;
			ssValidateSignature = true;
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[0];
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
				} else {
				}
			}
			get {
				BitArray[] all = new BitArray[0];
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssValidateSignature = r.ReadBoolean(index++, "VerifySignatureOptions.ValidateSignature", false);
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
		public void ReadIM(STVerifySignatureOptionsStructure r) {
			this = r;
		}


		public static bool operator == (STVerifySignatureOptionsStructure a, STVerifySignatureOptionsStructure b) {
			if (a.ssValidateSignature != b.ssValidateSignature) return false;
			return true;
		}

		public static bool operator != (STVerifySignatureOptionsStructure a, STVerifySignatureOptionsStructure b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(STVerifySignatureOptionsStructure)) return false;
			return (this == (STVerifySignatureOptionsStructure) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssValidateSignature.GetHashCode()
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

		public STVerifySignatureOptionsStructure(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssValidateSignature = true;
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssValidateSignature", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssValidateSignature' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssValidateSignature = (bool) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
		}

		public void InternalRecursiveSave() {
		}


		public STVerifySignatureOptionsStructure Duplicate() {
			STVerifySignatureOptionsStructure t;
			t.ssValidateSignature = this.ssValidateSignature;
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Structure");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
				fieldName = fieldName.ToLowerInvariant();
			}
			if (detailLevel > 0) {
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".ValidateSignature")) VarValue.AppendAttribute(recordElem, "ValidateSignature", ssValidateSignature, detailLevel, TypeKind.Boolean); else VarValue.AppendOptimizedAttribute(recordElem, "ValidateSignature");
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "validatesignature") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".ValidateSignature")) variable.Value = ssValidateSignature; else variable.Optimized = true;
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
			if (key == IdValidateSignature) {
				return ssValidateSignature;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssValidateSignature = (bool) other.AttributeGet(IdValidateSignature);
		}
		public bool IsDefault() {
			STVerifySignatureOptionsStructure defaultStruct = new STVerifySignatureOptionsStructure(null);
			if (this.ssValidateSignature != defaultStruct.ssValidateSignature) return false;
			return true;
		}
	} // STVerifySignatureOptionsStructure

	/// <summary>
	/// Structure <code>STTokenHeaderStructure</code> that represents the Service Studio structure
	///  <code>TokenHeader</code> <p> Description: Defines the header section of a token</p>
	/// </summary>
	[Serializable()]
	public partial struct STTokenHeaderStructure: ISerializable, ITypedRecord<STTokenHeaderStructure>, ISimpleRecord {
		internal static readonly GlobalObjectKey IdAlgorithm = GlobalObjectKey.Parse("vpN4uF9vl0+vymUjOgJk6Q*sNiXl3BApkmTRApwtlEuvw");
		internal static readonly GlobalObjectKey IdKeyId = GlobalObjectKey.Parse("vpN4uF9vl0+vymUjOgJk6Q*slxhDPnfpU+McqJX+njfFQ");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("Algorithm")]
		public string ssAlgorithm;

		[System.Xml.Serialization.XmlElement("KeyId")]
		public string ssKeyId;


		public BitArray OptimizedAttributes;

		public STTokenHeaderStructure(params string[] dummy) {
			OptimizedAttributes = null;
			ssAlgorithm = "";
			ssKeyId = "";
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[0];
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
				} else {
				}
			}
			get {
				BitArray[] all = new BitArray[0];
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssAlgorithm = r.ReadText(index++, "TokenHeader.Algorithm", "");
			ssKeyId = r.ReadText(index++, "TokenHeader.KeyId", "");
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
		public void ReadIM(STTokenHeaderStructure r) {
			this = r;
		}


		public static bool operator == (STTokenHeaderStructure a, STTokenHeaderStructure b) {
			if (a.ssAlgorithm != b.ssAlgorithm) return false;
			if (a.ssKeyId != b.ssKeyId) return false;
			return true;
		}

		public static bool operator != (STTokenHeaderStructure a, STTokenHeaderStructure b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(STTokenHeaderStructure)) return false;
			return (this == (STTokenHeaderStructure) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssAlgorithm.GetHashCode()
				^ ssKeyId.GetHashCode()
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

		public STTokenHeaderStructure(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssAlgorithm = "";
			ssKeyId = "";
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssAlgorithm", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssAlgorithm' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssAlgorithm = (string) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
			fieldInfo = objInfo.GetField("ssKeyId", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssKeyId' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssKeyId = (string) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
		}

		public void InternalRecursiveSave() {
		}


		public STTokenHeaderStructure Duplicate() {
			STTokenHeaderStructure t;
			t.ssAlgorithm = this.ssAlgorithm;
			t.ssKeyId = this.ssKeyId;
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Structure");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
				fieldName = fieldName.ToLowerInvariant();
			}
			if (detailLevel > 0) {
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".Algorithm")) VarValue.AppendAttribute(recordElem, "Algorithm", ssAlgorithm, detailLevel, TypeKind.Text); else VarValue.AppendOptimizedAttribute(recordElem, "Algorithm");
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".KeyId")) VarValue.AppendAttribute(recordElem, "KeyId", ssKeyId, detailLevel, TypeKind.Text); else VarValue.AppendOptimizedAttribute(recordElem, "KeyId");
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "algorithm") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Algorithm")) variable.Value = ssAlgorithm; else variable.Optimized = true;
			} else if (head == "keyid") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".KeyId")) variable.Value = ssKeyId; else variable.Optimized = true;
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
			if (key == IdAlgorithm) {
				return ssAlgorithm;
			} else if (key == IdKeyId) {
				return ssKeyId;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssAlgorithm = (string) other.AttributeGet(IdAlgorithm);
			ssKeyId = (string) other.AttributeGet(IdKeyId);
		}
		public bool IsDefault() {
			STTokenHeaderStructure defaultStruct = new STTokenHeaderStructure(null);
			if (this.ssAlgorithm != defaultStruct.ssAlgorithm) return false;
			if (this.ssKeyId != defaultStruct.ssKeyId) return false;
			return true;
		}
	} // STTokenHeaderStructure

} // OutSystems.NssJWT_Core
