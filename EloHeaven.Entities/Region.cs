using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloHeaven.Entities
{
    public class Region
    {
        public int Id { get; set; }
        public string LeagueApiId { get; set; }
        public string LongName { get; set; }
        public int ListOrder { get; set; }
    }
}
