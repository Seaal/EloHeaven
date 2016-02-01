using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EloHeaven.Infrastructure.Extensions
{
    public static class WebExceptionExtensions
    {
        public static HttpStatusCode? GetErrorCode(this WebException ex)
        {
            if (ex.Status == WebExceptionStatus.ProtocolError)
            {
                HttpWebResponse webResponse = (HttpWebResponse) ex.Response;

                return webResponse.StatusCode;
            }

            return null;
        }
    }
}
