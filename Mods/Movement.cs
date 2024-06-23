using HarmonyLib;
using Photon.Pun;
using StupidTemplate.Menu;
using StupidTemplate.Notifications;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace StupidTemplate.Mods
{
    public class Movement
    {

        // SPEED BOOST STUFF
        public static void SpeedBoost()
        {
            if (!Main.useGripForSpeedBoost && !Main.useTriggerForSpeedBoost)
            {
                GorillaLocomotion.Player.Instance.maxJumpSpeed = 9f;
                GorillaLocomotion.Player.Instance.jumpMultiplier = 9f;
            }
            else if (Main.useGripForSpeedBoost && !Main.useTriggerForSpeedBoost)
            {
                GripSpeedBoost();
            }
            else if (Main.useTriggerForSpeedBoost && !Main.useGripForSpeedBoost)
            {
                TriggerSpeedBoost();
            }
        }

        public static void MosaSpeed()
        {
            GorillaLocomotion.Player.Instance.maxJumpSpeed = 6.5f;
            GorillaLocomotion.Player.Instance.jumpMultiplier = 2f;
        }

        public static void Dash()
        {
            if (Main.leftPrimary)
            {
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity += GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime * (80);
            }
        }

        public static void GripSpeedBoost()
        {
            if (!Main.useLeftForSpeedBoost)
            {
                if (Main.rightGrab)
                {
                    GorillaLocomotion.Player.Instance.maxJumpSpeed = 9f;
                    GorillaLocomotion.Player.Instance.jumpMultiplier = 9f;
                }
                else
                {
                    GorillaLocomotion.Player.Instance.maxJumpSpeed = 6.5f;
                    GorillaLocomotion.Player.Instance.jumpMultiplier = 1.1f;
                }
            }

            if (Main.useLeftForSpeedBoost)
            {
                if (Main.leftGrab)
                {
                    GorillaLocomotion.Player.Instance.maxJumpSpeed = 9f;
                    GorillaLocomotion.Player.Instance.jumpMultiplier = 9f;
                }
                else
                {
                    GorillaLocomotion.Player.Instance.maxJumpSpeed = 6.5f;
                    GorillaLocomotion.Player.Instance.jumpMultiplier = 1.1f;
                }
            }
        }

        public static void TriggerSpeedBoost()
        {
            if (!Main.useLeftForSpeedBoost)
            {
                if (Main.rightTrigger == 1f)
                {
                    GorillaLocomotion.Player.Instance.maxJumpSpeed = 9f;
                    GorillaLocomotion.Player.Instance.jumpMultiplier = 9f;
                }
                else
                {
                    GorillaLocomotion.Player.Instance.maxJumpSpeed = 6.5f;
                    GorillaLocomotion.Player.Instance.jumpMultiplier = 1.1f;
                }
            }

            if (Main.useLeftForSpeedBoost)
            {
                if (Main.leftTrigger == 1f)
                {
                    GorillaLocomotion.Player.Instance.maxJumpSpeed = 9f;
                    GorillaLocomotion.Player.Instance.jumpMultiplier = 9f;
                }
                else
                {
                    GorillaLocomotion.Player.Instance.maxJumpSpeed = 6.5f;
                    GorillaLocomotion.Player.Instance.jumpMultiplier = 1.1f;
                }
            }
        }

        public static void ToggleUseGripsForSpeedBoost()
        {
            Main.useGripForSpeedBoost = true;
        }

        public static void ToggleUseTriggersForSpeedBoost()
        {
            Main.useGripForSpeedBoost = false;
        }

        public static void ToggleUseNoneForSpeedBoost()
        {
            Main.useGripForSpeedBoost = false;
        }


        public static void ToggleUseLeftForSpeedBoost()
        {
            Main.useLeftForSpeedBoost = true;
        }

        public static void ToggleUseRightForSpeedBoost()
        {
            Main.useLeftForSpeedBoost = false;
        }

        public static void FixSpeed()
        {
            GorillaLocomotion.Player.Instance.maxJumpSpeed = 6.5f;
            GorillaLocomotion.Player.Instance.jumpMultiplier = 1.1f;
        }

        public static void UncapVelocity()
        {
            GorillaLocomotion.Player.Instance.maxJumpSpeed = int.MaxValue;
        }




        // PLATFORM STUFF

        public static GameObject PlacePlatform(Vector3 pos, Quaternion rotation)
        {
            GameObject plat = GameObject.CreatePrimitive(PrimitiveType.Cube);
            plat.transform.localScale = new Vector3(0.025f, 0.3f, 0.4f);
            plat.GetComponent<Renderer>().material.color = UnityEngine.Color.HSVToRGB(Main.h, 1f, 1f);
            plat.transform.position = pos;
            plat.transform.rotation = rotation;
            return plat;
        }

        public static void Platforms()
        {
            if (Main.useGripForPlatforms)
            {
                if (Main.leftGrab)
                {
                    if (Main.Leftplat == null)
                    {
                        if (!Main.createdLeftPlat)
                        {
                            Main.Leftplat = PlacePlatform(GorillaTagger.Instance.leftHandTransform.position, GorillaTagger.Instance.leftHandTransform.rotation);
                            Main.createdLeftPlat = true;
                        }
                        Main.Leftplat.GetComponent<Renderer>().material.color = UnityEngine.Color.HSVToRGB(Main.h, 1f, 1f);
                    }
                }
                else
                {
                    GameObject.Destroy(Main.Leftplat);
                    Main.Leftplat = null;
                    Main.createdLeftPlat = false;
                }

                if (Main.rightGrab)
                {
                    if (Main.Rightplat == null)
                    {
                        if (!Main.createdRightPlat)
                        {
                            Main.Rightplat = PlacePlatform(GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.rightHandTransform.rotation);
                            Main.createdRightPlat = true;
                        }
                        Main.Rightplat.GetComponent<Renderer>().material.color = UnityEngine.Color.HSVToRGB(Main.h, 1f, 1f);
                    }
                }
                else
                {
                    GameObject.Destroy(Main.Rightplat);
                    Main.Rightplat = null;
                    Main.createdRightPlat = false;
                }
            }
            else
            {
                TriggerPlatforms();
            }
        }

        public static void SnowballPlatforms()
        {
            if (true)
            {
                if (Main.leftGrab)
                {
                    if (Main.Leftplat == null)
                    {
                        if (!Main.createdLeftPlat)
                        {
                            Main.Leftplat = PlacePlatform(GorillaTagger.Instance.leftHandTransform.position, GorillaTagger.Instance.leftHandTransform.rotation);
                            Main.createdLeftPlat = true;
                            UnityEngine.Object.Destroy(Main.Leftplat.GetComponent<Renderer>());
                            Main.Leftplat.AddComponent<GorillaSurfaceOverride>().overrideIndex = 32;
                        }
                        Main.Leftplat.GetComponent<Renderer>().material.color = UnityEngine.Color.HSVToRGB(Main.h, 1f, 1f);
                    }
                }
                else
                {
                    GameObject.Destroy(Main.Leftplat);
                    Main.Leftplat = null;
                    Main.createdLeftPlat = false;
                }

                if (Main.rightGrab)
                {
                    if (Main.Rightplat == null)
                    {
                        if (!Main.createdRightPlat)
                        {
                            Main.Rightplat = PlacePlatform(GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.rightHandTransform.rotation);
                            Main.createdRightPlat = true;
                            UnityEngine.Object.Destroy(Main.Rightplat.GetComponent<Renderer>());
                            Main.Rightplat.AddComponent<GorillaSurfaceOverride>().overrideIndex = 32;
                        }
                        Main.Rightplat.GetComponent<Renderer>().material.color = UnityEngine.Color.HSVToRGB(Main.h, 1f, 1f);
                    }
                }
                else
                {
                    GameObject.Destroy(Main.Rightplat);
                    Main.Rightplat = null;
                    Main.createdRightPlat = false;
                }
            }
            else
            {
                TriggerPlatforms();
            }
        }

        public static void WaterBalloonPlatforms()
        {
            if (true)
            {
                if (Main.leftGrab)
                {
                    if (Main.Leftplat == null)
                    {
                        if (!Main.createdLeftPlat)
                        {
                            Main.Leftplat = PlacePlatform(GorillaTagger.Instance.leftHandTransform.position, GorillaTagger.Instance.leftHandTransform.rotation);
                            Main.createdLeftPlat = true;
                            UnityEngine.Object.Destroy(Main.Leftplat.GetComponent<Renderer>());
                            Main.Leftplat.AddComponent<GorillaSurfaceOverride>().overrideIndex = 204;
                        }
                        Main.Leftplat.GetComponent<Renderer>().material.color = UnityEngine.Color.HSVToRGB(Main.h, 1f, 1f);
                    }
                }
                else
                {
                    GameObject.Destroy(Main.Leftplat);
                    Main.Leftplat = null;
                    Main.createdLeftPlat = false;
                }

                if (Main.rightGrab)
                {
                    if (Main.Rightplat == null)
                    {
                        if (!Main.createdRightPlat)
                        {
                            Main.Rightplat = PlacePlatform(GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.rightHandTransform.rotation);
                            Main.createdRightPlat = true;
                            UnityEngine.Object.Destroy(Main.Rightplat.GetComponent<Renderer>());
                            Main.Rightplat.AddComponent<GorillaSurfaceOverride>().overrideIndex = 204;
                        }
                        Main.Rightplat.GetComponent<Renderer>().material.color = UnityEngine.Color.HSVToRGB(Main.h, 1f, 1f);
                    }
                }
                else
                {
                    GameObject.Destroy(Main.Rightplat);
                    Main.Rightplat = null;
                    Main.createdRightPlat = false;
                }
            }
            else
            {
                TriggerPlatforms();
            }
        }

        public static void LavaRockPlatforms()
        {
            if (true)
            {
                if (Main.leftGrab)
                {
                    if (Main.Leftplat == null)
                    {
                        if (!Main.createdLeftPlat)
                        {
                            Main.Leftplat = PlacePlatform(GorillaTagger.Instance.leftHandTransform.position, GorillaTagger.Instance.leftHandTransform.rotation);
                            Main.createdLeftPlat = true;
                            UnityEngine.Object.Destroy(Main.Leftplat.GetComponent<Renderer>());
                            Main.Leftplat.AddComponent<GorillaSurfaceOverride>().overrideIndex = 231;
                        }
                        Main.Leftplat.GetComponent<Renderer>().material.color = UnityEngine.Color.HSVToRGB(Main.h, 1f, 1f);
                    }
                }
                else
                {
                    GameObject.Destroy(Main.Leftplat);
                    Main.Leftplat = null;
                    Main.createdLeftPlat = false;
                }

                if (Main.rightGrab)
                {
                    if (Main.Rightplat == null)
                    {
                        if (!Main.createdRightPlat)
                        {
                            Main.Rightplat = PlacePlatform(GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.rightHandTransform.rotation);
                            Main.createdRightPlat = true;
                            UnityEngine.Object.Destroy(Main.Rightplat.GetComponent<Renderer>());
                            Main.Rightplat.AddComponent<GorillaSurfaceOverride>().overrideIndex = 231;
                        }
                        Main.Rightplat.GetComponent<Renderer>().material.color = UnityEngine.Color.HSVToRGB(Main.h, 1f, 1f);
                    }
                }
                else
                {
                    GameObject.Destroy(Main.Rightplat);
                    Main.Rightplat = null;
                    Main.createdRightPlat = false;
                }
            }
            else
            {
                TriggerPlatforms();
            }
        }

        public static void GiftPlatforms()
        {
            if (true)
            {
                if (Main.leftGrab)
                {
                    if (Main.Leftplat == null)
                    {
                        if (!Main.createdLeftPlat)
                        {
                            Main.Leftplat = PlacePlatform(GorillaTagger.Instance.leftHandTransform.position, GorillaTagger.Instance.leftHandTransform.rotation);
                            Main.createdLeftPlat = true;
                            UnityEngine.Object.Destroy(Main.Leftplat.GetComponent<Renderer>());
                            Main.Leftplat.AddComponent<GorillaSurfaceOverride>().overrideIndex = 240;
                        }
                        Main.Leftplat.GetComponent<Renderer>().material.color = UnityEngine.Color.HSVToRGB(Main.h, 1f, 1f);
                    }
                }
                else
                {
                    GameObject.Destroy(Main.Leftplat);
                    Main.Leftplat = null;
                    Main.createdLeftPlat = false;
                }

                if (Main.rightGrab)
                {
                    if (Main.Rightplat == null)
                    {
                        if (!Main.createdRightPlat)
                        {
                            Main.Rightplat = PlacePlatform(GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.rightHandTransform.rotation);
                            Main.createdRightPlat = true;
                            UnityEngine.Object.Destroy(Main.Rightplat.GetComponent<Renderer>());
                            Main.Rightplat.AddComponent<GorillaSurfaceOverride>().overrideIndex = 240;
                        }
                        Main.Rightplat.GetComponent<Renderer>().material.color = UnityEngine.Color.HSVToRGB(Main.h, 1f, 1f);
                    }
                }
                else
                {
                    GameObject.Destroy(Main.Rightplat);
                    Main.Rightplat = null;
                    Main.createdRightPlat = false;
                }
            }
            else
            {
                TriggerPlatforms();
            }
        }

        public static void ScienceCandyPlatforms()
        {
            if (true)
            {
                if (Main.leftGrab)
                {
                    if (Main.Leftplat == null)
                    {
                        if (!Main.createdLeftPlat)
                        {
                            Main.Leftplat = PlacePlatform(GorillaTagger.Instance.leftHandTransform.position, GorillaTagger.Instance.leftHandTransform.rotation);
                            Main.createdLeftPlat = true;
                            UnityEngine.Object.Destroy(Main.Leftplat.GetComponent<Renderer>());
                            Main.Leftplat.AddComponent<GorillaSurfaceOverride>().overrideIndex = 249;
                        }
                        Main.Leftplat.GetComponent<Renderer>().material.color = UnityEngine.Color.HSVToRGB(Main.h, 1f, 1f);
                    }
                }
                else
                {
                    GameObject.Destroy(Main.Leftplat);
                    Main.Leftplat = null;
                    Main.createdLeftPlat = false;
                }

                if (Main.rightGrab)
                {
                    if (Main.Rightplat == null)
                    {
                        if (!Main.createdRightPlat)
                        {
                            Main.Rightplat = PlacePlatform(GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.rightHandTransform.rotation);
                            Main.createdRightPlat = true;
                            UnityEngine.Object.Destroy(Main.Rightplat.GetComponent<Renderer>());
                            Main.Rightplat.AddComponent<GorillaSurfaceOverride>().overrideIndex = 249;
                        }
                        Main.Rightplat.GetComponent<Renderer>().material.color = UnityEngine.Color.HSVToRGB(Main.h, 1f, 1f);
                    }
                }
                else
                {
                    GameObject.Destroy(Main.Rightplat);
                    Main.Rightplat = null;
                    Main.createdRightPlat = false;
                }
            }
            else
            {
                TriggerPlatforms();
            }
        }

        public static void FishFoodPlatforms()
        {
            if (true)
            {
                if (Main.leftGrab)
                {
                    if (Main.Leftplat == null)
                    {
                        if (!Main.createdLeftPlat)
                        {
                            Main.Leftplat = PlacePlatform(GorillaTagger.Instance.leftHandTransform.position, GorillaTagger.Instance.leftHandTransform.rotation);
                            Main.createdLeftPlat = true;
                            UnityEngine.Object.Destroy(Main.Leftplat.GetComponent<Renderer>());
                            Main.Leftplat.AddComponent<GorillaSurfaceOverride>().overrideIndex = 252;
                        }
                        Main.Leftplat.GetComponent<Renderer>().material.color = UnityEngine.Color.HSVToRGB(Main.h, 1f, 1f);
                    }
                }
                else
                {
                    GameObject.Destroy(Main.Leftplat);
                    Main.Leftplat = null;
                    Main.createdLeftPlat = false;
                }

                if (Main.rightGrab)
                {
                    if (Main.Rightplat == null)
                    {
                        if (!Main.createdRightPlat)
                        {
                            Main.Rightplat = PlacePlatform(GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.rightHandTransform.rotation);
                            Main.createdRightPlat = true;
                            UnityEngine.Object.Destroy(Main.Rightplat.GetComponent<Renderer>());
                            Main.Rightplat.AddComponent<GorillaSurfaceOverride>().overrideIndex = 252;
                        }
                        Main.Rightplat.GetComponent<Renderer>().material.color = UnityEngine.Color.HSVToRGB(Main.h, 1f, 1f);
                    }
                }
                else
                {
                    GameObject.Destroy(Main.Rightplat);
                    Main.Rightplat = null;
                    Main.createdRightPlat = false;
                }
            }
        }

        public static void NoClipPlatforms()
        {
            if (Main.useGripForPlatforms)
            {
                if (Main.leftGrab)
                {
                    NoClip(false);
                    if (Main.Leftplat == null)
                    {
                        if (!Main.createdLeftPlat)
                        {
                            Main.Leftplat = PlacePlatform(GorillaTagger.Instance.leftHandTransform.position, GorillaTagger.Instance.leftHandTransform.rotation);
                            Main.createdLeftPlat = true;
                        }
                        Main.Leftplat.GetComponent<Renderer>().material.color = UnityEngine.Color.HSVToRGB(Main.h, 1f, 1f);
                    }
                }
                else
                {
                    GameObject.Destroy(Main.Leftplat);
                    Main.Leftplat = null;
                    Main.createdLeftPlat = false;
                }

                if (Main.rightGrab)
                {
                    NoClip(false);
                    if (Main.Rightplat == null)
                    {
                        if (!Main.createdRightPlat)
                        {
                            Main.Rightplat = PlacePlatform(GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.rightHandTransform.rotation);
                            Main.createdRightPlat = true;
                        }
                        Main.Rightplat.GetComponent<Renderer>().material.color = UnityEngine.Color.HSVToRGB(Main.h, 1f, 1f);
                    }
                }
                else
                {
                    GameObject.Destroy(Main.Rightplat);
                    Main.Rightplat = null;
                    Main.createdRightPlat = false;
                }

                if (!Main.leftGrab && !Main.rightGrab)
                {
                    DisableNoClip();
                }
            }
            else
            {
                TriggerPlatforms(true);
            }
        }

        public static void TriggerPlatforms(bool useNoclip = false)
        {
            if (Main.leftTrigger == 1f)
            {
                if (useNoclip)
                {
                    NoClip(false);
                }
                if (Main.Leftplat == null)
                {
                    if (!Main.createdLeftPlat)
                    {
                        Main.Leftplat = PlacePlatform(GorillaTagger.Instance.leftHandTransform.position, GorillaTagger.Instance.leftHandTransform.rotation);
                        Main.createdLeftPlat = true;
                    }
                    Main.Leftplat.GetComponent<Renderer>().material.color = UnityEngine.Color.HSVToRGB(Main.h, 1f, 1f);
                }
            }
            else
            {
                GameObject.Destroy(Main.Leftplat);
                Main.Leftplat = null;
                Main.createdLeftPlat = false;
            }

            if (Main.rightTrigger == 1f)
            {
                if (useNoclip)
                {
                    NoClip(false);
                }
                if (Main.Rightplat == null)
                {
                    if (!Main.createdRightPlat)
                    {
                        Main.Rightplat = PlacePlatform(GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.rightHandTransform.rotation);
                        Main.createdRightPlat = true;
                    }
                    Main.Rightplat.GetComponent<Renderer>().material.color = UnityEngine.Color.HSVToRGB(Main.h, 1f, 1f);
                }
            }
            else
            {
                GameObject.Destroy(Main.Rightplat);
                Main.Rightplat = null;
                Main.createdRightPlat = false;
            }

            if (Main.leftTrigger == 0f && Main.rightTrigger == 0f)
            {
                DisableNoClip();
            }
        }

        public static void ToggleUseGripForPlatforms()
        {
            Main.useGripForPlatforms = true;
        }

        public static void ToggleUseTriggerForPlatforms()
        {
            Main.useGripForPlatforms = false;
        }


        public static void PlatformGun()
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

                if (Main.rightTrigger == 1f)
                {
                    pointer.GetComponent<Renderer>().material.color = UnityEngine.Color.HSVToRGB(Main.h, 1f, 1f);
                    GameObject plat = PlacePlatform(pointer.transform.position, GorillaTagger.Instance.rightHandTransform.rotation);
                    //plat.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                    plat.GetComponent<Renderer>().material.color = UnityEngine.Color.HSVToRGB(Main.h, 1f, 1f);
                    GameObject.Destroy(plat, 3f);
                }
                GameObject.Destroy(pointer, Time.deltaTime);
            }
        }

        public static void DisablePlatformGun()
        {

        }





        // Tag Freeze Shit
        public static void NoTagFreeze()
        {
            GorillaLocomotion.Player.Instance.disableMovement = false;
        }

        public static void TagFreeze()
        {
            GorillaLocomotion.Player.Instance.disableMovement = true;
        }


        // Gravity Shit
        public static void LowGravity()
        {
            GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.AddForce(Vector3.up * (Time.deltaTime * (6.66f / Time.deltaTime)), ForceMode.Acceleration);
        }

        public static void ZeroGravity()
        {
            GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.AddForce(Vector3.up * (Time.deltaTime * (9.81f / Time.deltaTime)), ForceMode.Acceleration);
        }

        public static void HighGravity()
        {
            GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.AddForce(Vector3.down * (Time.deltaTime * (7.77f / Time.deltaTime)), ForceMode.Acceleration);
        }

        public static async void TpGun()
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

                if (Main.rightTrigger == 1f && Main.canTp)
                {
                    pointer.GetComponent<Renderer>().material.color = UnityEngine.Color.HSVToRGB(Main.h, 1f, 1f);

                    Main.tpPosition = pointer.transform.position;
                    Main.canTp = false;

                    foreach (MeshCollider col in UnityEngine.Object.FindObjectsOfType<MeshCollider>())
                    {
                        col.enabled = false;
                    }
                    GorillaTagger.Instance.offlineVRRig.enabled = false;
                    GorillaTagger.Instance.offlineVRRig.transform.position = new Vector3(Ray.point.x / 2, Ray.point.y / 2, Ray.point.z / 2);
                    GorillaTagger.Instance.myVRRig.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position;
                    GorillaLocomotion.Player.Instance.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position;
                    GorillaTagger.Instance.offlineVRRig.enabled = true;
                    GorillaTagger.Instance.offlineVRRig.enabled = false;
                    GorillaTagger.Instance.offlineVRRig.transform.position = Main.tpPosition;
                    GorillaTagger.Instance.myVRRig.transform.position = Main.tpPosition;
                    GorillaLocomotion.Player.Instance.transform.position = Main.tpPosition;
                    GorillaTagger.Instance.offlineVRRig.enabled = true;
                    foreach (MeshCollider col in UnityEngine.Object.FindObjectsOfType<MeshCollider>())
                    {
                        col.enabled = true;
                    }
                    GameObject.Destroy(pointer, Time.deltaTime);
                    await Task.Delay(2000);
                    Main.canTp = true;
                }
                GameObject.Destroy(pointer, Time.deltaTime);
            }
        }

        public static async void ChangeFlySpeed(bool useButton)
        {
            if (useButton)
            {
                if (Main.flyCanChangeSpeed)
                {
                    if (Main.leftPrimary)
                    {
                        if (Main.flySpeedType == "Super Slow")
                        {
                            Main.flySpeedType = "Slow";
                            NotifiLib.SendNotification($"<color=blue>Fly Speed: {Main.flySpeedType}</color>");
                        }
                        else if (Main.flySpeedType == "Slow")
                        {
                            Main.flySpeedType = " Normal";
                            NotifiLib.SendNotification($"<color=blue>Fly Speed: {Main.flySpeedType}</color>");
                        }
                        else if (Main.flySpeedType == "Normal")
                        {
                            Main.flySpeedType = "Fast";
                            NotifiLib.SendNotification($"<color=blue>Fly Speed: {Main.flySpeedType}</color>");
                        }
                        else if (Main.flySpeedType == "Fast")
                        {
                            Main.flySpeedType = "Super Fast";
                            NotifiLib.SendNotification($"<color=blue>Fly Speed: {Main.flySpeedType}</color>");
                        }
                        else if (Main.flySpeedType == "Super Fast")
                        {
                            Main.flySpeedType = "Light Speed";
                            NotifiLib.SendNotification($"<color=blue>Fly Speed: {Main.flySpeedType}</color>");
                        }
                        else if (Main.flySpeedType == "Light Speed")
                        {
                            Main.flySpeedType = "Super Slow";
                            NotifiLib.SendNotification($"<color=blue>Fly Speed: {Main.flySpeedType}</color>");
                        }
                        Main.RecreateMenu();
                    }
                    Main.flyCanChangeSpeed = false;
                    await Task.Delay(200);
                    Main.flyCanChangeSpeed = true;
                }
            } 
            else
            {
                
                if (Main.flySpeedType == "Super Slow")
                {
                    Main.flySpeedType = "Slow";
                    NotifiLib.SendNotification($"<color=blue>Fly Speed: {Main.flySpeedType}</color>");
                }
                else if (Main.flySpeedType == "Slow")
                {
                    Main.flySpeedType = " Normal";
                    NotifiLib.SendNotification($"<color=blue>Fly Speed: {Main.flySpeedType}</color>");
                }
                else if (Main.flySpeedType == "Normal")
                {
                    Main.flySpeedType = "Fast";
                    NotifiLib.SendNotification($"<color=blue>Fly Speed: {Main.flySpeedType}</color>");
                }
                else if (Main.flySpeedType == "Fast")
                {
                    Main.flySpeedType = "Super Fast";
                    NotifiLib.SendNotification($"<color=blue>Fly Speed: {Main.flySpeedType}</color>");
                }
                else if (Main.flySpeedType == "Super Fast")
                {
                    Main.flySpeedType = "Light Speed";
                    NotifiLib.SendNotification($"<color=blue>Fly Speed: {Main.flySpeedType}</color>");
                }
                else if (Main.flySpeedType == "Light Speed")
                {
                    Main.flySpeedType = "Super Slow";
                    NotifiLib.SendNotification($"<color=blue>Fly Speed: {Main.flySpeedType}</color>");
                }
                Main.RecreateMenu();
            }
        }

        public static void NormalFly(bool noClip = false)
        {
            if (noClip)
            {
                NoClip(false);
            }
            if (Main.rightPrimary)
            {
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
                if (Main.flySpeedType == "Super Slow")
                {
                    GorillaLocomotion.Player.Instance.transform.position += GorillaLocomotion.Player.Instance.headCollider.transform.forward * 6 * Time.deltaTime;
                } else if (Main.flySpeedType == "Slow")
                {
                    GorillaLocomotion.Player.Instance.transform.position += GorillaLocomotion.Player.Instance.headCollider.transform.forward * 10 * Time.deltaTime;
                } else if (Main.flySpeedType == "Normal")
                {
                    GorillaLocomotion.Player.Instance.transform.position += GorillaLocomotion.Player.Instance.headCollider.transform.forward * 15 * Time.deltaTime;
                } else if (Main.flySpeedType == "Fast")
                {
                    GorillaLocomotion.Player.Instance.transform.position += GorillaLocomotion.Player.Instance.headCollider.transform.forward * 20 * Time.deltaTime;
                } else if (Main.flySpeedType == "Super Fast")
                {
                    GorillaLocomotion.Player.Instance.transform.position += GorillaLocomotion.Player.Instance.headCollider.transform.forward * 30 * Time.deltaTime;
                } else if (Main.flySpeedType == "Light Speed")
                {
                    GorillaLocomotion.Player.Instance.transform.position += GorillaLocomotion.Player.Instance.headCollider.transform.forward * 45 * Time.deltaTime;
                }
            } else
            {
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                DisableNoClip();
            }
        }

        public static void VelocityFly(bool noClip = false)
        {
            if (Main.rightPrimary)
            {
                if (noClip)
                {
                    NoClip(false);
                }
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
                if (Main.flySpeedType == "Super Slow")
                {
                    GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity += GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime * (10);
                }
                else if (Main.flySpeedType == "Slow")
                {
                    GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity += GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime * (30);
                }
                else if (Main.flySpeedType == "Normal")
                {
                    GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity += GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime * (50);
                }
                else if (Main.flySpeedType == "Fast")
                {
                    GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity += GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime * (75);
                }
                else if (Main.flySpeedType == "Super Fast")
                {
                    GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity += GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime * (95);
                }
                else if (Main.flySpeedType == "Light Speed")
                {
                    GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity += GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime * (115);
                }
            } else
            {
                DisableNoClip();
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().isKinematic = false;
            }
        }

        public static void SlideControl()
        {
            GorillaLocomotion.Player.Instance.slideControl = 2f;
        }

        public static void FixSlideControl()
        {
            GorillaLocomotion.Player.Instance.slideControl = Main.originSlideControl;
        }

        public static void FastSlide()
        {
            GorillaLocomotion.Player.Instance.slideVelocityLimit = Main.originSlideVelocity * 5f;
        }

        public static void FixFastSlide()
        {
            GorillaLocomotion.Player.Instance.slideVelocityLimit = Main.originSlideVelocity;
        }

        public static void BiggerSmaller()
        {
            if (Main.leftTrigger == 1f)
            {
                GorillaLocomotion.Player.Instance.scale -= 0.1f;
            }

            if (Main.rightTrigger == 1f)
            {
                GorillaLocomotion.Player.Instance.scale += 0.1f;
            }
        }

        public static void FixBiggerSmaller()
        {
            GorillaLocomotion.Player.Instance.scale = Main.originOfflineRigSize;
        }

        public static void NoClip(bool useButton)
        {
            if (Main.rightSecondary && useButton)
            {
                foreach (MeshCollider col in UnityEngine.Object.FindObjectsOfType<MeshCollider>())
                {
                    col.enabled = false;
                }
            } else
            {
                if (useButton)
                {
                    foreach (MeshCollider col in UnityEngine.Object.FindObjectsOfType<MeshCollider>())
                    {
                        col.enabled = true;
                    }
                }
                if (!useButton)
                {
                    foreach (MeshCollider col in UnityEngine.Object.FindObjectsOfType<MeshCollider>())
                    {
                        col.enabled = false;
                    }
                }
            }
        }

        public static void DisableNoClip()
        {
            foreach (MeshCollider col in UnityEngine.Object.FindObjectsOfType<MeshCollider>())
            {
                col.enabled = true;
            }
        }

        public static void UpAndDown()
        {
            if (Main.leftTrigger == 1f)
            {
                GorillaLocomotion.Player.Instance.transform.position -= new Vector3(0f, 0.3f, 0f);
            }

            if (Main.rightTrigger == 1f)
            {
                GorillaLocomotion.Player.Instance.transform.position += new Vector3(0f, 0.3f, 0f);
            }
        }

        public static void LeftAndRight()
        {
            if (Main.leftGrab)
            {
                GorillaLocomotion.Player.Instance.transform.position -= new Vector3(2f, 0f, 0f).normalized;
            }

            if (Main.rightGrab)
            {
                GorillaLocomotion.Player.Instance.transform.position += new Vector3(2f, 0f, 0f).normalized;
            }
        }

        public static async void TpToStump()
        {
            //-66.6725 11.7363 -82.0455
            if (Main.leftPrimary)
            {
                foreach (MeshCollider col in UnityEngine.Object.FindObjectsOfType<MeshCollider>())
                {
                    col.enabled = false;
                }
                await Task.Delay(100);
                GorillaLocomotion.Player.Instance.transform.position = new Vector3(-66.6725f, 13f, -82.0455f);
                await Task.Delay(200);
                foreach (MeshCollider col in UnityEngine.Object.FindObjectsOfType<MeshCollider>())
                {
                    col.enabled = true;
                }
            }
        }

        

        public static async void Checkpoint()
        {
            if (Main.rightGrab)
            {
                if (Main.checkpoint == null)
                {
                    Main.checkpoint = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    Main.checkpoint.transform.localScale = Vector3.one/4;
                    Main.checkpoint.GetComponent<Renderer>().material.color = Color.HSVToRGB(Main.h, 1f, 1f);
                    UnityEngine.Object.Destroy(Main.checkpoint.GetComponent<SphereCollider>());
                    Main.checkpoint.transform.position = GorillaTagger.Instance.rightHandTransform.position;
                } else
                {
                    Main.checkpoint.GetComponent<Renderer>().material.color = Color.HSVToRGB(Main.h, 1f, 1f);
                    Main.checkpoint.transform.position = GorillaTagger.Instance.rightHandTransform.position;
                }
            }

            if (Main.rightPrimary)
            {
                NoClip(false);
                Main.checkpoint.GetComponent<Renderer>().material.color = Color.green;
                GorillaLocomotion.Player.Instance.transform.position = Main.checkpoint.transform.position + new Vector3(0f, 0.5f, 0f);
                await Task.Delay(100);
                Main.checkpoint.GetComponent<Renderer>().material.color = Color.HSVToRGB(Main.h, 1f, 1f);
                DisableNoClip();
            }
        }

        public static void DisableCheckpoint()
        {
            GameObject.Destroy(Main.checkpoint);
            Main.checkpoint = null;
        }


        public static void CopyPlayerMovementGun()
        {
            Main.GunGameObjectEnabled = true;

            if (Main.rightGrab)
            {
                if (!Main.copyPlayerLocked)
                {
                    Physics.Raycast(GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.rightHandTransform.forward, out var Ray);

                    GameObject pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    pointer.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                    UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                    UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                    pointer.GetComponent<Renderer>().material.shader = UnityEngine.Shader.Find("GUI/Text Shader");
                    pointer.GetComponent<Renderer>().material.color = UnityEngine.Color.white;
                    pointer.transform.position = Ray.point;

                    if (Main.rightTrigger == 1f && Ray.collider != null && Ray.collider.GetComponentInParent<VRRig>())
                    {
                        pointer.GetComponent<Renderer>().material.color = UnityEngine.Color.HSVToRGB(Main.h, 1f, 1f);

                        Main.plrToLockOn = Ray.collider.GetComponentInParent<VRRig>();
                        Main.copyPlayerLocked = true;
                    }

                    GameObject.Destroy(pointer, Time.deltaTime);
                }

                if (Main.copyPlayerLocked && Main.plrToLockOn != null)
                {
                    VRRig plrrig = Main.plrToLockOn;
                    GorillaTagger.Instance.offlineVRRig.enabled = false;
                    GorillaTagger.Instance.offlineVRRig.transform.position = plrrig.transform.position;
                    GorillaTagger.Instance.offlineVRRig.transform.rotation = plrrig.transform.rotation;
                    try
                    {
                        GorillaTagger.Instance.myVRRig.transform.position = plrrig.transform.position;
                        GorillaTagger.Instance.myVRRig.transform.rotation = plrrig.transform.rotation;
                    }
                    catch (Exception) { }
                    GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.position = plrrig.rightHandTransform.position;
                    GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.rotation = plrrig.rightHandTransform.rotation;
                    GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.position = plrrig.leftHandTransform.position;
                    GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.rotation = plrrig.leftHandTransform.rotation;
                    GorillaTagger.Instance.offlineVRRig.head.rigTarget.transform.rotation = plrrig.headMesh.transform.rotation;
                }
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
                Main.copyPlayerLocked = false;
                Main.plrToLockOn = null;
            }
        }

        
        public static float fakeLagStepDelay = 0.35f;
        public static float fakeLagTime = 0f;
        public static void FakeLag()
        {
            if (Time.time > fakeLagTime)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = !GorillaTagger.Instance.offlineVRRig.enabled;
            }
            fakeLagTime = Time.time + fakeLagTime;
        }

        public static void FixOfflineRig()
        {
            GorillaTagger.Instance.offlineVRRig.enabled = true;
        }

        public static void GhostCam()
        {
            GorillaTagger.Instance.offlineVRRig.enabled = false;
            GorillaTagger.Instance.offlineVRRig.transform.position = GorillaLocomotion.Player.Instance.transform.position;
            GorillaTagger.Instance.offlineVRRig.transform.rotation = GorillaLocomotion.Player.Instance.transform.rotation;
        }




        public static void IronMonke()
        {
            if (Main.rightGrab)
            {
                Rigidbody rb = GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>();
                Vector3 force = GorillaTagger.Instance.rightHandTransform.up * 18;
                rb.AddForce(force, ForceMode.Acceleration);
                if (!Main.leftGrab)
                {
                    Splash(GorillaTagger.Instance.rightHandTransform.position, UnityEngine.Random.rotation);
                }
            }

            if (Main.leftGrab)
            {
                Rigidbody rb = GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>();
                Vector3 force = GorillaTagger.Instance.leftHandTransform.up * 18;
                rb.AddForce(force, ForceMode.Acceleration);
                if (!Main.rightGrab)
                {
                    Splash(GorillaTagger.Instance.leftHandTransform.position, UnityEngine.Random.rotation);
                }
            }

            if (Main.leftGrab && Main.rightGrab)
            {
                Splash(GorillaTagger.Instance.leftHandTransform.position, UnityEngine.Random.rotation, true, GorillaTagger.Instance.rightHandTransform.position);
            }
        }

        public static float splashDelay = 0.3f;
        public static float splashTime = 0f;
        public static void Splash(Vector3 pos, Quaternion rotation, bool twoPos = false, Vector3? pos2 = null, float num1 = 4f, float num2 = 100f)
        {
            if (Time.time > splashTime)
            {
                if (!twoPos)
                {
                    GorillaTagger.Instance.myVRRig.RPC("PlaySplashEffect", 0, new object[]
                    {
                    pos,
                    rotation,
                    num1,
                    num2,
                    true,
                    false
                    });
                    Sounds.RPCProtection();
                    Experimental.AntiRpc();
                }
                else
                {
                    if (pos2 != null)
                    {
                        GorillaTagger.Instance.myVRRig.RPC("PlaySplashEffect", 0, new object[]
                        {
                        pos,
                        rotation,
                        num1,
                        num2,
                        true,
                        false
                        });
                        GorillaTagger.Instance.myVRRig.RPC("PlaySplashEffect", 0, new object[]
                        {
                        pos2,
                        rotation,
                        num1,
                        num2,
                        true,
                        false
                        });
                        Sounds.RPCProtection();
                        Experimental.AntiRpc();
                    }
                }

                // Update the splashTime only if the splash effect was triggered
                splashTime = Time.time + splashDelay;
            }
        }


        public static void SolidPlayers()
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
                    GameObject.Destroy(box, Time.deltaTime);
                }
            }
        }


    }
}
