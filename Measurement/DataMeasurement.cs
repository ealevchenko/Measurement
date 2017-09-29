using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
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
        public List<T> ListData { get { return this.listdata; } }
        /// <summary>
        /// 
        /// </summary>
        public DataMeasurement() {}        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public virtual T Convert(object obj) {

            return default(T);
        }
    }

}
