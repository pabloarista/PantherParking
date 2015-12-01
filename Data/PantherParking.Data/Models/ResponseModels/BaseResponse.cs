using System.Net;

namespace PantherParking.Data.Models.ResponseModels
{
    public class BaseResponse
    {
        public HttpStatusCode HttpStatusCode { get; set; }
    }
}