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
        SummonerConfirmationModel Add(int userId, SummonerModel summonerModel);
        void Confirm(int userId, int summonerId);
        void Delete(int userId, int summonerId);
        SummonerConfirmationModel GetConfirmation(int userId, int summonerId);
    }
}
