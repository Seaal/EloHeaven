using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloHeaven.Logic.LeagueApi
{
    public interface ILeagueApiService
    {
        LeagueSummoner GetSummoner(string summonerName);
    }
}
