namespace PantherParking.Data.Models
{
    public class RequestLogin : BaseModel
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}