using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace summ_n_raz
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("От от 1 до скольки суммировать");
            string a = Console.ReadLine();
            int c = int.Parse(a);
            int rezultat = 0;
            int zero = 0;
            while (zero <= c)
            {
                rezultat = rezultat + zero;
                zero = zero + 1;
            }
            Console.WriteLine(rezultat);
            Console.ReadLine();
        }
    }
}
