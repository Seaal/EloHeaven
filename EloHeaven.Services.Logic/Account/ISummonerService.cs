using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloHeaven.Services.Logic.Account
{
    public interface ISummonerService
    {
        IEnumerable<SummonerModel> GetAllForUser(Guid userId);
    }
}
