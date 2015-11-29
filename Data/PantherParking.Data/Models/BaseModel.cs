using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json;


namespace PantherParking.Data.Models
{
    public class BaseModel : IBaseModel
    {

        public string objectId { get; set; }


        public bool ShouldSerializeobjectId()
        {
            return false;
        }

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

        public XElement ToXml()
        {
            string json = this.ToJson();
            XmlDocument xmlDoc = JsonConvert.DeserializeXmlNode(json);
            XElement xml = XElement.Load(new XmlNodeReader(xmlDoc));

            return xml;
        }
    }
}
