namespace PantherParking.Web.Models.Login
{
    public class LogoutRequest
    {
        public string username { get; set; }
        public string sessionToken { get; set; }
    }
}