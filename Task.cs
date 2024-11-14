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
            

        }

        public class Task3 : IMenuItem
        {
            public string Name => "Задание 3: Запуск процесса с аргументами для операции";

            public void Execute()
            {
                Console.Write("Введите имя запускаемого процесса: ");
                string processName = Console.ReadLine();
                Console.Write("Введите первое число: ");
                string number1 = Console.ReadLine();
                Console.Write("Введите второе число: ");
                string number2 = Console.ReadLine();
                Console.Write("Введите операцию (+, -, *, /): ");
                string operation = Console.ReadLine();

                var process = System.Diagnostics.Process.Start(processName, $"{number1} {number2} {operation}");
                process.WaitForExit();
            }
        }

        public class Task4 : IMenuItem
        {
            public string Name => "Задание 4: Поиск слова в файле";

            public void Execute()
            {
                Console.Write("Введите имя запускаемого процесса: ");
                string processName = Console.ReadLine();
                Console.Write("Введите путь к файлу: ");
                string filePath = Console.ReadLine();
                Console.Write("Введите слово для поиска: ");
                string word = Console.ReadLine();

                var process = System.Diagnostics.Process.Start(processName, $"{filePath} {word}");
                process.WaitForExit();
            }
        }
    }
}
