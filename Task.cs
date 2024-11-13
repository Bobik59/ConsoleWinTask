using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Linq.Expressions;

namespace ConsoleWinTask
{
    internal class Tasks
    {
        public class Task1 : IMenuItem
        {
            public string Name => "1. Вывод времение и даты";

            public void Execute()
            {
                var task1 = new Task(() => PrintDateTime("Start"));
                task1.Start();

                var task2 = Task.Run(() => PrintDateTime("Run"));

                var task3 = Task.Factory.StartNew(() => PrintDateTime("Task.Factory.StartNew"));
            }

            static void PrintDateTime(string str)
            {
                Console.WriteLine($"Thread {str}: {DateTime.Now}");
            }
        }
        public class Task2 : IMenuItem
        {
            public string Name => "2: простые числа до 1000";

            public async void Execute()
            {

                Console.WriteLine("Введите 1 число");
                int a = Int32.Parse(Console.ReadLine());

                Console.WriteLine("Введите 2 число");
                int b = Int32.Parse(Console.ReadLine());

                var task = new Task<List<int>>(() => addIsPrimeList(a, b));
                var task1 = task.ContinueWith(t => PrintPrime(t.Result));

                task.Start();


                await task;
                Console.WriteLine($"количество простых чисел: {task.Result.Count}");
            }

            public static bool IsPrime(int number)
            {
                for (int i = 2; i < number; i++)
                {
                    if (number % i == 0)
                        return false;
                }
                return true;
            }

            static List<int> addIsPrimeList(int a, int b)
            {
                List<int> values = new List<int>();
                for (int i = a; i <= b; i++)
                {
                    if (IsPrime(i))
                    {
                        values.Add(i);
                    }
                }

                return values;
            }

            static void PrintPrime(List<int> values)
            {
                foreach (int i in values)
                {
                    Console.WriteLine(i);
                }
            }
        }

        public class Task3 : IMenuItem
        {

            static List<int> ints = new List<int>();
            public string Name => "3: вывод ■ Минимум ■ Максимум ■ Среднее ■ Сумму.";

            public void Execute()
            {
                CreateList();

                Task[] tasks =
                {
                    new Task(FindMin),
                    new Task(FindMax),
                    new Task(FindAverage),
                    new Task(FindSum),

                };

                foreach (var item in tasks)
                    item.Start();
            }

            static void FindMin()
            {
                Console.WriteLine($"Min: {ints.Min()}");
            }
            static void FindMax()
            {
                Console.WriteLine($"Max: {ints.Max()}");
            }

            static void FindAverage()
            {
                Console.WriteLine($"Avg: {ints.Average()}");
            }

            static void FindSum()
            {
                Console.WriteLine($"Sum: {ints.Sum()}");
            }

            static void CreateList()
            {
                Console.Write("Введите целое число больше нуля: ");
                int num = int.Parse(Console.ReadLine());

                Random rnd = new Random();
                for (int i = 0; i < num; i++)
                    ints.Add(rnd.Next(0, 100));
            }

        }

        public class Task4 : IMenuItem
        {
            static int[] mass;
            public string Name => "4. работа с массивом";

            public async void Execute()
            {
                CreateMass();

                var task = new Task(() => DisctitMass());
                var task1 = task.ContinueWith(t => SortMass());
                var task2 = task1.ContinueWith(t => Binar());

                task.Start();

                task2.Wait();
            }
            static void SortMass()
            {
                Array.Sort(mass);
            }

            static int[] DisctitMass()
            {
                return mass.Distinct().ToArray();
            }

            static void Binar()
            {
                Console.WriteLine("число для поиска");
                int k = int.Parse(Console.ReadLine());
                int u = mass.ToList().BinarySearch(k);
                Console.WriteLine($"место: {u}");
            }
            static void CreateMass()
            {
                Console.Write("Введите целое число больше нуля: ");
                int num = int.Parse(Console.ReadLine());
                mass = new int[num];
                Random rnd = new Random();
                for (int i = 0; i < num; i++)
                    mass[i] = rnd.Next(0, 100);
            }
        }
    }
}
