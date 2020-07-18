using System;

/// <summary>
/// Saython Database Attribute Classes
/// </summary>
namespace Saython.Framework.CRUD
{
    public class SaythonDbField : Attribute
    {
        public string FieldName;
        public SaythonDbFieldType FieldType;
        public Object FieldValue;
        public string LookupTable;
        public string ChildPK;
        public string ParentPK;
        public string FieldNameAlias;
        public Boolean IsLookupField;

        public SaythonDbField()
        {
        }

        public SaythonDbField(string FieldName, SaythonDbFieldType FieldType)
        {
            this.FieldName = FieldName;
            this.FieldType = FieldType;
            this.LookupTable = "";
            this.ChildPK = "";
            this.ParentPK = "";
            this.FieldNameAlias = "";
            IsLookupField = false;
        }

        public SaythonDbField(string FieldName, string LookupTable, string ChildPK, string ParentPK, string FieldNameAlias)
        {
            this.FieldName = FieldName;
            this.LookupTable = LookupTable;
            this.ChildPK = ChildPK;
            this.ParentPK = ParentPK;
            this.FieldNameAlias = FieldNameAlias;
            IsLookupField = true;
        }
    }

    public class SaythonDbReadOnly : Attribute
    {
        public SaythonDbReadOnly()
        {
        }
    }

    public class SaythonDbCreatable : Attribute
    {
        public SaythonDbCreatable()
        {
        }
    }

    public class SaythonDbCreatableAutoIncrement : Attribute
    {
        public SaythonDbCreatableAutoIncrement()
        {
        }
    }
}