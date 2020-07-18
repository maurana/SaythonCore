using System;

namespace Saython.Framework.CRUD
{
    /// <summary>
    /// Saython Db Field Key Class
    /// </summary>
    public class SaythonDbFieldKey
    {
        public String Name;
        public String Value;
        public SaythonDbFieldType Type;
        public SaythonDbOperatorType OperatorType;

        public SaythonDbFieldKey(string name, string value)
        {
            this.Name = name;
            this.Value = value;
            this.Type = SaythonDbFieldType.Text;
            this.OperatorType = SaythonDbOperatorType.Equal;
        }

        public SaythonDbFieldKey(string name, string value, SaythonDbFieldType type)
        {
            this.Name = name;
            this.Value = value;
            this.Type = type;
            this.OperatorType = SaythonDbOperatorType.Equal;
        }

        public SaythonDbFieldKey(string name, string value, SaythonDbFieldType type, SaythonDbOperatorType operatortype)
        {
            this.Name = name;
            this.Value = value;
            this.Type = type;
            this.OperatorType = operatortype;
        }

    }
}
