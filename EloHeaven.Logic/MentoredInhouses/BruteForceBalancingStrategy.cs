using Combinatorics.Collections;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloHeaven.Logic.MentoredInhouses
{
    public class BruteForceBalancingStrategy : IBalancingStrategy
    {
        public SwapsModel Balance(ICollection<PlayerModel> blueTeam, ICollection<PlayerModel> redTeam)
        {
            if(blueTeam.Count + redTeam.Count != 10)
            {
                throw new ArgumentException("10 players required to balance the teams.");
            }

            int lowestRatingDiff = Int32.MaxValue;
            ICollection<PlayerModel> finalTeam1 = null;
            ICollection<PlayerModel> finalTeam2 = null;

            IList<PlayerModel> players = blueTeam.Concat(redTeam).ToList();
            
            Combinations<PlayerModel> combinations = new Combinations<PlayerModel>(players, 5);

            foreach(ICollection<PlayerModel> team1 in combinations)
            {
                ICollection<PlayerModel> team2 = GetOtherTeam(players, team1);

                int team1Rating = GetTeamRating(team1);
                int team2Rating = GetTeamRating(team2);

                if(Math.Abs(team1Rating - team2Rating) < lowestRatingDiff)
                {
                    lowestRatingDiff = Math.Abs(team1Rating - team2Rating);
                    finalTeam1 = team1;
                    finalTeam2 = team2;
                }
            }

            ICollection<PlayerModel> blueSwaps = CalculateSwaps(blueTeam, finalTeam1, finalTeam2);
            ICollection<PlayerModel> redSwaps = CalculateSwaps(redTeam, finalTeam1, finalTeam2);

            return new SwapsModel()
            {
                RatingDifference = lowestRatingDiff,
                BlueSwaps = blueSwaps,
                RedSwaps = redSwaps
            };
        }

        private int GetTeamRating(ICollection<PlayerModel> team)
        {
            return team.Sum(summoner => summoner.Rating);
        }

        private ICollection<PlayerModel> GetOtherTeam(IList<PlayerModel> players, ICollection<PlayerModel> team1)
        {
            return players.Except(team1).ToList();
        }

        private ICollection<PlayerModel> CalculateSwaps(ICollection<PlayerModel> originalTeam, ICollection<PlayerModel> team1, ICollection<PlayerModel> team2)
        {
            ICollection<PlayerModel> team1SwappedPlayers = team2.Except(originalTeam).ToList();

            //There should be at most 2 swaps per team, so if we get more than 2 swaps in team 1, then finding who changed to team 2 will be less than 2.
            if (team1SwappedPlayers.Count > 2)
            {
                return team1.Except(originalTeam).ToList();
            }

            return team1SwappedPlayers;
        }
    }  
}
