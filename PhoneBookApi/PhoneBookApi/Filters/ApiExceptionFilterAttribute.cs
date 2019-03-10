using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace PhoneBookApi.Filters
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            var exception = context.Exception;
            if (exception != null)
            {
                context.Response = context.Request
                    .CreateErrorResponse(HttpStatusCode.BadGateway, exception.Message);
            }
            
        }
    }
}