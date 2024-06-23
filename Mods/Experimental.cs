using ExitGames.Client.Photon;
using Fusion;
using GorillaLocomotion.Climbing;
using GorillaLocomotion.Gameplay;
using GorillaNetworking;
using GorillaTagScripts;
using Photon.Pun;
using Photon.Realtime;
using POpusCodec.Enums;
using Sirenix.OdinInspector;
using StupidTemplate.Menu;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR;
using Valve.VR;
using Color = UnityEngine.Color;

namespace StupidTemplate.Mods
{
    internal class Experimental
    {

        
        




        public static void Goto()
        {
            ChangeName("goto");
        }

        public static void Invis()
        {
            ChangeName("invis");
        }

        public static void Ghost()
        {
            ChangeName("ghost");
        }

        public static void ObsidianDev()
        {
            ChangeName("ObsidianDev");
        }

        public static void ChangeIdentity()
        {
            ChangeName(PhotonNetwork.PlayerList[UnityEngine.Random.Range(0, PhotonNetwork.PlayerList.Length)].NickName);
            
        }

        public static void ChangeName(string PlayerName)
        {
            
        }

        public static void GrabMonsters()
        {
            if (Main.rightGrab)
            {
                foreach (MonkeyeAI monke in GameObject.FindObjectsOfType<MonkeyeAI>())
                {
                    if (monke.GetComponent<PhotonView>().Owner == PhotonNetwork.LocalPlayer)
                    {
                        monke.transform.position = GorillaTagger.Instance.rightHandTransform.position;
                    } else
                    {
                        monke.GetComponent<PhotonView>().RequestOwnership();
                    }
                }
            }
        }

        public static void FloatPlayerGun()
        {
            if (Main.rightGrab)
            {
                if (!Main.floatPlayerGunLocked)
                {
                    Physics.Raycast(GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.rightHandTransform.forward, out var Ray);

                    GameObject pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    pointer.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                    UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                    UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                    pointer.GetComponent<Renderer>().material.shader = UnityEngine.Shader.Find("GUI/Text Shader");
                    pointer.GetComponent<Renderer>().material.color = UnityEngine.Color.white;
                    pointer.transform.position = Ray.point;
                    GameObject.Destroy(pointer, Time.deltaTime);
                    if (Main.rightTrigger == 1f)
                    {
                        pointer.GetComponent<Renderer>().material.color = UnityEngine.Color.HSVToRGB(Main.h, 1f, 1f);
                        Main.plrToLockOn = Ray.collider.GetComponentInParent<VRRig>();
                        Main.floatPlayerGunLocked = true;
                        
                        foreach (MonkeyeAI monkeyeAI in GameObject.FindObjectsOfType<MonkeyeAI>())
                        {
                            if (monkeyeAI.gameObject.GetComponent<PhotonView>().Owner == PhotonNetwork.LocalPlayer)
                            {
                                
                            }
                            else
                            {
                                monkeyeAI.gameObject.GetComponent<PhotonView>().RequestOwnership();
                            }
                        }
                        GameObject.Destroy(pointer, Time.deltaTime);
                    }
                }

                if (Main.floatPlayerGunLocked && Main.plrToLockOn != null)
                {
                    
                    foreach (MonkeyeAI monkeyeAI in GameObject.FindObjectsOfType<MonkeyeAI>())
                    {
                        if (monkeyeAI.gameObject.GetComponent<PhotonView>().Owner == PhotonNetwork.LocalPlayer)
                        {
                            monkeyeAI.transform.position = Main.plrToLockOn.head.rigTarget.transform.position;
                        }
                        else
                        {
                            monkeyeAI.gameObject.GetComponent<PhotonView>().RequestOwnership();
                        }
                    }
                }
            } else
            {
                Main.floatPlayerGunLocked = false;
                Main.plrToLockOn = null;
                foreach (MonkeyeAI monkeyeAI in GameObject.FindObjectsOfType<MonkeyeAI>())
                {
                    if (monkeyeAI.gameObject.GetComponent<PhotonView>().Owner == PhotonNetwork.LocalPlayer)
                    {
                        monkeyeAI.gameObject.transform.position = new Vector3(999f, 999f, 999f);
                    }
                    else
                    {
                        monkeyeAI.gameObject.GetComponent<PhotonView>().RequestOwnership();
                    }
                }
            }
        }

        public static void PunchMod()
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (vrrig != GorillaTagger.Instance.myVRRig)
                {
                    
                }
            }
        }

        public static void JoinCodeDarkMat()
        {
            PhotonNetworkController.Instance.AttemptToJoinSpecificRoom("DARKMAT", JoinType.Solo);
        }

        public static void AntiRpc()
        {
            GorillaNot.instance.rpcErrorMax = int.MaxValue;
            GorillaNot.instance.rpcCallLimit = int.MaxValue;
            GorillaNot.instance.logErrorMax = int.MaxValue;
            GorillaNot.instance.OnPlayerLeftRoom(PhotonNetwork.LocalPlayer);
            PhotonNetwork.RemoveBufferedRPCs(GorillaTagger.Instance.myVRRig.ViewID, null, null);
            PhotonNetwork.OpCleanRpcBuffer(GorillaTagger.Instance.myVRRig);
            PhotonNetwork.RemoveRPCs(PhotonNetwork.LocalPlayer);
            PhotonNetwork.RemoveRPCsInGroup(int.MaxValue);
            PhotonNetwork.SendAllOutgoingCommands();
            PhotonNetwork.OpRemoveCompleteCache();
            PhotonNetwork.OpRemoveCompleteCacheOfPlayer(PhotonNetwork.LocalPlayer.ActorNumber);
        }

        public static void CrashGun()
        {
            if (Main.rightGrab)
            {
                if (!Main.crashGunLocked)
                {
                    Physics.Raycast(GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.rightHandTransform.forward, out var Ray);

                    GameObject pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    pointer.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                    UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                    UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                    pointer.GetComponent<Renderer>().material.shader = UnityEngine.Shader.Find("GUI/Text Shader");
                    pointer.GetComponent<Renderer>().material.color = UnityEngine.Color.white;
                    pointer.transform.position = Ray.point;
                    GameObject.Destroy(pointer, Time.deltaTime);

                    if (Main.rightTrigger == 1f)
                    {
                        if (Ray.collider.GetComponentInParent<VRRig>())
                        {
                            Main.plrToLockOn = Ray.collider.GetComponentInParent<VRRig>();
                            Main.crashGunLocked = true;
                            pointer.GetComponent<Renderer>().material.color = UnityEngine.Color.HSVToRGB(Main.h, 1f, 1f);
                            GameObject.Destroy(pointer, Time.deltaTime);

                            
                        }

                        GameObject.Destroy(pointer, Time.deltaTime);
                    }
                }

                if (Main.crashGunLocked && Main.plrToLockOn != null)
                {
                    
                }
            } else
            {
                Main.crashGunLocked = false;
                Main.plrToLockOn = null;
            }
        }



        //[Unity] RPC by GODLUFFY sent SetOwnershipFromMasterClient // #188 'TROLL123', ||| [Unity] RPC by GODLUFFY sent SetOwnershipFromMasterClient // #165 'GODLUFFY',
        //[Unity] RPC by GTF1 sent InitializeNoobMaterial // 0.5555556, 0.1111111, 0, 
        //[Unity] RPC by GTF1 sent RequestMaterialColor // #186 'GTF1', 
        //[Unity] RPC by NOCOST sent UpdateCosmeticsWithTryon // System.String[], System.String[], 
        //[Unity] RPC by GRIM sent PlayHandTap // 8, False, 0.1, 
        //[Unity] RPC by GRAVITYVR sent UpdateCosmeticsWithTryon // System.String[], System.String[], 
        //[Unity] Event by GODLUFFY sent 3 // System.Object[]
        //[Unity] Event by GRAVITYVR sent 176 // System.Object[]
        //[Unity] Event by GODLUFFY sent 2 // System.Object[]
        //[Unity] Event by LAZYYMONKEY2 sent 202 // (System.Byte)6=(System.Int32)-366905433, (System.Byte)7=(System.Int32)198001, (System.Byte)4=(System.Int32[])System.Int32[], (System.Byte)1=(UnityEngine.Vector3)(-64.51, 11.85, -79.69), (System.Byte)0=(System.String)Player Network Controller
        //[Unity] Event by gorilla2588 sent 202 // (System.Byte)6=(System.Int32)-366917343, (System.Byte)7=(System.Int32)197001, (System.Byte)4=(System.Int32[])System.Int32[], (System.Byte)1=(UnityEngine.Vector3)(-65.75, 11.79, -78.52), (System.Byte)0=(System.String)Player Network Controller
        //[Unity] Event by GODLUFFY sent 212 // System.Int32[]
        //[Unity] Event by GODLUFFY sent 202 // (System.Byte)6=(System.Int32)-367698883, (System.Byte)7=(System.Int32)165001, (System.Byte)4=(System.Int32[])System.Int32[], (System.Byte)1=(UnityEngine.Vector3)(-71.18, 11.00, -56.06), (System.Byte)0=(System.String)Player Network Controller
        //[Unity] Event by FOUL sent 202 // (System.Byte)6=(System.Int32)-367365720, (System.Byte)7=(System.Int32)181001, (System.Byte)4=(System.Int32[])System.Int32[], (System.Byte)1=(UnityEngine.Vector3)(-66.45, 11.86, -78.59), (System.Byte)0=(System.String)Player Network Controller
        //[Unity] Event by GRAVITYVR sent 202 // (System.Byte)6=(System.Int32)-367307787, (System.Byte)7=(System.Int32)183001, (System.Byte)4=(System.Int32[])System.Int32[], (System.Byte)1=(UnityEngine.Vector3)(-66.54, 11.80, -78.32), (System.Byte)0=(System.String)Player Network Controller
        //[Unity] Event by GRIM sent 202 // (System.Byte)6=(System.Int32)-367225544, (System.Byte)7=(System.Int32)184001, (System.Byte)4=(System.Int32[])System.Int32[], (System.Byte)1=(UnityEngine.Vector3)(-67.71, 11.99, -79.34), (System.Byte)0=(System.String)Player Network Controller
        //[Unity] Event by NOCOST sent 202 // (System.Byte)6=(System.Int32)-367216743, (System.Byte)7=(System.Int32)185001, (System.Byte)4=(System.Int32[])System.Int32[], (System.Byte)1=(UnityEngine.Vector3)(-66.41, 12.20, -79.10), (System.Byte)0=(System.String)Player Network Controller
        //[Unity] Event by GTF1 sent 202 // (System.Byte)6=(System.Int32)-367216142, (System.Byte)7=(System.Int32)186001, (System.Byte)4=(System.Int32[])System.Int32[], (System.Byte)1=(UnityEngine.Vector3)(-66.72, 11.86, -79.85), (System.Byte)0=(System.String)Player Network Controller
        //[Unity] Event by THEPROMAN sent 202 // (System.Byte)6=(System.Int32)-367215988, (System.Byte)7=(System.Int32)187001, (System.Byte)4=(System.Int32[])System.Int32[], (System.Byte)1=(UnityEngine.Vector3)(-67.08, 12.34, -78.95), (System.Byte)0=(System.String)Player Network Controller
        //[Unity] Event by TROLL123 sent 202 // (System.Byte)6=(System.Int32)-367215820, (System.Byte)7=(System.Int32)188001, (System.Byte)4=(System.Int32[])System.Int32[], (System.Byte)1=(UnityEngine.Vector3)(-65.84, 11.84, -81.03), (System.Byte)0=(System.String)Player Network Controller
        //[Unity] Event by FROSTVR sent 202 // (System.Byte)6=(System.Int32)-367201495, (System.Byte)7=(System.Int32)189001, (System.Byte)4=(System.Int32[])System.Int32[], (System.Byte)1=(UnityEngine.Vector3)(-66.54, 11.92, -78.61), (System.Byte)0=(System.String)Player Network Controller



        public static void SetMasterForRealz()
        {
            GorillaTagger.Instance.myVRRig.RPC("SetOwnershipFromMasterClient", RpcTarget.All, new object[]
            {
                PhotonNetwork.LocalPlayer // D?
            });
            PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer);
        }

        public static void PlrNameChangeGun()
        {
            Physics.Raycast(GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.rightHandTransform.forward, out var Ray);

            GameObject pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            pointer.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
            UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
            pointer.GetComponent<Renderer>().material.shader = UnityEngine.Shader.Find("GUI/Text Shader");
            pointer.GetComponent<Renderer>().material.color = UnityEngine.Color.white;
            pointer.transform.position = Ray.point;

            if (Main.rightTrigger == 1f)
            {
                if (Ray.collider.GetComponentInParent<VRRig>())
                {
                    pointer.GetComponent<Renderer>().material.color = UnityEngine.Color.HSVToRGB(Main.h, 1f, 1f);

                    foreach (var kvp in PhotonNetwork.CurrentRoom.Players)
                    {
                        int playerId = kvp.Key;
                        Photon.Realtime.Player plr = kvp.Value;
                        VRRig plrVRRig = null;
                        // Search through all of the vrrigs in the lobby to find the corresponding one to the player
                        foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                        {
                            if (vrrig.Creator.UserId == plr.UserId)
                            {
                                plrVRRig = vrrig;
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }

                        int temp = plr.ActorNumber;
                        plr.CustomProperties["NickName"] = "DARKMATTER";
                        plr.CustomProperties["NickName"] = PhotonNetwork.LocalPlayer.NickName;
                    }

                }

                GameObject.Destroy(pointer, Time.deltaTime);
            }
            else
            {
                GameObject.Destroy(pointer, Time.deltaTime);
            }
            GameObject.Destroy(pointer, Time.deltaTime);
        }

        public static void ChangeToInfection()
        {
            if (PhotonNetwork.LocalPlayer.IsMasterClient)
            {
                Hashtable hashtable = new Hashtable();
                hashtable.Add("gameMode", "forestDEFAULTMODDED_MODDED_INFECTION");
                PhotonNetwork.CurrentRoom.SetCustomProperties(hashtable, null, null);
                PhotonNetwork.CurrentRoom.LoadBalancingClient.OpSetCustomPropertiesOfRoom(hashtable);
            }
        }

        public static void ChangeToHunt()
        {
            if (PhotonNetwork.LocalPlayer.IsMasterClient)
            {
                Hashtable hashtable = new Hashtable();
                hashtable.Add("gameMode", "forestDEFAULTMODDED_MODDED_HUNT");
                PhotonNetwork.CurrentRoom.SetCustomProperties(hashtable, null, null);
                PhotonNetwork.CurrentRoom.LoadBalancingClient.OpSetCustomPropertiesOfRoom(hashtable);
            }
        }

        public static void ChangeToBattle()
        {
            if (PhotonNetwork.LocalPlayer.IsMasterClient)
            {
                Hashtable hashtable = new Hashtable();
                hashtable.Add("gameMode", "forestDEFAULTMODDED_MODDED_BATTLE");
                PhotonNetwork.CurrentRoom.SetCustomProperties(hashtable, null, null);
                PhotonNetwork.CurrentRoom.LoadBalancingClient.OpSetCustomPropertiesOfRoom(hashtable);
            }
        }

        public static void ChangeToCasual()
        {
            if (PhotonNetwork.LocalPlayer.IsMasterClient)
            {
                Hashtable hashtable = new Hashtable();
                hashtable.Add("gameMode", "forestDEFAULTMODDED_MODDED_CASUAL");
                PhotonNetwork.CurrentRoom.SetCustomProperties(hashtable, null, null);
                PhotonNetwork.CurrentRoom.LoadBalancingClient.OpSetCustomPropertiesOfRoom(hashtable);
            }
        }

        
        public static void Test()
        {
            GorillaGameManager gm = GameObject.FindFirstObjectByType<GorillaGameManager>();
            GorillaFireballControllerManager fm = GameObject.FindFirstObjectByType<GorillaFireballControllerManager>();
            GorillaNot anticheat = GameObject.FindFirstObjectByType<GorillaNot>();
            GorillaTagManager gtam = GameObject.FindFirstObjectByType<GorillaTagManager>();
            GorillaThrowableController gtc = GameObject.FindFirstObjectByType<GorillaThrowableController>();
            GorillaThrowable gt = GameObject.FindFirstObjectByType<GorillaThrowable>();
            GorillaThrowingRock gtr = GameObject.FindFirstObjectByType<GorillaThrowingRock>();
            GorillaTrigger gti = GameObject.FindFirstObjectByType<GorillaTrigger>();
            GorillaTriggerBox gtib = GameObject.FindFirstObjectByType<GorillaTriggerBox>();
            GorillaTurning gturn = GameObject.FindFirstObjectByType<GorillaTurning>();
            GorillaTurningChoice gturnc = GameObject.FindFirstObjectByType<GorillaTurningChoice>();
            GorillaTurnSlider gturns = GameObject.FindFirstObjectByType<GorillaTurnSlider>();
            GorillaWalkingGrab gwg = GameObject.FindFirstObjectByType<GorillaWalkingGrab>();
            GorillaCaveCrystalSetup gccs = GameObject.FindFirstObjectByType<GorillaCaveCrystalSetup>();
            GorillaCaveCrystalVisuals gccv = GameObject.FindFirstObjectByType<GorillaCaveCrystalVisuals>();
            GorillaColor gc = GameObject.FindFirstObjectByType<GorillaColor>();
            GorillaColorizableBase gcb = GameObject.FindFirstObjectByType<GorillaColorizableBase>();
            GorillaColorizableParticle gcp = GameObject.FindFirstObjectByType<GorillaColorizableParticle>();
            GorillaColorSlider gcs = GameObject.FindFirstObjectByType<GorillaColorSlider>();
            GorillaComputer gcomputer = GameObject.FindFirstObjectByType<GorillaComputer>();
            GorillaComputerTerminal gcomputerterminal = GameObject.FindFirstObjectByType<GorillaComputerTerminal>();
            GorillaCTFUI gCTFUI = GameObject.FindFirstObjectByType<GorillaCTFUI>();
            GorillaDayNight gdn = GameObject.FindFirstObjectByType<GorillaDayNight>();
            GorillaDebugUI gdui = GameObject.FindFirstObjectByType<GorillaDebugUI>();
            GorillaDevButton gdb = GameObject.FindFirstObjectByType<GorillaDevButton>();
            GorillaEnemyAI geai = GameObject.FindFirstObjectByType<GorillaEnemyAI>();
            GorillaEnemySpawner ges = GameObject.FindFirstObjectByType<GorillaEnemySpawner>();
            GorillaEyeExpressions gee = GameObject.FindFirstObjectByType<GorillaEyeExpressions>();
            GorillaFireball gf = GameObject.FindFirstObjectByType<GorillaFireball>();
            GorillaFlagSpawn gfs = GameObject.FindFirstObjectByType<GorillaFlagSpawn>();
            GorillaFriendCollider gfc = GameObject.FindFirstObjectByType<GorillaFriendCollider>();
            GorillaGeoHideShowTrigger gghst = GameObject.FindFirstObjectByType<GorillaGeoHideShowTrigger>();
            GorillaGrabber gg = GameObject.FindFirstObjectByType<GorillaGrabber>();
            GorillaHandHistory ghh = GameObject.FindFirstObjectByType<GorillaHandHistory>();
            GorillaHasUITransformFollow ghhuitf = GameObject.FindFirstObjectByType<GorillaHasUITransformFollow>();
            GorillaHatButton ghb = GameObject.FindFirstObjectByType<GorillaHatButton>();
            GorillaHatButtonParent gbhp = GameObject.FindFirstObjectByType<GorillaHatButtonParent>();
            GorillaHeadset gh = GameObject.FindFirstObjectByType<GorillaHeadset>();
            GorillaHuntComputer ghc = GameObject.FindFirstObjectByType<GorillaHuntComputer>();
            GorillaHuntManager ghm = GameObject.FindFirstObjectByType<GorillaHuntManager>();
            GorillaIK gik = GameObject.FindFirstObjectByType<GorillaIK>();
            GorillaIKHandTarget gikht = GameObject.FindFirstObjectByType<GorillaIKHandTarget>();
            GorillaIKMgr gikm = GameObject.FindFirstObjectByType<GorillaIKMgr>();
            GorillaJoinTeamBox gjtb = GameObject.FindFirstObjectByType<GorillaJoinTeamBox>();
            GorillaKeyboardButton gkb = GameObject.FindFirstObjectByType<GorillaKeyboardButton>();
            GorillaLevelScreen gls = GameObject.FindFirstObjectByType<GorillaLevelScreen>();
            GorillaLightmapData gld = GameObject.FindFirstObjectByType<GorillaLightmapData>();
            GorillaMetaReport gmr = GameObject.FindFirstObjectByType<GorillaMetaReport>();
            GorillaModeSelector gms = GameObject.FindFirstObjectByType<GorillaModeSelector>();
            GorillaMouthFlap gmf = GameObject.FindFirstObjectByType<GorillaMouthFlap>();
            Gorillanalytics ga = GameObject.FindFirstObjectByType<Gorillanalytics>();
            GorillaNameManager gnm = GameObject.FindFirstObjectByType<GorillaNameManager>();
            GorillaNetworkDisconnectTrigger gndt = GameObject.FindFirstObjectByType<GorillaNetworkDisconnectTrigger>();
            GorillaNetworkJoinTrigger gnjt = GameObject.FindFirstObjectByType<GorillaNetworkJoinTrigger>();
            GorillaNetworkLeaveTutorialTrigger gnltt = GameObject.FindFirstObjectByType<GorillaNetworkLeaveTutorialTrigger>();
            GorillaNetworkLobbyJoinTrigger gnljt = GameObject.FindFirstObjectByType<GorillaNetworkLobbyJoinTrigger>();
            GorillaNetworkPublicTestJoin2 gnptj = GameObject.FindFirstObjectByType<GorillaNetworkPublicTestJoin2>();
            GorillaNetworkPublicTestsJoin gnptestsj = GameObject.FindFirstObjectByType<GorillaNetworkPublicTestsJoin>();
            GorillaParent gp = GameObject.FindFirstObjectByType<GorillaParent>();
            GorillaPlayerCounter gpc = GameObject.FindFirstObjectByType<GorillaPlayerCounter>();
            GorillaPlayerLineButton gplb = GameObject.FindFirstObjectByType<GorillaPlayerLineButton>();
            GorillaPlayerScoreboardLine gpsl = GameObject.FindFirstObjectByType<GorillaPlayerScoreboardLine>();
            GorillaPlaySpace gps = GameObject.FindFirstObjectByType<GorillaPlaySpace>();
            GorillaPlaySpaceForces gpsf = GameObject.FindFirstObjectByType<GorillaPlaySpaceForces>();
            GorillaPressableButton gpb = GameObject.FindFirstObjectByType<GorillaPressableButton>();
            GorillaQuitBox gqb = GameObject.FindFirstObjectByType<GorillaQuitBox>();
            GorillaReportButton grb = GameObject.FindFirstObjectByType<GorillaReportButton>();
            GorillaSceneCamera gsc = GameObject.FindFirstObjectByType<GorillaSceneCamera>();
            GorillaScoreBoard gsb = GameObject.FindFirstObjectByType<GorillaScoreBoard>();
            GorillaScoreboardSpawner gss = GameObject.FindFirstObjectByType<GorillaScoreboardSpawner>();
            GorillaScoreboardTotalUpdater gstu = GameObject.FindFirstObjectByType<GorillaScoreboardTotalUpdater>();
            GorillaScoreCounter gscorec = GameObject.FindFirstObjectByType<GorillaScoreCounter>();
            GorillaServer gs = GameObject.FindFirstObjectByType<GorillaServer>();
            GorillaSetZoneTrigger gszt = GameObject.FindFirstObjectByType<GorillaSetZoneTrigger>();
            GorillaSkin gskin = GameObject.FindFirstObjectByType<GorillaSkin>();
            GorillaSkinCatalog gskinc = GameObject.FindFirstObjectByType<GorillaSkinCatalog>();
            GorillaSkinToggle gskint = GameObject.FindFirstObjectByType<GorillaSkinToggle>();
            GorillaSpeakerLoudness gsl = GameObject.FindFirstObjectByType<GorillaSpeakerLoudness>();
            GorillaSurfaceOverride gso = GameObject.FindFirstObjectByType<GorillaSurfaceOverride>();
            GorillaTagger gtagger = GameObject.FindFirstObjectByType<GorillaTagger>();
            GorillaClimbable gclimb = GameObject.FindFirstObjectByType<GorillaClimbable>();
            GorillaClimbableRef gclimbr = GameObject.FindFirstObjectByType<GorillaClimbableRef>();
            GorillaRopeSegment grs = GameObject.FindFirstObjectByType<GorillaRopeSegment>();
            GorillaRopeSwing grswing = GameObject.FindFirstObjectByType<GorillaRopeSwing>();
            GorillaRopeSwingSettings grswings = GameObject.FindFirstObjectByType<GorillaRopeSwingSettings>();
            GorillaRopeSwingUpdateManager grswingum = GameObject.FindFirstObjectByType<GorillaRopeSwingUpdateManager>();
            GorillaZipline gzip = GameObject.FindFirstObjectByType<GorillaZipline>();
            GorillaZiplineSegment gzips = GameObject.FindFirstObjectByType<GorillaZiplineSegment>();
            GorillaZiplineSettings gzipsettings = GameObject.FindFirstObjectByType<GorillaZiplineSettings>();

        }

        public static void AntiFireball()
        {
            foreach (GorillaFireballControllerManager fm in GameObject.FindObjectsOfType<GorillaFireballControllerManager>())
            {
                fm.hasInitialized = false;
                fm.throwingThreshold = 0f;
            }
        }


        

        public static void SolidPlayersOopsNoLiverForYouAnymoreWompWomp()
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (vrrig.Creator.UserId != PhotonNetwork.LocalPlayer.UserId)
                {
                    Vector3 offset = new Vector3(0f, -0.1f, 0f);
                    GameObject box = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    UnityEngine.Object.Destroy(box.GetComponent<Renderer>());
                    box.transform.localScale = new Vector3(0.4f, 0.7f, 0.3f);
                    box.transform.position = vrrig.transform.position + offset;
                    box.transform.rotation = vrrig.transform.rotation;
                    GorillaSurfaceOverride surface = box.AddComponent<GorillaSurfaceOverride>();
                    surface.overrideIndex = 204;
                    //SnowballThrowable component = GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.L/upper_arm.L/forearm.L/hand.L/palm.01.L/TransferrableItemLeftHand/" + "WaterBalloon" + "LeftAnchor").transform.Find("WaterBalloon").GetComponent<SnowballThrowable>();
                    //component.randomizeColor = true;
                    //component.GetComponent<Renderer>().material.color = new Color32(138, 3, 3, 255);
                    GorillaTagger.Instance.offlineVRRig.LeftThrowableProjectileColor = new Color32(138, 3, 3, 255);
                    GorillaTagger.Instance.offlineVRRig.RightThrowableProjectileColor = new Color32(138, 3, 3, 255);
                    GameObject.Destroy(box, Time.deltaTime);
                }
            }
        }

        public static void SolidPlayersOopsNoHeartForYouAnymoreWompWomp()
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (vrrig.Creator.UserId != PhotonNetwork.LocalPlayer.UserId)
                {
                    Vector3 offset = new Vector3(0f, -0.1f, 0f);
                    GameObject box = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    UnityEngine.Object.Destroy(box.GetComponent<Renderer>());
                    box.transform.localScale = new Vector3(0.4f, 0.7f, 0.3f);
                    box.transform.position = vrrig.transform.position + offset;
                    box.transform.rotation = vrrig.transform.rotation;
                    GorillaSurfaceOverride surface = box.AddComponent<GorillaSurfaceOverride>();
                    surface.overrideIndex = 32;
                    //SnowballThrowable component = GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.L/upper_arm.L/forearm.L/hand.L/palm.01.L/TransferrableItemLeftHand/" + "Snowball" + "LeftAnchor").transform.Find("Snowball").GetComponent<SnowballThrowable>();
                    //component.randomizeColor = true;
                    //component.GetComponent<Renderer>().material.color = new Color32(220, 20, 60, 255);
                    GorillaTagger.Instance.offlineVRRig.LeftThrowableProjectileColor = new Color32(220, 20, 60, 255);
                    GorillaTagger.Instance.offlineVRRig.RightThrowableProjectileColor = new Color32(220, 20, 60, 255);
                    GameObject.Destroy(box, Time.deltaTime);
                }
            }
        }

        public static void NoSlippyWallsCuzUrSigmaWallClimber()
        {
            
        }

        public static void FixNoSlip()
        {
            GorillaLocomotion.Player.Instance.rightHandSlide = true;
            GorillaLocomotion.Player.Instance.leftHandSlide = true;
        }

        

        


        

        /*
        public static void CrashGun()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                GameObject NewPointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                Physics.Raycast(GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.rightHandTransform.forward, out var Ray);

                {
                    NewPointer.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                    NewPointer.GetComponent<Renderer>().material.color = Color.black / 20;
                    NewPointer.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                    NewPointer.transform.position = isCopying ? whoCopy.transform.position : Ray.point;
                    UnityEngine.Object.Destroy(NewPointer.GetComponent<BoxCollider>());
                    UnityEngine.Object.Destroy(NewPointer.GetComponent<Rigidbody>());
                    UnityEngine.Object.Destroy(NewPointer.GetComponent<Collider>());
                    

                    GameObject line = new GameObject("Line");
                    LineRenderer liner = line.AddComponent<LineRenderer>();
                    liner.material.shader = Shader.Find("GUI/Text Shader");
                    liner.startColor = Color.black / 20;
                    liner.endColor = Color.black / 20;
                    liner.startWidth = 0.231f;
                    liner.endWidth = 0.300f;
                    liner.positionCount = 5;
                    liner.useWorldSpace = true;
                    liner.SetPosition(0, GorillaTagger.Instance.rightHandTransform.position);
                    liner.SetPosition(1, isCopying ? whoCopy.transform.position : Ray.point);
                    UnityEngine.Object.Destroy(NewPointer.gameObject.GetComponent<SphereCollider>());
                    UnityEngine.Object.Destroy(NewPointer, Time.deltaTime);
                    UnityEngine.Object.Destroy(liner.gameObject.GetComponent<LineRenderer>());
                    UnityEngine.Object.Destroy(liner, Time.deltaTime);
                }
                if (ControllerInputPoller.instance.rightControllerIndexTouch > 0f)
                {
                    if (PhotonNetwork.IsConnected)
                    {
                        if (PhotonNetwork.IsMasterClient)
                        {
                            Hashtable hashtable = new Hashtable();
                            hashtable[(byte)0] = -1;

                            int num2 = RigShit.GetPhotonViewFromVRRig(RigShit.GetRandomVRRig(false)).GetHashCode();
                            Hashtable ServerCleanDestroyEvent = new Hashtable();
                            RaiseEventOptions ServerCleanOptions = new RaiseEventOptions
                            {
                                CachingOption = EventCaching.RemoveFromRoomCache
                            };
                            ServerCleanDestroyEvent[0] = num2;
                            ServerCleanOptions.CachingOption = EventCaching.AddToRoomCache;
                            PhotonNetwork.NetworkingClient.OpRaiseEvent(204, hashtable, null, SendOptions.SendUnreliable);
                            PhotonNetwork.NetworkingClient.OpRaiseEvent(202, hashtable, null, SendOptions.SendUnreliable);
                            PhotonNetwork.NetworkingClient.OpRaiseEvent(203, hashtable, null, SendOptions.SendUnreliable);
                            PhotonNetwork.NetworkingClient.Appraisements(207, hashtable, null, SendOptions.SendUnreliable);
                            

                            RPCProtection();
                            NewPointer.GetComponent<Renderer>().material.color = Color.black;
                        }
                    }
                    UnityEngine.Object.Destroy(NewPointer, Time.deltaTime);
                }
                else
                {
                }
                UnityEngine.Object.Destroy(NewPointer, Time.deltaTime);
            }
        }*/

    }

}
