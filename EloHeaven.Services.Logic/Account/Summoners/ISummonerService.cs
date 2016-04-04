using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloHeaven.Entities;

namespace EloHeaven.Services.Logic.Account.Summoners
{
    public interface ISummonerService
    {
        IEnumerable<SummonerModel> GetAllForUser(Guid userId);
        SummonerConfirmationModel Add(Guid userId, SummonerModel summonerModel);
        void Confirm(Guid userId, int summonerId);
        void Delete(int userId, int summonerId);
    }
}
