using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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
        List<Ships> ammuksetpl = new List<Ships>();
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
            ShipsCords();
            PcShips();
            while (true)
            {
                Board();
                Shoot();
                Console.ReadKey();
            }
        }

        private void Board()
        {
            Console.Clear();
            IntVector offset = new IntVector(30, 0);
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    Console.SetCursorPosition(x * 2, y);
                    Console.Write("X ");
                }
            }
            foreach (Ships player in ships)
            {
                Console.SetCursorPosition(player.Vector.x * 2, player.Vector.y);
                Console.Write("@");
            }
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    Console.SetCursorPosition(offset.x + x * 2, offset.y + y);
                    Console.Write("X");
                }
            }
            foreach (Ships enemy in pcships)
            {
                Console.SetCursorPosition(offset.x + enemy.Vector.x * 2, offset.y + enemy.Vector.y);
                Console.Write("@");
            }

            foreach (Ships ammukspl in ammuksetpl)
            {
                Console.SetCursorPosition(offset.x + ammukspl.Vector.x * 2, offset.y + ammukspl.Vector.y);
                Console.Write("Q");
            }
            Console.SetCursorPosition(0, 11);
        }
        public void Shoot()
        {
            bool flag = false;
            Console.WriteLine("Anna x koordinaatti 1-10 väliltä ammukselle: ");
            int.TryParse(Console.ReadLine(), out int xres);
            Console.WriteLine("Anna y koordinaatti 1-10 väliltä ammukselle: ");
            int.TryParse(Console.ReadLine(), out int yres);
            if ((xres < 1 || xres >= 10) && (yres < 1 || yres >= 10))
            {
                if (yres < 1 || yres >= 10)
                {
                    Console.WriteLine("Molemmat arvot ovat liian suuria tai liian pieniä");
                }
                else
                {
                    Console.WriteLine("X arvo on liian suuri tai liian pieni");
                }
            }
            else
            {
                foreach (Ships pship in pcships)
                {
                    if (pship.Vector.x == xres - 1 && pship.Vector.y == yres - 1)
                    {
                        flag = true;
                    }
                }
                if (flag)
                {
                    Console.WriteLine("Osuit.");
                }
                else
                {
                    Console.WriteLine("Ohi.");
                }
                Ships ammuks = new Ships(xres - 1, yres - 1);
                ammuksetpl.Add(ammuks);
            }
        }

        private void PcShips()
        {
            Random rnd = new Random();
            for (int h = 0; h < 5; h++)
            {
                int x1 = rnd.Next(0, 9), y1 = rnd.Next(0, 9);
                if (ships.Count == 0)
                {
                    Ships pcShipss = new Ships(x1, y1);
                    pcships.Add(pcShipss);
                }
                else
                {
                    int o = 0;
                    foreach (Ships shp in ships)
                    {
                        if (shp.Vector.x == x1 && shp.Vector.y == y1)
                        {
                            h--;
                            o = 0;
                        }
                        else
                        {
                            o++;
                        }
                    }
                    if (o > 0)
                    {
                        Ships pcShipss = new Ships(x1, y1);
                        pcships.Add(pcShipss);
                    }
                }
            }
        }

        private void ShipsCords()
        {
            for (int k = 0; k < 5; k++)
            {
                Console.WriteLine("Anna luku 1-10 välillä" + "\n");
                Console.Write("Anna x cordinaatti: ");
                int.TryParse(Console.ReadLine(), out int x);
                Console.Write("\n" + "Anna y cordinaatti: ");
                int.TryParse(Console.ReadLine(), out int y);
                if ((x < 1 || x >= 10) && (y < 1 || y >= 10))
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
                    Ships shipsi;
                    if (ships.Count == 0)
                    {
                        Console.Clear();
                        shipsi = new Ships(x - 1, y - 1);
                        ships.Add(shipsi);
                    }
                    else
                    {
                        int g = 0;
                        foreach (Ships shp in ships)
                        {
                            if (shp.Vector.x + 1 == x && shp.Vector.y + 1 == y)
                            {
                                Console.Clear();
                                k--;
                                g = 0;
                                Console.WriteLine("Tämä koordinaatti löytyy jo ");
                            }
                            else
                            {
                                g++;
                            }
                        }
                        if (g > 0)
                        {
                            Console.Clear();
                            shipsi = new Ships(x - 1, y - 1);
                            ships.Add(shipsi);
                        }
                    }

                }

                if (ships.Count == 5)
                {
                    break;
                }
            }
        }
    }
}
