using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloHeaven.Logic.LeagueApi;

namespace EloHeaven.Logic.MentoredInhouses
{
    public class BalancingService : IBalancingService
    {
        public int GetRating(LeagueSummoner summoner)
        {
            if (summoner.Level < 30)
            {
                return 250;
            }

            int rating;

            switch (summoner.Tier)
            {
                case "Bronze":
                    rating = 0;
                    break;
                case "Silver":
                case "Unranked":
                    rating = 500;
                    break;
                case "Gold":
                    rating = 1000;
                    break;
                case "Platinum":
                    rating = 1500;
                    break;
                case "Diamond":
                    rating = 2000;
                    break;
                case "Master":
                    rating = 2500;
                    break;
                case "Challenger":
                    rating = 2500;
                    break;
                default:
                    throw new InvalidOperationException("Unsupported Ranked Tier");
            }

            switch (summoner.Division)
            {
                case "V":
                case "":
                    rating += 0;
                    break;
                case "IV":
                    rating += 100;
                    break;
                case "III":
                    rating += 200;
                    break;
                case "II":
                    rating += 300;
                    break;
                case "I":
                    rating += 400;
                    break;
                default:
                    throw new InvalidOperationException("Unsupported Ranked Division");
            }

            rating += summoner.LeaguePoints;

            return rating;
        }

        public SwapsModel BalanceInhouse(InhouseModel inhouse)
        {
            BalancingStrategyFactory balancingStrategyFactory = new BalancingStrategyFactory();

            IBalancingStrategy balancingStrategy = balancingStrategyFactory.Make(BalancingStrategy.BruteForce);

            return balancingStrategy.Balance(inhouse.BlueTeam, inhouse.RedTeam);
        }
    }
}
