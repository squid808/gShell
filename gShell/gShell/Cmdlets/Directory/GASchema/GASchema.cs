using System;
using System.Linq;
using System.Collections.Generic;
using System.Management.Automation;
using Data = Google.Apis.Admin.Directory.directory_v1.Data;

namespace gShell.Cmdlets.Directory.GASchema
{
    [Cmdlet(VerbsCommon.Get, "GASchema",
          DefaultParameterSetName = "One",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GASchema")]
    public class GetGASchema : DirectoryBase
    {
        #region Properties

        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string CustomerId { get; set; }

        //Domain position = 1

        [Parameter(Position = 2,
            Mandatory = true,
            ParameterSetName = "One",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string SchemaKey { get; set; }

        [Parameter(Position = 3,
            ParameterSetName = "List")]
        public SwitchParameter All { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess(CustomerId, "Get-GASchema"))
            {
                switch (ParameterSetName)
                {
                    case "One":
                        WriteObject((SchemaFieldCollection)schemas.Get(CustomerId, SchemaKey));
                        break;
                    case "List":
                        WriteObject((schemas.List(CustomerId)).Cast<SchemaFieldCollection>().ToList());
                        break;
                }
            }
        }
    }

    [Cmdlet(VerbsCommon.Remove, "GASchema",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Remove-GASchema")]
    public class RemoveGASchema : DirectoryBase
    {
        #region Properties

        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string CustomerId { get; set; }

        //Domain position = 1

        [Parameter(Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string SchemaKey { get; set; }

        [Parameter(Position = 2)]
        public SwitchParameter Force { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess(CustomerId, "Remove-GASchema"))
            {
                if (Force || ShouldContinue((String.Format("Schema Key {0} for CustomerId {2} will be removed from the {1} Google Apps domain.\nContinue?",
                    SchemaKey, Domain, CustomerId)), "Confirm Google Apps Schema Removal"))
                {
                    try
                    {
                        WriteDebug(string.Format("Attempting to remove Schema {0}...",
                            CustomerId));
                        WriteObject(schemas.Delete(CustomerId, SchemaKey));
                        WriteVerbose(string.Format("Removal of Schema {0} completed without error.",
                            CustomerId));
                    }
                    catch (Exception e)
                    {
                        WriteError(new ErrorRecord(e, e.GetBaseException().ToString(), ErrorCategory.InvalidData, CustomerId));
                    }
                }
                else
                {
                    WriteError(new ErrorRecord(new Exception("Schema deletion not confirmed"),
                        "", ErrorCategory.InvalidData, CustomerId));
                }
            }
        }
    }

    [Cmdlet(VerbsCommon.Set, "GASchema",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Set-GASchema")]
    public class SetGASchema : DirectoryBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string CustomerId { get; set; }

        //Domain position = 1

        [Parameter(Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string SchemaKey { get; set; }

        [Parameter(Position = 3,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public SchemaFieldCollection FieldCollection { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess(CustomerId, "Set-GASchema"))
            {
                WriteObject(schemas.Patch((Data.Schema)FieldCollection, CustomerId, SchemaKey));
            }
        }
    }

    [Cmdlet(VerbsCommon.Add, "GASchema",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Add-GASchema")]
    public class NewGASchema : DirectoryBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string CustomerId { get; set; }

        //Domain position = 1

        [Parameter(Position = 2,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public SchemaFieldCollection FieldCollection { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess(CustomerId, "Add-GASchema"))
            {
                WriteObject(schemas.Insert((Data.Schema)FieldCollection, CustomerId));
            }
        }
    }

    [Cmdlet(VerbsCommon.New, "GASchemaField",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/New-GASchemaField",
          DefaultParameterSetName="New")]
    public class NewGASchemaField : PSCmdlet
    {
        #region Properties
        [Parameter(Position = 0,
            ParameterSetName = "New",
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string FieldName { get; set; }

        [Parameter(Position = 1,
            ParameterSetName = "New",
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public SchemaField.SchemaFieldType FieldType { get; set; }

        [Parameter(Position = 2,
            ParameterSetName = "New",
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public bool? Indexed { get; set; }

        [Parameter(Position = 3,
            ParameterSetName = "New",
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public bool? MultiValued { get; set; }

        [Parameter(Position = 4,
            ParameterSetName = "New",
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public double? MinValue { get; set; }

        [Parameter(Position = 5,
            ParameterSetName = "New",
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public double? MaxValue { get; set; }

        [Parameter(Position = 6,
            ParameterSetName = "New",
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public SchemaField.SchemaFieldReadAccessType? ReadAccessType { get; set; }

        [Parameter(Position = 0,
            ParameterSetName = "Google",
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public Data.SchemaFieldSpec SchemaFieldSpec { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            switch (ParameterSetName)
            {
                case "New":

                    SchemaField field = new SchemaField(FieldName, FieldType)
                    {
                        minValue = MinValue,
                        maxValue = MaxValue,
                        indexed = Indexed,
                        multiValued = MultiValued,
                        readAccessType = ReadAccessType
                    };

                    WriteObject(field);
                    break;

                case "Google":
                    WriteObject((SchemaField)SchemaFieldSpec);
                    break;
            }

        }
    }

    [Cmdlet(VerbsCommon.New, "GASchemaFieldCollection",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/New-GASchemaFieldCollection",
          DefaultParameterSetName="New")]
    public class NewGASchemaFieldCollection : PSCmdlet
    {
        #region Properties
        [Parameter(Position = 0,
            ParameterSetName = "New",
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string SchemaName { get; set; }

        [Parameter(Position = 1,
            ParameterSetName = "New",
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public SchemaField Field { get; set; }

        [Parameter(Position = 0,
            ParameterSetName = "Google",
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public Data.Schema Schema { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (Field != null)
            {
                WriteObject(new SchemaFieldCollection(SchemaName, Field));
            }
            else if (Schema != null)
            {
                WriteObject((SchemaFieldCollection)Schema);
            }
            else
            {
                WriteObject(new SchemaFieldCollection(SchemaName));
            }
        }
    }

    /// <summary>
    /// A custom wrapper for a List<SchemaField> type.
    /// </summary>
    public class SchemaFieldCollection
    {
        #region Properties
        public string schemaName;

        public List<SchemaField> fields {get {return _fields;}}

        private List<SchemaField> _fields = new List<SchemaField>();
        #endregion

        #region Getters
        public List<SchemaField> GetFields()
        {
            return _fields;
        }
        #endregion

        #region Constructors
        public SchemaFieldCollection() { }

        public SchemaFieldCollection(string SchemaName) 
        {
            schemaName = SchemaName;
        }

        public SchemaFieldCollection(string SchemaName, SchemaField field)
        {
            schemaName = SchemaName;
            Add(field);
        }
        #endregion

        #region Add
        public void Add(SchemaField field) {
            _fields.Add(field);
        }
        #endregion

        #region AddRange
        public void AddRange(IEnumerable<SchemaField> fList) {
            foreach (SchemaField field in fList)
            {
                _fields.Add(field);
            }
        }
        #endregion

        #region OperatorPlusOverload
        public static SchemaFieldCollection operator +(SchemaFieldCollection coll1, SchemaFieldCollection coll2)
        {
            coll1.AddRange(coll2.fields);

            return coll1;
        }

        public static SchemaFieldCollection operator +(SchemaFieldCollection coll1, SchemaField f2)
        {
            coll1.Add(f2);

            return coll1;
        }
        #endregion

        #region RemoveAt
        public void RemoveAt(int index)
        {
            if (index >= 0)
            {
                if (_fields.Count > index)
                {
                    _fields.RemoveAt(index);
                }
            }
        }
        #endregion

        #region Clear
        public void Clear()
        {
            _fields.Clear();
        }
        #endregion

        #region Explicit Conversion

        public static explicit operator SchemaFieldCollection(Data.Schema schema)
        {
            SchemaFieldCollection coll = new SchemaFieldCollection();

            coll.schemaName = schema.SchemaName;

            foreach (Data.SchemaFieldSpec spec in schema.Fields)
            {
                coll.Add((SchemaField)spec);
            }

            return coll;
        }

        public static explicit operator Data.Schema(SchemaFieldCollection coll)
        {
            Data.Schema schema = new Data.Schema()
            {
                Fields = new List<Data.SchemaFieldSpec>()
            };

            schema.SchemaName = coll.schemaName;

            foreach (SchemaField field in coll.fields)
            {
                schema.Fields.Add((Data.SchemaFieldSpec)field);
            }

            return schema;
        }
        #endregion
    }

    /// <summary>
    /// A friendly version of Data.Schema, allowing for use of enums to restrict options.
    /// </summary>
    public class SchemaField
    {
        public enum SchemaFieldType
        {
            STRING, INT64, BOOL, DOUBLE, EMAIL, PHONE, DATE
        }

        public enum SchemaFieldReadAccessType
        {
            ALL_DOMAIN_USERS, ADMINS_AND_SELF
        }

        #region Properties
        public string fieldName;
        public SchemaFieldType fieldType;
        public bool? indexed;
        public bool? multiValued;
        public double? minValue;
        public double? maxValue;
        public SchemaFieldReadAccessType? readAccessType;
        #endregion

        public SchemaField(string FieldName, SchemaFieldType FieldType){
            fieldName = FieldName;
            fieldType = FieldType;
        }

        #region Explicit Conversion
        public static explicit operator SchemaField(Data.SchemaFieldSpec spec)
        {
            SchemaFieldType type = (SchemaFieldType)Enum.Parse(typeof(SchemaFieldType), (string)spec.FieldType, false);

            SchemaField field = new SchemaField(spec.FieldName, type);

            if (spec.Indexed.HasValue)
            {
                field.indexed = spec.Indexed.Value;
            }

            if (spec.MultiValued.HasValue)
            {
                field.multiValued = spec.MultiValued.Value;
            }
            
            if (spec.NumericIndexingSpec != null &&
                spec.NumericIndexingSpec.MinValue.HasValue &&
                spec.NumericIndexingSpec.MaxValue.HasValue)
            {
                if (spec.NumericIndexingSpec.MinValue.HasValue)
                {
                    field.minValue = spec.NumericIndexingSpec.MinValue.Value;
                }

                if (spec.NumericIndexingSpec.MaxValue.HasValue)
                {
                    field.maxValue = spec.NumericIndexingSpec.MaxValue.Value;
                }
            }

            if (!string.IsNullOrWhiteSpace(spec.ReadAccessType))
            {
                field.readAccessType = (SchemaFieldReadAccessType)Enum.Parse(typeof(SchemaFieldReadAccessType),
                        spec.ReadAccessType, false);
            }

            return field;
        }

        public static explicit operator Data.SchemaFieldSpec(SchemaField field)
        {
            Data.SchemaFieldSpec spec = new Data.SchemaFieldSpec()
            {
                FieldName = field.fieldName,
                FieldType = field.fieldType.ToString(),
                Indexed = field.indexed,
                MultiValued = field.multiValued,
                ReadAccessType = field.readAccessType.ToString()
            };

            spec.NumericIndexingSpec = new Data.SchemaFieldSpec.NumericIndexingSpecData()
            {
                MinValue = field.minValue,
                MaxValue = field.maxValue
            };

            return spec;
        }
        #endregion
    }

    
}
