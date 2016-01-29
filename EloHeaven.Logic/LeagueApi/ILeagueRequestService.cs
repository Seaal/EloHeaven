using EloHeaven.Logic.LeagueApi.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloHeaven.Logic.LeagueApi
{
    public interface ILeagueRequestService
    {
        SummonerDTO GetSummoner(string summonerName);
        ICollection<LeagueDTO> GetLeagues(long summonerId);
    }
}
