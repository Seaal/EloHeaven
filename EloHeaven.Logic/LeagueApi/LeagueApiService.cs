using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloHeaven.Logic.LeagueApi.DTOs;

namespace EloHeaven.Logic.LeagueApi
{
    public class LeagueApiService : ILeagueApiService
    {
        private readonly ILeagueRequestService _leagueRequestService;

        private readonly string _rankedSolo = "RANKED_SOLO_5x5";

        public LeagueApiService(ILeagueRequestService leagueRequestService)
        {
            _leagueRequestService = leagueRequestService;
        }

        public LeagueSummoner GetSummoner(string summonerName)
        {
            SummonerDTO summonerDto = _leagueRequestService.GetSummoner(summonerName);

            LeagueSummoner summoner = new LeagueSummoner()
            {
                Name = summonerDto.Name,
                Level = summonerDto.SummonerLevel
            };

            ICollection<LeagueDTO> leagueDtos = _leagueRequestService.GetLeagues(summonerDto.Id);

            if (leagueDtos == null)
            {
                summoner.Tier = "Unranked";
                return summoner;
            }

            LeagueDTO rankedSoloLeagueDto = leagueDtos.FirstOrDefault(l => l.Queue == _rankedSolo);

            if (rankedSoloLeagueDto == null)
            {
                summoner.Tier = "Unranked";
            }
            else
            {
                summoner.Tier = rankedSoloLeagueDto.Tier;

                //For solo queue there's only one entry, so we can just get it
                LeagueEntryDTO entryDto = rankedSoloLeagueDto.Entries.First();

                summoner.Division = entryDto.Division;
                summoner.LeaguePoints = entryDto.LeaguePoints;
            }

            return summoner;
        }
    }
}
