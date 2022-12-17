using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using WebApi.App_Start;

namespace WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //Web API configuration and services
            config.Filters.Add(new CustomExceptionFilter());// Customer Filter
            config.Services.Replace(typeof(IExceptionHandler),new GlobalExceptionHandler()); // Global Exception Handler
            //Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
