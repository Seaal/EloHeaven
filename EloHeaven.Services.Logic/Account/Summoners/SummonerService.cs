using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloHeaven.Data;
using EloHeaven.Entities;
using EloHeaven.Infrastructure.Exceptions;
using EloHeaven.Logic.LeagueApi;

namespace EloHeaven.Services.Logic.Account.Summoners
{
    public class SummonerService : ISummonerService
    {
        private readonly ISummonerRepository _summonerRepository;
        private readonly IRegionRepository _regionRepository;
        private readonly ILeagueApiService _apiService;
        private readonly IModelMapper<Summoner, SummonerModel> _summonerModelMapper; 

        public SummonerService(ISummonerRepository summonerRepository, ILeagueApiService apiService, IRegionRepository regionRepository, IModelMapper<Summoner, SummonerModel> summonerModelMapper)
        {
            _summonerRepository = summonerRepository;
            _apiService = apiService;
            _regionRepository = regionRepository;
            _summonerModelMapper = summonerModelMapper;
        }

        public IEnumerable<SummonerModel> GetAllForUser(Guid userId)
        {
            IEnumerable<Summoner> summoners = _summonerRepository.GetForUser(userId);

            return summoners.Select(_summonerModelMapper.ToModel).ToList();
        }

        public SummonerConfirmationModel Add(Guid userId, SummonerModel summonerModel)
        {
            LeagueSummoner leagueSummoner = _apiService.GetSummoner(summonerModel.Region, summonerModel.Name);

            string confirmationCode = "test";

            Summoner summoner = new Summoner()
            {
                LeagueApiId = leagueSummoner.Id,
                Name = leagueSummoner.Name,
                UserId = userId,
                Region = _regionRepository.GetFromLeagueId(summonerModel.Region),
                ConfirmationCode = confirmationCode,
                IsConfirmed = false
            };

            _summonerRepository.Add(summoner);

            return new SummonerConfirmationModel()
            {
                Code = confirmationCode,
                Summoner = _summonerModelMapper.ToModel(summoner)
            };
        }

        public void Confirm(Guid userId, int summonerId)
        {
            Summoner summoner = _summonerRepository.Get(summonerId);

            if (summoner.IsConfirmed)
            {
                throw new BadRequestException("This summoner has already been confirmed");
            }

            bool confirmed = _apiService.ConfirmSummoner(summoner);

            if (confirmed)
            {
                summoner.IsConfirmed = true;
                summoner.ConfirmationCode = null;
            }

            _summonerRepository.Update(summoner);
        }
    }
}
