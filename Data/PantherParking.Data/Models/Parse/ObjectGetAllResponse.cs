namespace PantherParking.Data.Models.Parse
{
    public class ObjectGetAllResponse<TResults> : BaseModel
        where TResults : IBaseModel
    {
        public TResults[] results { get; set; }
    }
}