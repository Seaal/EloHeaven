using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloHeaven.Entities
{
    public class Summoner
    {
        public int Id { get; set; }
        public long LeagueApiId { get; set; }
        public int UserId { get; set; }
        public int RegionId { get; set; }
        public string Name { get; set; }
        public bool IsVerified { get; set; }
        public string VerificationCode { get; set; }

        public Region Region { get; set; }
    }
}
