using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace ConsoleWinTask
{
    internal class Task
    {
        public class Task1 : IMenuItem
        {
            public string Name => "Задание 1: факториал числа через Patallel class";

            public void Execute()
            {

            }
        }
        public class Task2 : IMenuItem
        {
            public string Name => "Задание 2: Ожидание или принудительное завершение процесса";

            public void Execute()
            {
                Console.Write("Введите имя запускаемого процесса: ");
                string processName = Console.ReadLine();

                var process = System.Diagnostics.Process.Start(processName);

                Console.WriteLine("Нажмите 'W' для ожидания завершения или 'K' для завершения процесса.");
                var key = Console.ReadKey(intercept: true).Key;

                if (key == ConsoleKey.W)
                {
                    process.WaitForExit();
                    Console.WriteLine($"\nПроцесс завершен с кодом: {process.ExitCode}");
                }
                else if (key == ConsoleKey.K)
                {
                    process.Kill();
                    Console.WriteLine("\nПроцесс был завершен принудительно.");
                }
            }
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
