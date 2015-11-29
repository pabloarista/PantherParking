namespace PantherParking.Web.Models.Location
{
    public class CheckinRequest
    {
        public string username { get; set; }
        public string garageId { get; set; }
        public string sessionToken { get; set; }
    }
}