using Photon.Pun;
using Photon.Realtime;
using StupidTemplate.Menu;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.XR;

namespace StupidTemplate.Mods
{
    public class Master
    {
        public static async void MatSpamAll()
        {
            if (PhotonNetwork.LocalPlayer.IsMasterClient)
            {
                foreach (GorillaTagManager gtagm in UnityEngine.Object.FindObjectsOfType<GorillaTagManager>())
                {
                    await Task.Delay(50);
                    gtagm.ClearInfectionState();
                    gtagm.currentInfected.Clear();
                    foreach (Photon.Realtime.Player plr in PhotonNetwork.PlayerList)
                    {
                        gtagm.AddInfectedPlayer(plr);
                        await Task.Delay(50);
                    }
                }
            }
        }

        public static async void MatSpamSelf()
        {
            if (PhotonNetwork.LocalPlayer.IsMasterClient)
            {
                foreach (GorillaTagManager gtagm in UnityEngine.Object.FindObjectsOfType<GorillaTagManager>())
                {
                    gtagm.currentInfected.Remove(PhotonNetwork.LocalPlayer);
                    await Task.Delay(50);
                    gtagm.currentInfected.Add(PhotonNetwork.LocalPlayer);
                    await Task.Delay(50);
                }
            }
        }

        public static void SlowOthers()
        {
            if (PhotonNetwork.LocalPlayer.IsMasterClient)
            {
                foreach (GorillaTagManager gtagm in UnityEngine.Object.FindObjectsOfType<GorillaTagManager>())
                {
                    foreach (Photon.Realtime.Player plr in PhotonNetwork.PlayerList)
                    {
                        if (plr != PhotonNetwork.LocalPlayer)
                        {
                            GorillaTagger.Instance.myVRRig.RPC("SetTaggedTime", plr, null);
                            
                        }
                    }
                }
            }
        }

        public static async void SlowGun()
        {
            if (Main.rightGrab)
            {
                if (!Main.slowGunLocked)
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

                        if (PhotonNetwork.LocalPlayer.IsMasterClient && Ray.collider.GetComponentInParent<VRRig>() != null)
                        {
                            Main.plrToLockOn = Ray.collider.GetComponentInParent<VRRig>();
                            Main.slowGunLocked = true;

                            Player plr = RigManager.GetPhotonViewFromVRRig(Ray.collider.GetComponentInParent<VRRig>()).Owner;
                            GorillaTagger.Instance.myVRRig.RPC("SetTaggedTime", plr, null);
                            Sounds.RPCProtection();
                            Experimental.AntiRpc();
                            await Task.Delay(350);
                        }

                    }
                    GameObject.Destroy(pointer, Time.deltaTime);
                }

                if (Main.slowGunLocked && Main.plrToLockOn != null)
                {
                    if (PhotonNetwork.LocalPlayer.IsMasterClient)
                    {
                        Player plr = RigManager.GetPhotonViewFromVRRig(Main.plrToLockOn).Owner;
                        GorillaTagger.Instance.myVRRig.RPC("SetTaggedTime", plr, null);
                        Sounds.RPCProtection();
                        Experimental.AntiRpc();
                        await Task.Delay(350);
                    }
                }
            }
        }

        public static async void GiveSlowGun()
        {
            if (Main.rightGrab)
            {
                if (!Main.giveSlowGunLocked)
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

                        if (PhotonNetwork.LocalPlayer.IsMasterClient && Ray.collider.GetComponentInParent<VRRig>() != null)
                        {
                            Main.plrToLockOn = Ray.collider.GetComponentInParent<VRRig>();
                            Main.giveSlowGunLocked = true;
                        }

                    }
                    GameObject.Destroy(pointer, Time.deltaTime);
                }

                if (Main.giveSlowGunLocked && Main.plrToLockOn != null)
                {
                    if (PhotonNetwork.LocalPlayer.IsMasterClient)
                    {
                        VRRig plr = Main.plrToLockOn;
                        if (plr.rightMiddle.gripValue == 1f)
                        {
                            Physics.Raycast(plr.rightHandTransform.position, plr.rightHandTransform.forward, out var Ray);

                            GameObject pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                            pointer.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                            UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                            UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                            pointer.GetComponent<Renderer>().material.shader = UnityEngine.Shader.Find("GUI/Text Shader");
                            pointer.GetComponent<Renderer>().material.color = UnityEngine.Color.white;
                            pointer.transform.position = Ray.point;
                            GameObject.Destroy(pointer, Time.deltaTime);

                            if (plr.rightIndex.triggerValue == 1f)
                            {
                                if (PhotonNetwork.LocalPlayer.IsMasterClient && Ray.collider.GetComponentInParent<VRRig>() != null)
                                {
                                    Player plr2 = RigManager.GetPhotonViewFromVRRig(Ray.collider.GetComponentInParent<VRRig>()).Owner;
                                    GorillaTagger.Instance.myVRRig.RPC("SetTaggedTime", plr2, null);
                                    Sounds.RPCProtection();
                                    Experimental.AntiRpc();
                                    await Task.Delay(350);
                                }
                                GameObject.Destroy(pointer, Time.deltaTime);
                            }
                        }
                    }
                }
            }
            else
            {
                Main.giveSlowGunLocked = false;
                Main.plrToLockOn = null;
            }
        }

        public static void VibrateOthers()
        {
            if (PhotonNetwork.LocalPlayer.IsMasterClient)
            {
                foreach (GorillaTagManager gtagm in UnityEngine.Object.FindObjectsOfType<GorillaTagManager>())
                {
                    foreach (Photon.Realtime.Player plr in PhotonNetwork.PlayerList)
                    {
                        if (plr != PhotonNetwork.LocalPlayer)
                        {
                            GorillaTagger.Instance.myVRRig.RPC("SetJoinTaggedTime", plr, null);
                        }
                    }
                }
            }
        }

        public static async void VibrateGun()
        {
            if (Main.rightGrab)
            {
                if (!Main.vibrateGunLocked)
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

                        if (PhotonNetwork.LocalPlayer.IsMasterClient && Ray.collider.GetComponentInParent<VRRig>() != null)
                        {
                            Main.plrToLockOn = Ray.collider.GetComponentInParent<VRRig>();
                            Main.vibrateGunLocked = true;

                            Player plr = RigManager.GetPhotonViewFromVRRig(Ray.collider.GetComponentInParent<VRRig>()).Owner;
                            GorillaTagger.Instance.myVRRig.RPC("SetJoinTaggedTime", plr, null);
                            Sounds.RPCProtection();
                            Experimental.AntiRpc();
                            await Task.Delay(350);
                        }
                        GameObject.Destroy(pointer, Time.deltaTime);
                    }
                }

                if (Main.vibrateGunLocked && Main.plrToLockOn != null)
                {
                    if (PhotonNetwork.LocalPlayer.IsMasterClient)
                    {
                        Player plr = RigManager.GetPhotonViewFromVRRig(Main.plrToLockOn).Owner;
                        GorillaTagger.Instance.myVRRig.RPC("SetJoinTaggedTime", plr, null);
                        Sounds.RPCProtection();
                        Experimental.AntiRpc();
                        await Task.Delay(350);
                    }
                }
            }
        }

        public static async void GiveVibrateGun()
        {
            if (Main.rightGrab)
            {
                if (!Main.giveVibrateGunLocked)
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

                        if (PhotonNetwork.LocalPlayer.IsMasterClient && Ray.collider.GetComponentInParent<VRRig>() != null)
                        {
                            Main.plrToLockOn = Ray.collider.GetComponentInParent<VRRig>();
                            Main.giveVibrateGunLocked = true;
                        }

                    }
                    GameObject.Destroy(pointer, Time.deltaTime);
                }

                if (Main.giveVibrateGunLocked && Main.plrToLockOn != null)
                {
                    if (PhotonNetwork.LocalPlayer.IsMasterClient)
                    {
                        VRRig plr = Main.plrToLockOn;
                        if (plr.rightMiddle.gripValue == 1f)
                        {
                            Physics.Raycast(plr.rightHandTransform.position, plr.rightHandTransform.forward, out var Ray);

                            GameObject pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                            pointer.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                            UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                            UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                            pointer.GetComponent<Renderer>().material.shader = UnityEngine.Shader.Find("GUI/Text Shader");
                            pointer.GetComponent<Renderer>().material.color = UnityEngine.Color.white;
                            pointer.transform.position = Ray.point;
                            GameObject.Destroy(pointer, Time.deltaTime);

                            if (plr.rightIndex.triggerValue == 1f)
                            {
                                if (PhotonNetwork.LocalPlayer.IsMasterClient && Ray.collider.GetComponentInParent<VRRig>() != null)
                                {
                                    Player plr2 = RigManager.GetPhotonViewFromVRRig(Ray.collider.GetComponentInParent<VRRig>()).Owner;
                                    GorillaTagger.Instance.myVRRig.RPC("SetJoinTaggedTime", plr2, null);
                                    Sounds.RPCProtection();
                                    Experimental.AntiRpc();
                                    await Task.Delay(350);
                                }
                                GameObject.Destroy(pointer, Time.deltaTime);
                            }
                        }
                    }
                }
            }
            else
            {
                Main.giveVibrateGunLocked = false;
                Main.plrToLockOn = null;
            }
        }

        public static void TagSelf()
        {
            if (PhotonNetwork.LocalPlayer.IsMasterClient)
            {
                foreach (GorillaTagManager gtagm in UnityEngine.Object.FindObjectsOfType<GorillaTagManager>())
                {
                    if (!gtagm.currentInfected.Contains(PhotonNetwork.LocalPlayer))
                    {
                        gtagm.currentInfected.Add(PhotonNetwork.LocalPlayer);
                    }
                }
            }
        }

        public static void UntagSelf()
        {
            if (PhotonNetwork.LocalPlayer.IsMasterClient)
            {
                foreach (GorillaTagManager gtagm in UnityEngine.Object.FindObjectsOfType<GorillaTagManager>())
                {
                    if (gtagm.currentInfected.Contains(PhotonNetwork.LocalPlayer))
                    {
                        gtagm.currentInfected.Remove(PhotonNetwork.LocalPlayer);
                    }
                }
            }
        }

        public static async void MatSpamGun()
        {
            if (Main.rightGrab)
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

                    if (PhotonNetwork.LocalPlayer.IsMasterClient)
                    {
                        foreach (GorillaTagManager gtagm in UnityEngine.Object.FindObjectsOfType<GorillaTagManager>())
                        {
                            foreach (Photon.Realtime.Player plr in PhotonNetwork.PlayerList)
                            {
                                if (plr.UserId == Ray.collider.GetComponentInParent<VRRig>().Creator.UserId)
                                {
                                    pointer.GetComponent<Renderer>().material.color = UnityEngine.Color.HSVToRGB(Main.h, 1f, 1f);
                                    await Task.Delay(100);
                                    gtagm.currentInfected.Remove(plr);
                                    gtagm.UpdateInfectionState();
                                    gtagm.UpdateState();
                                    await Task.Delay(100);
                                    gtagm.currentInfected.Add(plr);
                                    gtagm.UpdateInfectionState();
                                    gtagm.UpdateState();
                                }
                            }
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
        }

        public static async void GiveMatSpamGun()
        {
            if (Main.rightGrab)
            {
                if (!Main.giveMatSpamGunLocked)
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

                        if (PhotonNetwork.LocalPlayer.IsMasterClient && Ray.collider.GetComponentInParent<VRRig>() != null)
                        {
                            Main.plrToLockOn = Ray.collider.GetComponentInParent<VRRig>();
                            Main.giveMatSpamGunLocked = true;
                        }

                    }
                    GameObject.Destroy(pointer, Time.deltaTime);
                }

                if (Main.giveMatSpamGunLocked && Main.plrToLockOn != null)
                {
                    if (PhotonNetwork.LocalPlayer.IsMasterClient)
                    {
                        VRRig plr = Main.plrToLockOn;
                        if (plr.rightMiddle.gripValue == 1f)
                        {
                            Physics.Raycast(plr.rightHandTransform.position, plr.rightHandTransform.forward, out var Ray);

                            GameObject pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                            pointer.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                            UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                            UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                            pointer.GetComponent<Renderer>().material.shader = UnityEngine.Shader.Find("GUI/Text Shader");
                            pointer.GetComponent<Renderer>().material.color = UnityEngine.Color.white;
                            pointer.transform.position = Ray.point;
                            GameObject.Destroy(pointer, Time.deltaTime);

                            if (plr.rightIndex.triggerValue == 1f)
                            {
                                if (PhotonNetwork.LocalPlayer.IsMasterClient && Ray.collider.GetComponentInParent<VRRig>() != null)
                                {
                                    foreach (GorillaTagManager gtagm in UnityEngine.Object.FindObjectsOfType<GorillaTagManager>())
                                    {
                                        foreach (Photon.Realtime.Player plr3 in PhotonNetwork.PlayerList)
                                        {
                                            if (plr3.UserId == Ray.collider.GetComponentInParent<VRRig>().Creator.UserId)
                                            {
                                                pointer.GetComponent<Renderer>().material.color = UnityEngine.Color.HSVToRGB(Main.h, 1f, 1f);
                                                await Task.Delay(100);
                                                gtagm.currentInfected.Remove(plr3);
                                                gtagm.UpdateInfectionState();
                                                gtagm.UpdateState();
                                                await Task.Delay(100);
                                                gtagm.currentInfected.Add(plr3);
                                                gtagm.UpdateInfectionState();
                                                gtagm.UpdateState();
                                            }
                                        }
                                    }
                                }
                                GameObject.Destroy(pointer, Time.deltaTime);
                            }
                        }
                    }
                }
            }
            else
            {
                Main.giveMatSpamGunLocked = false;
                Main.plrToLockOn = null;
            }
        }

        public static async void ForceTagGun()
        {
            if (Main.rightGrab)
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

                    if (PhotonNetwork.LocalPlayer.IsMasterClient)
                    {
                        foreach (GorillaTagManager gtagm in UnityEngine.Object.FindObjectsOfType<GorillaTagManager>())
                        {
                            foreach (Photon.Realtime.Player plr in PhotonNetwork.PlayerList)
                            {
                                if (plr.UserId == Ray.collider.GetComponentInParent<VRRig>().Creator.UserId)
                                {
                                    pointer.GetComponent<Renderer>().material.color = UnityEngine.Color.HSVToRGB(Main.h, 1f, 1f);
                                    if (!gtagm.currentInfected.Contains(plr))
                                    {
                                        gtagm.currentInfected.Add(plr);
                                    }
                                    await Task.Delay(100);
                                    GameObject.Destroy(pointer, Time.deltaTime);
                                }
                                else
                                {
                                    GameObject.Destroy(pointer, Time.deltaTime);
                                }
                            }
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
        }

        public static async void ForceUntagGun()
        {
            if (Main.rightGrab)
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

                    if (PhotonNetwork.LocalPlayer.IsMasterClient)
                    {
                        foreach (GorillaTagManager gtagm in UnityEngine.Object.FindObjectsOfType<GorillaTagManager>())
                        {
                            foreach (Photon.Realtime.Player plr in PhotonNetwork.PlayerList)
                            {
                                if (plr.UserId == Ray.collider.GetComponentInParent<VRRig>().Creator.UserId)
                                {
                                    pointer.GetComponent<Renderer>().material.color = UnityEngine.Color.HSVToRGB(Main.h, 1f, 1f);
                                    if (gtagm.currentInfected.Contains(plr))
                                    {
                                        gtagm.currentInfected.Remove(plr);
                                    }
                                    await Task.Delay(100);
                                }
                            }
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
        }

        public static async void ForceTagAll()
        {
            if (PhotonNetwork.LocalPlayer.IsMasterClient)
            {
                foreach (GorillaTagManager gtagm in UnityEngine.Object.FindObjectsOfType<GorillaTagManager>())
                {
                    foreach (Photon.Realtime.Player plr in PhotonNetwork.PlayerList)
                    {
                        if (!gtagm.currentInfected.Contains(plr))
                        {
                            gtagm.currentInfected.Add(plr);
                            await Task.Delay(100);
                        }
                    }
                }
            }
        }

        public static async void ForceUntagAll()
        {
            if (PhotonNetwork.LocalPlayer.IsMasterClient)
            {
                foreach (GorillaTagManager gtagm in UnityEngine.Object.FindObjectsOfType<GorillaTagManager>())
                {
                    foreach (Photon.Realtime.Player plr in PhotonNetwork.PlayerList)
                    {
                        if (gtagm.currentInfected.Contains(plr))
                        {
                            gtagm.currentInfected.Remove(plr);
                            await Task.Delay(100);
                        }
                    }
                }
            }
        }

        public static async void ForceTagAura()
        {
            if (Main.rightGrab)
            {
                if (PhotonNetwork.LocalPlayer.IsMasterClient)
                {
                    foreach (GorillaTagManager gtagm in UnityEngine.Object.FindObjectsOfType<GorillaTagManager>())
                    {
                        foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                        {
                            if (Vector3.Distance(GorillaTagger.Instance.offlineVRRig.transform.position, vrrig.transform.position) <= 2.5f)
                            {
                                foreach (Photon.Realtime.Player plr in PhotonNetwork.PlayerList)
                                {
                                    if (plr.UserId == vrrig.Creator.UserId)
                                    {
                                        if (!gtagm.currentInfected.Contains(plr))
                                        {
                                            gtagm.currentInfected.Add(plr);
                                        }
                                    }
                                    await Task.Delay(100);
                                }
                            }
                        }

                    }
                }
            }
        }


        public static async void ForceUntagAura()
        {
            if (Main.leftGrab)
            {
                if (PhotonNetwork.LocalPlayer.IsMasterClient)
                {
                    foreach (GorillaTagManager gtagm in UnityEngine.Object.FindObjectsOfType<GorillaTagManager>())
                    {
                        foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                        {
                            if (Vector3.Distance(GorillaTagger.Instance.offlineVRRig.transform.position, vrrig.transform.position) <= 2.5f)
                            {
                                foreach (Photon.Realtime.Player plr in PhotonNetwork.PlayerList)
                                {
                                    if (plr.UserId == vrrig.Creator.UserId)
                                    {
                                        if (gtagm.currentInfected.Contains(plr))
                                        {
                                            gtagm.currentInfected.Remove(plr);
                                        }
                                    }
                                    await Task.Delay(100);
                                }
                            }
                        }

                    }
                }
            }
        }


        public static void ForceSpawnAsIt()
        {
            if (Main.rightGrab)
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

                    if (PhotonNetwork.LocalPlayer.IsMasterClient)
                    {
                        foreach (GorillaTagManager gtagm in UnityEngine.Object.FindObjectsOfType<GorillaTagManager>())
                        {
                            foreach (Photon.Realtime.Player plr in PhotonNetwork.PlayerList)
                            {
                                if (plr.UserId == Ray.collider.GetComponentInParent<VRRig>().Creator.UserId)
                                {
                                    pointer.GetComponent<Renderer>().material.color = UnityEngine.Color.HSVToRGB(Main.h, 1f, 1f);
                                    Main.plrToAlwaysBeIt = plr;
                                }
                            }
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
        }


        public static void ForceNeverBeIt()
        {
            if (Main.rightGrab)
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

                    if (PhotonNetwork.LocalPlayer.IsMasterClient)
                    {
                        foreach (GorillaTagManager gtagm in UnityEngine.Object.FindObjectsOfType<GorillaTagManager>())
                        {
                            foreach (Photon.Realtime.Player plr in PhotonNetwork.PlayerList)
                            {
                                if (plr.UserId == Ray.collider.GetComponentInParent<VRRig>().Creator.UserId)
                                {
                                    pointer.GetComponent<Renderer>().material.color = UnityEngine.Color.HSVToRGB(Main.h, 1f, 1f);
                                    Main.plrToNeverBeIt = plr;
                                }
                            }
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
        }

        public static void ResetSpawnAsIt()
        {
            Main.plrToAlwaysBeIt = null;
        }

        public static void ResetNeverIt()
        {
            Main.plrToNeverBeIt = null;
        }

        public static void AntiTagSelf()
        {
            if (PhotonNetwork.LocalPlayer.IsMasterClient)
            {
                foreach (GorillaTagManager gtagm in UnityEngine.Object.FindObjectsOfType<GorillaTagManager>())
                {
                    if (gtagm.currentInfected.Contains(PhotonNetwork.LocalPlayer))
                    {
                        gtagm.currentInfected.Remove(PhotonNetwork.LocalPlayer);
                    }
                }
            }
        }

        public static void ForceTagSelf()
        {
            if (PhotonNetwork.LocalPlayer.IsMasterClient)
            {
                foreach (GorillaTagManager gtagm in UnityEngine.Object.FindObjectsOfType<GorillaTagManager>())
                {
                    if (!gtagm.currentInfected.Contains(PhotonNetwork.LocalPlayer))
                    {
                        gtagm.currentInfected.Add(PhotonNetwork.LocalPlayer);
                    }
                }
            }
        }
    }
}
