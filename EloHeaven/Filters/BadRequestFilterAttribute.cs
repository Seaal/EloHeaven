using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;
using EloHeaven.Infrastructure.Exceptions;
using EloHeaven.Services.Logic;

namespace EloHeaven.Filters
{
    public class BadRequestFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is BadRequestException)
            {
                context.Response = context.Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorModel(context.Exception.Message));
            }
        }
    }
}