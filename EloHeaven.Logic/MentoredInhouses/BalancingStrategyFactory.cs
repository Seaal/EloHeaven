using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloHeaven.Logic.MentoredInhouses
{
    public enum BalancingStrategy
    {
        BruteForce
    }

    public class BalancingStrategyFactory
    {
        public IBalancingStrategy Make(BalancingStrategy balancingStrategy)
        {
            switch (balancingStrategy)
            {
                case BalancingStrategy.BruteForce:
                    return new BruteForceBalancingStrategy();
                default:
                    throw new ArgumentOutOfRangeException(nameof(balancingStrategy), balancingStrategy, null);
            }
        }
    }
}
