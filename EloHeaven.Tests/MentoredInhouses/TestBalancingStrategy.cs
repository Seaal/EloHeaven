using System;
using System.Collections.Generic;
using System.Linq;
using EloHeaven.Logic.MentoredInhouses;
using FluentAssertions;
using NUnit.Framework;

namespace EloHeaven.Tests.MentoredInhouses
{
    [TestFixture]
    public class TestBalancingStrategy
    {
        [Test]
        public void TestBruteForceLessThan10Players()
        {
            ArgumentException ex = null;

            ICollection<PlayerModel> blueTeam = GetPlayerCollectionHelper(0);
            ICollection<PlayerModel> redTeam = GetPlayerCollectionHelper();

            try
            {
                IBalancingStrategy strategy = new BruteForceBalancingStrategy();

                strategy.Balance(blueTeam, redTeam);
            }
            catch(ArgumentException e)
            {
                ex = e;
            }

            ex.Should().NotBe(null);
        }

        [Test]
        public void TestBruteForceAllSameRating()
        {
            ICollection<PlayerModel> blueTeam = GetPlayerCollectionHelper(100, 100, 100, 100, 100);
            ICollection<PlayerModel> redTeam = GetPlayerCollectionHelper(100, 100, 100, 100, 100);

            IBalancingStrategy strategy = new BruteForceBalancingStrategy();

            SwapsModel result = strategy.Balance(blueTeam, redTeam);

            result.RedSwaps.Should().BeEmpty();
            result.BlueSwaps.Should().BeEmpty();
            result.RatingDifference.Should().Be(0);
        }

        [Test]
        public void TestBruteForceTwoDifferentRating()
        {
            ICollection<PlayerModel> blueTeam = GetPlayerCollectionHelper(200, 200, 100, 100, 100);
            ICollection<PlayerModel> redTeam = GetPlayerCollectionHelper(100, 100, 100, 100, 100);

            IBalancingStrategy strategy = new BruteForceBalancingStrategy();

            SwapsModel result = strategy.Balance(blueTeam, redTeam);

            result.RedSwaps.Should().HaveCount(1);
            result.BlueSwaps.Should().HaveCount(1);
            result.RatingDifference.Should().Be(0);
        }

        [Test]
        public void TestBruteForceAllDifferentRatingBalanced()
        {
            ICollection<PlayerModel> blueTeam = GetPlayerCollectionHelper(100, 300, 500, 700, 900);
            ICollection<PlayerModel> redTeam = GetPlayerCollectionHelper(150, 250, 600, 750, 750);

            IBalancingStrategy strategy = new BruteForceBalancingStrategy();

            SwapsModel result = strategy.Balance(blueTeam, redTeam);

            result.RedSwaps.Should().BeEmpty();
            result.BlueSwaps.Should().BeEmpty();
            result.RatingDifference.Should().Be(0);
        }

        [Test]
        public void TestBruteForceAllDifferentRatingUnbalanced()
        {
            ICollection<PlayerModel> blueTeam = GetPlayerCollectionHelper(100, 200, 300, 400, 500);
            ICollection<PlayerModel> redTeam = GetPlayerCollectionHelper(600, 700, 800, 900, 1000);

            IBalancingStrategy strategy = new BruteForceBalancingStrategy();

            SwapsModel result = strategy.Balance(blueTeam, redTeam);

            result.RedSwaps.Should().HaveCount(2);
            result.BlueSwaps.Should().HaveCount(2);
            result.RatingDifference.Should().Be(100);
        }

        [Test]
        public void TestBruteForce1DifferentRatingNoSwaps()
        {
            ICollection<PlayerModel> blueTeam = GetPlayerCollectionHelper(100, 100, 100, 100, 105);
            ICollection<PlayerModel> redTeam = GetPlayerCollectionHelper(100, 100, 100, 100, 100);

            IBalancingStrategy strategy = new BruteForceBalancingStrategy();

            SwapsModel result = strategy.Balance(blueTeam, redTeam);

            result.RedSwaps.Should().BeEmpty();
            result.BlueSwaps.Should().BeEmpty();
            result.RatingDifference.Should().Be(5);
        }

        private ICollection<PlayerModel> GetPlayerCollectionHelper(params int[] ratings)
        {
            List<PlayerModel> playerModels = new List<PlayerModel>(ratings.Length);

            playerModels.AddRange(ratings.Select((r, i) => new PlayerModel()
            {
                Rating = r, Name = "Summoner" + i
            }));

            return playerModels;
        }
    }
}
