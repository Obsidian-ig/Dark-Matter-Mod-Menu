using Photon.Pun;
using StupidTemplate.Menu;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace StupidTemplate.Mods
{
    public class Projectiles
    {
        public static string[] fullProjectileNames = new string[] {
            "Snowball",
            "WaterBalloon",
            "LavaRock",
            "ThrowableGift",
            "ScienceCandy",
            "FishFood"
        };

        public static int[] array = new int[] {
                32,
                204,
                231,
                240,
                249,
                252
            };

        public static string[] array2 = new string[] {
                        "LMACE.",
                        "LMAEX.",
                        "LMAGD.",
                        "LMAHQ.",
                        "LMAIE.",
                        "LMAIO."
                    };

        public static float projDelay = 0f;
        public static float projShootDelay = 0.15f;
        public static void WORKINGPROJECTILESFRFRFORREALZYS()
        {
            if (Main.rightTrigger == 1f)
            {
                // remember to give creds to brandon
                string[] possibleProjectiles = new string[] {
            "Snowball",
            "WaterBalloon",
            "LavaRock",
            "ThrowableGift",
            "ScienceCandy",
            "FishFood"};



                Projectile(possibleProjectiles[UnityEngine.Random.Range(0, possibleProjectiles.Length)], GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.rightHandTransform.forward * 16, new Color32((byte)UnityEngine.Random.Range(1, 255), (byte)UnityEngine.Random.Range(1, 255), (byte)UnityEngine.Random.Range(1, 255), 255));
                Projectile(possibleProjectiles[UnityEngine.Random.Range(0, possibleProjectiles.Length)], GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.rightHandTransform.forward * 16, new Color32((byte)UnityEngine.Random.Range(1, 255), (byte)UnityEngine.Random.Range(1, 255), (byte)UnityEngine.Random.Range(1, 255), 255));
                Projectile(possibleProjectiles[UnityEngine.Random.Range(0, possibleProjectiles.Length)], GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.rightHandTransform.forward * 16, new Color32((byte)UnityEngine.Random.Range(1, 255), (byte)UnityEngine.Random.Range(1, 255), (byte)UnityEngine.Random.Range(1, 255), 255));
                Projectile(possibleProjectiles[UnityEngine.Random.Range(0, possibleProjectiles.Length)], GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.rightHandTransform.forward * 16, new Color32((byte)UnityEngine.Random.Range(1, 255), (byte)UnityEngine.Random.Range(1, 255), (byte)UnityEngine.Random.Range(1, 255), 255));
                Projectile(possibleProjectiles[UnityEngine.Random.Range(0, possibleProjectiles.Length)], GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.rightHandTransform.forward * 16, new Color32((byte)UnityEngine.Random.Range(1, 255), (byte)UnityEngine.Random.Range(1, 255), (byte)UnityEngine.Random.Range(1, 255), 255));
                Projectile(possibleProjectiles[UnityEngine.Random.Range(0, possibleProjectiles.Length)], GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.rightHandTransform.forward * 16, new Color32((byte)UnityEngine.Random.Range(1, 255), (byte)UnityEngine.Random.Range(1, 255), (byte)UnityEngine.Random.Range(1, 255), 255));
                Projectile(possibleProjectiles[UnityEngine.Random.Range(0, possibleProjectiles.Length)], GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.rightHandTransform.forward * 16, new Color32((byte)UnityEngine.Random.Range(1, 255), (byte)UnityEngine.Random.Range(1, 255), (byte)UnityEngine.Random.Range(1, 255), 255));
                Projectile(possibleProjectiles[UnityEngine.Random.Range(0, possibleProjectiles.Length)], GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.rightHandTransform.forward * 16, new Color32((byte)UnityEngine.Random.Range(1, 255), (byte)UnityEngine.Random.Range(1, 255), (byte)UnityEngine.Random.Range(1, 255), 255));
                Projectile(possibleProjectiles[UnityEngine.Random.Range(0, possibleProjectiles.Length)], GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.rightHandTransform.forward * 16, new Color32((byte)UnityEngine.Random.Range(1, 255), (byte)UnityEngine.Random.Range(1, 255), (byte)UnityEngine.Random.Range(1, 255), 255));
                Projectile(possibleProjectiles[UnityEngine.Random.Range(0, possibleProjectiles.Length)], GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.rightHandTransform.forward * 16, new Color32((byte)UnityEngine.Random.Range(1, 255), (byte)UnityEngine.Random.Range(1, 255), (byte)UnityEngine.Random.Range(1, 255), 255));
                Projectile(possibleProjectiles[UnityEngine.Random.Range(0, possibleProjectiles.Length)], GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.rightHandTransform.forward * 16, new Color32((byte)UnityEngine.Random.Range(1, 255), (byte)UnityEngine.Random.Range(1, 255), (byte)UnityEngine.Random.Range(1, 255), 255));
                Projectile(possibleProjectiles[UnityEngine.Random.Range(0, possibleProjectiles.Length)], GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.rightHandTransform.forward * 16, new Color32((byte)UnityEngine.Random.Range(1, 255), (byte)UnityEngine.Random.Range(1, 255), (byte)UnityEngine.Random.Range(1, 255), 255));
                Projectile(possibleProjectiles[UnityEngine.Random.Range(0, possibleProjectiles.Length)], GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.rightHandTransform.forward * 16, new Color32((byte)UnityEngine.Random.Range(1, 255), (byte)UnityEngine.Random.Range(1, 255), (byte)UnityEngine.Random.Range(1, 255), 255));
                Projectile(possibleProjectiles[UnityEngine.Random.Range(0, possibleProjectiles.Length)], GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.rightHandTransform.forward * 16, new Color32((byte)UnityEngine.Random.Range(1, 255), (byte)UnityEngine.Random.Range(1, 255), (byte)UnityEngine.Random.Range(1, 255), 255));
                Sounds.RPCProtection();
                Experimental.AntiRpc();
            }
        }

        public static void SnowballGun()
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
                    pointer.GetComponent<Renderer>().material.color = UnityEngine.Color.HSVToRGB(Main.h, 1f, 1f);
                    Projectile("Snowball", pointer.transform.position, Vector3.zero, Color.HSVToRGB(Main.h, 1f, 1f));
                    GameObject.Destroy(pointer, Time.deltaTime);
                }
                GameObject.Destroy(pointer, Time.deltaTime);
            }
        }

        public static void WaterballoonGun()
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
                    pointer.GetComponent<Renderer>().material.color = UnityEngine.Color.HSVToRGB(Main.h, 1f, 1f);
                    Projectile("WaterBalloon", pointer.transform.position, Vector3.zero, Color.HSVToRGB(Main.h, 1f, 1f));
                    GameObject.Destroy(pointer, Time.deltaTime);
                }
                GameObject.Destroy(pointer, Time.deltaTime);
            }
        }

        public static void LavaRockGun()
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
                    pointer.GetComponent<Renderer>().material.color = UnityEngine.Color.HSVToRGB(Main.h, 1f, 1f);
                    Projectile("LavaRock", pointer.transform.position, Vector3.zero, Color.HSVToRGB(Main.h, 1f, 1f));
                    GameObject.Destroy(pointer, Time.deltaTime);
                }
                GameObject.Destroy(pointer, Time.deltaTime);
            }
        }

        public static void GiftGun()
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
                    pointer.GetComponent<Renderer>().material.color = UnityEngine.Color.HSVToRGB(Main.h, 1f, 1f);
                    Projectile("ThrowableGift", pointer.transform.position, Vector3.zero, Color.HSVToRGB(Main.h, 1f, 1f));
                    GameObject.Destroy(pointer, Time.deltaTime);
                }
                GameObject.Destroy(pointer, Time.deltaTime);
            }
        }

        public static void CandyGun()
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
                    pointer.GetComponent<Renderer>().material.color = UnityEngine.Color.HSVToRGB(Main.h, 1f, 1f);
                    Projectile("ScienceCandy", pointer.transform.position, Vector3.zero, Color.HSVToRGB(Main.h, 1f, 1f));
                    GameObject.Destroy(pointer, Time.deltaTime);
                }
                GameObject.Destroy(pointer, Time.deltaTime);
            }
        }

        public static void FishFoodGun()
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
                    pointer.GetComponent<Renderer>().material.color = UnityEngine.Color.HSVToRGB(Main.h, 1f, 1f);
                    Projectile("FishFood", pointer.transform.position, Vector3.zero, Color.HSVToRGB(Main.h, 1f, 1f));
                    GameObject.Destroy(pointer, Time.deltaTime);
                }
                GameObject.Destroy(pointer, Time.deltaTime);
            }
        }

        public static void SnowballSpam()
        {
            if (Main.rightGrab)
            {
                Projectile("Snowball", GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.rightHandTransform.forward * 0, new Color32(255, 255, 255, 255), false);
                Sounds.RPCProtection();
                Experimental.AntiRpc();
            }
        }

        public static void WaterBalloonSpam()
        {
            if (Main.rightGrab)
            {
                Projectile("WaterBalloon", GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.rightHandTransform.forward * 0, new Color32((byte)UnityEngine.Random.Range(1, 255), (byte)UnityEngine.Random.Range(1, 255), (byte)UnityEngine.Random.Range(1, 255), 255), false);
                Sounds.RPCProtection();
                Experimental.AntiRpc();
            }
        }

        public static void LavarockSpam()
        {
            if (Main.rightGrab)
            {
                Projectile("LavaRock", GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.rightHandTransform.forward * 0, new Color32(255, 255, 255, 255), false);
                Sounds.RPCProtection();
                Experimental.AntiRpc();
            }
        }

        public static void GiftSpam()
        {
            if (Main.rightGrab)
            {
                Projectile("ThrowableGift", GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.rightHandTransform.forward * 0, new Color32(255, 255, 255, 255), false);
                Sounds.RPCProtection();
                Experimental.AntiRpc();
            }
        }

        public static void ScienceCandySpam()
        {
            if (Main.rightGrab)
            {
                Projectile("ScienceCandy", GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.rightHandTransform.forward * 0, new Color32((byte)UnityEngine.Random.Range(1, 255), (byte)UnityEngine.Random.Range(1, 255), (byte)UnityEngine.Random.Range(1, 255), 255), false);
                Sounds.RPCProtection();
                Experimental.AntiRpc();
            }
        }

        public static void FishFoodSpam()
        {
            if (Main.rightGrab)
            {
                Projectile("FishFood", GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.rightHandTransform.forward * 0, new Color32(255, 255, 255, 255), false);
                Sounds.RPCProtection();
                Experimental.AntiRpc();
            }
        }

        public static void RandomSpam()
        {
            if (Main.rightGrab)
            {
                string[] possibleProjectiles = new string[] {
                "Snowball",
                "WaterBalloon",
                "LavaRock",
                "ThrowableGift",
                "ScienceCandy",
                "FishFood"};
                Projectile(possibleProjectiles[UnityEngine.Random.Range(0, possibleProjectiles.Length)], GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.rightHandTransform.forward * 0, new Color32(255, 255, 255, 255), false);
                Sounds.RPCProtection();
                Experimental.AntiRpc();
            }
        }

        public static void SnowballGroundForest()
        {
            if (Main.leftPrimary)
            {
                GameObject.Find("pit ground").GetComponent<GorillaSurfaceOverride>().overrideIndex = 32;
            }
            else
            {
                GameObject.Find("pit ground").GetComponent<GorillaSurfaceOverride>().overrideIndex = 0;
            }
        }

        public static void WaterBalloonGroundForest()
        {
            if (Main.leftPrimary)
            {
                GameObject.Find("pit ground").GetComponent<GorillaSurfaceOverride>().overrideIndex = 204;
            }
            else
            {
                GameObject.Find("pit ground").GetComponent<GorillaSurfaceOverride>().overrideIndex = 0;
            }
        }

        public static void LavaRockGroundForest()
        {
            if (Main.leftPrimary)
            {
                GameObject.Find("pit ground").GetComponent<GorillaSurfaceOverride>().overrideIndex = 231;
            }
            else
            {
                GameObject.Find("pit ground").GetComponent<GorillaSurfaceOverride>().overrideIndex = 0;
            }
        }

        public static void GiftGroundForest()
        {
            if (Main.leftPrimary)
            {
                GameObject.Find("pit ground").GetComponent<GorillaSurfaceOverride>().overrideIndex = 240;
            }
            else
            {
                GameObject.Find("pit ground").GetComponent<GorillaSurfaceOverride>().overrideIndex = 0;
            }
        }

        public static void ScienceCandyGroundForest()
        {
            if (Main.leftPrimary)
            {
                GameObject.Find("pit ground").GetComponent<GorillaSurfaceOverride>().overrideIndex = 249;
            }
            else
            {
                GameObject.Find("pit ground").GetComponent<GorillaSurfaceOverride>().overrideIndex = 0;
            }
        }

        public static void FishFoodGroundForest()
        {
            if (Main.leftPrimary)
            {
                GameObject.Find("pit ground").GetComponent<GorillaSurfaceOverride>().overrideIndex = 252;
            }
            else
            {
                GameObject.Find("pit ground").GetComponent<GorillaSurfaceOverride>().overrideIndex = 0;
            }
        }

        public static void RandomProjectileGroundForest()
        {
            if (Main.leftPrimary)
            {
                GameObject.Find("pit ground").GetComponent<GorillaSurfaceOverride>().overrideIndex = array[UnityEngine.Random.Range(0, array.Length)];
            }
            else
            {
                GameObject.Find("pit ground").GetComponent<GorillaSurfaceOverride>().overrideIndex = 0;
            }
        }

        public static void ChangeSurfaceId(int changeBy)
        {
            Main.surfaceId += changeBy;
            if (Main.surfaceId <= 0)
            {
                Main.surfaceId = 0;
            }
        }

        public static void CustomSurface()
        {
            if (Main.leftPrimary)
            {
                GameObject.Find("pit ground").GetComponent<GorillaSurfaceOverride>().overrideIndex = array[UnityEngine.Random.Range(Main.surfaceId, array.Length)];
            }
            else
            {
                GameObject.Find("pit ground").GetComponent<GorillaSurfaceOverride>().overrideIndex = 0;
            }
        }





        public static void Projectile(string projectileName, Vector3 position, Vector3 velocity, UnityEngine.Color color, bool noDelay = false)
        {
            ControllerInputPoller.instance.leftControllerGripFloat = 1f;
            GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            gameObject.tag = "projectilesmth";
            gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            gameObject.transform.position = GorillaTagger.Instance.leftHandTransform.position;
            gameObject.transform.rotation = GorillaTagger.Instance.leftHandTransform.rotation;
            int[] array = new int[] {
                32,
                204,
                231,
                240,
                249,
                252
            };
            gameObject.AddComponent<GorillaSurfaceOverride>().overrideIndex = array[Array.IndexOf(fullProjectileNames, projectileName)];
            gameObject.GetComponent<Renderer>().enabled = false;
            if (Time.time > projDelay)
            {
                try
                {
                    Vector3 velocity2 = GorillaTagger.Instance.GetComponent<Rigidbody>().velocity;
                    string[] array2 = new string[] {
                        "LMACE.",
                        "LMAEX.",
                        "LMAGD.",
                        "LMAHQ.",
                        "LMAIE.",
                        "LMAIO."
                    };
                    SnowballThrowable component = GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.L/upper_arm.L/forearm.L/hand.L/palm.01.L/TransferrableItemLeftHand/" + fullProjectileNames[Array.IndexOf(fullProjectileNames, projectileName)] + "LeftAnchor").transform.Find(array2[Array.IndexOf(fullProjectileNames, projectileName)]).GetComponent<SnowballThrowable>();
                    Vector3 position2 = component.transform.position;
                    component.randomizeColor = true;
                    component.transform.position = position;
                    GorillaTagger.Instance.GetComponent<Rigidbody>().velocity = velocity;
                    GorillaTagger.Instance.offlineVRRig.LeftThrowableProjectileColor = color;
                    GorillaTagger.Instance.offlineVRRig.RightThrowableProjectileColor = color;
                    GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer/EquipmentInteractor").GetComponent<EquipmentInteractor>().ReleaseLeftHand();
                    GorillaTagger.Instance.GetComponent<Rigidbody>().velocity = velocity2;
                    component.transform.position = position2;
                    component.randomizeColor = false;

                    // component.projectilePrefab.tag = "CupidBow_Projectile";
                    UnityEngine.Object.Destroy(gameObject, 0.1f);
                    Sounds.RPCProtection();
                    Experimental.AntiRpc();
                    foreach (GameObject obj in GameObject.FindGameObjectsWithTag("projectilesmth"))
                    {
                        GameObject.Destroy(obj);
                    }
                }
                catch { }
                if (projShootDelay > 0f && !noDelay)
                {
                    projDelay = Time.time + projShootDelay;
                }
            }
        }
    }
}
