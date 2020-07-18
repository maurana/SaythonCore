using System;
using System.Collections;
using System.Data;

/// <summary>
/// Saython Dictionary Base Class
/// </summary>
namespace Saython.Framework.CRUD
{
    [Serializable()]
    public class SaythonDictionaryBase : DictionaryBase
    {
        public ArrayList DeletedList;

        public SaythonDictionaryBase()
        {
            DeletedList = new ArrayList();
        }

        public void Remove(string key)
        {
            DeletedList.Add(this.InnerHashtable[key]);
            base.InnerHashtable.Remove(key);
        }

        protected DataTable GetDataTable(IDictionary dics, Object item)
        {
            IDictionaryEnumerator enm = dics.GetEnumerator();
            ArrayList arr = new ArrayList();
            while (enm.MoveNext())
            {
                arr.Add(enm.Value);
            }

            SaythonCollectionBase adaptee = new SaythonCollectionBase();
            adaptee.DeletedList = this.DeletedList;

            return adaptee.FriendGetDataTable(arr, item);
        }
    }
}

