using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ackermansAlg
{
    class Program
    {
        static long ack(long m, long n)
        {
            long ans;
            if (m == 0) ans = n + 1;
            else if (n == 0) ans = ack(m - 1, 1);
            else ans = ack(m - 1, ack(m, n - 1));
            return ans;
        }

        static void Main(string[] args)
        {
            for (var x = 0; x <= 5; x++)
            {
                for (var y = 0; y <= 5; y++)
                {
                    Console.WriteLine($"{x} {y} gives {ack(x, y)}");
                }
            }

        }
    }
}
