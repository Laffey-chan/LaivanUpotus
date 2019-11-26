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
    }
}
