using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloHeaven.Data;
using EloHeaven.Entities;

namespace EloHeaven.Services.Logic.Account
{
    public class SummonerService : ISummonerService
    {
        private readonly ISummonerRepository _summonerRepository;

        public SummonerService(ISummonerRepository summonerRepository)
        {
            _summonerRepository = summonerRepository;
        }

        public IEnumerable<SummonerModel> GetAllForUser(Guid userId)
        {
            IEnumerable<Summoner> summoners = _summonerRepository.GetForUser(userId);

            return summoners.Select(s => new SummonerModel()
            {
                Name = s.Name,
                Region = s.Region.LeagueApiId
            }).ToList();
        }
    }
}
