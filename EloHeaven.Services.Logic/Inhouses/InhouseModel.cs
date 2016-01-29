using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloHeaven.Services.Logic.Inhouses
{
    public class InhouseModel
    {
        public ICollection<PlayerModel> BlueTeam { get; set; }
        public ICollection<PlayerModel> RedTeam { get; set; }
    }
}
