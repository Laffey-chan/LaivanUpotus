using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace LaivanUpotus
{
    class GameHandler
    {
        List<Ships> ships = new List<Ships>();
        List<Ships> pcships = new List<Ships>();
        List<Ships> ammuksetpl = new List<Ships>();
        List<Ships> ammuksetpc = new List<Ships>();
        string path = ".\\MyTest.txt";
        public Player test = new Player();
        public bool flag = false, first = false, flag2 = false, syöt = true;
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
                pcshoot();
                
            }
        }

        private void Checkships()
        {
            int amount = 0;
            foreach (Ships shps in ships)
            {
                if (shps.Destroy)
                {
                    amount++;
                }
            }

            if (amount == 5)
            {

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

            foreach (Ships ammks in ammuksetpc)
            {
                bool osuma = false;
                foreach (Ships playership in ships)
                {
                    if (ammks.Vector == playership.Vector)
                    {
                        osuma = true;
                    }
                }
                if (osuma)
                {
                    Console.SetCursorPosition(ammks.Vector.x * 2, ammks.Vector.y);
                    Console.Write("1");
                }
                else
                {
                    Console.SetCursorPosition(ammks.Vector.x * 2, ammks.Vector.y);
                    Console.Write("M");
                }
            }
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    Console.SetCursorPosition(offset.x + x * 2, offset.y + y);
                    Console.Write("X");
                }
            }
            foreach (Ships ammukspl in ammuksetpl)
            {
                bool osuma = false;
                foreach (Ships enemy in pcships)
                {
                    if (ammukspl.Vector == enemy.Vector)
                    {
                        osuma = true;
                    }
                }
                if (osuma)
                {
                    Console.SetCursorPosition(offset.x + ammukspl.Vector.x * 2, offset.y + ammukspl.Vector.y);
                    Console.Write("1");
                }
                else
                {
                    Console.SetCursorPosition(offset.x + ammukspl.Vector.x * 2, offset.y + ammukspl.Vector.y);
                    Console.Write("M");
                }
            }
            Console.SetCursorPosition(0, 10);
            if (first)
            {
                if (flag2)
                {
                    Console.WriteLine("Yritit ampua samaan koordinaattiin ");
                }
                else
                {
                    if (flag)
                    {
                        Console.WriteLine("Osuit.");
                    }
                    else
                    {
                        Console.WriteLine("Ohi.");
                    }
                }
            }
            first = true;
            Console.SetCursorPosition(0, 11);
        }
        public void Shoot()
        {
            IntVector test = new IntVector(0, 06);
            while (syöt)
            {
                Console.WriteLine("Anna x ja y koordinaatti 1-10 välillä: ");
                test = Asknum(Console.ReadLine(), Console.ReadLine());
            }
            syöt = true;
            foreach (Ships ammukS in ammuksetpl)
            {
                if (ammukS.Vector.x == test.x - 1 && ammukS.Vector.y == test.y - 1)
                {
                    flag2 = true;
                }
            }
            if (!flag2)
            {
                foreach (Ships pship in pcships)
                {
                    if (pship.Vector.x == test.x - 1 && pship.Vector.y == test.y - 1)
                    {
                        flag = true;
                    }
                }
                Ships ammuks = new Ships(test.x - 1, test.y - 1);
                ammuksetpl.Add(ammuks);
            }
        }

        public void pcshoot()
        {
            Random rn = new Random();
            int x2 = rn.Next(0, 9), y2 = rn.Next(0, 9);
            Ships ammk = new Ships(x2, y2);
            ammuksetpc.Add(ammk);
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
                if ((x < 1 || x >= 10) || (y < 1 || y >= 10))
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

        private IntVector Asknum(string xnum, string ynum)
        {
            int.TryParse(xnum, out int xres);
            int.TryParse(ynum, out int yres);
            if ((xres >= 1 && xres <= 10) && (yres >= 1 && yres <= 10))
            {
                syöt = false;
                return new IntVector(xres, yres);
            }
            else
            {
                return new IntVector(0, 0);
            }
        }
    }
}
