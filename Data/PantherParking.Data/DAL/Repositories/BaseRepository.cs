using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using PantherParking.Data.Models.enumerations;
//using Pqsk.Helper;
//using Pqsk.Helper.Xml;

namespace PantherParking.Data.DAL.Repositories
{
    public class BaseRepository
    {
#warning TODO: here we need the call to our datastore that shall be inherited by all repository classes

        /*
        for now I made three classes of objects beyond the default Users...
        ParkedUsers
        History
        AvailableSpaces
        */

        private string AppID => ConfigurationManager.AppSettings["appID"];
        private string JavaScriptID => ConfigurationManager.AppSettings["javaScriptID"];

        public dynamic GetRestApiResponse(string url
                                , HttpMethod httpMethod
                                , Dictionary<string, string> headers
                                , HttpContentType httpContentType)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            try
            {
                ServicePointManager.ServerCertificateValidationCallback =
                        new RemoteCertificateValidationCallback(
                            (object sender, X509Certificate certification, X509Chain chain, SslPolicyErrors sslPolicyErrors) => true);

                request = (HttpWebRequest)WebRequest.Create(url);

                request.Method = httpMethod + "";

                if (headers != null && headers.Count > 0)
                {
                    foreach (KeyValuePair<string, string> kvp in headers)
                    {
                        request.Headers.Add(kvp.Key, kvp.Value);
                    }//foreach kvp
                }//if

                switch (httpContentType)
                {
                    case HttpContentType.NONE:
                        request.ContentType = "";
                        break;
                    case HttpContentType.APPLICATION_XML:
                        request.ContentType = "application/xml";
                        break;
                    case HttpContentType.APPLICATION_X_WWW_FORM_URLENCODED:
                        request.ContentType = "application/x-www-form-urlencoded";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(httpContentType), httpContentType, null);
                }

                //StreamWriter writer = new StreamWriter(request.GetRequestStream());

                //writer.WriteLine(rawXml.ToString());
                //writer.Close();
                // Send the data to the webserver
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (Exception ex)
            {
                ex.Data["URL"] = url;
                ex.Data["Content Type"] = httpContentType + "";
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
