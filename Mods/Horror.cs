using Photon.Pun;
using StupidTemplate.Menu;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace StupidTemplate.Mods
{
    public class Horror
    {
        public static async void TpToHorrorLab()
        {
            //-112.4874 -99.248 -152.4347
            if (Main.leftPrimary)
            {
                foreach (MeshCollider col in UnityEngine.Object.FindObjectsOfType<MeshCollider>())
                {
                    col.enabled = false;
                }
                await Task.Delay(100);
                GorillaLocomotion.Player.Instance.transform.position = new Vector3(-112.4874f, -99.248f, -152.4347f);
                await Task.Delay(200);
                foreach (MeshCollider col in UnityEngine.Object.FindObjectsOfType<MeshCollider>())
                {
                    col.enabled = true;
                }
            }
        }

        public static void GrabCard()
        {
            if (Main.rightGrab)
            {
                GameObject card = GameObject.Find("Environment Objects/05Maze_PersistentObjects/HiddenIDCard");
                card.transform.position = GorillaTagger.Instance.rightHandTransform.position;
            }
        }

        public static void ToggleAllHorrorFences()
        {
            foreach (GhostLabButton btn in GameObject.FindObjectsOfType<GhostLabButton>())
            {
                btn.SendMessage("ButtonActivation");
            }
        }

        public static async void SpamGates()
        {
            foreach (GhostLab lab in GameObject.FindObjectsOfType<GhostLab>())
            {
                foreach (GhostLabButton btn in  GameObject.FindObjectsOfType<GhostLabButton>())
                {
                    btn.Invoke("ButtonActivation", Time.deltaTime);
                    await Task.Delay(100);
                }
            }
        }


    }
}
