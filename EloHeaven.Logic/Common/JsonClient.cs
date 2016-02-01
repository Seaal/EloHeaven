using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EloHeaven.Infrastructure.Extensions;
using Newtonsoft.Json;

namespace EloHeaven.Logic.Common
{
    public class JsonClient : IJsonClient
    {
        public T GetRequest<T>(string uri)
        {
            using (WebClient webClient = new WebClient())
            {
                try
                {
                    string result = webClient.DownloadString(uri);

                    return JsonConvert.DeserializeObject<T>(result);
                }
                catch (WebException ex)
                {
                    HttpStatusCode? statusCode = ex.GetErrorCode();

                    if (statusCode.HasValue && statusCode == HttpStatusCode.NotFound)
                    {
                        return default(T);
                    }

                    throw;
                }
                
            }
        }
    }
}
