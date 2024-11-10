using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleWinTask.Task;

namespace ConsoleWinTask
{
    public class Run
    {
        public static void Runing()
        {
            var menu = new Menu("Главное меню", new List<IMenuItem>
            {
                new Task1(),
                new Task2(),
                new Task3(),
                new Task4()
            });

            menu.Execute();

        }
    }
}
