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
        IEnumerable<SummonerModel> GetAllForUser(int userId);
        SummonerVerificationModel Add(int userId, SummonerModel summonerModel);
        void Verify(int userId, int summonerId);
        void Delete(int userId, int summonerId);
        SummonerVerificationModel GetVerification(int userId, int summonerId);
    }
}
