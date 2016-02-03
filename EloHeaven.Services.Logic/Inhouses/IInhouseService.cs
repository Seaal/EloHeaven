using EloHeaven.Logic.MentoredInhouses;

namespace EloHeaven.Services.Logic.Inhouses
{
    public interface IInhouseService
    {
        SwapsModel BalanceTeams(InhouseModel inhouseModel);
        PlayerModel GetPlayer(string playerName);
    }
}
