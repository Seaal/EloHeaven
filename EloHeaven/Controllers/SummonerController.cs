using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using EloHeaven.Services.Logic.Account.Summoners;

namespace EloHeaven.Controllers
{
    [RoutePrefix("api/account/{userId}/summoner")]
    public class SummonerController : ApiController
    {
        private readonly ISummonerService _summonerService;

        public SummonerController(ISummonerService summonerService)
        {
            _summonerService = summonerService;
        }

        [Route("")]
        public IEnumerable<SummonerModel> GetAll(Guid userId)
        {
            return _summonerService.GetAllForUser(userId);
        }

        [Route("")]
        public SummonerConfirmationModel Post(Guid userId, SummonerModel summonerModel)
        {
            return _summonerService.Add(userId, summonerModel);
        }

        [Route("{summonerId}/confirmation")]
        [HttpPost]
        public void Confirm(Guid userId, int summonerId)
        {
            _summonerService.Confirm(userId, summonerId);
        }
    }
}