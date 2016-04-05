using System;
using System.Collections.Generic;
using System.Linq;
using EloHeaven.Data;
using EloHeaven.Entities;
using EloHeaven.Infrastructure.Exceptions;
using EloHeaven.Logic;
using EloHeaven.Logic.LeagueApi;

namespace EloHeaven.Services.Logic.Account.Summoners
{
    public class SummonerService : ISummonerService
    {
        private readonly ISummonerRepository _summonerRepository;
        private readonly IRegionRepository _regionRepository;
        private readonly ILeagueApiService _apiService;
        private readonly IModelMapper<Summoner, SummonerModel> _summonerModelMapper;
        private readonly ISecureTokenGenerator _secureTokenGenerator;

        private readonly int _confirmationTokenLength = 8;

        public SummonerService(ISummonerRepository summonerRepository, ILeagueApiService apiService, IRegionRepository regionRepository, IModelMapper<Summoner, SummonerModel> summonerModelMapper, ISecureTokenGenerator secureTokenGenerator)
        {
            _summonerRepository = summonerRepository;
            _apiService = apiService;
            _regionRepository = regionRepository;
            _summonerModelMapper = summonerModelMapper;
            _secureTokenGenerator = secureTokenGenerator;
        }

        public IEnumerable<SummonerModel> GetAllForUser(int userId)
        {
            IEnumerable<Summoner> summoners = _summonerRepository.GetForUser(userId);

            return summoners.Select(_summonerModelMapper.ToModel).ToList();
        }

        public SummonerConfirmationModel Add(int userId, SummonerModel summonerModel)
        {
            Summoner existingSummoner = _summonerRepository.Get(summonerModel.Name, summonerModel.Region);

            if (existingSummoner.IsConfirmed)
            {
                throw new BadRequestException("This League of Legends account has already been confirmed by somebody else.");
            }

            LeagueSummoner leagueSummoner = _apiService.GetSummoner(summonerModel.Region, summonerModel.Name);

            string confirmationCode = _secureTokenGenerator.GenerateToken(_confirmationTokenLength);

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

        public void Confirm(int userId, int summonerId)
        {
            Summoner summoner = _summonerRepository.Get(summonerId);

            if (summoner.IsConfirmed)
            {
                throw new BadRequestException("This League of Legends account has already been confirmed.");
            }

            bool confirmed = _apiService.ConfirmSummoner(summoner);

            if (!confirmed)
            {
                throw new BadRequestException("No runepage names matched the given code.");
            }

            summoner.IsConfirmed = true;
            summoner.ConfirmationCode = null;

            _summonerRepository.Update(summoner);
        }

        public void Delete(int userId, int summonerId)
        {
            Summoner summoner = _summonerRepository.Get(summonerId);

            _summonerRepository.Delete(summoner);
        }

        public SummonerConfirmationModel GetConfirmation(int userId, int summonerId)
        {
            Summoner summoner = _summonerRepository.Get(summonerId);

            if (summoner.IsConfirmed)
            {
                throw new BadRequestException("This League of Legends account has already been confirmed.");
            }

            string confirmationCode = _secureTokenGenerator.GenerateToken(_confirmationTokenLength);

            summoner.ConfirmationCode = confirmationCode;

            _summonerRepository.Update(summoner);

            return new SummonerConfirmationModel()
            {
                Code = confirmationCode,
                Summoner = _summonerModelMapper.ToModel(summoner)
            };
        }
    }
}
