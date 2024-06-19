using StupidTemplate.Classes;
using StupidTemplate.Mods;
using System;
using static StupidTemplate.Settings;

namespace StupidTemplate.Menu
{
    internal class Buttons
    {
        public static ButtonInfo[][] buttons = new ButtonInfo[][]
        {
            new ButtonInfo[] { // Main Mods [0]
                new ButtonInfo { buttonText = "Settings", method =() => SettingsMods.EnterSettings(), isTogglable = false, toolTip = "Opens the main settings page for the menu."},
                new ButtonInfo { buttonText = "Join Code DARKMAT", method =() => Experimental.JoinCodeDarkMat(), isTogglable = false, toolTip = "Joins the code DARKMAT."},
                new ButtonInfo { buttonText = "Safety", method =() => SettingsMods.EnterSafetyMods(), isTogglable = false, toolTip = "Opens the safety mods."},
                new ButtonInfo { buttonText = "Movement", method =() => SettingsMods.EnableMoveMods(), isTogglable = false, toolTip = "Opens the movement mods."},
                new ButtonInfo { buttonText = "Rig", method =() => SettingsMods.EnableRigMods(), isTogglable = false, toolTip = "Opens the rig related mods."},
                new ButtonInfo { buttonText = "Fun", method =() => SettingsMods.EnableFunMods(), isTogglable = false, toolTip = "Opens the fun mods."},
                new ButtonInfo { buttonText = "Sounds", method =() => SettingsMods.EnableSoundMods(), isTogglable = false, toolTip = "Opens the sound related mods."},
                new ButtonInfo { buttonText = "Overpowered", method =() => SettingsMods.EnableOverpoweredMods(), isTogglable = false, toolTip = "Opens the op mods."},
                new ButtonInfo { buttonText = "Master", method =() => SettingsMods.EnableMasterMods(), isTogglable = false, toolTip = "Opens the master mods."},
                new ButtonInfo { buttonText = "Identity", method =() => SettingsMods.EnterIdentityMods(), isTogglable = false, toolTip = "Opens the identity mods."},
                new ButtonInfo { buttonText = "Horror", method =() => SettingsMods.EnterHorrorMods(), isTogglable = false, toolTip = "Opens the new horror mode mods."},
                new ButtonInfo { buttonText = "Experimental", method =() => SettingsMods.EnableExperimentMods(), isTogglable = false, toolTip = "Opens the experimental mods."},
                new ButtonInfo { buttonText = "Menu Sided", method = () => SettingsMods.EnterMenuSidedMods(), isTogglable = false, toolTip = "Opens the menu sided mods."},
                new ButtonInfo { buttonText = "Misc", method = () => SettingsMods.EnterMiscMods(), isTogglable = false, toolTip = "Opens the misc mods."},
                new ButtonInfo { buttonText = "Projectile", method = () => SettingsMods.EnterProjectileMods(), isTogglable = false, toolTip = "Opens the projectile mods."},
            },

            new ButtonInfo[] { // Settings [1]
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Menu Settings", method =() => SettingsMods.MenuSettings(), isTogglable = false, toolTip = "Opens the settings for the menu."},
                new ButtonInfo { buttonText = "Movement Settings", method =() => SettingsMods.MovementSettings(), isTogglable = false, toolTip = "Opens the movement settings for the menu."},
                new ButtonInfo { buttonText = "Projectile Settings", method =() => SettingsMods.ProjectileSettings(), isTogglable = false, toolTip = "Opens the projectile settings for the menu."},
            },

            new ButtonInfo[] { // Menu Settings [2]
                new ButtonInfo { buttonText = "Back", method =() => SettingsMods.EnterSettings(), isTogglable = false, toolTip = "Goes back to the previous page."},
                new ButtonInfo { buttonText = "Change Menu Theme", method =() => SettingsMods.ChangeTheme(), isTogglable = false, toolTip = "Changes the menu theme."},
                new ButtonInfo { buttonText = "Right Hand", enableMethod =() => SettingsMods.RightHand(), disableMethod =() => SettingsMods.LeftHand(), toolTip = "Puts the menu on your right hand."},
                new ButtonInfo { buttonText = "Notifications", enableMethod =() => SettingsMods.EnableNotifications(), disableMethod =() => SettingsMods.DisableNotifications(), enabled = !disableNotifications, toolTip = "Toggles the notifications."},
                new ButtonInfo { buttonText = "FPS Counter", enableMethod =() => SettingsMods.EnableFPSCounter(), disableMethod =() => SettingsMods.DisableFPSCounter(), enabled = fpsCounter, toolTip = "Toggles the FPS counter."},
                new ButtonInfo { buttonText = "Disconnect Button", enableMethod =() => SettingsMods.EnableDisconnectButton(), disableMethod =() => SettingsMods.DisableDisconnectButton(), enabled = disconnectButton, toolTip = "Toggles the disconnect button."},
            },

            new ButtonInfo[] { // Movement Settings [3]
                new ButtonInfo { buttonText = "Back", method =() => SettingsMods.EnterSettings(), isTogglable = false, toolTip = "Goes back to the previous page."},
                new ButtonInfo { buttonText = "SpeedBoost Settings", enableMethod =() => SettingsMods.EnterSpeedBoostSettings(), toolTip = "Toggles the speedboost settings."},
                new ButtonInfo { buttonText = "Platforms Settings", enableMethod =() => SettingsMods.EnterPlatformsSettings(), toolTip = "Toggles the platforms settings."},
                new ButtonInfo { buttonText = "Fly Settings", enableMethod =() => SettingsMods.EnterFlySettings(), toolTip = "Toggles the fly mod settings."},
            },

            new ButtonInfo[] { // Projectile Settings [4]
                new ButtonInfo { buttonText = "Back", method =() => SettingsMods.EnterSettings(), isTogglable = false, toolTip = "Goes back to the previous page."},
            },

            new ButtonInfo[] { // Movement Mods [5]
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Tp To Stump [X]", method =() => Movement.TpToStump(), toolTip = "Teleports you to stump."},
                new ButtonInfo { buttonText = $"TP Gun", method =() => Movement.TpGun(), toolTip = "Tp's you to where the pointer is."},
                new ButtonInfo { buttonText = $"Checkpoint [G][A]", method =() => Movement.Checkpoint(), disableMethod =() => Movement.DisableCheckpoint(), toolTip = "Tp's you to where the checkpoint is."},
                new ButtonInfo { buttonText = "", isTogglable = false, toolTip = "" },
                new ButtonInfo { buttonText = "No Tag Freeze", method =() => Movement.NoTagFreeze(), toolTip = "Stops you from getting frozen when tagged or a new round starts."},
                new ButtonInfo { buttonText = "Force Tag Freeze", method =() => Movement.TagFreeze(), toolTip = "Stops you from moving."},
                new ButtonInfo { buttonText = $"Speed Boost", method =() => Movement.SpeedBoost(), disableMethod =() => Movement.FixSpeed(), toolTip = "Enables speed boost."},
                new ButtonInfo { buttonText = $"Mosa Speed", method =() => Movement.MosaSpeed(), disableMethod =() => Movement.FixSpeed(), toolTip = "Enables mosa boost."},
                new ButtonInfo { buttonText = "Uncap Velocity", method =() => Movement.UncapVelocity(), disableMethod =() => Movement.FixSpeed(), toolTip = "Uncaps the max velocity the player can move at."},
                new ButtonInfo { buttonText = $"Dash [X]", method =() => Movement.Dash(), toolTip = "When you press X you get boosted forward a bit."},
                new ButtonInfo { buttonText = "", isTogglable = false, toolTip = "" },
                new ButtonInfo { buttonText = "Slide Control", method =() => Movement.SlideControl(), disableMethod =() => Movement.FixSlideControl(), toolTip = "Makes it easier to control how you slide."},
                new ButtonInfo { buttonText = "Fast Slide [W?]", method =() => Movement.FastSlide(), disableMethod =() => Movement.FixFastSlide(), toolTip = "Makes you slide faster."},
                new ButtonInfo { buttonText = "", isTogglable = false, toolTip = "" },
                new ButtonInfo { buttonText = $"No Clip [B]", method =() => Movement.NoClip(true), disableMethod =() => Movement.DisableNoClip(), toolTip = "Enables no clip."},
                new ButtonInfo { buttonText = $"Platforms", method =() => Movement.Platforms(), toolTip = "Enables platforms."},
                new ButtonInfo { buttonText = $"Platforms + NoClip", method =() => Movement.NoClipPlatforms(), disableMethod =() => Movement.DisableNoClip(), toolTip = "Enables platforms."},
                new ButtonInfo { buttonText = $"Platforms Gun", method =() => Movement.PlatformGun(), disableMethod =() => Movement.DisablePlatformGun(), toolTip = "Places platforms with the point is."},
                new ButtonInfo { buttonText = "", isTogglable = false, toolTip = "" },
                new ButtonInfo { buttonText = $"Low Gravity", method =() => Movement.LowGravity(), toolTip = "Makes the gravity in game low like the moon."},
                new ButtonInfo { buttonText = $"Zero Gravity", method =() => Movement.ZeroGravity(), toolTip = "Removes gravity."},
                new ButtonInfo { buttonText = $"High Gravity", method =() => Movement.HighGravity(), toolTip = "Makes the gravity in game super high like jupiter."},
                new ButtonInfo { buttonText = "", isTogglable = false, toolTip = "" },
                new ButtonInfo { buttonText = $"Fly [A]", method =() => Movement.NormalFly(), toolTip = "Fly in the direction your looking."},
                new ButtonInfo { buttonText = $"Velocity Fly [A]", method =() => Movement.VelocityFly(), toolTip = "Fly in the direction your looking."},
                new ButtonInfo { buttonText = $"Change Fly Speed [{Main.flySpeedType}] [X]", method =() => Movement.ChangeFlySpeed(true), toolTip = "Change the fly mods speed."},
                new ButtonInfo { buttonText = $"NoClip Fly [A]", method =() => Movement.NormalFly(true), toolTip = "Fly in the direction your looking with no clip."},
                new ButtonInfo { buttonText = $"NoClip Velocity Fly [A]", method =() => Movement.VelocityFly(true), toolTip = "Fly in the direction your looking with no clip."},
                new ButtonInfo { buttonText = "", isTogglable = false, toolTip = "" },
                new ButtonInfo { buttonText = "Steam Long Arms", method =() => Rig.SteamLongArms(), disableMethod =() => Rig.FixScale(), toolTip = "Makes you have steam long arms."},
                new ButtonInfo { buttonText = "+ Arm Length +", method =() => Rig.ChangeArmSizeBy(0.1f), disableMethod =() => Rig.FixScale(), isTogglable= false, toolTip = "Changes the custom long arms length."},
                new ButtonInfo { buttonText = "++ Arm Length ++", method =() => Rig.ChangeArmSizeBy(0.2f), disableMethod =() => Rig.FixScale(), isTogglable= false, toolTip = "Changes the custom long arms length."},
                new ButtonInfo { buttonText = "Custom Long Arms", method =() => Rig.CustomLongArms(), disableMethod =() => Rig.FixScale(), toolTip = "Gives you custom long arms."},
                new ButtonInfo { buttonText = "-- Arm Length --", method =() => Rig.ChangeArmSizeBy(-0.2f), disableMethod =() => Rig.FixScale(), isTogglable= false, toolTip = "Changes the custom long arms length."},
                new ButtonInfo { buttonText = "- Arm Length -", method =() => Rig.ChangeArmSizeBy(-0.1f), disableMethod =() => Rig.FixScale(), isTogglable= false, toolTip = "Changes the custom long arms length."},
                new ButtonInfo { buttonText = "", isTogglable = false, toolTip = "" },
                new ButtonInfo { buttonText = "Bigger Smaller [T]", method =() => Movement.BiggerSmaller(), disableMethod =() => Movement.FixBiggerSmaller(), toolTip = "Makes you bigger or smaller." },
                new ButtonInfo { buttonText = "Up And Down [T]", method =() => Movement.UpAndDown(), toolTip = "Makes you go up and down." },
                new ButtonInfo { buttonText = "Left And Right [G]", method =() => Movement.LeftAndRight(), toolTip = "Makes you go left and right." },
                new ButtonInfo { buttonText = "", isTogglable = false, toolTip = "" },
                new ButtonInfo { buttonText = "Copy Player Gun", method =() => Movement.CopyPlayerMovementGun(), toolTip = "Copys selected players movement."},
                new ButtonInfo { buttonText = "Fake Lag", method =() => Movement.FakeLag(), disableMethod =() => Movement.FixOfflineRig(), toolTip = "Makes you look like your lagging." },
                new ButtonInfo { buttonText = "Ghost Cam", method =() => Movement.GhostCam(), disableMethod =() => Movement.FixOfflineRig(), toolTip = "Makes your rig freeze." },
            },

            new ButtonInfo[] // Speed Boost Settings [6]
            {
                new ButtonInfo { buttonText = "Back", method =() => Global.GoToPage(3), isTogglable = false, toolTip = "Goes back to the previous page"},
                new ButtonInfo { buttonText = "Set Use None", method =() => Movement.ToggleUseNoneForSpeedBoost(), isTogglable = false, toolTip = "Set whether or not speedboost is auto active."},
                new ButtonInfo { buttonText = "Set Use Grip", method =() => Movement.ToggleUseGripsForSpeedBoost(), isTogglable = false, toolTip = "Set whether or not speedboost uses grips to activate."},
                new ButtonInfo { buttonText = "Set Use Trigger", method =() => Movement.ToggleUseTriggersForSpeedBoost(), isTogglable = false, toolTip = "Set whether or not speedboost uses triggers to activate."},
                new ButtonInfo { buttonText = "Set Use Left", method =() => Movement.ToggleUseLeftForSpeedBoost(), isTogglable = false, toolTip = "Set whether or not grip speed boost uses left grip/trigger."},
                new ButtonInfo { buttonText = "Set Use Right", method =() => Movement.ToggleUseRightForSpeedBoost(), isTogglable = false, toolTip = "Set whether or not grip speed boost uses right grip/trigger."},
            },

            new ButtonInfo[] // Platform Settings [7]
            {
                new ButtonInfo { buttonText = "Back", method =() => Global.GoToPage(3), isTogglable = false, toolTip = "Goes back to the previous page."},
                new ButtonInfo { buttonText = "Set Use Grips", method =() => Movement.ToggleUseGripForPlatforms(), isTogglable = false, toolTip = "Set grip to use platforms."},
                new ButtonInfo { buttonText = "Set Use Triggers", method =() => Movement.ToggleUseTriggerForPlatforms(), isTogglable = false, toolTip = "Set trigger to use platforms."},
            },

            new ButtonInfo[] // Rig Mods [8]
            {
                new ButtonInfo { buttonText = "Return To Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Goes back to the home page"}, //1
                new ButtonInfo { buttonText = "Skeleton ESP", method =() => Rig.SkeletonESP(), disableMethod =() => Rig.CleanupSkeletonESP(), toolTip = "Turns On Skeleton Esp"}, //2
                new ButtonInfo { buttonText = "", isTogglable = false, toolTip = "" },
                new ButtonInfo { buttonText = "Backwards Head", method =() => Rig.BackwardsHead(), disableMethod =() => Rig.FixTrackingOffsets(), toolTip = "Makes your head turn backwards."}, // 3
                new ButtonInfo { buttonText = "Upside Down Head", method =() => Rig.UpsideDownHead(), disableMethod =() => Rig.FixTrackingOffsets(), toolTip = "Makes your head turn upside down."}, //4
                new ButtonInfo { buttonText = "Spin Bot", method =() => Rig.SpinBot(), disableMethod =() => Rig.DisableSpinBot(), toolTip = "Makes your rig spin really fast."},
                new ButtonInfo { buttonText = "Spin Head X", method =() => Rig.SpinHeadX(), disableMethod =() => Rig.FixTrackingOffsets(), toolTip = "Makes your head spin on the x axis."}, //5
                new ButtonInfo { buttonText = "Spin Head Y", method =() => Rig.SpinHeadY(), disableMethod =() => Rig.FixTrackingOffsets(), toolTip = "Makes your head spin on the y axis."}, //6
                new ButtonInfo { buttonText = "Spin Head Z", method =() => Rig.SpinHeadZ(), disableMethod =() => Rig.FixTrackingOffsets(), toolTip = "Makes your head spin on the z axis."}, //7

                new ButtonInfo { buttonText = "Move Body X", method =() => Rig.HeadPositionTestX(), disableMethod =() => Rig.FixTrackingOffsets(), toolTip = "Makes your head move on the x axis."}, //8
                new ButtonInfo { buttonText = "Move Body Y", method =() => Rig.HeadPositionTestY(), disableMethod =() => Rig.FixTrackingOffsets(), toolTip = "Makes your head move on the y axis."}, //9
                new ButtonInfo { buttonText = "Move Body Z", method =() => Rig.HeadPositionTestZ(), disableMethod =() => Rig.FixTrackingOffsets(), toolTip = "Makes your head move on the z axis."}, //10

                new ButtonInfo { buttonText = "Fix Rig", method =() => Rig.FixTrackingOffsets(), isTogglable = false, toolTip = "Moves your offline vrrig to the pointer."}, //11
                new ButtonInfo { buttonText = "", isTogglable = false, toolTip = "" },
                new ButtonInfo { buttonText = "Look At Player Gun", method =() => Rig.LookAtPlayerGun(), toolTip = "Makes you look at the selected player."},
                new ButtonInfo { buttonText = "Look At Closest Player", method =() => Rig.LookAtClosest(), toolTip = "Makes you look at the closest player."},
                new ButtonInfo { buttonText = "Rig Gun [UND]", method =() => Rig.RigGun(), toolTip = "Moves your offline vrrig to the pointer."},//12
                new ButtonInfo { buttonText = "Hold Rig [RG]", method =() => Rig.HoldRig(), toolTip = "Moves your offline vrrig to your right hand."},//13
                new ButtonInfo { buttonText = "Invis Monke [UND][B]", method =() => Rig.InvisMonke(), disableMethod =() => Rig.FixTrackingOffsets(), toolTip = "Makes you invisible"},//14
                new ButtonInfo { buttonText = "Ghost Monke [UND][B]", method =() => Rig.GhostMonke(), disableMethod =() => Rig.FixTrackingOffsets(), toolTip = "Makes you into a frozen ghost."},//15
                new ButtonInfo { buttonText = "Bees [UND][A]", method =() => Rig.Bees(), disableMethod =() => Rig.FixTrackingOffsets(), toolTip = "Makes you tp to each player in the lobby repeatedly."},//16
                new ButtonInfo { buttonText = "", isTogglable = false, toolTip = "" },
                new ButtonInfo { buttonText = "Third Person [WIP]", method =() => Rig.ThirdPerson(), disableMethod =() => Rig.FixTrackingOffsets(), toolTip = "Makes you go into the third person."},//17
            },

            new ButtonInfo[] // Sound Mods [9]
            {
                new ButtonInfo { buttonText = "Return To Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Goes back to the home page"},
                new ButtonInfo { buttonText = "AK47 Spam [RG]", method =() => Sounds.AK47(), toolTip = "Spams an annoying sound thats close to the sound of a ak47."},
                new ButtonInfo { buttonText = "Random Sound Spam [RG]", method =() => Sounds.Random(), toolTip = "Spams an annoying random sound."},
                new ButtonInfo { buttonText = "", isTogglable = false, toolTip = "" },
                new ButtonInfo { buttonText = "+ Sound Id +", method =() => Sounds.ChangeSoundId(1), isTogglable = false, toolTip = "Changes the custom sound id."},
                new ButtonInfo { buttonText = "++ Sound Id ++", method =() => Sounds.ChangeSoundId(10), isTogglable = false, toolTip = "Changes the custom sound id."},
                new ButtonInfo { buttonText = "Spam Custom Sound", method =() => Sounds.CustomSound(), toolTip = "Spams custom sound using the sound id you chose."},
                new ButtonInfo { buttonText = "- Sound Id -", method =() => Sounds.ChangeSoundId(-1), isTogglable = false, toolTip = "Changes the custom sound id."},
                new ButtonInfo { buttonText = "-- Sound Id --", method =() => Sounds.ChangeSoundId(-10), isTogglable = false, toolTip = "Changes the custom sound id."},
                new ButtonInfo { buttonText = "", isTogglable = false, toolTip = "" },
            },

            new ButtonInfo[] // OverPowered Mods [10]
            {
                new ButtonInfo { buttonText = "Return To Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Goes back to the home page"},
                new ButtonInfo { buttonText = "Flick Tag Gun [UND]", method =() => OverPowered.FlickTagGun(), toolTip = "A gun that allows you to flick tag with ease."},
                new ButtonInfo { buttonText = "Tag Gun [UND]", method =() => OverPowered.TagGun(), toolTip = "A gun that allows you to tag with ease."},
                //new ButtonInfo { buttonText = "Tag All [W?]", method =() => OverPowered.TagAll(), toolTip = "A tag all. pretty self explanatory."},
                new ButtonInfo { buttonText = "Tag All [UND][RT]", method =() => OverPowered.TestTagAll(), toolTip = "A tag all. pretty self explanatory."},
                new ButtonInfo { buttonText = "Tag Aura [RG]", method =() => OverPowered.TagAura(), toolTip = "Tags everyone within 10 meters of you automatically."},
                new ButtonInfo { buttonText = "Tag Self", method =() => OverPowered.TagSelf(), toolTip = "Tags yourself."},

            },

            new ButtonInfo[] // Fun Mods [11]
            {
                new ButtonInfo { buttonText = "Return To Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Goes back to the home page"},
                new ButtonInfo { buttonText = "", isTogglable = false, toolTip = "" },
                new ButtonInfo { buttonText = "Steal Doug", method =() => Fun.JediDoug(), toolTip = "Uses the force on doug and if you are master can steal him from others."},
                new ButtonInfo { buttonText = "Doug Gun", method =() => Fun.DougGun(), toolTip = "Shoots doug to the position of the pointer."},
                new ButtonInfo { buttonText = "Fast Doug", method =() => Fun.FastDoug(), disableMethod =() => Fun.FixDoug(), toolTip = "Makes doug fast."},
                new ButtonInfo { buttonText = "Spaz Doug", method =() => Fun.SpazDoug(), disableMethod =() => Fun.FixDoug(), toolTip = "Makes doug spaz."},
                new ButtonInfo { buttonText = "Doug Beyblade", method =() => Fun.DougBeyblade(), disableMethod =() => Fun.FixDoug(), toolTip = "Makes doug spin like a beyblade."},
                new ButtonInfo { buttonText = "", isTogglable = false, toolTip = "" },
                new ButtonInfo { buttonText = "Steal Matt", method =() => Fun.JediMatt(), toolTip = "Uses the force on matt and if you are master can steal him from others."},
                new ButtonInfo { buttonText = "Matt Gun", method =() => Fun.MattGun(), toolTip = "Shoots matt to the position of the pointer."},
                new ButtonInfo { buttonText = "Fast Matt", method =() => Fun.FastMatt(), disableMethod =() => Fun.FixMatt(), toolTip = "Makes matt fast."},
                new ButtonInfo { buttonText = "Spaz Matt", method =() => Fun.SpazMatt(), disableMethod =() => Fun.FixMatt(), toolTip = "Makes matt spaz."},
                new ButtonInfo { buttonText = "Matt Beyblade", method =() => Fun.MattBeyblade(), disableMethod =() => Fun.FixMatt(), toolTip = "Makes matt spin like a beyblade."},
                new ButtonInfo { buttonText = "", isTogglable = false, toolTip = "" },
                new ButtonInfo { buttonText = "Glider Gun", method =() => Fun.GliderGun(), toolTip = "Puts all of the gliders to the pointers position."},
                new ButtonInfo { buttonText = "Glider Spaz", method =() => Fun.GlidersSpaz(), toolTip = "Spazes out all of the gliders."},
                new ButtonInfo { buttonText = "Glider Spaz V2", method =() => Fun.SpazGlidersV2(), toolTip = "Makes all of the gliders spaz around you."},
                new ButtonInfo { buttonText = "Glider Orbit Gun", method =() => Fun.GliderGun(), toolTip = "Puts all of the gliders to the pointers position."},
                new ButtonInfo { buttonText = "Blind Player Gun", method =() => Fun.BlindPlayerWithGliders(), toolTip = "Blinds the selected player with gliders."},
                new ButtonInfo { buttonText = "Blind All", method =() => Fun.BlindAllPlayersWithGliders(), toolTip = "Blinds everyone with gliders."},
                new ButtonInfo { buttonText = "Glider Beyblades", method =() => Fun.GliderBeyblades(), toolTip = "Spins all of the gliders like beyblades."},
                new ButtonInfo { buttonText = "No Respawn Gliders", method =() => Fun.DestroyGliders(), toolTip = "Destroys all gliders."},
                new ButtonInfo { buttonText = "Respawn Gliders", method =() => Fun.RespawnGliders(), toolTip = "Respawns all gliders."},
                new ButtonInfo { buttonText = "", isTogglable = false, toolTip = "" },
                new ButtonInfo { buttonText = "Balloons Gun", method =() => Fun.BalloonsGun(), toolTip = "Puts all of the balloons to the pointers position."},
                new ButtonInfo { buttonText = "Grab Balloons [RG]", method =() => Fun.GrabBalloons(), toolTip = "Grabs all of the balloons in the lobby."},
                new ButtonInfo { buttonText = "Balloon Beyblades", method =() => Fun.BalloonsBeyblades(), toolTip = "Spins all of the balloons like beyblades."},
                new ButtonInfo { buttonText = "Upright Balloons", method =() => Fun.UprightBalloons(), toolTip = "Puts all of the balloons in an upright position and they cant get rotated."},
                new ButtonInfo { buttonText = "Balloon Head", method =() => Fun.BalloonHead(), toolTip = "Puts all of the balloons in your head."},
                new ButtonInfo { buttonText = "Pop All Balloons", method =() => Fun.PopAllBalloons(), toolTip = "Pops all of the balloons."},
                new ButtonInfo { buttonText = "", isTogglable = false, toolTip = "" },
                new ButtonInfo { buttonText = "Water Bender [LT]", method =() => Fun.LWaterSplash(), toolTip = "Splashes water on your left hand."},
                new ButtonInfo { buttonText = "Water Bender [RT]", method =() => Fun.RWaterSplash(), toolTip = "Splashes water on your right hand."},
                new ButtonInfo { buttonText = "Water Gun", method =() => Fun.WaterGun(), toolTip = "Splashes water on the pointer."},
                new ButtonInfo { buttonText = "Give Water Bender [LT]", method =() => Fun.GiveLWaterSplash(), toolTip = "Splashes water on there left hand."},
                new ButtonInfo { buttonText = "Give Water Bender [RT]", method =() => Fun.GiveRWaterSplash(), toolTip = "Splashes water on there right hand."},
                new ButtonInfo { buttonText = "Give Water Gun", method =() => Fun.GiveWaterGun(), toolTip = "Splashes water on where they point."},
                new ButtonInfo { buttonText = "", isTogglable = false, toolTip = "" },

            },

            new ButtonInfo[] // Experiment Mods [12]
            {
                new ButtonInfo { buttonText = "Return To Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Goes back to the home page"},
                new ButtonInfo { buttonText = "", isTogglable = false, toolTip = "" },

                new ButtonInfo { buttonText = "", isTogglable = false, toolTip = "" },
                new ButtonInfo { buttonText = "Push Players [NW]", method =() => Experimental.GrabMonsters(), toolTip = "Grabs the basement monsters."},
                new ButtonInfo { buttonText = "Float Player Gun [M]", method =() => Experimental.FloatPlayerGun(), toolTip = "Makes the selected player float in the air."},
                new ButtonInfo { buttonText = "", isTogglable = false, toolTip = "" },
                //new ButtonInfo { buttonText = "Punch Mod [NW]", method =() => Experimental.PunchMod(), toolTip = "Flings you when a player punches you."},
                //new ButtonInfo { buttonText = "Crash Gun [NW]", method =() => Experimental.CrashGun(), toolTip = "Crashes the player selected." },
                new ButtonInfo { buttonText = "", isTogglable = false, toolTip = "" },
            },

            new ButtonInfo[] // Safety Mods [13] 
            {
                new ButtonInfo { buttonText = "Return To Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Goes back to the home page"},
                new ButtonInfo { buttonText = "Anti Report", method =() => Safety.AntireportDisconnect(), toolTip = "Makes it so you don't get reported."},
            },

            new ButtonInfo[] // Master Required Mods [14]
            {
                new ButtonInfo { buttonText = "Return To Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Goes back to the home page"},
                //new ButtonInfo { buttonText = "Set Master [D! DONT USE]", method =() => Experimental.SetMasterForRealz(), toolTip = "Makes you master" },
                new ButtonInfo { buttonText = "Mat Spam All [M]", method =() => Master.MatSpamAll(), toolTip = "Mat spams everyone."},
                new ButtonInfo { buttonText = "Mat Spam Self [M]", method =() => Master.MatSpamSelf(), toolTip = "Mat spams only you."},
                new ButtonInfo { buttonText = "Mat Spam Gun [M]", method =() => Master.MatSpamGun(), toolTip = "Mat spams target player."},
                new ButtonInfo { buttonText = "Give Mat Spam Gun [M]", method =() => Master.GiveMatSpamGun(), toolTip = "Gives someone matspam gun."},
                new ButtonInfo { buttonText = "Slow Others [M]", method =() => Master.SlowOthers(), toolTip = "Slows everyone but you."},
                new ButtonInfo { buttonText = "Slow Gun [M]", method =() => Master.SlowGun(), toolTip = "Slows target player."},
                new ButtonInfo { buttonText = "Give Slow Gun [M]", method =() => Master.GiveSlowGun(), toolTip = "Gives someone slow gun."},
                new ButtonInfo { buttonText = "Vibrate Others [M]", method =() => Master.VibrateOthers(), toolTip = "Vibrates everyone but you."},
                new ButtonInfo { buttonText = "Vibrate Gun [M]", method =() => Master.VibrateGun(), toolTip = "Vibrates target player."},
                new ButtonInfo { buttonText = "Give Vibrate Gun [M]", method =() => Master.GiveVibrateGun(), toolTip = "Gives someone vibrate gun."},
                new ButtonInfo { buttonText = "Tag Self [M]", method =() => Master.TagSelf(), isTogglable = false, toolTip = "Tags yourself."},
                new ButtonInfo { buttonText = "Untag Self [M]", method =() => Master.UntagSelf(), isTogglable = false, toolTip = "Untags yourself."},
                new ButtonInfo { buttonText = "Silent Tag Gun [M]", method =() => Master.ForceTagGun(), toolTip = "Tags Wanted Player Without Vibration."},
                new ButtonInfo { buttonText = "Silent Untag Gun [M]", method =() => Master.ForceUntagGun(), toolTip = "Untags Wanted Player Without Vibration."},
                new ButtonInfo { buttonText = "Silent Tag All [M]", method =() => Master.ForceTagAll(), toolTip = "Tags Everyone Without A Vibration."},
                new ButtonInfo { buttonText = "Silent Untag All [M]", method =() => Master.ForceUntagAll(), toolTip = "Untags Everyone Without A Vibration."},
                new ButtonInfo { buttonText = "Silent Tag Aura [M]", method =() => Master.ForceTagAura(), toolTip = "Tags Everyone Within A Specific Area Near You Without A Vibration."},
                new ButtonInfo { buttonText = "Silent Untag Aura [M]", method =() => Master.ForceUntagAura(), toolTip = "Untags Everyone Within A Specific Area Near You Without A Vibration."},
                new ButtonInfo { buttonText = "Force Start As It Gun [M]", method =() => Master.ForceSpawnAsIt(), toolTip = "Makes The Player You Hit With This Always Be It No Matter What."},
                new ButtonInfo { buttonText = "Force Never Tagged Gun [M]", method =() => Master.ForceNeverBeIt(), toolTip = "Makes The Player You Hit With This Never Be Tagged No Matter What."},
                new ButtonInfo { buttonText = "Reset Force To Be It", method =() => Master.ResetSpawnAsIt(), toolTip = "Removes the last selected player from the always be it."},
                new ButtonInfo { buttonText = "Reset Never Be It", method =() => Master.ResetNeverIt(), toolTip = "Removes the last selected player from the never be it."},
                new ButtonInfo { buttonText = "Anti Tag [M]", method =() => Master.AntiTagSelf(), toolTip = "Makes It So You Instantly Get Untagged."},
                new ButtonInfo { buttonText = "Force Tag [M]", method =() => Master.ForceTagSelf(), isTogglable = false, toolTip = "Makes It So You Instantly Get Tagged."},
            },

            new ButtonInfo[] // Fly Mods Settings Page [15]
            {
                new ButtonInfo { buttonText = "Back", method =() => Global.GoToPage(5), isTogglable = false, toolTip = "Goes back to the last page."},
                new ButtonInfo { buttonText = $"Change Fly Speed [{Main.flySpeedType}]", method =() => Movement.ChangeFlySpeed(false), isTogglable = false, toolTip = "Changes the fly mods speed."},
            },

            new ButtonInfo[] // Identity Mods Page [16]
            {
                new ButtonInfo { buttonText = "Return To Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Goes back to the home page"},
                new ButtonInfo { buttonText = "Become goto", method =() => Experimental.Goto(), toolTip = "Changes your name to \"goto\"."},
                new ButtonInfo { buttonText = "Become invis", method =() => Experimental.Invis(), toolTip = "Changes your name to \"invis\"."},
                new ButtonInfo { buttonText = "Become ghost", method =() => Experimental.Ghost(), toolTip = "Changes your name to \"ghost\"."},
                new ButtonInfo { buttonText = "Become ObsidianDev", method =() => Experimental.ObsidianDev(), toolTip = "Changes your name to \"ObsidianDev\"."},
                new ButtonInfo { buttonText = "Change Identity", method =() => Experimental.ChangeIdentity(), toolTip = "Changes your name to a random players name."},
            },

            new ButtonInfo[] // Ghost/Horror Lab Mods [17]
            {
                new ButtonInfo { buttonText = "Return To Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Goes back to the home page"},
                new ButtonInfo { buttonText = "Tp To Lab [X]", method =() => Horror.TpToHorrorLab(), toolTip = "Teleports you to the lab."},
                new ButtonInfo { buttonText = "Grab Id Card [RG]", method =() => Horror.GrabCard(), toolTip = "Grabs the hidden id card."},
                new ButtonInfo { buttonText = "Toggle All Fences", method =() => Horror.ToggleAllHorrorFences(), isTogglable = false, toolTip = "Toggles all of the gates."},
                new ButtonInfo { buttonText = "Spam Gates", method =() => Horror.SpamGates(), toolTip = "Spams the gates."},
            },

            new ButtonInfo[] // Menu Sided Mods [18]
            {
                new ButtonInfo { buttonText = "Return To Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Goes back to the home page"},
                new ButtonInfo { buttonText = "Bigger Smaller [MS][W?]", method =() => MenuSided.BiggerSmallerHandler(), toolTip = "Makes it so other menu users can see you get bigger/smaller."},
                new ButtonInfo { buttonText = "Bigger Smaller Doug [MS][W?]", method =() => MenuSided.BiggerSmallerDougHandler(), toolTip = "Makes it so other menu users can see doug get bigger/smaller."},
                new ButtonInfo { buttonText = "Bigger Smaller Matt [MS][W?]", method =() => MenuSided.BiggerSmallerMattHandler(), toolTip = "Makes it so other menu users can see matt get bigger/smaller."},
            },

            new ButtonInfo[] // Misc Mods [19]
            {
                new ButtonInfo { buttonText = "Return To Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Goes back to the home page"},
                new ButtonInfo { buttonText = "Unlock Comp", method =() => Misc.UnlockComp(), toolTip = "Unlocks competitive."},
                new ButtonInfo { buttonText = "Lock Comp", method =() => Misc.LockComp(), toolTip = "Locks competitive cause why not."},
                new ButtonInfo { buttonText = "Disable Afk Kick", method =() => Misc.DisableAfkKick(), toolTip = "Disables afk kick."},
                new ButtonInfo { buttonText = "Enable Afk kick", method =() => Misc.EnableAfkKick(), toolTip = "Enables afk kick cause why not."},
            },

            new ButtonInfo[] // PROJECTILE MODS WWW [20]
            {
                new ButtonInfo { buttonText = "Return To Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Goes back to the home page"},
                new ButtonInfo { buttonText = "PROJECTILE GUN MADE BY: 504BRANDON :)", isTogglable = false, toolTip = "" },
                new ButtonInfo { buttonText = "Projectile Gun", method =() => Projectiles.WORKINGPROJECTILESFRFRFORREALZYS(), toolTip = "Shoots projectiles out of your hand."},
                new ButtonInfo { buttonText = "Random Projectile Ground [FO][X]", method =() => Projectiles.RandomProjectileGroundForest(), toolTip = "When holding X you can grab projectiles from the ground in forest."},
                new ButtonInfo { buttonText = "Snowball Ground [FO][X]", method =() => Projectiles.SnowballGroundForest(), toolTip = "When holding X you can grab projectiles from the ground in forest."},
                new ButtonInfo { buttonText = "WaterBalloon Ground [FO][X]", method =() => Projectiles.WaterBalloonGroundForest(), toolTip = "When holding X you can grab projectiles from the ground in forest."},
                new ButtonInfo { buttonText = "LavaRock Ground [FO][X]", method =() => Projectiles.LavaRockGroundForest(), toolTip = "When holding X you can grab projectiles from the ground in forest."},
                new ButtonInfo { buttonText = "Gift Ground [FO][X]", method =() => Projectiles.GiftGroundForest(), toolTip = "When holding X you can grab projectiles from the ground in forest."},
                new ButtonInfo { buttonText = "Science Candy Ground [FO][X]", method =() => Projectiles.ScienceCandyGroundForest(), toolTip = "When holding X you can grab projectiles from the ground in forest."},
                new ButtonInfo { buttonText = "Fish Food Ground [FO][X]", method =() => Projectiles.FishFoodGroundForest(), toolTip = "When holding X you can grab projectiles from the ground in forest."},
                new ButtonInfo { buttonText = "Snowball Spam [RG]", method =() => Projectiles.SnowballSpam(), toolTip = "When holding right grip you can spam projectiles."},
                new ButtonInfo { buttonText = "WaterBalloon Spam [RG]", method =() => Projectiles.WaterBalloonSpam(), toolTip = "When holding right grip you can spam projectiles."},
                new ButtonInfo { buttonText = "LavaRock Spam [RG]", method =() => Projectiles.LavarockSpam(), toolTip = "When holding right grip you can spam projectiles."},
                new ButtonInfo { buttonText = "Gift Spam [RG]", method =() => Projectiles.GiftSpam(), toolTip = "When holding right grip you can spam projectiles."},
                new ButtonInfo { buttonText = "Science Candy Spam [RG]", method =() => Projectiles.ScienceCandySpam(), toolTip = "When holding right grip you can spam projectiles."},
                new ButtonInfo { buttonText = "Fish Food Spam [RG]", method =() => Projectiles.FishFoodSpam(), toolTip = "When holding right grip you can spam projectiles."},
                new ButtonInfo { buttonText = "Random Spam [RG]", method =() => Projectiles.RandomSpam(), toolTip = "When holding right grip you can spam projectiles."},
                new ButtonInfo { buttonText = "", isTogglable = false, toolTip = "" },
                new ButtonInfo { buttonText = "", isTogglable = false, toolTip = "" },
                new ButtonInfo { buttonText = "+ Surface Id +", method =() => Projectiles.ChangeSurfaceId(1), isTogglable = false, toolTip = "Changes the custom surface id."},
                new ButtonInfo { buttonText = "++ Surface Id ++", method =() => Projectiles.ChangeSurfaceId(10), isTogglable = false, toolTip = "Changes the custom surface id."},
                new ButtonInfo { buttonText = "Custom Surface [X]", method =() => Projectiles.CustomSurface(), toolTip = "Changes the forest surface override."},
                new ButtonInfo { buttonText = "-- Surface Id --", method =() => Projectiles.ChangeSurfaceId(-1), isTogglable = false, toolTip = "Changes the custom surface id."},
                new ButtonInfo { buttonText = "- Surface Id -", method =() => Projectiles.ChangeSurfaceId(-10), isTogglable = false, toolTip = "Changes the custom surface id."},
            },
        };
    }
}

//63 mods 
