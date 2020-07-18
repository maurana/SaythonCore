﻿using System;
using System.Data;

/// <summary>
/// Saython Base Class
/// </summary>
namespace Saython.Framework.CRUD
{
    [Serializable()]
    public class SaythonBase
    {
        public DataRowState RowState;

        public SaythonBase()
        {
            Console.WriteLine("Saython Framework v.0.0.1 Production 2020");
            Console.WriteLine("@Created By Wacara Start-Up");
            Console.WriteLine("\n");
            Console.WriteLine("Author: Maulana Hasanudin (Founder & CEO Wacara)");
        }

        protected DataTable GetDataTable(Object item)
        {
            DataTable tbl = new DataTable();
            System.Reflection.FieldInfo[] fieldInfos;
            System.Reflection.PropertyInfo[] propInfos;
            Object[] rowValues;
            Int32 fieldCount = 0;
            Int32 propCount = 0;
            Int32 columnCount = 0;
            Int32 j;

            if (item == null) return null;

            //Get Fields and Properties

            fieldInfos = item.GetType().GetFields();
            propInfos = item.GetType().GetProperties();

            //Create table columns
            for (j = 0; j < fieldInfos.Length; j++)
            {
                if (fieldInfos[j].IsDefined((new SaythonDbField()).GetType(), false))
                {
                    tbl.Columns.Add(fieldInfos[j].Name);
                    fieldCount += 1;
                    columnCount += 1;
                }
            }

            for (j = 0; j < propInfos.Length; j++)
            {
                if (fieldInfos[j].IsDefined((new SaythonDbField()).GetType(), false))
                {
                    tbl.Columns.Add(propInfos[j].Name);
                    propCount += 1;
                    columnCount += 1;
                }
            }


            rowValues = new Object[columnCount];

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
                            rowValues[idx] = fieldInfos[j].GetValue(item);
                            idx += 1;
                        }
                    }
                }

                if (propCount > 0)
                {
                    for (j = 0; j < propInfos.Length; j++)
                    {
                        if (fieldInfos[j].IsDefined((new SaythonDbField()).GetType(), false))
                        {
                            rowValues[idx] = propInfos[j].GetValue(item, null);
                            idx += 1;
                        }
                    }
                }

                tbl.Rows.Add(rowValues);
            }

            return tbl;
        }

    }
}
