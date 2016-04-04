using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloHeaven.Entities;

namespace EloHeaven.Data
{
    public class SummonerRepository : ISummonerRepository
    {
        public IEnumerable<Summoner> GetForUser(int userId)
        {
            Region na = new Region() {Id = 1, LeagueApiId = "NA", LongName = "North America"};

            return new[]
            {
                new Summoner() { Id = 1, LeagueApiId = 197348, Name = "Seaal", Region = na, RegionId = 1, UserId = 1, IsConfirmed = false, ConfirmationCode = "Jungle" },
                new Summoner() { Id = 2, LeagueApiId = 19311231, Name = "IcanhasSmurf", Region = na, RegionId = 1, UserId = 1, IsConfirmed = false },
            };
        }

        public void Add(Summoner summoner)
        {
            summoner.Id = 1;
        }

        public Summoner Get(int summonerId)
        {
            return GetForUser(1).First();
        }

        public Summoner Get(string name, string region)
        {
            return GetForUser(1).First();
        }

        public void Update(Summoner summoner)
        {
        }

        public void Delete(Summoner summoner)
        {
        }
    }
}
