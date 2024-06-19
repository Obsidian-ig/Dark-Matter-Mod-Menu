using Photon.Pun;
using StupidTemplate.Menu;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StupidTemplate.Mods
{
    internal class Sounds
    {
        public static void RPCProtection()
        {

            PhotonNetwork.RemoveRPCs(PhotonNetwork.LocalPlayer);
            PhotonNetwork.OpCleanRpcBuffer(GorillaTagger.Instance.myVRRig);
            PhotonNetwork.RemoveBufferedRPCs(GorillaTagger.Instance.myVRRig.ViewID, null, null);
            PhotonNetwork.RemoveRPCsInGroup(int.MaxValue);
            PhotonNetwork.SendAllOutgoingCommands();
            GorillaNot.instance.OnPlayerLeftRoom(PhotonNetwork.LocalPlayer);
        }

        public static async void AK47 ()
        {
            if (Main.rightGrab)
            {
                GorillaTagger.Instance.myVRRig.RPC("PlayHandTap", RpcTarget.All, new object[]{
                    203,
                    false,
                    999999f
                });
                RPCProtection();
                await Task.Delay(150);
            }
        }

        public static async void Random()
        {
            if (Main.rightGrab)
            {
                GorillaTagger.Instance.myVRRig.RPC("PlayHandTap", RpcTarget.All, new object[]{
                    UnityEngine.Random.Range(1, 255),
                    false,
                    999999f
                });
                RPCProtection();
                await Task.Delay(150);
            }
        }

        public static void ChangeSoundId(int changeBy)
        {
            Main.soundId += changeBy;
        }

        public static async void CustomSound()
        {
            if (Main.rightGrab)
            {
                GorillaTagger.Instance.myVRRig.RPC("PlayHandTap", RpcTarget.All, new object[]{
                    Main.soundId,
                    false,
                    999999f
                });
                RPCProtection();
                await Task.Delay(150);
            }
        }
    }
}
