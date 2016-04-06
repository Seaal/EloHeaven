using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using EloHeaven.Logic;
using EloHeaven.Services.Logic.Regions;

namespace EloHeaven.Controllers
{
    public class RegionController : ApiController
    {
        private readonly IRegionService _regionService;

        public RegionController(IRegionService regionService)
        {
            _regionService = regionService;
        }

        public IEnumerable<RegionModel> GetAll()
        {
            return _regionService.GetAll();
        } 
    }
}