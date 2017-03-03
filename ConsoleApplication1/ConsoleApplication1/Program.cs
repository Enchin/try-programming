using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(65, 10);
            Console.SetBufferSize(65, 10);
            // установка зеленого цвета шрифта
            Console.ForegroundColor = ConsoleColor.Cyan;

            try
            {
                do
                {
                    Console.WriteLine("Введите первое число");
                    int num1 = Int32.Parse(Console.ReadLine());

                    Console.WriteLine("Введите второе число");
                    int num2 = Int32.Parse(Console.ReadLine());

                    Console.WriteLine("Сумма чисел {0} и {1} равна {2}", num1, num2, num1 + num2);

                    Console.WriteLine("Для выхода нажмите Escape; для продолжения - любую другую клавишу");
                }
                while (Console.ReadKey().Key != ConsoleKey.Escape);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
}
