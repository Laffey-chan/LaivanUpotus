using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaivanUpotus
{
    class GameHandler
    {
        public Player test = new Player();
        public void Save()
        {
            string path = ".\\MyTest.txt";
            try
            {

                using (FileStream fs = File.Create(path))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(test.ToString());

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
            string path = ".\\MyTest.txt";
            try
            {

                using (FileStream fs = File.Create(path))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(test.ToString());

                    fs.Write(info, 0, info.Length);
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void Load()
        {
            string path = ".\\MyTest.txt";

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
                    test.Xp = x;
                    test.WinLoss = w;
                    test.Shoot = s;
                    test.Sink = si;
                    test.Earnings = ea;
                    fs.Close();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
