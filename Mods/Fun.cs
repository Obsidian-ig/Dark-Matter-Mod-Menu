using Fusion;
using HarmonyLib;
using Photon.Pun;
using StupidTemplate.Menu;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

namespace StupidTemplate.Mods
{
    internal class Fun
    {

        public static void JediDoug()
        {
            if (Main.rightGrab)
            {
                GameObject doug = GameObject.Find("Floating Bug Holdable");
                
                GorillaLocomotion.Player.Instance.rightControllerTransform.position = doug.transform.position;
                GorillaTagger.Instance.offlineVRRig.rightHandTransform.position = doug.transform.position;
                doug.transform.position = GorillaLocomotion.Player.Instance.rightControllerTransform.position;
            }
        }

        public static void JediMatt()
        {
            if (Main.rightGrab)
            {
                GameObject doug = GameObject.Find("Cave Bat Holdable");

                GorillaLocomotion.Player.Instance.rightControllerTransform.position = doug.transform.position;
                GorillaTagger.Instance.offlineVRRig.rightHandTransform.position = doug.transform.position;
                doug.transform.position = GorillaLocomotion.Player.Instance.rightControllerTransform.position;
            }
        }
        
        public static void DougGun()
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
                GameObject.Destroy(pointer, Time.deltaTime);
                if (Main.rightTrigger == 1f)
                {
                    pointer.GetComponent<Renderer>().material.color = UnityEngine.Color.HSVToRGB(Main.h, 1f, 1f);
                    GameObject doug = GameObject.Find("Floating Bug Holdable");
                    doug.transform.position = pointer.transform.position + new Vector3(0f, 0.2f, 0f);
                    GameObject.Destroy(pointer, Time.deltaTime);
                }
            }
        }

        public static void MattGun()
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
                    GameObject doug = GameObject.Find("Cave Bat Holdable");
                    doug.transform.position = pointer.transform.position + new Vector3(0f, 0.2f, 0f);
                    GameObject.Destroy(pointer, Time.deltaTime);
                }
                GameObject.Destroy(pointer, Time.deltaTime);
            }
        }

        
        public static void FastDoug()
        {
            GameObject doug = GameObject.Find("Floating Bug Holdable");
            doug.GetComponent<ThrowableBug>().maxNaturalSpeed = 9f;
        }

        public static void SpazDoug()
        {
            GameObject doug = GameObject.Find("Floating Bug Holdable");
            doug.GetComponent<ThrowableBug>().bobingFrequency = 5f;
            doug.GetComponent<ThrowableBug>().bobMagnintude = 3f;
            doug.GetComponent<ThrowableBug>().bobingSpeed = 25f;
        }

        public static void FixDoug()
        {
            GameObject doug = GameObject.Find("Floating Bug Holdable");
            doug.GetComponent<ThrowableBug>().maxNaturalSpeed = Main.originDougSpeed;
            doug.GetComponent<ThrowableBug>().bobingSpeed = Main.originDougBobbingSpeed;
            doug.GetComponent<ThrowableBug>().bobMagnintude = Main.originDougBobMag;
            doug.GetComponent<ThrowableBug>().allowPlayerStealing = true;
        }

        
        public static void FastMatt()
        {
            GameObject doug = GameObject.Find("Cave Bat Holdable");
            doug.GetComponent<ThrowableBug>().maxNaturalSpeed = 9f;
        }

        public static void SpazMatt()
        {
            GameObject doug = GameObject.Find("Floating Bug Holdable");
            doug.GetComponent<ThrowableBug>().bobingFrequency = 5f;
            doug.GetComponent<ThrowableBug>().bobMagnintude = 3f;
            doug.GetComponent<ThrowableBug>().bobingSpeed = 25f;
        }

        public static void FixMatt()
        {
            GameObject doug = GameObject.Find("Cave Bat Holdable");
            doug.GetComponent<ThrowableBug>().maxNaturalSpeed = Main.originMattSpeed;
            doug.GetComponent<ThrowableBug>().bobingSpeed = Main.originMattBobbingSpeed;
            doug.GetComponent<ThrowableBug>().bobMagnintude = Main.originMattBobMag;
            doug.GetComponent<ThrowableBug>().allowPlayerStealing = true;
        }

        public static void DougBeyblade()
        {
            GameObject doug = GameObject.Find("Floating Bug Holdable");
            Vector3 currentEulerAngles = doug.transform.rotation.eulerAngles;
            currentEulerAngles.y += 40f;
            doug.transform.rotation = Quaternion.Euler(currentEulerAngles);
        }

        public static void MattBeyblade()
        {
            GameObject doug = GameObject.Find("Cave Bat Holdable");
            Vector3 currentEulerAngles = doug.transform.rotation.eulerAngles;
            currentEulerAngles.y += 40f;
            doug.transform.rotation = Quaternion.Euler(currentEulerAngles);
        }

        public static void FreezeDoug()
        {
            ThrowableBug doug = GameObject.Find("Floating Bug Holdable").GetComponent<ThrowableBug>();
            doug.maxNaturalSpeed = 0;
        }

        public static void FreezeMatt()
        {
            ThrowableBug doug = GameObject.Find("Cave Bat Holdable").GetComponent<ThrowableBug>();
            doug.maxNaturalSpeed = 0;
        }

        public static void NoMoreDoug()
        {
            ThrowableBug doug = GameObject.Find("Floating Bug Holdable").GetComponent<ThrowableBug>();
            doug.transform.position = new Vector3(999f, 999f, 999f);
        }

        public static void NoMoreMatt()
        {
            ThrowableBug doug = GameObject.Find("Cave Bat Holdable").GetComponent<ThrowableBug>();
            doug.transform.position = new Vector3(999f, 999f, 999f);
        }

        public static void NoGrabDoug()
        {
            ThrowableBug doug = GameObject.Find("Floating Bug Holdable").GetComponent<ThrowableBug>();
            doug.allowPlayerStealing = false;
        }

        public static void NoGrabMatt()
        {
            ThrowableBug doug = GameObject.Find("Cave Bat Holdable").GetComponent<ThrowableBug>();
            doug.allowPlayerStealing = false;
        }

        public static void NoDropDoug()
        {
            ThrowableBug doug = GameObject.Find("Floating Bug Holdable").GetComponent<ThrowableBug>();
            doug.canDrop = false;
        }

        public static void NoDropMatt()
        {
            ThrowableBug doug = GameObject.Find("Cave Bat Holdable").GetComponent<ThrowableBug>();
            doug.canDrop = false;
        }

        public static void NoDoug()
        {
            ThrowableBug doug = GameObject.Find("Floating Bug Holdable").GetComponent<ThrowableBug>();
            doug.ascentRate = 1;
            doug.ascentSlerp = 0;
            doug.ascentSlerpRate = 2;
            doug.bobingFrequency = 1;
            doug.bobingSpeed = 3;
            doug.bobingState = 2.4411f;
            doug.bobMagnintude = 0.03f;

        }


        public static void GrabGliders()
        {
            foreach (GliderHoldable glider in GameObject.FindObjectsOfType(typeof(GliderHoldable)))
            {
                if (glider.photonView.Owner == PhotonNetwork.LocalPlayer)
                {
                    glider.transform.position = GorillaTagger.Instance.rightHandTransform.position;
                }
                else
                {
                    glider.OnHover(null, null);
                }
            }
        }

        public static void GliderGun()
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
                    foreach (GliderHoldable glider in GameObject.FindObjectsOfType(typeof(GliderHoldable)))
                    {
                        if (glider.photonView.Owner == PhotonNetwork.LocalPlayer)
                        {
                            glider.transform.position = pointer.transform.position;
                        } else
                        {
                            glider.OnHover(null, null);
                        }
                    }
                    GameObject.Destroy(pointer, Time.deltaTime);
                }
                GameObject.Destroy(pointer, Time.deltaTime);
            }
        }

        public static void GlidersSpaz()
        {
            foreach (GliderHoldable glider in GameObject.FindObjectsOfType(typeof(GliderHoldable)))
            {
                if (glider.photonView.Owner == PhotonNetwork.LocalPlayer)
                {
                    glider.transform.position += new Vector3(UnityEngine.Random.Range(-10, 10), UnityEngine.Random.Range(-10, 10), UnityEngine.Random.Range(-10, 10));
                }
                else
                {
                    glider.OnHover(null, null);
                }
            }
        }

        public static void BlindPlayerWithGliders()
        {
            if (Main.rightGrab)
            {
                if (!Main.gliderBlindPlayerLocked)
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
                            Main.plrToLockOn = Ray.collider.GetComponentInParent<VRRig>();
                            Main.gliderBlindPlayerLocked = true;
                            VRRig plr = Ray.collider.GetComponentInParent<VRRig>();
                            pointer.GetComponent<Renderer>().material.color = UnityEngine.Color.HSVToRGB(Main.h, 1f, 1f);
                            foreach (GliderHoldable glider in GameObject.FindObjectsOfType(typeof(GliderHoldable)))
                            {
                                if (glider.photonView.Owner == PhotonNetwork.LocalPlayer)
                                {
                                    glider.transform.position = plr.headMesh.transform.position;
                                }
                                else
                                {
                                    glider.OnHover(null, null);
                                }
                            }
                        }
                        GameObject.Destroy(pointer, Time.deltaTime);
                    }
                    GameObject.Destroy(pointer, Time.deltaTime);
                }

                if (Main.gliderBlindPlayerLocked && Main.plrToLockOn != null)
                {
                    foreach (GliderHoldable glider in GameObject.FindObjectsOfType(typeof(GliderHoldable)))
                    {
                        if (glider.photonView.Owner == PhotonNetwork.LocalPlayer)
                        {
                            glider.transform.position = Main.plrToLockOn.headMesh.transform.position;
                        }
                        else
                        {
                            glider.OnHover(null, null);
                        }
                    }
                }
            } else
            {
                Main.gliderBlindPlayerLocked = false;
                Main.plrToLockOn = null;
            }
        }

        public static void BlindAllPlayersWithGliders()
        {
            if (Main.rightGrab)
            {
                foreach (VRRig plr in GorillaParent.instance.vrrigs)
                {
                    foreach (GliderHoldable glider in GameObject.FindObjectsOfType(typeof(GliderHoldable)))
                    {
                        if (glider.photonView.Owner == PhotonNetwork.LocalPlayer)
                        {
                            glider.transform.position = plr.headMesh.transform.position;
                        }
                        else
                        {
                            glider.OnHover(null, null);
                        }
                    }
                }
            }
        }

        public static Transform target = GorillaTagger.Instance.offlineVRRig.head.rigTarget; // The GameObject to orbit around
        public static float orbitDistance = 1f; // Distance from the target
        public static float orbitSpeed = 10.0f; // Speed of the orbit
        public static float angle = 0.0f;
        public static void SpazGlidersV2()
        {
            int index = 0;
            foreach (GliderHoldable glider in GameObject.FindObjectsOfType<GliderHoldable>())
            {
                angle += orbitSpeed * Time.deltaTime;

                // Ensure the angle stays between 0 and 360 degrees
                if (angle >= 360f)
                    angle -= 360f;

                // Calculate the new position
                float x = target.position.x + (orbitDistance + index*10) * Mathf.Cos(angle);
                float z = target.position.z + orbitDistance * Mathf.Sin(angle);

                // Update the position of the orbiting object
                glider.transform.position = new Vector3(x, glider.transform.position.y, z);

                // Optional: Make the object always face the target
                glider.transform.LookAt(target);
                index++;
            }
        }

        public static void GliderOrbitGun()
        {
            if (Main.rightGrab)
            {
                if (!Main.gliderOrbitPlayerLocked)
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
                            Main.gliderOrbitPlayerLocked = true;
                            Main.plrToLockOn = Ray.collider.GetComponentInParent<VRRig>();

                            pointer.GetComponent<Renderer>().material.color = UnityEngine.Color.HSVToRGB(Main.h, 1f, 1f);
                            int index = 0;
                            foreach (GliderHoldable glider in GameObject.FindObjectsOfType<GliderHoldable>())
                            {
                                angle += orbitSpeed * Time.deltaTime;

                                // Ensure the angle stays between 0 and 360 degrees
                                if (angle >= 360f)
                                    angle -= 360f;

                                // Calculate the new position
                                float x = Ray.collider.GetComponentInParent<VRRig>().head.rigTarget.transform.position.x + (orbitDistance + index * 10) * Mathf.Cos(angle);
                                float z = Ray.collider.GetComponentInParent<VRRig>().head.rigTarget.transform.position.z + orbitDistance * Mathf.Sin(angle);

                                // Update the position of the orbiting object
                                glider.transform.position = new Vector3(x, glider.transform.position.y, z);

                                // Optional: Make the object always face the target
                                glider.transform.LookAt(Ray.collider.GetComponentInParent<VRRig>().transform);
                                index++;
                            }
                        }
                        GameObject.Destroy(pointer, Time.deltaTime);
                    }
                }

                if (Main.gliderOrbitPlayerLocked && Main.plrToLockOn != null)
                {
                    int index = 0;
                    foreach (GliderHoldable glider in GameObject.FindObjectsOfType<GliderHoldable>())
                    {
                        angle += orbitSpeed * Time.deltaTime;

                        // Ensure the angle stays between 0 and 360 degrees
                        if (angle >= 360f)
                            angle -= 360f;

                        // Calculate the new position
                        float x = Main.plrToLockOn.head.rigTarget.transform.position.x + (orbitDistance + index * 10) * Mathf.Cos(angle);
                        float z = Main.plrToLockOn.head.rigTarget.transform.position.z + orbitDistance * Mathf.Sin(angle);

                        // Update the position of the orbiting object
                        glider.transform.position = new Vector3(x, glider.transform.position.y, z);

                        // Optional: Make the object always face the target
                        glider.transform.LookAt(Main.plrToLockOn.transform);
                        index++;
                    }
                }
            } else
            {
                Main.gliderOrbitPlayerLocked = false;
                Main.plrToLockOn = null;
            }
        }

        public static void GliderBeyblades()
        {
            foreach (GliderHoldable glider in GameObject.FindObjectsOfType(typeof(GliderHoldable)))
            {
                if (glider.photonView.Owner == PhotonNetwork.LocalPlayer)
                {
                    glider.transform.Rotate(Vector3.up, 600 * Time.deltaTime);
                    Main.lastBeybladeRotation = glider.transform.rotation;
                }
                else
                {
                    glider.OnHover(null, null);
                }
            }
        }

        public static async void DestroyGliders()
        {
            foreach (GliderHoldable glider in GameObject.FindObjectsOfType(typeof(GliderHoldable)))
            {
                if (glider.photonView.Owner == PhotonNetwork.LocalPlayer)
                {
                    if (glider.transform.position != new Vector3(9999f, 9999f, 9999f))
                    {
                        Main.gliderPositions.AddItem<Vector3>(glider.transform.position);
                        await Task.Delay(50);
                        glider.transform.position = new Vector3(9999f, 9999f, 9999f);
                    }
                }
                else
                {
                    glider.OnHover(null, null);
                }
            }
        }

        public static void RespawnGliders()
        {
            int index = 0;
            foreach (GliderHoldable glider in GameObject.FindObjectsOfType(typeof(GliderHoldable)))
            {
                if (glider.photonView.Owner == PhotonNetwork.LocalPlayer)
                {
                    if (glider.transform.position == new Vector3(9999f, 9999f, 9999f))
                    {
                        glider.transform.position = Main.gliderPositions[index];
                        Main.gliderPositions[index] = glider.transform.position;
                        index++;
                    }
                }
                else
                {
                    glider.OnHover(null, null);
                }
            }
        }


        public static void GrabBalloons()
        {
            if (Main.rightGrab)
            {
                foreach (BalloonHoldable balloon in GameObject.FindObjectsOfType<BalloonHoldable>())
                {
                    balloon.transform.position = GorillaTagger.Instance.rightHandTransform.position;
                }
            }
        }

        



        public static void BalloonsGun()
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
                GameObject.Destroy(pointer, Time.deltaTime);

                if (Main.rightTrigger == 1f)
                {
                    pointer.GetComponent<Renderer>().material.color = Color.HSVToRGB(Main.h, 1f, 1f);
                    foreach (BalloonHoldable balloon in GameObject.FindObjectsOfType<BalloonHoldable>())
                    {
                        balloon.transform.position = pointer.transform.position;
                    }
                    GameObject.Destroy(pointer, Time.deltaTime);
                }

            }
        }

        

        public static void UprightBalloons()
        {
            foreach (BalloonHoldable balloon in GameObject.FindObjectsOfType<BalloonHoldable>())
            {
                balloon.transform.rotation = Quaternion.Euler(balloon.transform.rotation.x, Main.lastBeybladeRotation.y + 10f, balloon.transform.rotation.z);
                Main.lastBeybladeRotation = balloon.transform.rotation;
            }
        }

        public static void BalloonsBeyblades()
        {
            foreach (BalloonHoldable balloon in GameObject.FindObjectsOfType<BalloonHoldable>())
            {
                Vector3 currentEulerAngles = balloon.transform.rotation.eulerAngles;
                currentEulerAngles.y += 30f;
                balloon.transform.rotation = Quaternion.Euler(currentEulerAngles);
            }
        }

        

        public static void PopAllBalloons()
        {
            foreach (BalloonHoldable balloon in GameObject.FindObjectsOfType<BalloonHoldable>())
            {
                balloon.PopBalloonRemote();
            }
        }

        


        public static void BalloonHead()
        {
            foreach (BalloonHoldable balloon in GameObject.FindObjectsOfType<BalloonHoldable>())
            {
                balloon.transform.position = GorillaTagger.Instance.offlineVRRig.head.rigTarget.transform.position;
            }
        }

        
        public static async void RWaterSplash()
        {
            if (Main.rightTrigger == 1f)
            {
                GorillaTagger.Instance.myVRRig.RPC("PlaySplashEffect", 0, new object[]
                {
                        GorillaTagger.Instance.rightHandTransform.position,
                        UnityEngine.Random.rotation,
                        4f,
                        100f,
                        true,
                        false
                });
                Sounds.RPCProtection();
                Experimental.AntiRpc();
                await Task.Delay(300);
            }
        }

        public static async void GiveRWaterSplash()
        {
            if (Main.rightGrab)
            {
                if (!Main.giveRWaterSplashLocked)
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

                        if (Ray.collider.GetComponentInParent<VRRig>() != null)
                        {
                            Main.plrToLockOn = Ray.collider.GetComponentInParent<VRRig>();
                            Main.giveRWaterSplashLocked = true;
                        }
                        GameObject.Destroy(pointer, Time.deltaTime);
                    }
                }

                if (Main.giveRWaterSplashLocked && Main.plrToLockOn != null)
                {

                        VRRig plr = Main.plrToLockOn;
                        if (plr.rightIndex.triggerValue > 0f)
                        {
                            GorillaTagger.Instance.offlineVRRig.enabled = false;
                            GorillaTagger.Instance.offlineVRRig.transform.position = Main.plrToLockOn.transform.position - new Vector3(0f, 2f, 0f);
                            GorillaTagger.Instance.myVRRig.transform.position = Main.plrToLockOn.transform.position;
                            GorillaTagger.Instance.myVRRig.RPC("PlaySplashEffect", 0, new object[]
                            {
                                plr.rightHandTransform.position,
                                UnityEngine.Random.rotation,
                                4f,
                                100f,
                                true,
                                false
                            });
                            Sounds.RPCProtection();
                            Experimental.AntiRpc();
                            await Task.Delay(350);
                        } else
                    {
                        GorillaTagger.Instance.offlineVRRig.enabled = true;
                    }

                }
            }
            else
            {
                Main.giveRWaterSplashLocked = false;
                Main.plrToLockOn = null;
            }
        }

        public static async void LWaterSplash()
        {
            if (Main.leftTrigger == 1f)
            {
                GorillaTagger.Instance.myVRRig.RPC("PlaySplashEffect", 0, new object[]
                {
                        GorillaTagger.Instance.leftHandTransform.position,
                        UnityEngine.Random.rotation,
                        4f,
                        100f,
                        true,
                        false
                });
                Sounds.RPCProtection();
                Experimental.AntiRpc();
                await Task.Delay(300);
            }
        }


        public static async void GiveLWaterSplash()
        {
            if (Main.rightGrab)
            {
                if (!Main.giveLWaterSplashLocked)
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
                            Main.giveLWaterSplashLocked = true;
                        }
                        GameObject.Destroy(pointer, Time.deltaTime);
                    }
                }

                if (Main.giveLWaterSplashLocked && Main.plrToLockOn != null)
                {
                        VRRig plr = Main.plrToLockOn;
                        if (plr.leftIndex.triggerValue > 0f)
                        {
                            GorillaTagger.Instance.offlineVRRig.enabled = false;
                            GorillaTagger.Instance.offlineVRRig.transform.position = Main.plrToLockOn.transform.position;
                            GorillaTagger.Instance.myVRRig.transform.position = Main.plrToLockOn.transform.position;
                            GorillaTagger.Instance.myVRRig.RPC("PlaySplashEffect", 0, new object[]
                            {
                                plr.leftHandTransform.position,
                                UnityEngine.Random.rotation,
                                4f,
                                100f,
                                true,
                                false
                            });
                            Sounds.RPCProtection();
                            Experimental.AntiRpc();
                            await Task.Delay(350);
                        } else
                    {
                        GorillaTagger.Instance.offlineVRRig.enabled = true;
                    }
                }
            }
            else
            {
                Main.giveLWaterSplashLocked = false;
                Main.plrToLockOn = null;
            }
        }


        public static async void WaterGun()
        {
            if (Main.rightGrab)
            {
                if (!Main.waterGunLocked)
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
                            Main.waterGunLocked = true;
                        }
                        else
                        {
                            GorillaTagger.Instance.offlineVRRig.enabled = false;
                            GorillaTagger.Instance.offlineVRRig.transform.position = pointer.transform.position;
                            GorillaTagger.Instance.myVRRig.transform.position = pointer.transform.position;
                            pointer.GetComponent<Renderer>().material.color = Color.HSVToRGB(Main.h, 1f, 1f);
                            GorillaTagger.Instance.myVRRig.RPC("PlaySplashEffect", 0, new object[]
                            {
                                pointer.transform.position,
                                UnityEngine.Random.rotation,
                                4f,
                                100f,
                                true,
                                false
                            });
                            Sounds.RPCProtection();
                            Experimental.AntiRpc();
                            await Task.Delay(150);
                        }
                        GameObject.Destroy(pointer, Time.deltaTime);
                    } else
                    {
                        GorillaTagger.Instance.offlineVRRig.enabled = true;
                    }
                }

                if (Main.waterGunLocked && Main.plrToLockOn != null)
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = false;
                    GorillaTagger.Instance.offlineVRRig.transform.position = Main.plrToLockOn.transform.position;
                    GorillaTagger.Instance.myVRRig.transform.position = Main.plrToLockOn.transform.position;
                    GorillaTagger.Instance.myVRRig.RPC("PlaySplashEffect", 0, new object[]
                    {
                        Main.plrToLockOn.transform.position,
                        UnityEngine.Random.rotation,
                        4f,
                        100f,
                        true,
                        false
                    });
                    Sounds.RPCProtection();
                    Experimental.AntiRpc();
                    await Task.Delay(150);
                }

            } else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
                Main.waterGunLocked = false;
                Main.plrToLockOn = null;
            }
        }



        public static async void GiveWaterGun()
        {
            if (Main.rightGrab)
            {
                if (!Main.giveWaterGunLocked)
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

                        if (Ray.collider.GetComponentInParent<VRRig>() != null)
                        {
                            Main.plrToLockOn = Ray.collider.GetComponentInParent<VRRig>();
                            Main.giveWaterGunLocked = true;
                        }

                    }
                    GameObject.Destroy(pointer, Time.deltaTime);
                }

                if (Main.giveWaterGunLocked && Main.plrToLockOn != null)
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
                                GorillaTagger.Instance.offlineVRRig.enabled = false;
                                GorillaTagger.Instance.offlineVRRig.transform.position = pointer.transform.position;
                                GorillaTagger.Instance.myVRRig.transform.position = pointer.transform.position;
                                pointer.GetComponent<Renderer>().material.color = Color.HSVToRGB(Main.h, 1f, 1f);
                                GorillaTagger.Instance.myVRRig.RPC("PlaySplashEffect", 0, new object[]
                                {
                                pointer.transform.position,
                                UnityEngine.Random.rotation,
                                4f,
                                100f,
                                true,
                                false
                                });
                                Sounds.RPCProtection();
                                Experimental.AntiRpc();
                                await Task.Delay(250);
                                GameObject.Destroy(pointer, Time.deltaTime);
                            }
                        
                    }
                }
            } else
            {
                Main.giveWaterGunLocked = false;
                Main.plrToLockOn = null;
            }
        }


    }
}
