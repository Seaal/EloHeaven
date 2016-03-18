using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloHeaven.Entities
{
    public class Summoner
    {
        public int Id { get; set; }
        public int LeagueApiId { get; set; }
        public Guid UserId { get; set; }
        public int RegionId { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }

        public Region Region { get; set; }
    }
}
