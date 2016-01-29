using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloHeaven.Logic.Common
{
    public interface IJsonClient
    {
        T GetRequest<T>(string uri);
    }
}
