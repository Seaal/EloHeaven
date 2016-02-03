using System.Collections.Generic;

namespace EloHeaven.Logic.MentoredInhouses
{
    public class InhouseModel
    {
        public ICollection<PlayerModel> BlueTeam { get; set; }
        public ICollection<PlayerModel> RedTeam { get; set; }
    }
}
