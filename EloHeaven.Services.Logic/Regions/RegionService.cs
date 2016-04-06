using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloHeaven.Data;
using EloHeaven.Entities;
using EloHeaven.Logic;

namespace EloHeaven.Services.Logic.Regions
{
    public class RegionService : IRegionService
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IModelMapper<Region, RegionModel> _regionModelMapper; 

        public RegionService(IRegionRepository regionRepository, IModelMapper<Region, RegionModel> regionModelMapper)
        {
            _regionRepository = regionRepository;
            _regionModelMapper = regionModelMapper;
        }

        public IEnumerable<RegionModel> GetAll()
        {
            return _regionRepository.GetAll().Select(_regionModelMapper.ToModel).ToList();
        }
    }
}
