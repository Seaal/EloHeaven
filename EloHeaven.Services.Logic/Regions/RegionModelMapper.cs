using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloHeaven.Entities;
using EloHeaven.Logic;

namespace EloHeaven.Services.Logic.Regions
{
    public class RegionModelMapper : IModelMapper<Region, RegionModel>
    {
        public Region ToEntity(RegionModel model)
        {
            throw new NotImplementedException();
        }

        public RegionModel ToModel(Region entity)
        {
            return new RegionModel()
            {
                Id = entity.LeagueApiId,
                Name = entity.LongName
            };
        }
    }
}
