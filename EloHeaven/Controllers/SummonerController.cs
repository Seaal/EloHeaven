using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EloHeaven.Logic.LeagueApi.DTOs;
using EloHeaven.Services.Logic.Account;

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
    }
}