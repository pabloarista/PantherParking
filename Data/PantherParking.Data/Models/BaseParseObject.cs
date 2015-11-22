using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Parse;

namespace PantherParking.Data.Models
{
    public class BaseParseObject : ParseObject
    {
        public static T CreateMe<T>() where T : BaseParseObject
        {
            return (T)ParseObject.Create(typeof(T).Name);
        }

        public bool Build()
        {
            try
            {
                Type t = this.GetType();
                PropertyInfo[] props = t.GetProperties();

                foreach (PropertyInfo pi in props)
                {
                    object propertyValue = pi.GetValue(this, null);
                    string propertyName = pi.Name;
                    this[propertyName] = propertyValue;
                }//foreach pi

                return true;
            }
            catch (Exception ex)
            {
#warning TODO:log
                return false;
            }
        }
    }
}
