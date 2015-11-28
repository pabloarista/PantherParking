using System.Net;

namespace PantherParking.Data.Models.ResponseModels
{
    public class ResponseParse<TBody> where TBody : IBaseModel
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public TBody ResponseBody { get; set; } 
    }
}