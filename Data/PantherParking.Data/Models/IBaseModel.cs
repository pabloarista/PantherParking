using System.Xml.Linq;

namespace PantherParking.Data.Models
{
    public interface IBaseModel
    {
        string objectId { get; set; }
        string ToJson();
        IBaseModel ToModel(string json);
        XElement ToXml();
    }
}