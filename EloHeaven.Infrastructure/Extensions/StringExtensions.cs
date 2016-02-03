using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloHeaven.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static string ToCapitalized(this string @string)
        {
            if (String.IsNullOrWhiteSpace(@string))
            {
                return @string;
            }

            char[] characters = @string.ToLowerInvariant().ToCharArray();

            characters[0] = Char.ToUpperInvariant(characters[0]);

            return new string(characters);
        }
    }
}
