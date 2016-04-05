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

        private readonly int _verificationTokenLength = 8;

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

        public SummonerVerificationModel Add(int userId, SummonerModel summonerModel)
        {
            Summoner existingSummoner = _summonerRepository.Get(summonerModel.Name, summonerModel.Region);

            if (existingSummoner.IsVerified)
            {
                throw new BadRequestException("This League of Legends account has already been verified by somebody else.");
            }

            LeagueSummoner leagueSummoner = _apiService.GetSummoner(summonerModel.Region, summonerModel.Name);

            string verificationCode = _secureTokenGenerator.GenerateToken(_verificationTokenLength);

            Summoner summoner = new Summoner()
            {
                LeagueApiId = leagueSummoner.Id,
                Name = leagueSummoner.Name,
                UserId = userId,
                Region = _regionRepository.GetFromLeagueId(summonerModel.Region),
                VerificationCode = verificationCode,
                IsVerified = false
            };

            _summonerRepository.Add(summoner);

            return new SummonerVerificationModel()
            {
                Code = verificationCode,
                Summoner = _summonerModelMapper.ToModel(summoner)
            };
        }

        public void Verify(int userId, int summonerId)
        {
            Summoner summoner = _summonerRepository.Get(summonerId);

            if (summoner.IsVerified)
            {
                throw new BadRequestException("This League of Legends account has already been verified.");
            }

            bool verified = _apiService.ConfirmSummoner(summoner);

            if (!verified)
            {
                throw new BadRequestException("No runepage names matched the given code.");
            }

            summoner.IsVerified = true;
            summoner.VerificationCode = null;

            _summonerRepository.Update(summoner);
        }

        public void Delete(int userId, int summonerId)
        {
            Summoner summoner = _summonerRepository.Get(summonerId);

            _summonerRepository.Delete(summoner);
        }

        public SummonerVerificationModel GetVerification(int userId, int summonerId)
        {
            Summoner summoner = _summonerRepository.Get(summonerId);

            if (summoner.IsVerified)
            {
                throw new BadRequestException("This League of Legends account has already been verified.");
            }

            string verificationCode = _secureTokenGenerator.GenerateToken(_verificationTokenLength);

            summoner.VerificationCode = verificationCode;

            _summonerRepository.Update(summoner);

            return new SummonerVerificationModel()
            {
                Code = verificationCode,
                Summoner = _summonerModelMapper.ToModel(summoner)
            };
        }
    }
}
