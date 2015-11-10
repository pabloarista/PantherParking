using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using PantherParking.Data.Models.Attributes;

namespace PantherParking.Data.Models
{
    /// <summary>
    /// The purpose of this class is to convert a model into a dictionary that is a key (public property name) and value (public property value)
    /// </summary>
    public static class ModelToDictionary
    {
        public static bool HasAttribute<CustomAttribute>(this PropertyInfo prop) where CustomAttribute : Attribute
        {
            Attribute[] attr = Attribute.GetCustomAttributes(prop);

            return attr.Length > 0 && attr.OfType<CustomAttribute>().FirstOrDefault() != null;
        }
        public static Dictionary<string, string> SerializeToDictionary<M>(this M model)
        {
            if(model == null) return new Dictionary<string, string>(0);

            Type t = model.GetType();

            PropertyInfo[] props = t.GetProperties();

            if(props.Length < 1) return new Dictionary<string, string>(0);

            Dictionary<string, string> serialized = new Dictionary<string, string>(props.Length);

            foreach (PropertyInfo p in props)
            {
                bool serializableProp = p.HasAttribute<SerializePropertyAttribute>();
                bool serializableModel = p.HasAttribute<SerializeModelAttribute>();

                if (serializableProp)
                {
                    
                }//if
                else if (serializableModel)
                {
                    
                }
            }//foreach p

            return serialized;
        }
    }
}