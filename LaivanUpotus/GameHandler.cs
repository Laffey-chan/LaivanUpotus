using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace LaivanUpotus
{
    class GameHandler
    {
        List<Ships> ships = new List<Ships>();
        List<Ships> pcships = new List<Ships>();
        string path = ".\\MyTest.txt";
        public Player test = new Player();
        public void Save()
        {
            //string path = ".\\MyTest.txt";
            try
            {

                using (FileStream fs = File.Create(path))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(test.ToString() + "\n" + test.Inv.ToString());
                    fs.Write(info, 0, info.Length);
                    Console.WriteLine("Peli tallennettu...");
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void NewPlayer(string name)
        {
            test.Name = name;
            //string path = ".\\MyTest.txt";
            try
            {

                using (FileStream fs = File.Create(path))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(test.ToString() + "\n" + test.Inv.ToString());

                    fs.Write(info, 0, info.Length);
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public int CheckFile()
        {
            int val = 0;
            if (File.Exists(path))
            {
                val++;
            }
            return val;
        }


        public void Load()
        {
            //string path = ".\\MyTest.txt";

            try
            {
                using (StreamReader fs = new StreamReader(path))
                {
                    test.Name = fs.ReadLine();
                    int.TryParse(fs.ReadLine(), out int x);
                    int.TryParse(fs.ReadLine(), out int w);
                    int.TryParse(fs.ReadLine(), out int s);
                    int.TryParse(fs.ReadLine(), out int si);
                    int.TryParse(fs.ReadLine(), out int ea);
                    int.TryParse(fs.ReadLine(), out int coi);
                    int.TryParse(fs.ReadLine(), out int ss);
                    int.TryParse(fs.ReadLine(), out int a);
                    test.Xp = x;
                    test.WinLoss = w;
                    test.Shoot = s;
                    test.Sink = si;
                    test.Earnings = ea;
                    test.Coins = coi;
                    test.Inv.S = ss;
                    test.Inv.A = a;
                    fs.Close();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void Battle()
        {
            for (int k = 0; k < 5; k++)
            {
                Console.Clear();
                Console.WriteLine("Anna luku 1-10 välillä" + "\n");
                Console.WriteLine("Anna x cordinaatti: ");
                int.TryParse(Console.ReadLine(), out int x);
                Console.WriteLine("Anna y cordinaatti: ");
                int.TryParse(Console.ReadLine(), out int y);
                if ((x < 0 || x >= 10) && (y < 0 || y >= 10))
                {
                    if (y < 1 || y >= 10)
                    {
                        Console.Clear();
                        Console.WriteLine("Molemmat arvot ovat liian suuria tai liian pieniä");
                        k--;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("X arvo on liian suuri tai liian pieni");
                        k--;
                    }
                }
                else
                {
                    Ships shipsi = new Ships(x-1, y-1);
                    ships.Add(shipsi);
                }
            }
            while (true)
            {
                Board();
                Console.ReadKey();
            }
        }

        private void Board()
        {
            List<int> shipsss = new List<int>();
            foreach (Ships shipsis in ships)
            {
                shipsss.Add(shipsis.Vector.x+shipsis.Vector.y*10);
            }
            for (int y =0;y<10;y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    
                    if (shipsss.Contains(x+y*10))
                    {
                        Console.Write("@ ");
                    }
                    else
                    {
                        Console.Write("X ");
                    }
                }
                Console.Write("\n");
            }
        }
    }
}
