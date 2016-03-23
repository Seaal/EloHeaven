using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloHeaven.Services.Logic.Account.Summoners
{
    public interface ISummonerService
    {
        IEnumerable<SummonerModel> GetAllForUser(Guid userId);
        SummonerConfirmationModel Add(Guid userId, SummonerModel summonerModel);
        void Confirm(Guid userId, int summonerId);
    }
}
