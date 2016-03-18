using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloHeaven.Data;

namespace EloHeaven.Services.Logic.Regions
{
    public class RegionService : IRegionService
    {
        private readonly IRegionRepository _regionRepository;

        public RegionService(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }

        public IEnumerable<RegionModel> GetAll()
        {
            return _regionRepository.GetAll().Select(r => new RegionModel()
            {
                Id = r.LeagueApiId,
                Name = r.LongName
            }).ToList();
        }
    }
}
