using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWinTask
{
    public interface IMenuItem
    {
        string Name { get; }
        void Execute();
    }

    public class Menu : IMenuItem
    {
        public string Name { get; }
        private readonly List<IMenuItem> _menuItems;

        public Menu(string name, List<IMenuItem> menuItems)
        {
            Name = name;
            _menuItems = menuItems;
        }

        public void Execute()
        {
            ShowMenu(_menuItems);
        }

        private void ShowMenu(List<IMenuItem> menuItems)
        {
            int selectedIndex = 0;
            int previousIndex = -1;
            int maxLength = menuItems.Max(item => item.Name.Length) + 4;

            Console.Clear();
            Console.CursorVisible = false;
            DrawMenu(menuItems, selectedIndex, maxLength, fullDraw: true);

            while (true)
            {
                var key = Console.ReadKey(intercept: true).Key;

                if (key == ConsoleKey.UpArrow)
                {
                    previousIndex = selectedIndex;
                    selectedIndex = (selectedIndex > 0) ? selectedIndex - 1 : menuItems.Count - 1;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    previousIndex = selectedIndex;
                    selectedIndex = (selectedIndex < menuItems.Count - 1) ? selectedIndex + 1 : 0;
                }
                else if (key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    menuItems[selectedIndex].Execute();
                    Console.WriteLine("\nPress any key to return to the menu...");
                    Console.ReadKey();
                    Console.Clear();
                    DrawMenu(menuItems, selectedIndex, maxLength, fullDraw: true);
                    continue;
                }
                else if (key == ConsoleKey.Escape)
                {
                    break;
                }

                if (previousIndex != selectedIndex)
                {
                    DrawMenu(menuItems, selectedIndex, maxLength, fullDraw: false, previousIndex);
                }
            }

            Console.CursorVisible = true;
        }

        private void DrawMenu(List<IMenuItem> menuItems, int selectedIndex, int maxLength, bool fullDraw, int previousIndex = -1)
        {
            if (fullDraw)
            {
                Console.WriteLine("+" + new string('-', maxLength) + "+");
                for (int i = 0; i < menuItems.Count; i++)
                {
                    DrawMenuItem(menuItems[i], i, selectedIndex, maxLength);
                }
                Console.WriteLine("+" + new string('-', maxLength) + "+");
                Console.WriteLine("Use arrow keys to navigate, Enter to select, Esc to exit.");
            }
            else
            {
                if (previousIndex >= 0)
                {
                    Console.SetCursorPosition(0, previousIndex + 1);
                    DrawMenuItem(menuItems[previousIndex], previousIndex, selectedIndex, maxLength);
                }
                Console.SetCursorPosition(0, selectedIndex + 1);
                DrawMenuItem(menuItems[selectedIndex], selectedIndex, selectedIndex, maxLength);
            }
        }

        private void DrawMenuItem(IMenuItem item, int index, int selectedIndex, int maxLength)
        {
            string prefix = (index == selectedIndex) ? "* " : "  ";
            Console.WriteLine($"| {prefix}{item.Name.PadRight(maxLength - 4)} |");
        }
    }
}
