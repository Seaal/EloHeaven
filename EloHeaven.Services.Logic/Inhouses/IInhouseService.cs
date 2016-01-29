namespace EloHeaven.Services.Logic.Inhouses
{
    public interface IInhouseService
    {
        InhouseModel BalanceTeams(InhouseModel inhouseModel);
        PlayerModel GetPlayer(string playerName);
    }
}
