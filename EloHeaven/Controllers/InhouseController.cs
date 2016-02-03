using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using EloHeaven.Logic.MentoredInhouses;
using EloHeaven.Services.Logic.Inhouses;

namespace EloHeaven.Controllers
{
    public class InhouseController : ApiController
    {
        private readonly IInhouseService _inhouseService;

        public InhouseController(IInhouseService inhouseService)
        {
            _inhouseService = inhouseService;
        }

        [Route("api/inhouse/player/{playerName}")]
        public PlayerModel GetPlayer(string playerName)
        {
            return _inhouseService.GetPlayer(playerName);
        }

        [Route("api/inhouse/balance")]
        public SwapsModel BalanceInhouse(InhouseModel inhouseModel)
        {
            return _inhouseService.BalanceTeams(inhouseModel);
        }
    }
}