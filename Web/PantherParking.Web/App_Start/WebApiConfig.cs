using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;

namespace PantherParking.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer sessionToken authentication.
            //config.SuppressDefaultHostAuthentication();
            //config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //config.Services.Add(typeof(IExceptionLogger), new TraceExceptionLogger());
        }
    }

    //public class TraceExceptionLogger : ExceptionLogger
    //{
    //    public override void Log(ExceptionLoggerContext context)
    //    {
    //        //
    //        try
    //        {
    //            Trace.TraceError(context.ExceptionContext.Exception.ToString());
    //            EventLog.CreateEventSource("EventSystem", "Application");

    //            EventLog.WriteEntry("Application", context.Exception + "",EventLogEntryType.Error);



    //        }
    //        catch (Exception)
    //        {
    //            Trace.TraceError(context.ExceptionContext.Exception.ToString());
    //        }
            
    //    }
    //}
}
