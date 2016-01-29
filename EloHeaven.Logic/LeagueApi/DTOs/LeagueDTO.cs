using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloHeaven.Logic.LeagueApi.DTOs
{
    public class LeagueDTO
    {
        public string Queue { get; set; }
        public string Tier { get; set; }
        public ICollection<LeagueEntryDTO> Entries { get; set; }
    }
}
