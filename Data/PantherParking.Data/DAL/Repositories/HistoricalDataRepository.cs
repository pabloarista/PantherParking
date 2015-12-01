using System.Linq;
using System.Net;
using PantherParking.Data.DAL.Interfaces;
using PantherParking.Data.Models;
using PantherParking.Data.Models.Parse;
using PantherParking.Data.Models.ResponseModels;

namespace PantherParking.Data.DAL.Repositories
{
    public class HistoricalDataRepository : BaseRepository, IHistoricalDataRepository
    {
        public HistoricalDataResponse GetWeeklyHistory(System.DateTime beginWeek, string garageID, string username, string token)
        {
            //--data-urlencode 'where={"$or":[{"wins":{"$gt":150}},{"wins":{"$lt":5}}]}' \
            //https://api.parse.com/1/classes/Player

            if (string.IsNullOrWhiteSpace(token)) return null;

            ResponseDatastore<ObjectGetAllResponse<History>> rr = this.GetObjects<ObjectGetAllResponse<History>, Garage>(token);

            if (rr == null || rr.ResponseBody?.results?.Length < 1)
            {
                return new HistoricalDataResponse
                {
                    ResponseData = rr?.ResponseBody?.results,
                    ResponseMessage = "Error retrieving history",
                    HttpStatusCode = HttpStatusCode.InternalServerError,
                };
            }//if


            History[] hh = rr.ResponseBody.results
                            .Where(o => o.createdAt.HasValue
                                    && o.createdAt.Value.Date >= beginWeek.Date
                                    && o.createdAt.Value.Date <= beginWeek.Date.AddDays(7))
                            .ToArray();

            return new HistoricalDataResponse
            {
                HttpStatusCode = hh.Length > 1 ? HttpStatusCode.OK : HttpStatusCode.InternalServerError,
                ResponseMessage = hh.Length > 1 ? "" : "No data found!",
                ResponseData =  hh
            };
        }

        public Garage[] GetSpacesAvailable(string sessionToken)
        {
            if (string.IsNullOrWhiteSpace(sessionToken)) return null;

            ResponseDatastore<ObjectGetAllResponse<Garage>> rr = this.GetObjects<ObjectGetAllResponse<Garage>, Garage>(sessionToken);

            return rr?.ResponseBody?.results;
        }
    }
}