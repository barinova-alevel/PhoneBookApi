using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace MVC25.Exceptions
{
    public class MVC25Exception : Exception
    {
        public MVC25Exception(HttpStatusCode statusCode, string message)
            : base(message)
        {
            StatusCode = statusCode;
        }

        public HttpStatusCode StatusCode { get; }
    }
}