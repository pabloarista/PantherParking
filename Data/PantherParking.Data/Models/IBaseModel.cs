namespace PantherParking.Data.Models
{
    public interface IBaseModel
    {
        string ObjectId { get; set; }
        string ToJson();
        IBaseModel ToModel(string json);
    }
}