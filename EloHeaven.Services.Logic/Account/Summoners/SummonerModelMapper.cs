using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloHeaven.Entities;

namespace EloHeaven.Services.Logic.Account.Summoners
{
    public class SummonerModelMapper : IModelMapper<Summoner, SummonerModel>
    {
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
                Region = entity.Region.LeagueApiId
            };
        }
    }
}
