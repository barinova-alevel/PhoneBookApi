using Microsoft.Web.Http.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Routing;

namespace PhoneBookApi
{

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var constraintResolver = new DefaultInlineConstraintResolver()
            {
                ConstraintMap = { ["apiVersion"] = typeof(ApiVersionRouteConstraint) }
            };
            config.MapHttpAttributeRoutes(constraintResolver);
            config.AddApiVersioning(o=> o.AssumeDefaultVersionWhenUnspecified = true);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }

}
