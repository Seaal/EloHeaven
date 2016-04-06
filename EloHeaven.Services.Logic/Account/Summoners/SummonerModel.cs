using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloHeaven.Logic;
using EloHeaven.Services.Logic.Regions;

namespace EloHeaven.Services.Logic.Account.Summoners
{
    public class SummonerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RegionModel Region { get; set; }
        public bool IsVerified { get; set; }
    }
}
