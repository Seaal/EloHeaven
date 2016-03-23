using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloHeaven.Entities;

namespace EloHeaven.Data
{
    public interface ISummonerRepository
    {
        IEnumerable<Summoner> GetForUser(Guid userId);
        void Add(Summoner summoner);
        Summoner Get(int summonerId);
        void Update(Summoner summoner);
    }
}
