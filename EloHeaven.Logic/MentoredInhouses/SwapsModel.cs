using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloHeaven.Logic.MentoredInhouses
{
    public class SwapsModel
    {
        public int RatingDifference { get; set; }
        public ICollection<PlayerModel> BlueSwaps { get; set; }
        public ICollection<PlayerModel> RedSwaps { get; set; }
    }
}
