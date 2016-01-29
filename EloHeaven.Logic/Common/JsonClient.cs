using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
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
                    if (ex.Status == WebExceptionStatus.ProtocolError)
                    {
                        HttpWebResponse webResponse = (HttpWebResponse) ex.Response;

                        if (webResponse.StatusCode == HttpStatusCode.NotFound)
                        {
                            return default(T);
                        }
                    }

                    throw;
                }
                
            }
        }
    }
}
