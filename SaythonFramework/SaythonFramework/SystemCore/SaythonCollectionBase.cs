using System;
using System.Collections;
using System.Data;

/// <summary>
/// Saython Collection Base Class
/// </summary>
namespace Saython.Framework.CRUD
{
    [Serializable()]
    public class SaythonCollectionBase : CollectionBase
    {
        public ArrayList DeletedList;

        public SaythonCollectionBase()
        {
            DeletedList = new ArrayList();
        }

        public void RemoveAtIndex(Int32 index)
        {
            DeletedList.Add(this.InnerList[index]);
            base.RemoveAt(index);
        }

        protected DataTable GetDataTable(ArrayList data, Object item)
        {
            DataTable tbl = new DataTable();
            System.Reflection.FieldInfo[] fieldInfos;
            System.Reflection.PropertyInfo[] propInfos;
            Object[] rowValues;
            Int32 fieldCount = 0;
            Int32 propCount = 0;
            Int32 columnCount = 0;
            Int32 j;

            if (data.Count == 0)
            {
                fieldInfos = item.GetType().GetFields();
                propInfos = item.GetType().GetProperties();

                //Create table columns
                for (j = 0; j < fieldInfos.Length; j++)
                {
                    if (fieldInfos[j].IsDefined((new SaythonDbField()).GetType(), false))
                    {
                        tbl.Columns.Add(fieldInfos[j].Name, fieldInfos[j].FieldType);
                    }
                }
                for (j = 0; j < propInfos.Length; j++)
                {
                    if (propInfos[j].IsDefined((new SaythonDbField()).GetType(), false))
                    {
                        tbl.Columns.Add(fieldInfos[j].Name, fieldInfos[j].FieldType);
                    }
                }
            }
            else
            {
                //Get Fields and Properties
                fieldInfos = data[0].GetType().GetFields();
                propInfos = data[0].GetType().GetProperties();

                //Create table columns
                for (j = 0; j < fieldInfos.Length; j++)
                {
                    if (fieldInfos[j].IsDefined((new SaythonDbField()).GetType(), false))
                    {
                        tbl.Columns.Add(fieldInfos[j].Name, fieldInfos[j].FieldType);
                        fieldCount += 1;
                        columnCount += 1;
                    }
                }

                for (j = 0; j < propInfos.Length; j++)
                {
                    if (propInfos[j].IsDefined((new SaythonDbField()).GetType(), false))
                    {
                        tbl.Columns.Add(fieldInfos[j].Name, fieldInfos[j].FieldType);
                        propCount += 1;
                        columnCount += 1;
                    }
                }


                rowValues = new Object[columnCount];


                for (Int32 i = 0; i < data.Count; i++)
                {
                    //Add table rows
                    if (columnCount > 0)
                    {
                        Int16 idx = 0;
                        if (fieldCount > 0)
                        {
                            for (j = 0; j < fieldInfos.Length; j++)
                            {
                                if (fieldInfos[j].IsDefined((new SaythonDbField()).GetType(), false))
                                {
                                    rowValues[idx] = fieldInfos[j].GetValue(data[i]);
                                    idx += 1;
                                }
                            }
                        }

                        if (propCount > 0)
                        {
                            for (j = 0; j < propInfos.Length; j++)
                            {
                                if (propInfos[j].IsDefined((new SaythonDbField()).GetType(), false))
                                {
                                    rowValues[idx] = propInfos[j].GetValue(data[i], null);
                                    idx += 1;
                                }
                            }
                        }

                        tbl.Rows.Add(rowValues);
                    }
                }
            }

            return tbl;
        }

        internal DataTable FriendGetDataTable(ArrayList cols, Object item)
        {
            return GetDataTable(cols, item);
        }
    }
}