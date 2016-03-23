using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloHeaven.Entities;

namespace EloHeaven.Data
{
    public class RegionRepository : IRegionRepository
    {
        public IEnumerable<Region> GetAll()
        {
            return new[]
            {
                new Region() {Id = 1, LeagueApiId = "NA", LongName = "North America"},
                new Region() {Id = 2, LeagueApiId = "EUW1", LongName = "Europe - West"},
                new Region() {Id = 3, LeagueApiId = "EUNE", LongName = "Europe - North & East"},
            };
        }

        public Region GetFromLeagueId(string regionId)
        {
            return new Region() {Id = 1, LeagueApiId = "NA", LongName = "North America"};
        }
    }
}
