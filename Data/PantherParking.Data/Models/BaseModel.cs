using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace PantherParking.Data.Models
{
    public class BaseModel : IBaseModel
    {
        public string objectId { get; set; }

        public string ToJson()
        {
            string json = JsonConvert.SerializeObject(this);

            return json;
        }

        public IBaseModel ToModel(string json)
        {
            IBaseModel o = JsonConvert.DeserializeObject<IBaseModel>(json);

            return o;
        }

        public static TModel GetModel<TModel>(string json) where TModel : IBaseModel
        {
            TModel o = JsonConvert.DeserializeObject<TModel>(json);

            return o;
        }
    }
}
