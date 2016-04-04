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
        public IEnumerable<SummonerModel> GetAll(int userId)
        {
            return _summonerService.GetAllForUser(userId);
        }

        [Route("")]
        public SummonerConfirmationModel Post(int userId, SummonerModel summonerModel)
        {
            return _summonerService.Add(userId, summonerModel);
        }

        [Route("{summonerId}/confirmation")]
        [HttpPost]
        public void Confirm(int userId, int summonerId)
        {
            _summonerService.Confirm(userId, summonerId);
        }

        [Route("{summonerId}")]
        public void Delete(int userId, int summonerId)
        {
            _summonerService.Delete(userId, summonerId);
        }
    }
}