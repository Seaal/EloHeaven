using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloHeaven.Infrastructure.Extensions;
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
                Id = summonerDto.Id,
                Name = summonerDto.Name,
                Level = summonerDto.SummonerLevel
            };

            SetRankingInformation(summoner, summonerDto);

            return summoner;
        }

        private void SetRankingInformation(LeagueSummoner summoner, SummonerDTO summonerDto)
        {
            ICollection<LeagueDTO> leagueDtos = _leagueRequestService.GetLeagues(summonerDto.Id);

            if (leagueDtos == null)
            {
                summoner.Tier = "Unranked";
                summoner.Division = "";
                return;
            }

            LeagueDTO rankedSoloLeagueDto = leagueDtos.FirstOrDefault(l => l.Queue == _rankedSolo);

            if (rankedSoloLeagueDto == null)
            {
                summoner.Tier = "Unranked";
                summoner.Division = "";
            }
            else
            {
                summoner.Tier = rankedSoloLeagueDto.Tier.ToCapitalized();

                //For solo queue there's only one entry, so we can just get it
                LeagueEntryDTO entryDto = rankedSoloLeagueDto.Entries.First();

                summoner.Division = IsDivisionRequired(summoner.Tier) ? entryDto.Division : "";
                summoner.LeaguePoints = entryDto.LeaguePoints;
            }
        }

        private bool IsDivisionRequired(string tier)
        {
            if (tier == "Challenger" || tier == "Master")
            {
                return false;
            }

            return true;
        }
    }
}
