using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EloHeaven.Logic
{
    public class SecureTokenGenerator : ISecureTokenGenerator
    {
        public string GenerateToken(int length)
        {
            using (RandomNumberGenerator rng = new RNGCryptoServiceProvider())
            {
                int numOfBytes = (int)Math.Ceiling(length * 3.0 / 4);

                byte[] tokenData = new byte[numOfBytes];
                rng.GetBytes(tokenData);

                return Convert.ToBase64String(tokenData);
            }
        }
    }
}
