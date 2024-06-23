using StupidTemplate.Menu;
using static StupidTemplate.Menu.Main;
using static StupidTemplate.Settings;

namespace StupidTemplate.Mods
{
    internal class SettingsMods
    {
        public static void ChangeTheme()
        {
            if (Main.currentTheme < 7)
            {
                Main.currentTheme += 1;
            } else
            {
                Main.currentTheme = 0;
            }
        }

        public static void EnterSettings()
        {
            buttonsType = 1;
            pageNumber = 0;
        }

        public static void EnterSafetyMods()
        {
            buttonsType = 13;
            pageNumber = 0;
        }

        public static void MenuSettings()
        {
            buttonsType = 2;
            pageNumber = 0;
        }

        public static void MovementSettings()
        {
            buttonsType = 3;
            pageNumber = 0;
        }

        public static void ProjectileSettings()
        {
            buttonsType = 4;
            pageNumber = 0;
        }

        public static void EnableMoveMods()
        {
            buttonsType = 5;
            pageNumber = 0;
        }

        public static void EnterSpeedBoostSettings()
        {
            buttonsType = 6;
            pageNumber = 0;
        }

        public static void EnterPlatformsSettings()
        {
            buttonsType = 7;
            pageNumber = 0;
        }

        public static void EnterFlySettings()
        {
            buttonsType = 15;
            pageNumber = 0;
        }

        public static void EnterIdentityMods()
        {
            buttonsType = 16;
            pageNumber = 0;
        }

        public static void EnterHorrorMods()
        {
            buttonsType = 17;
            pageNumber = 0;
        }

        public static void EnterMenuSidedMods()
        {
            buttonsType = 18;
            pageNumber = 0;
        }

        public static void EnterMiscMods()
        {
            buttonsType = 19;
            pageNumber = 0;
        }

        public static void EnterProjectileMods()
        {
            buttonsType = 20;
            pageNumber = 0;
        }

        public static void EnterVisualMods()
        {
            buttonsType = 21;
            pageNumber = 0;
        }

        public static void EnableRigMods()
        {
            buttonsType = 8;
            pageNumber = 0;
        }

        public static void EnableSoundMods()
        {
            buttonsType = 9;
            pageNumber = 0;
        }

        public static void EnableOverpoweredMods()
        {
            buttonsType = 10;
            pageNumber = 0;
        }

        public static void EnableFunMods()
        {
            buttonsType = 11;
            pageNumber = 0;
        }

        public static void EnableExperimentMods()
        {
            buttonsType = 12;
            pageNumber = 0;
        }

        public static void EnableMasterMods()
        {
            buttonsType = 14;
            pageNumber = 0;
        }

        public static void RightHand()
        {
            rightHanded = true;
        }

        public static void LeftHand()
        {
            rightHanded = false;
        }

        public static void EnableFPSCounter()
        {
            fpsCounter = true;
        }

        public static void DisableFPSCounter()
        {
            fpsCounter = false;
        }

        public static void EnableNotifications()
        {
            disableNotifications = false;
        }

        public static void DisableNotifications()
        {
            disableNotifications = true;
        }


        public static void EnableCustomBoards()
        {
            disableCustomBoards = false;
        }

        public static void DisableCustomBoards()
        {
            disableCustomBoards = true;
        }

        public static void EnableDisconnectButton()
        {
            disconnectButton = true;
        }

        public static void DisableDisconnectButton()
        {
            disconnectButton = false;
        }
    }
}
