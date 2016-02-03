using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloHeaven.Logic.LeagueApi;

namespace EloHeaven.Logic.MentoredInhouses
{
    public interface IBalancingService
    {
        int GetRating(LeagueSummoner summoner);

        SwapsModel BalanceInhouse(InhouseModel inhouse);
    }
}
