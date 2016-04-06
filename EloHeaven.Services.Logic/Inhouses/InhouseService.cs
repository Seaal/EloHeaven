using EloHeaven.Logic;
using EloHeaven.Logic.LeagueApi;
using EloHeaven.Logic.MentoredInhouses;

namespace EloHeaven.Services.Logic.Inhouses
{
    public class InhouseService : IInhouseService
    {
        private readonly ILeagueApiService _leagueApiService;
        private readonly IBalancingService _balancingService;

        public InhouseService(ILeagueApiService leagueApiService, IBalancingService balancingService)
        {
            _leagueApiService = leagueApiService;
            _balancingService = balancingService;
        }

        public SwapsModel BalanceTeams(InhouseModel inhouseModel)
        {
            return _balancingService.BalanceInhouse(inhouseModel);
        }

        public PlayerModel GetPlayer(string playerName)
        {
            LeagueSummoner summoner = _leagueApiService.GetSummoner("na", playerName);

            return new PlayerModel()
            {
                Id = (int) summoner.Id,
                Name = summoner.Name,
                Level = summoner.Level,
                Rank = summoner.Tier + " " + summoner.Division,
                Rating = _balancingService.GetRating(summoner),
                Region = new RegionModel { Id = "NA", Name = "North America"},
                Status = "confirmed"
            };
        }
    }
}
