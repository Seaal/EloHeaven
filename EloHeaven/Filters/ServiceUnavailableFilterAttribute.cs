using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;
using EloHeaven.Infrastructure.Exceptions;
using EloHeaven.Logic.LeagueApi.DTOs;
using EloHeaven.Services.Logic;

namespace EloHeaven.Filters
{
    public class ServiceUnavailableFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is ServiceUnavailableException)
            {
                context.Response = context.Request.CreateResponse(HttpStatusCode.ServiceUnavailable, new ErrorModel(context.Exception.Message));
            }
        }
    }
}