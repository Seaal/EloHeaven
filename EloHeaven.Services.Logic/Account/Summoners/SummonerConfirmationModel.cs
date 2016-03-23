using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloHeaven.Services.Logic.Account.Summoners
{
    public class SummonerConfirmationModel
    {
        public string Code { get; set; }
        public SummonerModel Summoner { get; set; }
    }
}
