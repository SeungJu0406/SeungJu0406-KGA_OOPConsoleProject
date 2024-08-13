using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEternalReturn
{
    public class Util
    {
        public static Random random = new Random();
        public static int Random(int n, int m)
        {
            return random.Next(n, m+1);
        }
    }
}
