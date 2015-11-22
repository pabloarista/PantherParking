using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using PantherParking.Data.Models.enumerations;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace PantherParking.Data.DAL.Repositories
{
    public class JsonTest
    {
        
    }
    public class BaseRepository
    {
        public static void Main()
        {
            BaseRepository br = new BaseRepository();
            dynamic response = br.GetRestApiResponse<object>(BaseRepository.ParseUrlPrefix + "classes/JsonTest", HttpMethod.Post,
                new {foo = "bar"}, null, false);
        }

#warning TODO: here we need the call to our datastore that shall be inherited by all repository classes

        /*
        for now I made three classes of objects beyond the default Users...
        ParkedUsers
        History
        AvailableSpaces
        */

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

        public static T DeserializeJsonToModel<T>(string json)
        {
            T o = JsonConvert.DeserializeObject<T>(json);

            return o;
        }
        public static string SerializeModeltoJson(object o)
        {
            string json = JsonConvert.SerializeObject(o);

            return json;
        }

        public dynamic GetRestApiResponse<TResponseResult>(string url
                                , HttpMethod httpMethod
                                , object contents
                                , string token
                                , bool session)
            where TResponseResult : class
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
                if (session)
                {
                    request.Headers.Add("X-Parse-Revocable-Session", "1");
                }//if

                //for the roles api:
                //"X-Parse-Master-Key: gbddxekqnucHKN2EnFlKpYmFc1xvYrphlRT03siW"
                #endregion headers

                if (contents != null)
                {
                    request.ContentType = BaseRepository.DefaultParseHttpContentType;

                    using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
                    {

                        writer.WriteLine(BaseRepository.SerializeModeltoJson(contents));
                        writer.Flush();
                        writer.Close();
                    }//using writer
                }
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
                return parseResponse == null ? null : BaseRepository.DeserializeJsonToModel<TResponseResult>(parseResponse);

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
#warning TODO:should we respond with the HTTP status code and set an object by reference? or a new model that will have the http status code?
            return response?.StatusCode ?? HttpStatusCode.InternalServerError;
        }
    }
}
