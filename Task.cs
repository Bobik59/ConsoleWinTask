using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace ConsoleWinTask
{
    internal class Tasks
    {
        public class Task1 : IMenuItem
        {
            public string Name => "Задание 1, 2: факториал числа через Patallel class";

            public void Execute()
            {
                Console.WriteLine("число для подсчета");
                int a = int.Parse(Console.ReadLine());
                Parallel.Invoke(
                    () => PrintFact(a),
                    () => PrintSumDigits(a),
                    () => PrintCountDigits(a)
                    );
            }

            public static void PrintFact(int a)
            {

                Console.WriteLine($"факториал: {Fact(a)}");
            }

            public static void PrintSumDigits(int a)
            {
                Console.WriteLine($"summa: {SumDigits(a)}");
            }

            public static void PrintCountDigits(int a)
            {
                Console.WriteLine($"чисел в числе: {CountDigits(a)}");
            }

            static int CountDigits(int number)
            {
                int count = 0;
                number = Math.Abs(number);
                while (number > 0)
                {
                    count++;
                    number /= 10;
                }
                return count;
            }

            static int SumDigits(int number)
            {
                int sum = 0;
                number = Math.Abs(number);
                while (number > 0)
                {
                    sum += number % 10;
                    number /= 10;
                }
                return sum;
            }


            public static long Fact(long n)
            {
                if (n == 0)
                    return 1;
                else
                    return n * Fact(n - 1);
            }
        }
        public class Task2 : IMenuItem
        {
            public string Name => "Задание 3: таблица умножения";

            public void Execute()
            {
                List<int> list = new List<int>();
                Console.WriteLine("Введите даипозон:");
                Console.Write("1 число:");
                int num1 = int.Parse(Console.ReadLine());
                Console.Write("2 число:");
                int num2 = int.Parse(Console.ReadLine());

                for(int i = num1; i < num2 + 1; i++)
                {
                    list.Add(i);
                }


                Parallel.ForEach(list, item =>
                {
                    Multiplikationstabelle(item);
                });
            }

            static void Multiplikationstabelle(int item)
            {
                for(int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"{item} * {i} = {item * i}");
                }
                Console.WriteLine();
            }
        }
    }
}
