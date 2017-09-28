using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Measurement
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DataMeasurement<T>
    {
        private List<T> listdata = new List<T>();

        public DataMeasurement() {}        
        
        public DataMeasurement(object data) {
            if (data is IEnumerable)
            {
                foreach (Object um in ((IEnumerable<object>)data).ToList())
                {
                    listdata.Add((T)Convert(um));
                }
            } else 
                listdata.Add((T)Convert(data));      
        }

        public virtual T Convert(object obj) {

            return default(T);
        }
    }

    //public class DBDataMeasurement<T>
    //{
    //    protected List<DBUnitMeasurement> listunion = new List<DBUnitMeasurement>();
    //    protected List<T> list = new List<T>();
    //    protected List<DBValueMeasurement> list = new List<DBValueMeasurement>();
    //    public DBDataMeasurement(T obj)
    //    {

    //    }

    //}

    //public class DBDataValueMeasurement<T> {

    //    private Type type;
    //    private object data;
    //    public DBDataValueMeasurement(T objdata, Type obj) { 
        
    //    }
    //}
}
