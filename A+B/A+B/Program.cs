using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_B
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Сложение двух чисел");
            Console.WriteLine("Введите первое число");
            string a = Console.ReadLine();
            int c = int.Parse(a);
            Console.WriteLine("Введите второе число");
            string b = Console.ReadLine();
            int d = int.Parse(b);
            int s;
            //Console.ReadLine(a, b);
            s = c + d;
            Console.WriteLine("Результат" + ": " + s);
            Console.ReadLine();

        }
    }
}
