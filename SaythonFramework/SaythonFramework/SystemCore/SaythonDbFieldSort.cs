using System;

namespace Saython.Framework.CRUD
{
    /// <summary>
    /// Saython Db Field Sort Class
    /// </summary>
    public class SaythonDbFieldSort
    {
        public string Name;
        public SaythonDbSortDirection Direction;

        public SaythonDbFieldSort(string name)
        {
            this.Name = name;
            this.Direction = SaythonDbSortDirection.Asc;
        }

        public SaythonDbFieldSort(string name, SaythonDbSortDirection direction)
        {
            this.Name = name;
            this.Direction = direction;
        }


    }
}
