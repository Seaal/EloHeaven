using EloHeaven.Logic.LeagueApi;
using EloHeaven.Logic.MentoredInhouses;
using FluentAssertions;
using NUnit.Framework;

namespace EloHeaven.Tests.MentoredInhouses
{
    [TestFixture]
    public class TestSummonerRating
    {
        private IBalancingService _balancingService;

        [SetUp]
        public void Init()
        {
            _balancingService = new BalancingService();
        }

        [Test]
        public void Under_Level_30_Should_Return_250_Rating()
        {
            LeagueSummoner summoner = new LeagueSummoner()
            {
                Level = 25
            };

            int rating = _balancingService.GetRating(summoner);

            rating.Should().Be(250);
        }

        [Test]
        public void TestUnrankedRating()
        {
            LeagueSummoner summoner = GetSummonerHelper("Unranked", "", 0);

            int rating = _balancingService.GetRating(summoner);

            rating.Should().Be(500);
        }

        [Test]
        public void TestBronzeVRating()
        {
            LeagueSummoner summoner = GetSummonerHelper("Bronze", "V", 0);

            int rating = _balancingService.GetRating(summoner);

            rating.Should().Be(0);
        }

        [Test]
        public void TestSilverVRating()
        {
            LeagueSummoner summoner = GetSummonerHelper("Silver", "V", 0);

            int rating = _balancingService.GetRating(summoner);

            rating.Should().Be(500);
        }

        [Test]
        public void TestGoldVRating()
        {
            LeagueSummoner summoner = GetSummonerHelper("Gold", "V", 0);

            int rating = _balancingService.GetRating(summoner);

            rating.Should().Be(1000);
        }

        [Test]
        public void TestPlatinumVRating()
        {
            LeagueSummoner summoner = GetSummonerHelper("Platinum", "V", 0);

            int rating = _balancingService.GetRating(summoner);

            rating.Should().Be(1500);
        }

        [Test]
        public void TestDiamondVRating()
        {
            LeagueSummoner summoner = GetSummonerHelper("Diamond", "V", 0);

            int rating = _balancingService.GetRating(summoner);

            rating.Should().Be(2000);
        }

        [Test]
        public void TestMasterIRating()
        {
            LeagueSummoner summoner = GetSummonerHelper("Master", "", 0);

            int rating = _balancingService.GetRating(summoner);

            rating.Should().Be(2500);
        }

        [Test]
        public void TestChallengerIRating()
        {
            LeagueSummoner summoner = GetSummonerHelper("Challenger", "", 0);

            int rating = _balancingService.GetRating(summoner);

            rating.Should().Be(2500);
        }

        [Test]
        public void TestLPRating()
        {
            LeagueSummoner summoner = GetSummonerHelper("Challenger", "", 527);

            int rating = _balancingService.GetRating(summoner);

            rating.Should().Be(3027);
        }

        [Test]
        public void TestBronzeIVRating()
        {
            LeagueSummoner summoner = GetSummonerHelper("Bronze", "IV", 0);

            int rating = _balancingService.GetRating(summoner);

            rating.Should().Be(100);
        }

        [Test]
        public void TestBronzeIIIRating()
        {
            LeagueSummoner summoner = GetSummonerHelper("Bronze", "III", 0);

            int rating = _balancingService.GetRating(summoner);

            rating.Should().Be(200);
        }

        [Test]
        public void TestBronzeIIRating()
        {
            LeagueSummoner summoner = GetSummonerHelper("Bronze", "II", 0);

            int rating = _balancingService.GetRating(summoner);

            rating.Should().Be(300);
        }

        [Test]
        public void TestBronzeIRating()
        {
            LeagueSummoner summoner = GetSummonerHelper("Bronze", "I", 0);

            int rating = _balancingService.GetRating(summoner);

            rating.Should().Be(400);
        }

        private LeagueSummoner GetSummonerHelper(string tier, string division, int lp)
        {
            LeagueSummoner summoner = new LeagueSummoner
            {
                Tier = tier,
                Division = division,
                LeaguePoints = lp,
                Level = 30
            };

            return summoner;
        }
    }
}
