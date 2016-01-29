using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloHeaven.Logic.LeagueApi.DTOs
{
    public class SummonerDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int SummonerLevel { get; set; }
    }
}
