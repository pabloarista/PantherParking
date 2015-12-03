using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantherParking.Data.UnitTests
{
    public class BaseRepository
    {
        private User user = new User();

        public BaseRepository()
        {
            //this.baseRepository = new BaseRepository();
        }

        public ResponseParse<TResponseResult> GetObject<TResponseResult>(string token,
            Dictionary<string, string> constraints)
            where TResponseResult : IBaseModel
        {
            ResponseParse<TResponseResult> r = new ResponseParse<TResponseResult>(){
                HttpStatusCode = string.IsNullOrWhiteSpace(token) ? HttpStatusCode.BadRequest : HttpStatusCode.OK,
                ResponseBody = Activator.CreateInstance<TResponseResult>()
            };

            return r;
        }

        public ResponseParse<ObjectUpdatedResponse> UpdateObject(IBaseModel model, string token)
        {
            ResponseParse<ObjectUpdatedResponse> r = new ResponseParse<ObjectUpdatedResponse>()
            {
                HttpStatusCode = HttpStatusCode.OK,
                ResponseBody = new ObjectUpdatedResponse()
            };

            return r;
        }
    

    }

    public interface ILocationRepository
    {
        LocationResponse CheckIn(CheckIn data);
        LocationResponse CheckOut(CheckIn data);
    }

    public class CheckIn
    {
        public string Username { get; set; }
        public string GarageId { get; set; }
        public string Token { get; set; }
    }

    public class LocationResponse
    {
        public bool ResponseValue { get; set; }
        public string ResponseMessage { get; set; }
    }

    public class ResponseParse<TBody> where TBody : IBaseModel
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public TBody ResponseBody { get; set; }
    }

    public interface IBaseModel
    {
        string objectId { get; set; }
        string ToJson();
        IBaseModel ToModel(string json);
    }

    public class ObjectUpdatedResponse : BaseModel
    {
        public System.DateTime updatedAt { get; set; }
    }

    public class BaseModel : IBaseModel
    {
        public string objectId { get; set; }

        public string ToJson()
        {
            string json = "json";

            return json;
        }

        public IBaseModel ToModel(string json)
        {
            IBaseModel o = new BaseModel(){objectId = json};

            return o;
        }
        /*
        public static TModel GetModel<TModel>(string json) where TModel : IBaseModel
        {
            TModel o = //PABLO;

            return o;
        }*/
    }
}
