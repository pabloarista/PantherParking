using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using System.Xml.Linq;
using PantherParking.Data.Models.enumerations;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using PantherParking.Data.Models;
using PantherParking.Data.Models.Parse;
using PantherParking.Data.Models.ResponseModels;

namespace PantherParking.Data.DAL.Repositories
{
    public class JsonTest
    {
        
    }
    public class BaseRepository
    {
        public static void Main()
        {
            //BaseRepository br = new BaseRepository();
            //dynamic response = br.GetRestApiResponse<object>(BaseRepository.ParseUrlPrefix + "classes/JsonTest", HttpMethod.Post,
            //    new {foo = "bar"}, null, false);
        }
        
#warning TODO: here we need the call to our datastore that shall be inherited by all repository classes

        private static string AppID => ConfigurationManager.AppSettings["appID"];
        private static string RestApiKey => ConfigurationManager.AppSettings["restApiKey"];
        private static string DefaultParseHttpContentType => ConfigurationManager.AppSettings["defaultParseHttpContentType"];

        private static string ParseUrlPrefix => $"{ConfigurationManager.AppSettings["parseRestApi"]}/{ConfigurationManager.AppSettings["parseVersion"]}/";

        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value + "");

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            return attributes.Length > 0
                ? attributes[0].Description
                : value.ToString();
        }

        public ResponseParse<TResponseResult> CreateObject<TResponseResult>(IBaseModel model, string token)
            where TResponseResult : IBaseModel
        {
            string url = BaseRepository.ParseUrlPrefix + "classes/" + model.GetType();

            ResponseParse<TResponseResult> r = this.GetRestApiResponse<TResponseResult>(url, HttpMethod.Post, model, token);

            return r;
        }

        public ResponseParse<TResponseResult> ChangeObject<TResponseResult>(IBaseModel model, string token, HttpMethod httpMethod)
            where TResponseResult : IBaseModel
        {
            string url = $"{BaseRepository.ParseUrlPrefix}classes/{model.GetType()}/{model.ObjectId}";

            ResponseParse<TResponseResult> r = this.GetRestApiResponse<TResponseResult>(url, httpMethod, model, token);

            return r;
        }

        public ResponseParse<ObjectUpdatedResponse> UpdateObject(IBaseModel model, string token)
        {
            return this.ChangeObject<ObjectUpdatedResponse>(model, token, HttpMethod.Put);
        }

        public ResponseParse<TResponseResult> DeleteObject<TResponseResult>(IBaseModel model, string token)
            where TResponseResult : IBaseModel
        {
            return this.ChangeObject<TResponseResult>(model, token, HttpMethod.Delete);
        }

        public ResponseParse<TResponseResult> GetObject<TResponseResult>(string token,
            Dictionary<string, string> constraints)
            where TResponseResult : IBaseModel
        {

            StringBuilder sbUrl = new StringBuilder(BaseRepository.ParseUrlPrefix + "classes/" + typeof(TResponseResult) + "?where={");
            bool begin = true;
            foreach (KeyValuePair<string, string> kvp in constraints)
            {
                if (begin)
                {
                    begin = false;
                }//if
                else
                {
                    sbUrl.Append(",");
                }//else
                //WebUtility for non-webapplications
                sbUrl.Append(HttpUtility.UrlEncode($"\"{kvp.Key}\":\"{kvp.Value}\""));
            }//foreach kvp

            sbUrl.Append("}");

            ResponseParse<TResponseResult> r = this.GetRestApiResponse<TResponseResult>(sbUrl + "", HttpMethod.Get, null,
                token);

            return r;
        }

        /*curl -X GET \
  -H "X-Parse-Application-Id: 1gcrCuX9jtjkpMXpPLHjHPBXx4gxU2PUvOrGP184" \
  -H "X-Parse-REST-API-Key: 1k8GdjzcH2tB0IBXuFgahOu1QurpYdjNynHavdJz" \
  -G \
  --data-urlencode 'where={"playerName":"Sean Plott","cheatMode":false}' \
  https://api.parse.com/1/classes/GameScore*/

        public ResponseParse<TResponseResult> GetRestApiResponse<TResponseResult>(string url
                                , HttpMethod httpMethod
                                , IBaseModel contents
                                , string token
                                //, bool session
            )
            where TResponseResult : IBaseModel
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            try
            {
                ServicePointManager.ServerCertificateValidationCallback =
                        new RemoteCertificateValidationCallback(
                            (object sender, X509Certificate certification, X509Chain chain, SslPolicyErrors sslPolicyErrors) => true);

                request = (HttpWebRequest)WebRequest.Create(url);

                request.Method = BaseRepository.GetEnumDescription(httpMethod);
                

                #region headers
                request.Headers.Add("X-Parse-Application-Id", BaseRepository.AppID);
                request.Headers.Add("X-Parse-REST-API-Key", BaseRepository.RestApiKey);
                if (!string.IsNullOrWhiteSpace(token))
                {
                    //sample token:
                    //r:pnktnjyb996sj4p156gjtp4im
                    request.Headers.Add("X-Parse-Session-Token", token);
                }//if

                //if (session)
                //{
                //    request.Headers.Add("X-Parse-Revocable-Session", "1");
                //}//if

                //for the roles api:
                //"X-Parse-Master-Key: gbddxekqnucHKN2EnFlKpYmFc1xvYrphlRT03siW"
                #endregion headers

                if (contents != null)
                {
                    request.ContentType = BaseRepository.DefaultParseHttpContentType;

                    using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
                    {

                        writer.WriteLine(contents.ToJson());
                        writer.Flush();
                        writer.Close();
                    }//using writer
                }//if

                // Send the data to the webserver
                response = (HttpWebResponse)request.GetResponse();
                
                string parseResponse = null;
                Stream s = response.GetResponseStream();
                if (s != null)
                {
                    using (var streamReader = new StreamReader(s))
                    {
                        parseResponse = streamReader.ReadToEnd();
                    }
                }//if
                //TResponseResult noResponseResult = null;
                ResponseParse<TResponseResult> rp = new ResponseParse<TResponseResult>
                {
                    HttpStatusCode = response.StatusCode,
                    ResponseBody = string.IsNullOrWhiteSpace(parseResponse) ? default(TResponseResult) : BaseModel.GetModel<TResponseResult>(parseResponse)
                };

                return rp;
            }
            catch (Exception ex)
            {
                ex.Data["URL"] = url;
                ex.Data["Content Type"] = BaseRepository.DefaultParseHttpContentType;
                ex.Data["HTTP Method"] = httpMethod;
                //ex.Data["HTTP Headers"] = headers.ToString(seperator: "],[", isItemWrapped: true, iWrapItems: 1);
                throw;
            }
            finally
            {
                request?.GetRequestStream().Close();
                Stream responseStream = response?.GetResponseStream();
                responseStream?.Close();
            }
        }
    }
}
