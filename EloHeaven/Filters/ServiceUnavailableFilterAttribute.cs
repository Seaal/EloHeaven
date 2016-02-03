using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;
using EloHeaven.Infrastructure.Exceptions;

namespace EloHeaven.Filters
{
    public class ServiceUnavailableFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is ServiceUnavailableException)
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.ServiceUnavailable)
                {
                    ReasonPhrase = context.Exception.Message
                };
            }
        }
    }
}