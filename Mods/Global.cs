using StupidTemplate.Menu;
using static StupidTemplate.Menu.Main;

namespace StupidTemplate.Mods
{
    internal class Global
    {
        public static void ReturnHome()
        {
            buttonsType = 0;
        }

        public static void GoToPage(int buttonsType)
        {
            Main.buttonsType = buttonsType;
        }

        public static void Nothing()
        {

        }
    }
}
