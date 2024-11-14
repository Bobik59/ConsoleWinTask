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
            static CancellationTokenSource cts = new CancellationTokenSource();
            static CancellationToken token = cts.Token;
            public string Name => "Задание 1: Теория урока";

            public void Execute()
            {
                try
                {
                    var task = Task.Run(() => Print());

                    Thread.Sleep(1000);
                    cts.Cancel();
                    task.Wait();
                    cts.Dispose();
                }
                catch (Exception oc)
                {
                    Console.WriteLine(oc.Message);
                }
                finally
                {
                    cts.Dispose();
                }
            }

            static void Print()
            {
                for (int i = 0; i < 100; i++)
                {
                    if (token.IsCancellationRequested)
                        //return;
                        token.ThrowIfCancellationRequested(); // ошибку пробросили
                    Console.WriteLine($"Task! {Task.CurrentId} {i}");
                    Thread.Sleep(10);
                }
            }
        }
        public class Task2 : IMenuItem
        {
            public string Name => "Задание 2: class Parallel";

            public void Execute()
            {
                Parallel.Invoke(
                    () => { Console.WriteLine("Hello, World!"); },
                    () => Sum(5, 6),
                    Print
                    );


                Parallel.For(1, 16, x =>
                {
                    for (int i = 0; i < 100; i++)
                    {
                        Console.WriteLine(x);
                        Thread.Sleep(100);
                    }
                });

                Parallel.ForEach(new List<int> { 1, 2, 3, 4, 5 }, item =>
                {
                    PrintItem(item);
                });


            }

            static void PrintItem(int item)
            {
                Console.WriteLine($"Processing item: {item}");
            }

            static void Print(int a, ParallelLoopState parallelLoop)
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine($"Task! {Task.CurrentId} {i}");
                    Thread.Sleep(10);
                }
            }
            static void Sum(int u, int a)
            {
                Console.WriteLine($"{u} + {a} = {a + u}");
            }

        }
    }
}

