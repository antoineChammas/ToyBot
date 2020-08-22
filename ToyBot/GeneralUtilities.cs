using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyBot
{
    public class GeneralUtilities
    {
        public static short Mod(short x, short m)
        {
            return (short)(((x % m) + m) % m);
        }

    }
}
