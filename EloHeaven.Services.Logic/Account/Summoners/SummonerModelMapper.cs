using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloHeaven.Entities;
using EloHeaven.Logic;
using EloHeaven.Services.Logic.Regions;

namespace EloHeaven.Services.Logic.Account.Summoners
{
    public class SummonerModelMapper : IModelMapper<Summoner, SummonerModel>
    {
        private readonly IModelMapper<Region, RegionModel> _regionModelMapper;

        public SummonerModelMapper(IModelMapper<Region, RegionModel> regionModelMapper)
        {
            _regionModelMapper = regionModelMapper;
        }

        public Summoner ToEntity(SummonerModel model)
        {
            throw new NotImplementedException();
        }

        public SummonerModel ToModel(Summoner entity)
        {
            return new SummonerModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Region = _regionModelMapper.ToModel(entity.Region),
                IsVerified = entity.IsVerified
            };
        }
    }
}
