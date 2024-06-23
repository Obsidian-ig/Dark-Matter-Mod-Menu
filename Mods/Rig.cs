using Fusion;
using HarmonyLib;
using Photon.Pun;
using PlayFab.ClientModels;
using StupidTemplate.Menu;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace StupidTemplate.Mods
{
    internal class Rig
    {


        public static void ChasePlayerGun()
        {
            if (Main.rightGrab)
            {
                if (!Main.chasePlayerGunLocked)
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
                        if (Ray.collider.GetComponentInParent<VRRig>())
                        {
                            VRRig plr = Ray.collider.GetComponentInParent<VRRig>();
                            Main.plrToLockOn = plr;
                            Main.chasePlayerGunLocked = true;
                            GorillaTagger.Instance.offlineVRRig.enabled = false;
                            Main.ghostRigActive = true;
                            GorillaTagger.Instance.offlineVRRig.transform.LookAt(plr.transform);
                            GorillaTagger.Instance.offlineVRRig.transform.position += GorillaTagger.Instance.offlineVRRig.transform.forward * 30 * Time.deltaTime;
                        }
                        GameObject.Destroy(pointer, Time.deltaTime);
                    }
                }

                if (Main.chasePlayerGunLocked && Main.plrToLockOn != null)
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = false;
                    GorillaTagger.Instance.offlineVRRig.transform.LookAt(Main.plrToLockOn.transform);
                    GorillaTagger.Instance.offlineVRRig.transform.position += GorillaTagger.Instance.offlineVRRig.transform.forward * 30 * Time.deltaTime;
                }

            }
            else
            {
                Main.chasePlayerGunLocked = false;
                Main.plrToLockOn = null;
                GorillaTagger.Instance.offlineVRRig.enabled = true;
                Main.ghostRigActive = false;
            }
        }

        public static void FixTrackingOffsets()
        {
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.x = 0f;
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.y = 0f;
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.z = 0f;
            /*GorillaTagger.Instance.offlineVRRig.head.trackingPositionOffset.x = 0f;
            GorillaTagger.Instance.offlineVRRig.head.trackingPositionOffset.y = 0f;
            GorillaTagger.Instance.offlineVRRig.head.trackingPositionOffset.z = 0f;
            GorillaTagger.Instance.offlineVRRig.headBodyOffset.x = 0f;
            GorillaTagger.Instance.offlineVRRig.headBodyOffset.y = 0f;
            GorillaTagger.Instance.offlineVRRig.headBodyOffset.z = 0f;*/
        }

        public static void BackwardsHead()
        {
            if (!Main.updatedTrackingOffsets)
            {
                Main.originalHeadRotationTrackingOffsetX = GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.x;
                Main.originalHeadRotationTrackingOffsetY = GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.y;
                Main.originalHeadRotationTrackingOffsetZ = GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.z;

                Main.originalHeadPositionTrackingOffsetX = GorillaTagger.Instance.offlineVRRig.head.trackingPositionOffset.x;
                Main.originalHeadPositionTrackingOffsetX = GorillaTagger.Instance.offlineVRRig.head.trackingPositionOffset.y;
                Main.originalHeadPositionTrackingOffsetX = GorillaTagger.Instance.offlineVRRig.head.trackingPositionOffset.z;

                Main.updatedTrackingOffsets = true;
            }
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.y = 180f;
        }

        public static void UpsideDownHead()
        {
            if (!Main.updatedTrackingOffsets)
            {
                Main.originalHeadRotationTrackingOffsetX = GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.x;
                Main.originalHeadRotationTrackingOffsetY = GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.y;
                Main.originalHeadRotationTrackingOffsetZ = GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.z;

                Main.originalHeadPositionTrackingOffsetX = GorillaTagger.Instance.offlineVRRig.head.trackingPositionOffset.x;
                Main.originalHeadPositionTrackingOffsetX = GorillaTagger.Instance.offlineVRRig.head.trackingPositionOffset.y;
                Main.originalHeadPositionTrackingOffsetX = GorillaTagger.Instance.offlineVRRig.head.trackingPositionOffset.z;

                Main.updatedTrackingOffsets = true;
            }
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.x = -180f;
        }

        public static void SpinHeadX()
        {
            if (!Main.updatedTrackingOffsets)
            {
                Main.originalHeadRotationTrackingOffsetX = GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.x;
                Main.originalHeadRotationTrackingOffsetY = GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.y;
                Main.originalHeadRotationTrackingOffsetZ = GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.z;

                Main.originalHeadPositionTrackingOffsetX = GorillaTagger.Instance.offlineVRRig.head.trackingPositionOffset.x;
                Main.originalHeadPositionTrackingOffsetX = GorillaTagger.Instance.offlineVRRig.head.trackingPositionOffset.y;
                Main.originalHeadPositionTrackingOffsetX = GorillaTagger.Instance.offlineVRRig.head.trackingPositionOffset.z;

                Main.updatedTrackingOffsets = true;
            }
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.x += 15;
        }

        public static void SpinHeadY()
        {
            if (!Main.updatedTrackingOffsets)
            {
                Main.originalHeadRotationTrackingOffsetX = GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.x;
                Main.originalHeadRotationTrackingOffsetY = GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.y;
                Main.originalHeadRotationTrackingOffsetZ = GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.z;

                Main.originalHeadPositionTrackingOffsetX = GorillaTagger.Instance.offlineVRRig.head.trackingPositionOffset.x;
                Main.originalHeadPositionTrackingOffsetX = GorillaTagger.Instance.offlineVRRig.head.trackingPositionOffset.y;
                Main.originalHeadPositionTrackingOffsetX = GorillaTagger.Instance.offlineVRRig.head.trackingPositionOffset.z;

                Main.updatedTrackingOffsets = true;
            }
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.y += 15;
        }

        public static void SpinHeadZ()
        {
            if (!Main.updatedTrackingOffsets)
            {
                Main.originalHeadRotationTrackingOffsetX = GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.x;
                Main.originalHeadRotationTrackingOffsetY = GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.y;
                Main.originalHeadRotationTrackingOffsetZ = GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.z;

                Main.originalHeadPositionTrackingOffsetX = GorillaTagger.Instance.offlineVRRig.head.trackingPositionOffset.x;
                Main.originalHeadPositionTrackingOffsetX = GorillaTagger.Instance.offlineVRRig.head.trackingPositionOffset.y;
                Main.originalHeadPositionTrackingOffsetX = GorillaTagger.Instance.offlineVRRig.head.trackingPositionOffset.z;

                Main.updatedTrackingOffsets = true;
            }
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.z += 15;
        }

        public static void HeadPositionTestX()
        {
            if (!Main.updatedTrackingOffsets)
            {
                Main.originalHeadRotationTrackingOffsetX = GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.x;
                Main.originalHeadRotationTrackingOffsetY = GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.y;
                Main.originalHeadRotationTrackingOffsetZ = GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.z;

                Main.originalHeadPositionTrackingOffsetX = GorillaTagger.Instance.offlineVRRig.head.trackingPositionOffset.x;
                Main.originalHeadPositionTrackingOffsetX = GorillaTagger.Instance.offlineVRRig.head.trackingPositionOffset.y;
                Main.originalHeadPositionTrackingOffsetX = GorillaTagger.Instance.offlineVRRig.head.trackingPositionOffset.z;

                Main.updatedTrackingOffsets = true;
            }
            GorillaTagger.Instance.offlineVRRig.head.trackingPositionOffset.x += 1 * Time.deltaTime;
        }

        public static void HeadPositionTestY()
        {
            if (!Main.updatedTrackingOffsets)
            {
                Main.originalHeadRotationTrackingOffsetX = GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.x;
                Main.originalHeadRotationTrackingOffsetY = GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.y;
                Main.originalHeadRotationTrackingOffsetZ = GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.z;

                Main.originalHeadPositionTrackingOffsetX = GorillaTagger.Instance.offlineVRRig.head.trackingPositionOffset.x;
                Main.originalHeadPositionTrackingOffsetX = GorillaTagger.Instance.offlineVRRig.head.trackingPositionOffset.y;
                Main.originalHeadPositionTrackingOffsetX = GorillaTagger.Instance.offlineVRRig.head.trackingPositionOffset.z;

                Main.updatedTrackingOffsets = true;
            }
            GorillaTagger.Instance.offlineVRRig.head.trackingPositionOffset.y += 1 * Time.deltaTime;
        }

        public static void HeadPositionTestZ()
        {
            if (!Main.updatedTrackingOffsets)
            {
                Main.originalHeadRotationTrackingOffsetX = GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.x;
                Main.originalHeadRotationTrackingOffsetY = GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.y;
                Main.originalHeadRotationTrackingOffsetZ = GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.z;

                Main.originalHeadPositionTrackingOffsetX = GorillaTagger.Instance.offlineVRRig.head.trackingPositionOffset.x;
                Main.originalHeadPositionTrackingOffsetX = GorillaTagger.Instance.offlineVRRig.head.trackingPositionOffset.y;
                Main.originalHeadPositionTrackingOffsetX = GorillaTagger.Instance.offlineVRRig.head.trackingPositionOffset.z;

                Main.updatedTrackingOffsets = true;
            }
            GorillaTagger.Instance.offlineVRRig.head.trackingPositionOffset.z += 1 * Time.deltaTime;
        }

        public static void RigGun()
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

                if (Main.rightTrigger >= 1f)
                {
                    pointer.GetComponent<Renderer>().material.color = UnityEngine.Color.HSVToRGB(Main.h, 1f, 1f);
                    GorillaTagger.Instance.offlineVRRig.enabled = false;
                    Main.ghostRigActive = true;
                    GorillaTagger.Instance.offlineVRRig.transform.position = pointer.transform.position;
                    try
                    {
                        GorillaTagger.Instance.myVRRig.transform.position = pointer.transform.position;
                    } catch(Exception) { }
                    GameObject.Destroy(pointer, Time.deltaTime);
                } else if (Main.rightTrigger == 0f)
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = true;
                    Main.ghostRigActive = false;
                }
                GameObject.Destroy(pointer, Time.deltaTime);
            }
        }

        public static void HoldRig()
        {
            if (Main.rightGrab)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                Main.ghostRigActive = true;
                GorillaTagger.Instance.offlineVRRig.transform.position = GorillaTagger.Instance.rightHandTransform.position + new Vector3(0f, 0.2f, 0f);
                try
                {
                    GorillaTagger.Instance.myVRRig.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position;
                } catch (Exception) { }
            } else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
                Main.ghostRigActive = false;
            }
        }

        

        public static void InvisMonke()
        {
            if (Main.rightSecondary)
            {
                GorillaTagger.Instance.offlineVRRig.headBodyOffset = new Vector3(9999f, 9999f, 9999f);
                Main.ghostRigActive = true;
            } else
            {
                GorillaTagger.Instance.offlineVRRig.headBodyOffset = Vector3.zero;
                Main.ghostRigActive = false;
            }
        }

        public static void GhostMonke()
        {
            if (Main.rightSecondary)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                try
                {
                    GorillaTagger.Instance.myVRRig.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position;
                }
                catch (Exception) { }
                Main.ghostRigActive = true;
            } else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
                Main.ghostRigActive = false;
            }
        }

        public static async void Bees()
        {
            if (Main.rightPrimary)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                Main.ghostRigActive = true;
                foreach (VRRig plr in GorillaParent.instance.vrrigs)
                {
                    GorillaTagger.Instance.offlineVRRig.transform.position = plr.transform.position;
                    try
                    {
                        GorillaTagger.Instance.myVRRig.transform.position = plr.transform.position;
                    } catch (Exception) { }
                    await Task.Delay(100);
                    continue;
                }
            } else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
                Main.ghostRigActive = false;
            }
        }

        public static void SteamLongArms()
        {
            GorillaLocomotion.Player.Instance.transform.localScale = new Vector3(1.15f, 1.15f, 1.15f);
        }

        public static void CustomLongArms()
        {
            GorillaLocomotion.Player.Instance.transform.localScale = new Vector3(Main.armLength, Main.armLength, Main.armLength);
        }

        public static void ChangeArmSizeBy(float size)
        {
            Main.armLength += size;
        }

        public static void FixScale()
        {
            GorillaLocomotion.Player.Instance.transform.localScale = new Vector3(1f, 1f, 1f);
        }

        public static void ThirdPerson()
        {
            if (Main.leftPrimary)
            {
                Main.thirdPersonEnabled = true;
            } else
            {
                Main.thirdPersonEnabled = false;
            }

            if (Main.thirdPersonEnabled)
            {
                GameObject.Find("Main Camera").GetComponent<Camera>().enabled = false;
                GameObject.Find("Player Objects/Third Person Camera/Shoulder Camera").GetComponent<Camera>().enabled = true;
            } else
            {
                GameObject.Find("Main Camera").GetComponent<Camera>().enabled = true;
                GameObject.Find("Player Objects/Third Person Camera/Shoulder Camera").GetComponent<Camera>().enabled = false;
                Task.Delay(200);
                GameObject.Find("Player Objects/Third Person Camera/Shoulder Camera").GetComponent<Camera>().enabled = true;
            }
        }

        public static void LookAtPlayerGun()
        {
            if (Main.rightGrab)
            {
                if (!Main.lookAtPlayerLocked)
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
                        if (Ray.collider.GetComponentInParent<VRRig>())
                        {
                            VRRig plr = Ray.collider.GetComponentInParent<VRRig>();
                            Main.plrToLockOn = plr;
                            Main.lookAtPlayerLocked = true;
                            GorillaTagger.Instance.offlineVRRig.head.rigTarget.transform.LookAt(plr.transform);
                        }
                        GameObject.Destroy(pointer, Time.deltaTime);
                    }
                }

                if (Main.lookAtPlayerLocked && Main.plrToLockOn != null)
                {
                    GorillaTagger.Instance.offlineVRRig.head.rigTarget.transform.LookAt(Main.plrToLockOn.transform);
                }

            } else
            {
                Main.lookAtPlayerLocked = false;
                Main.plrToLockOn = null;
            }
        }

        public static void LookAtClosest()
        {
            List<VRRig> plrVRRigs = new List<VRRig>();
            foreach (VRRig plr in GorillaParent.instance.vrrigs)
            {
                plrVRRigs.Add(plr);


                if (plrVRRigs.Count == 0)
                {
                    return;
                }

                plrVRRigs.Sort((a, b) =>
                    Vector3.Distance(a.transform.position, GorillaTagger.Instance.offlineVRRig.transform.position)
                    .CompareTo(Vector3.Distance(b.transform.position, GorillaTagger.Instance.offlineVRRig.transform.position))
                );

                if (plrVRRigs[0].Creator.UserId != PhotonNetwork.LocalPlayer.UserId)
                {
                    GorillaTagger.Instance.offlineVRRig.head.rigTarget.transform.LookAt(plrVRRigs[0].transform);
                } else
                {
                    GorillaTagger.Instance.offlineVRRig.head.rigTarget.transform.LookAt(plrVRRigs[1].transform);
                }
                
            }
        }

        public static void SpinBot()
        {
            GorillaTagger.Instance.offlineVRRig.enabled = false;
            Vector3 currentEulerAngles = GorillaTagger.Instance.offlineVRRig.transform.rotation.eulerAngles;
            currentEulerAngles.y += 10f;
            
            GorillaTagger.Instance.offlineVRRig.transform.rotation = Quaternion.Euler(currentEulerAngles);
            GorillaTagger.Instance.offlineVRRig.transform.position = GorillaLocomotion.Player.Instance.transform.position;
            Main.ghostRigActive = true;
        }


        public static void DisableSpinBot()
        {
            GorillaTagger.Instance.offlineVRRig.enabled = true;
            Main.ghostRigActive = false;
        }

    }
}
