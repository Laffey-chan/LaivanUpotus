using System;
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
            menu.Start();
            switch (menu.Value)
            {
                case 1:
                    game.Save();
                    break;
                case 2:
                    game.Load();
                    break;
            }
            Console.WriteLine(game.test.ToString());
            Console.ReadKey();
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