using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ApiUnes
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            //config.EnableSystemDiagnosticsTracing();

            // Web API routes
            //config.MapHttpAttributeRoutes();
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{token}",
                defaults: new { token = RouteParameter.Optional }
            );


            config.Routes.MapHttpRoute(
                name: "API Default",
                routeTemplate: "api/{controller}/{token}/{id}",
                defaults: new { token = RouteParameter.Optional, id = RouteParameter.Optional }
            );


            config.Routes.MapHttpRoute(
                name: "RotaDinamica",
                routeTemplate: "api/{controller}/{token}/{colecao}/{campo}/{orderBy}/{pageSize}/{pageNumber}",
                defaults: new
                {
                    token = RouteParameter.Optional,
                    colecao = RouteParameter.Optional,
                    campo = RouteParameter.Optional,
                    orderBy = RouteParameter.Optional,
                    pageSize = RouteParameter.Optional,
                    pageNumber = RouteParameter.Optional
                }
            );


            // Custom Formatters:
            /*config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(
                config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml"));

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();*/
        }
    }
}
