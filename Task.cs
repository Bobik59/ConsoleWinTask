using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections;


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
            static SortedList<int, List<string>> sortedList = new SortedList<int, List<string>>();

            public string Name => "Задание 3: таблица умножения";

            public void Execute()
            {
                Console.WriteLine("Введите даипозон:");
                Console.Write("1 число:");
                int num1 = int.Parse(Console.ReadLine());
                Console.Write("2 число:");
                int num2 = int.Parse(Console.ReadLine());



                Parallel.For(num1, num2 + 1, item =>
                {
                    List<string> table = Multiplikationstabelle(item);
                    lock (sortedList)
                    {
                        sortedList.Add(item, table);
                    }
                });

                WriteFile("C:\\Users\\top_acdemy_student\\Desktop\\таблица умн.txt");

            }

            static void WriteFile(string Path)
            {
                using (StreamWriter writer = new StreamWriter(Path))
                {
                    foreach (var entry in sortedList)
                    {
                        writer.Write($"Key {entry.Key}: ");
                        writer.WriteLine(string.Join(", ", entry.Value));
                    }
                }
            }

            static List<string> Multiplikationstabelle(int item)
            {
                List<string> table = new List<string>();
                for (int i = 1; i <= 10; i++)
                {
                    table.Add($"{item} * {i} = {item * i}");
                }
                return table;
            }
        }
    }
}
