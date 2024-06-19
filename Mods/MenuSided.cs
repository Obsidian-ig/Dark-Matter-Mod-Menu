using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using StupidTemplate.Menu;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace StupidTemplate.Mods
{
    public class MenuSided
    {
        public static void BiggerSmallerHandler()
        {

            if (Main.rightTrigger == 1f)
            {
                GorillaLocomotion.Player.Instance.scale += 0.1f;
            }

            if (Main.leftTrigger == 1f)
            {
                GorillaLocomotion.Player.Instance.scale -= 0.1f;
            }
            
            object[] eventContent = new object[]
            {
                GorillaLocomotion.Player.Instance.scale,
                PhotonNetwork.LocalPlayer.UserId
            };
            RaiseEventOptions raiseEventOptions = new RaiseEventOptions
            {
                Receivers = ReceiverGroup.Others
            };
            PhotonNetwork.RaiseEvent(69, eventContent, raiseEventOptions, SendOptions.SendReliable);
        }

        public static void BiggerSmallerDougHandler()
        {

            if (Main.rightTrigger == 1f)
            {
                GameObject.Find("Floating Bug Holdable").GetComponent<ThrowableBug>().transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
            }

            if (Main.leftTrigger == 1f)
            {
                GameObject.Find("Floating Bug Holdable").GetComponent<ThrowableBug>().transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
            }

            object[] eventContent = new object[]
            {
                GameObject.Find("Floating Bug Holdable").GetComponent<ThrowableBug>().transform.localScale,
            };
            RaiseEventOptions raiseEventOptions = new RaiseEventOptions
            {
                Receivers = ReceiverGroup.Others
            };
            PhotonNetwork.RaiseEvent(70, eventContent, raiseEventOptions, SendOptions.SendReliable);
        }

        public static void BiggerSmallerMattHandler()
        {

            if (Main.rightTrigger == 1f)
            {
                GameObject.Find("Cave Bat Holdable").GetComponent<ThrowableBug>().transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
            }

            if (Main.leftTrigger == 1f)
            {
                GameObject.Find("Cave Bat Holdable").GetComponent<ThrowableBug>().transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
            }

            object[] eventContent = new object[]
            {
                GameObject.Find("Cave Bat Holdable").GetComponent<ThrowableBug>().transform.localScale,
            };
            RaiseEventOptions raiseEventOptions = new RaiseEventOptions
            {
                Receivers = ReceiverGroup.Others
            };
            PhotonNetwork.RaiseEvent(71, eventContent, raiseEventOptions, SendOptions.SendReliable);
        }

        public static void MenuNetwork(EventData eventData)
        {
            if (Main.allowMenuSidedMods)
            {
                byte code = eventData.Code;

                if (code == 69)
                {
                    object[] array = (object[])eventData.CustomData;
                    foreach (VRRig plr in GorillaParent.instance.vrrigs)
                    {
                        if (plr.Creator.UserId.ToString() == array[1].ToString())
                        {
                            plr.transform.localScale = (Vector3)array[0];
                        }
                    }
                }

                if (code == 70)
                {
                    object[] array = (object[])eventData.CustomData;
                    GameObject.Find("Floating Bug Holdable").GetComponent<ThrowableBug>().transform.localScale = (Vector3)array[0];
                }

                if (code == 71)
                {
                    object[] array = (object[])eventData.CustomData;
                    GameObject.Find("Cave Bat Holdable").GetComponent<ThrowableBug>().transform.localScale = (Vector3)array[0];
                }
            }
        }
    }
}
