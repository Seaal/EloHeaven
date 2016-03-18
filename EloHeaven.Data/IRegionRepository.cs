using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloHeaven.Entities;

namespace EloHeaven.Data
{
    public interface IRegionRepository
    {
        IEnumerable<Region> GetAll();
    }
}
