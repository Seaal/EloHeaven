using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloHeaven.Logic.LeagueApi
{
    public class LeagueSummoner
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public string Tier { get; set; }
        public string Division { get; set; }
        public int LeaguePoints { get; set; }
    }
}
