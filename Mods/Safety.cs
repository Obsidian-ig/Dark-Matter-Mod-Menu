using Photon.Pun;
using StupidTemplate.Menu;
using StupidTemplate.Notifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace StupidTemplate.Mods
{
    public class Safety
    {
        public static async void AntireportDisconnect()
        {
            {
                try
                {
                    foreach (GorillaPlayerScoreboardLine gorillaPlayerScoreboardLine in GorillaScoreboardTotalUpdater.allScoreboardLines)
                    {
                        if (gorillaPlayerScoreboardLine.linePlayer == NetworkSystem.Instance.LocalPlayer)
                        {
                            Transform transform = gorillaPlayerScoreboardLine.reportButton.gameObject.transform;
                            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                            {
                                if (vrrig != GorillaTagger.Instance.offlineVRRig)
                                {
                                    float num = Vector3.Distance(vrrig.rightHandTransform.position, transform.position);
                                    float num2 = Vector3.Distance(vrrig.leftHandTransform.position, transform.position);
                                    float num3 = 0.35f;
                                    if (num < num3 || num2 < num3)
                                    {

                                        PhotonNetwork.Disconnect();

                                        if (!Main.sentReportNotif)
                                        {
                                            NotifiLib.SendNotification("<color=grey>[</color><color=red>SOMEONE ATTEMPTED TO REPORT YOU!</color>");
                                            Main.sentReportNotif = true;
                                            
                                        } else
                                        {
                                            await Task.Delay(5000);
                                            Main.sentReportNotif = false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch { }
            }
        }
    }
}
