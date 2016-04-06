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
        IEnumerable<Summoner> GetForUser(int userId);
        void Add(Summoner summoner);
        Summoner Get(int summonerId);
        Summoner Get(string name, string region);
        void Update(Summoner summoner);
        void Delete(Summoner summoner);
    }
}
