using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace ADVWebAPI
{

    public class CustomJsonFormatter : JsonMediaTypeFormatter
    {
        public CustomJsonFormatter()
        {
            this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            this.SerializerSettings.Formatting = Formatting.Indented;
        }

        public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
        {
            base.SetDefaultContentHeaders(type, headers, mediaType);
            headers.ContentType = new MediaTypeHeaderValue("application/json");
        }
    }

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "ApiById",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "ApiByStatus",
                routeTemplate: "api/{controller}/GetEmployeesByMaritalStatus/{mStatus}",
                defaults: new { mStatus = RouteParameter.Optional }
            );

            //This is to get employees by gender
            config.Routes.MapHttpRoute(
                name: "ApiByGender",
                routeTemplate: "api/{controller}/GetEmployeesByGender/{gender}",
                defaults: new { gender = "All" }
            );

            config.Routes.MapHttpRoute(
               name: "ApiByOrgLevel",
               routeTemplate: "api/{controller}/GetEmployeesByOrgLevel/{orgLevel}",
               defaults: new { orgLevel = RouteParameter.Optional }
           );

            config.Routes.MapHttpRoute(
                name: "ApiByAction",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { action = "Get" }
            );

            config.Formatters.Add(new CustomJsonFormatter());

        }

        
    }

    
}
