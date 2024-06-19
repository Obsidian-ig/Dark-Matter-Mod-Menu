using HarmonyLib;
using StupidTemplate.Menu;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace StupidTemplate.Mods
{
    internal class OverPowered
    {

        public static async void FlickTagGun()
        {
            Main.GunGameObjectEnabled = true;
            //CoroutineRunner coroutineRunner = new CoroutineRunner();
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

                if (Main.rightTrigger == 1f && Ray.collider.GetComponentInParent<VRRig>())
                {
                    pointer.GetComponent<Renderer>().material.color = UnityEngine.Color.HSVToRGB(Main.h, 1f, 1f);
                    GorillaLocomotion.Player.Instance.rightControllerTransform.position = pointer.transform.position;
                    await Task.Delay(400);
                    Main.rightTrigger = 0f;
                    GameObject.Destroy(pointer, Time.deltaTime);
                }
                else
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = true;
                    GameObject.Destroy(pointer, Time.deltaTime);
                }
                GameObject.Destroy(pointer, Time.deltaTime);
            }
        }

        public static async void TagGun()
        {
            Main.GunGameObjectEnabled = true;
            //CoroutineRunner coroutineRunner = new CoroutineRunner();
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

                if (Main.rightTrigger == 1f && Ray.collider.GetComponentInParent<VRRig>())
                {
                    Vector3 originPos = GorillaLocomotion.Player.Instance.transform.position;
                    pointer.GetComponent<Renderer>().material.color = UnityEngine.Color.HSVToRGB(Main.h, 1f, 1f);
                    GorillaTagger.Instance.offlineVRRig.enabled = false;
                    GorillaTagger.Instance.offlineVRRig.transform.position = pointer.transform.position + new Vector3(1f, 1f, 1f);
                    try
                    {
                        GorillaTagger.Instance.myVRRig.transform.position = pointer.transform.position;
                    } catch (Exception) { }

                    GameObject.Destroy(pointer, Time.deltaTime);
                    GorillaLocomotion.Player.Instance.rightControllerTransform.position = pointer.transform.position;
                    await Task.Delay(15);
                    GorillaLocomotion.Player.Instance.transform.position = pointer.transform.position - new Vector3(pointer.transform.position.x/2, pointer.transform.position.y / 2, pointer.transform.position.z / 2);
                    await Task.Delay(15);
                    GorillaLocomotion.Player.Instance.transform.position = originPos;             
                    await Task.Delay(15);
                    GameObject.Destroy(pointer, Time.deltaTime);
                }
                else
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = true;
                    GameObject.Destroy(pointer, Time.deltaTime);
                }
                GameObject.Destroy(pointer, Time.deltaTime);
            }
        }

        public static VRRig[] excludedPlrs = new VRRig[] { };
        public static bool canTag = true;
        public static async void TagAll()
        {
            if (Main.rightTrigger == 1f)
            {
                Vector3 originPos = GorillaLocomotion.Player.Instance.transform.position;
                foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                {
                    if (!vrrig.mainSkin.material.name.Contains("fected"))
                    {
                        foreach (VRRig vrrig2 in excludedPlrs)
                        {
                            if (vrrig2 == vrrig)
                            {
                                canTag = false;
                            }
                        }

                        if (canTag)
                        {
                            GorillaTagger.Instance.offlineVRRig.enabled = false;
                            GorillaTagger.Instance.rightHandTransform.position = vrrig.transform.position;
                            GorillaTagger.Instance.offlineVRRig.rightHandTransform.position = vrrig.transform.position;
                            GorillaTagger.Instance.offlineVRRig.transform.position = vrrig.transform.position;
                            try
                            {
                                GorillaTagger.Instance.myVRRig.transform.position = vrrig.transform.position;
                            }
                            catch (Exception) { }

                            GorillaLocomotion.Player.Instance.transform.position = vrrig.transform.position - new Vector3(vrrig.transform.position.x / 3, vrrig.transform.position.y / 3, vrrig.transform.position.z / 3);
                            await Task.Delay(50);
                            GorillaLocomotion.Player.Instance.transform.position = originPos;
                            excludedPlrs.AddItem<VRRig>(vrrig);
                            GorillaTagger.Instance.offlineVRRig.enabled = true;
                        }
                        else
                        {
                            canTag = true;
                            GorillaTagger.Instance.offlineVRRig.enabled = true;
                            continue;
                        }
                    } else
                    {
                        continue;
                    }
                }
            }
        }

        public static async void TestTagAll()
        {
            if (Main.rightTrigger == 1f)
            {
                TagAura();
                Vector3 originPos = GorillaLocomotion.Player.Instance.transform.position;
                foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                {
                    if (!vrrig.mainSkin.material.name.Contains("fected"))
                    {
                        foreach (MeshCollider col in UnityEngine.Object.FindObjectsOfType<MeshCollider>())
                        {
                            //col.enabled = false;
                        }
                        GorillaTagger.Instance.offlineVRRig.enabled = false;
                        GorillaTagger.Instance.rightHandTransform.position = vrrig.transform.position;
                        try
                        {
                            GorillaTagger.Instance.myVRRig.transform.position = vrrig.transform.position;
                        }
                        catch (Exception) { }
                        GorillaLocomotion.Player.Instance.transform.position = vrrig.transform.position - new Vector3(vrrig.transform.position.x / 1.5f, vrrig.transform.position.y / 1.5f, vrrig.transform.position.z / 1.5f);
                        await Task.Delay(100);
                        GorillaTagger.Instance.offlineVRRig.rightHandTransform.position = vrrig.transform.position;
                        GorillaTagger.Instance.offlineVRRig.transform.position = vrrig.transform.position;

                        await Task.Delay(50);
                        GorillaLocomotion.Player.Instance.transform.position = originPos;
                        excludedPlrs.AddItem<VRRig>(vrrig);
                        foreach (MeshCollider col in UnityEngine.Object.FindObjectsOfType<MeshCollider>())
                        {
                            //col.enabled = true;
                        }
                        GorillaTagger.Instance.offlineVRRig.enabled = true;
                    } else
                    {
                        continue;
                    }
                }
            }
        }

        public static async void TagAura()
        {
            if (Main.rightGrab)
            {
                foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                {
                    if (!vrrig.mainSkin.material.name.Contains("fected"))
                    {
                        if (Vector3.Distance(GorillaTagger.Instance.offlineVRRig.transform.position, vrrig.transform.position) < 3.5)
                        {
                            GorillaTagger.Instance.offlineVRRig.enabled = false;
                            GorillaTagger.Instance.offlineVRRig.transform.position = vrrig.transform.position;
                            try
                            {
                                GorillaTagger.Instance.myVRRig.transform.position = vrrig.transform.position;
                            }
                            catch (Exception) { }
                            await Task.Delay(100);
                            GorillaTagger.Instance.rightHandTransform.position = vrrig.transform.position;
                            GorillaTagger.Instance.offlineVRRig.rightHandTransform.position = vrrig.transform.position;
                            GorillaLocomotion.Player.Instance.rightControllerTransform.position = vrrig.transform.position;
                            await Task.Delay(100);
                            GorillaTagger.Instance.offlineVRRig.enabled = true;
                        }
                    } else
                    {
                        continue;
                    }
                }
            }
        }


        public static void TagSelf()
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (vrrig.mainSkin.material.name.Contains("fected"))
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = false;
                    GorillaTagger.Instance.offlineVRRig.transform.position = vrrig.transform.position;
                    GorillaTagger.Instance.myVRRig.transform.position = vrrig.transform.position;
                    GorillaLocomotion.Player.Instance.transform.position = vrrig.transform.position;
                }
            }
            GorillaTagger.Instance.offlineVRRig.enabled = true;
        }

    }
}
