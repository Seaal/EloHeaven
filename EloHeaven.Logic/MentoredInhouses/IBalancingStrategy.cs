using System.Collections.Generic;
using EloHeaven.Logic.LeagueApi;

namespace EloHeaven.Logic.MentoredInhouses
{
    public interface IBalancingStrategy
    {
        SwapsModel Balance(ICollection<PlayerModel> blueTeam, ICollection<PlayerModel> redTeam);
    }
}
