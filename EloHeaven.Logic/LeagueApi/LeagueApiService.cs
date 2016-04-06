using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloHeaven.Entities;
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

        public LeagueSummoner GetSummoner(string region, string summonerName)
        {
            SummonerDTO summonerDto = _leagueRequestService.GetSummoner(region ,summonerName);

            LeagueSummoner summoner = new LeagueSummoner()
            {
                Id = summonerDto.Id,
                Name = summonerDto.Name,
                Level = summonerDto.SummonerLevel
            };

            SetRankingInformation(region, summoner, summonerDto);

            return summoner;
        }

        public bool ConfirmSummoner(Summoner summoner)
        {
            RunepagesDTO runepagesDto = _leagueRequestService.GetRunepages(summoner.Region.LeagueApiId, summoner.LeagueApiId);

            return runepagesDto.Pages.Any(rp => rp.Name == summoner.VerificationCode);
        }

        private void SetRankingInformation(string region, LeagueSummoner summoner, SummonerDTO summonerDto)
        {
            IEnumerable<LeagueDTO> leagueDtos = _leagueRequestService.GetLeagues(region, summonerDto.Id);

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
