using EloHeaven.Logic.LeagueApi;

namespace EloHeaven.Services.Logic.Inhouses
{
    public class InhouseService : IInhouseService
    {
        private readonly ILeagueApiService _leagueApiService;

        public InhouseService(ILeagueApiService leagueApiService)
        {
            _leagueApiService = leagueApiService;
        }

        public InhouseModel BalanceTeams(InhouseModel inhouseModel)
        {
            throw new System.NotImplementedException();
        }

        public PlayerModel GetPlayer(string playerName)
        {
            LeagueSummoner summoner = _leagueApiService.GetSummoner(playerName);

            return new PlayerModel()
            {
                Id = (int) summoner.Id,
                Name = summoner.Name,
                Rank = summoner.Tier + " " + summoner.Division,
                Region = "NA",
                Status = "confirmed"
            };
        }
    }
}
