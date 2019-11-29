﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaivanUpotus
{
    class Program
    {
        static void Main()
        {
            Menu menu = new Menu();
            GameHandler game = new GameHandler();
            switch (menu.Multi(false, "Aloita uusi peli", "Lataa vanha tallennus"))
            {
                case 0:
                    switch (game.CheckFile())
                    {
                        case 0:
                            Console.Clear();
                            Console.WriteLine("Pelaajan nimi: ");
                            game.NewPlayer(Console.ReadLine());
                            break;
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Oletko varma että haluat aloittaa uuden");
                            switch (menu.Multi(false, "kyllä", "Ei, jatka vanhaa"))
                            {
                                case 0:
                                    Console.Clear();
                                    Console.WriteLine("Pelaajan nimi: ");
                                    game.NewPlayer(Console.ReadLine());
                                    break;
                                case 1:
                                    game.Load();
                                    break;
                            }
                            break;
                    }
                    break;
                case 1:
                    game.Load();
                    break;
            }
            Peli(menu,game,true);

        }

        static void Peli(Menu menu,GameHandler game,bool inmenu)
        {
            while (inmenu)
            {
                Console.Clear();
                switch (menu.Multi(false,"Aloita taistelu","Pelaajan tiedot","Kauppa","Tallenna peli","Poistu ja Tallenna"))
                {
                    case 0:
                        break;
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Tiedot:\nPelaajan nimi: " + game.test.Name + "\nXp: " + game.test.Xp + "\nWinLoss ration: "+ game.test.WinLoss + "\nShooted: " + game.test.Shoot + "\nLaivoja upotettu: " + game.test.Sink + "\nTotal Earning: " + game.test.Earnings +"\nCoins: "+game.test.Coins + "\n\nInventory: " +"\nS: "+ game.test.Inv.S + "\nA: " + game.test.Inv.A);
                        Console.ReadKey();
                        break;
                    case 2:
                        game.test.Coins += 400;
                        Shop(menu,game,true);
                        break;
                    case 3:
                        Console.Clear();
                        game.Save();
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        game.Save();
                        inmenu = false;
                        Environment.Exit(0);
                        break;
                }
            }
        }

        static void Shop(Menu menu,GameHandler game,bool inshop)
        {
            while (inshop)
            {
                switch (menu.Multi(false,"sad","asd","Exit"))
                {
                    case 0:
                        game.test.Inv.S++;
                        game.test.Coins -= 50;
                        break;
                    case 1:
                        game.test.Inv.A++;
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine(game.test.Inv.ToString());
                        inshop = false;
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}


/* todo: Features
 * - Xp ?
 * - Coins ?
 * - Levels ?
 * - Shop/Unlockables ?
 * - Multiplayer ?
 * - Skill Tree ?
 * todo: Menu
 * - Interface
 *      - Save and Load option
 *      - Start game option
 *      - Some kind of options ~Maby~
 *      - Shop ?
 *      - Skill Tree ?
 * - Debug menu
 * todo: Grid
 * - Grid for the ships
 *      - Grid Size: Medium or Big ~Maby~
 * - Xp bar place ?
 * - Coins count place ?
 * todo: Player Stats ?
 * - Wins / Loses
 * - Shot Fires
 * - Total Earning
 * - Total Xp
 * - Total ships sink
 * todo: Skill Tree ?
 * - Radar Shot ?
 * - Fix 1 spot in ship ?
 * - Diffrent Ammunation ?
 * todo: Enemy player
 * - Random Generated shot
 *      - Maby if hitted shoot around that spot ?
 * - Harder Enemies with diffrent ammunations ?
 * todo: Story ?
 * todo: Diffrent Ship to chose ?
 * - Diffrent size ships ?
 * - Special ships ?
 * todo: Save And Load
 * - What file to do ?
 * - is the file readable ?
 * - Maby Database saves ?
 * - Auto Save time ?
 * - Load interface to From Auto save or from File ?
*/