using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloHeaven.Entities;

namespace EloHeaven.Logic.LeagueApi
{
    public interface ILeagueApiService
    {
        LeagueSummoner GetSummoner(string region, string summonerName);
        bool ConfirmSummoner(Summoner summoner);
    }
}
