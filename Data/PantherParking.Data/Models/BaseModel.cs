using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Parse;

namespace PantherParking.Data.Models
{
    public class BaseModel : IBaseModel
    {
        [JsonProperty("objectId")]
        public string ObjectId { get; set; }

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
            IBaseModel o = JsonConvert.DeserializeObject<TModel>(json);

            return o;
        }
    }
}
