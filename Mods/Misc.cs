using GorillaNetworking;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace StupidTemplate.Mods
{
    public class Misc
    {
        public static void UnlockComp()
        {
            GorillaComputer cm = GameObject.FindFirstObjectByType<GorillaComputer>();
            cm.allowedInCompetitive = true;
        }

        public static void LockComp()
        {
            GorillaComputer cm = GameObject.FindFirstObjectByType<GorillaComputer>();
            cm.allowedInCompetitive = false;
        }

        public static void DisableAfkKick()
        {
            PhotonNetworkController.Instance.disableAFKKick = true;
        }

        public static void EnableAfkKick()
        {
            PhotonNetworkController.Instance.disableAFKKick = false;
        }

        public static void CustomBoards()
        {
            Material material = new Material(Shader.Find("GorillaTag/UberShader"));
            material.color = Color.Lerp(Color.black, Color.magenta, Mathf.PingPong(Time.time, 1f));
            GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/StaticUnlit/motdscreen").GetComponent<MeshRenderer>().material = material;
            GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/StaticUnlit/screen").GetComponent<Renderer>().material = material;
            GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Terrain/campgroundstructure/scoreboard/REMOVE board").GetComponent<Renderer>().material = material;
            GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/-- PhysicalComputer UI --/monitor").GetComponent<Renderer>().material = material;
            GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/Wall Monitors Screens/wallmonitorcanyon").GetComponent<Renderer>().material = material;
            GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/Wall Monitors Screens/wallmonitorcosmetics").GetComponent<Renderer>().material = material;
            GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/Wall Monitors Screens/wallmonitorcave").GetComponent<Renderer>().material = material;
            GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/Wall Monitors Screens/wallmonitorforest").GetComponent<Renderer>().material = material;
            GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/Wall Monitors Screens/wallmonitorskyjungle").GetComponent<Renderer>().material = material;
            GameObject.Find("Environment Objects/LocalObjects_Prefab/Standard Sky/newsky (1)").GetComponent<Renderer>().material = material;
            GameObject.Find("Environment Objects/LocalObjects_Prefab/Standard Sky").GetComponent<Renderer>().material = material;
            GameObject.Find("motdtext").GetComponent<Text>().text = "Thank you for using Dark Matter! If you get reported and banned I am not responsible for that.";
            GameObject.Find("COC Text").GetComponent<Text>().text = "Made by @ObsidianDev because i'm fucking bored and have nothing else to do.";
            GameObject.Find("CodeOfConduct").GetComponent<Text>().text = "Backstory";
            GameObject.Find("motd").GetComponent<Text>().text = "Dark Matter V5";
        }
    }
}
