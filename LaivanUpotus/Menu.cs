using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaivanUpotus
{
    class Menu
    {
        private string text;
        public int Value;
        private ConsoleKeyInfo cki;
        public void Start()
        {
            text = "1. Aloita uusi peli \n2. Jatka olevaa peliä";
            while (true)
            {
                Console.WriteLine(text);
                cki = Console.ReadKey(true);
                switch (cki.Key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine("hkgl");
                        break;
                    case ConsoleKey.D2:
                        Value = 2;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Paina luvullista näppäintä");
                        break;
                }

                if (cki.Key == ConsoleKey.D1 || cki.Key == ConsoleKey.D2)
                {
                    break;
                }
            }
        }
        public int Multi(bool canCancel, params string[] options)
        {
            const int startX = 0;
            const int startY = 0;
            const int optionsPerLine = 1;
            const int spacingPerLine = 14;

            int currentSelection = 0;

            ConsoleKey key;

            Console.CursorVisible = false;

            do
            {
                Console.Clear();

                for (int i = 0; i < options.Length; i++)
                {
                    Console.SetCursorPosition(startX + (i % optionsPerLine) * spacingPerLine, startY + i / optionsPerLine);

                    if (i == currentSelection)
                        Console.ForegroundColor = ConsoleColor.Red;

                    Console.Write(options[i]);
                    Console.ResetColor();
                }

                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                    {
                        if (currentSelection >= optionsPerLine)
                            currentSelection -= optionsPerLine;
                        break;
                    }
                    case ConsoleKey.DownArrow:
                    {
                        if (currentSelection + optionsPerLine < options.Length)
                            currentSelection += optionsPerLine;
                        break;
                    }
                    case ConsoleKey.Escape:
                    {
                        if (canCancel)
                            return -1;
                        break;
                    }
                }
            } while (key != ConsoleKey.Enter);

            Console.CursorVisible = true;

            return currentSelection;
        }
    }
}
