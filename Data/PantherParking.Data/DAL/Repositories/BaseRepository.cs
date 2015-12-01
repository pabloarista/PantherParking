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
            //dynamic response = br.RetrieveRestApiResponse<object>(BaseRepository.ParseUrlPrefix + "classes/JsonTest", HttpMethod.Post,
            //    new {foo = "bar"}, null, false);

            BaseRepository br = new BaseRepository();

            User u = new User
            {
                username = "test@me.com",
                adminUser = false,
                email = "test@me.com",
                garageID = "",
                password = "test",

            };

            //ResponseDatastore<ObjectCreatedResponse> rp = br.PostResponse<ObjectCreatedResponse>(u,
            //            u.token, DatastoreType.Users);

            //ResponseDatastore<ObjectCreatedResponse> r = br.CreateObject<ObjectCreatedResponse>(u, "");

            ResponseDatastore<ObjectGetAllResponse<User>> rr = br.GetObject<ObjectGetAllResponse<User>,  User>("", new Dictionary<string, string>(1) { { "username", u.username } });


        }

        public enum DatastoreType
        {
            [Description("classes")]
            Entity = 1,
            [Description("login")]
            Login = 2,
            [Description("users")]
            Users = 4,
            [Description("logout")]
            Logout = 8
        }

        public ResponseDatastore<TResponseResult> PostResponse<TResponseResult>(
            IBaseModel contents
            , string token
            , DatastoreType datastoreType)
            where TResponseResult : IBaseModel
        {
            return this.RetrieveResponse<TResponseResult>(HttpMethod.Post, contents, token, datastoreType);
        }

        public ResponseDatastore<TResponseResult> GetResponse<TResponseResult>(
            IBaseModel contents
            , string token
            , DatastoreType datastoreType)
            where TResponseResult : IBaseModel
        {
            return this.RetrieveResponse<TResponseResult>(HttpMethod.Get, contents, token, datastoreType);
        }

        public ResponseDatastore<TResponseResult> RetrieveResponse<TResponseResult>(
            HttpMethod httpMethod
            , IBaseModel contents
            , string token
            , DatastoreType datastoreType)
            where TResponseResult : IBaseModel
        {
            string url = $"{BaseRepository.ParseUrlPrefix + BaseRepository.GetEnumDescription(datastoreType)}/";
            if (datastoreType == DatastoreType.Entity)
            {
                url += contents.GetType().Name;
            }//if

            if (httpMethod == HttpMethod.Get)
            {
                Type t = contents.GetType();
                PropertyInfo[] props = t.GetProperties();
                StringBuilder sb = new StringBuilder();

                foreach (PropertyInfo pi in props)
                {
                    string name = pi.Name;
                    string value = pi.GetValue(contents, null) + "";
                    if (sb.Length != 0)
                    {
                        sb.Append("&");
                    }//if
                    sb.Append($"{name}={HttpUtility.UrlEncode(value)}");
                }//foreach pi

                url += "?" + sb;
                contents = null;
            }//if

            return this.RetrieveRestApiResponse<TResponseResult>(url, httpMethod, contents, token);
        }

#warning TODO: here we need the call to our datastore that shall be inherited by all repository classes

        protected static string AppID => ConfigurationManager.AppSettings["appID"];
        protected static string RestApiKey => ConfigurationManager.AppSettings["restApiKey"];
        protected static string DefaultParseHttpContentType => ConfigurationManager.AppSettings["defaultParseHttpContentType"];
        protected static string MasterKey => ConfigurationManager.AppSettings["masterKey"];

        protected static string ParseUrlPrefix => $"{ConfigurationManager.AppSettings["parseRestApi"]}/{ConfigurationManager.AppSettings["parseVersion"]}/";

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

        public ResponseDatastore<TResponseResult> CreateObject<TResponseResult>(IBaseModel model, string token)
            where TResponseResult : IBaseModel
        {
            string url = BaseRepository.ParseUrlPrefix + "classes/" + model.GetType().Name;

            ResponseDatastore<TResponseResult> r = this.RetrieveRestApiResponse<TResponseResult>(url, HttpMethod.Post, model, token);

            return r;
        }

        public ResponseDatastore<TResponseResult> ChangeObject<TResponseResult>(IBaseModel model, string token, HttpMethod httpMethod)
            where TResponseResult : IBaseModel
        {
            Type t = model.GetType();
            string className = t == typeof(User)
                ? "_User"
                : t.Name;
            string url = $"{BaseRepository.ParseUrlPrefix}classes/{className}/{model.objectId}";

            ResponseDatastore<TResponseResult> r = this.RetrieveRestApiResponse<TResponseResult>(url, httpMethod, model, token);

            return r;
        }

        public ResponseDatastore<ObjectUpdatedResponse> UpdateObject(IBaseModel model, string token)
        {
            return this.ChangeObject<ObjectUpdatedResponse>(model, token, HttpMethod.Put);
        }

        public ResponseDatastore<TResponseResult> DeleteObject<TResponseResult>(IBaseModel model, string token)
            where TResponseResult : IBaseModel
        {
            return this.ChangeObject<TResponseResult>(model, token, HttpMethod.Delete);
        }

        public ResponseDatastore<TResponseResult> GetObjects<TResponseResult, TResponseArray>(string token)
            where TResponseResult : IBaseModel
        {
            Type t = typeof(TResponseArray);
            string className = t == typeof(User)
                ? "_User"
                : typeof(TResponseArray).Name;

            string url = BaseRepository.ParseUrlPrefix + "classes/" + className;

            ResponseDatastore<TResponseResult> r = this.RetrieveRestApiResponse<TResponseResult>(url, HttpMethod.Get, null,
                token);

            return r;
        }

        public ResponseDatastore<TResponseResult> GetObject<TResponseResult, TResponseArray>(string token,
            Dictionary<string, string> constraints)
            where TResponseResult : IBaseModel
        {
            string className = typeof(TResponseArray) == typeof(User) ? "_User" : typeof(TResponseArray).Name;
            string urlPrefix = BaseRepository.ParseUrlPrefix + "classes/" + className + "?where=";
            StringBuilder sbUrl = new StringBuilder("{");
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
                string jsonProp = $"\"{kvp.Key}\":\"{kvp.Value}\"";
                sbUrl.Append(jsonProp);
            }//foreach kvp

            sbUrl.Append("}");
            string url = urlPrefix + HttpUtility.UrlEncode(sbUrl + "");
            ResponseDatastore<TResponseResult> r = this.RetrieveRestApiResponse<TResponseResult>(url, HttpMethod.Get, null,
                token);

            return r;
        }

        /*curl -X GET \
  -H "X-Parse-Application-Id: 1gcrCuX9jtjkpMXpPLHjHPBXx4gxU2PUvOrGP184" \
  -H "X-Parse-REST-API-Key: 1k8GdjzcH2tB0IBXuFgahOu1QurpYdjNynHavdJz" \
  -G \
  --data-urlencode 'where={"playerName":"Sean Plott","cheatMode":false}' \
  https://api.parse.com/1/classes/GameScore*/

        public ResponseDatastore<TResponseResult> RetrieveRestApiResponse<TResponseResult>(string url
                                , HttpMethod httpMethod
                                , IBaseModel contents
                                , string token)
            where TResponseResult : IBaseModel
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            Stream requestStream = null;
            Stream responseStream = null;
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
                request.Headers.Add("X-Parse-Master-Key", BaseRepository.MasterKey);
                if (!string.IsNullOrWhiteSpace(token))
                {
                    //sample token:
                    //r:pnktnjyb996sj4p156gjtp4im
                    request.Headers.Add("X-Parse-Session-sessionToken", token);
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
                    requestStream = request.GetRequestStream();

                    using (StreamWriter writer = new StreamWriter(requestStream))
                    {
                        string json = contents.ToJson();
                        writer.WriteLine(json);
                        writer.Flush();
                        writer.Close();
                    }//using writer
                }//if

                try
                {
                    // Send the data to the webserver
                    response = (HttpWebResponse)request.GetResponse();
                }
                catch (WebException err)
                {
                    response = (HttpWebResponse)err.Response;
                }

                string parseResponse = null;
                responseStream = response.GetResponseStream();
                if (responseStream != null)
                {
                    using (var streamReader = new StreamReader(responseStream))
                    {
                        parseResponse = streamReader.ReadToEnd();
                    }
                }//if
                //TResponseResult noResponseResult = null;
                ResponseDatastore<TResponseResult> rp = new ResponseDatastore<TResponseResult>
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
                try
                {
                    requestStream?.Close();
                }
                catch (Exception)
                {

                }
                try
                {

                    responseStream?.Close();
                }
                catch (Exception)
                {

                }
            }
        }
    }
}
