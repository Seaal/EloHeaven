using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloHeaven.Logic
{
    public interface ISecureTokenGenerator
    {
        string GenerateToken(int length);
    }
}
