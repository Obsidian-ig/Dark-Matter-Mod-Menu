using Photon.Pun;
using StupidTemplate.Menu;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace StupidTemplate.Mods
{
    public class Visual
    {
        public static void SkeletonESP()
        {
            int[] bones = new int[]
            {
            4, 3, 5, 4, 19, 18, 20, 19, 3, 18, 21, 20, 22, 21, 25, 21, 29, 21, 31, 29, 27, 25, 24, 22, 6, 5, 7, 6, 10, 6, 14, 6, 16, 14, 12, 10, 9, 7
            };

            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (!vrrig.isMyPlayer)
                {
                    // Create a new GameObject for holding LineRenderers
                    GameObject skeletonGO = new GameObject("SkeletonESP");
                    skeletonGO.transform.SetParent(vrrig.transform); // Optional: Parent it to the VRRig for organization

                    for (int i = 0; i < bones.Length; i += 2)
                    {
                        Vector3 lineStart = vrrig.mainSkin.bones[bones[i]].position;
                        Vector3 lineEnd = vrrig.mainSkin.bones[bones[i + 1]].position;

                        // Create a new GameObject for each line segment
                        GameObject lineGO = new GameObject("BoneLine");
                        lineGO.transform.SetParent(skeletonGO.transform); // Optional: Parent it to the SkeletonESP GO

                        LineRenderer lineRen = lineGO.AddComponent<LineRenderer>();

                        // Configure the LineRenderer
                        lineRen.startWidth = 0.01f; // Set the line width
                        lineRen.endWidth = 0.01f; // Set the line width
                        lineRen.material = new Material(Shader.Find("GUI/Text Shader")); // Use a basic material
                        lineRen.startColor = Color.HSVToRGB(Main.h, 1f, 1f); // Set the line color
                        lineRen.endColor = Color.HSVToRGB(Main.h, 1f, 1f); // Set the line color
                        lineRen.positionCount = 2; // Number of points in the line

                        // Set the positions for the LineRenderer
                        lineRen.SetPosition(0, lineStart);
                        lineRen.SetPosition(1, lineEnd);
                        UnityEngine.Object.Destroy(lineGO.GetComponent<LineRenderer>(), Time.deltaTime);
                        UnityEngine.GameObject.Destroy(lineGO, Time.deltaTime);
                    }
                    UnityEngine.GameObject.Destroy(skeletonGO, Time.deltaTime);
                }
            }
        }

        public static List<Color> OriginPlrColors = new List<Color>();
        public static void BuggyChams()
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (vrrig.Creator.UserId != PhotonNetwork.LocalPlayer.UserId)
                {
                    vrrig.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
                }
            }
        }

        public static void FixPlayerShader()
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (vrrig.Creator.UserId != PhotonNetwork.LocalPlayer.UserId)
                {
                    vrrig.mainSkin.material.shader = Shader.Find("GorillaTag/UberShader");
                }
            }
        }


        public static void BoxEsp2D()
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (vrrig.Creator.UserId != PhotonNetwork.LocalPlayer.UserId)
                {
                    GameObject box = new GameObject("ESPBox");
                    box.transform.position = vrrig.transform.position;

                    Vector3 direction = box.transform.position - GorillaTagger.Instance.headCollider.transform.position;
                    Quaternion rotation = Quaternion.LookRotation(direction);
                    box.transform.rotation = rotation;

                    // Add and configure LineRenderer
                    LineRenderer lineRenderer = box.AddComponent<LineRenderer>();
                    lineRenderer.startWidth = 0.1f;
                    lineRenderer.endWidth = 0.1f;
                    lineRenderer.material.color = vrrig.mainSkin.material.color;
                    lineRenderer.material.shader = Shader.Find("GUI/Text Shader");
                    lineRenderer.positionCount = 5;
                    lineRenderer.useWorldSpace = false;
                    lineRenderer.loop = false;
                    lineRenderer.widthMultiplier = 0.1f;

                    box.transform.localScale = new Vector3(0.4f, 0.7f, 0.3f);

                    Vector3[] corners = new Vector3[5];

                    float halfWidth = box.transform.localScale.x / 2;
                    float halfHeight = box.transform.localScale.y / 2;

                    corners[0] = new Vector3(-halfWidth, -halfHeight, 0);
                    corners[1] = new Vector3(halfWidth, -halfHeight, 0);
                    corners[2] = new Vector3(halfWidth, halfHeight, 0);
                    corners[3] = new Vector3(-halfWidth, halfHeight, 0);
                    corners[4] = corners[0];

                    lineRenderer.SetPositions(corners);

                    GameObject.Destroy(lineRenderer, Time.deltaTime);
                    GameObject.Destroy(box, Time.deltaTime);
                }
            }
        }


        public static void BoxEsp3D()
        {
            //chat gpt carried lmao im too lazy to code this shit lmao
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (vrrig.Creator.UserId != PhotonNetwork.LocalPlayer.UserId)
                {
                    GameObject box = new GameObject("ESPBox");
                    box.transform.position = vrrig.transform.position;

                    Vector3 direction = box.transform.position - GorillaTagger.Instance.headCollider.transform.position;
                    Quaternion rotation = Quaternion.LookRotation(direction);
                    box.transform.rotation = rotation;

                    LineRenderer lineRenderer = box.AddComponent<LineRenderer>();
                    lineRenderer.startWidth = 0.1f;
                    lineRenderer.endWidth = 0.1f;
                    lineRenderer.material.color = vrrig.mainSkin.material.color;
                    lineRenderer.material.shader = Shader.Find("GUI/Text Shader");
                    lineRenderer.positionCount = 24;
                    lineRenderer.useWorldSpace = false;
                    lineRenderer.loop = false;
                    lineRenderer.widthMultiplier = 0.1f;

                    box.transform.localScale = new Vector3(0.4f, 0.7f, 0.3f);

                    Vector3[] corners = new Vector3[8];

                    float halfWidth = box.transform.localScale.x / 2;
                    float halfHeight = box.transform.localScale.y / 2;
                    float halfDepth = box.transform.localScale.z / 2;

                    corners[0] = new Vector3(-halfWidth, -halfHeight, -halfDepth); // Bottom-front-left
                    corners[1] = new Vector3(halfWidth, -halfHeight, -halfDepth);  // Bottom-front-right
                    corners[2] = new Vector3(halfWidth, -halfHeight, halfDepth);   // Bottom-back-right
                    corners[3] = new Vector3(-halfWidth, -halfHeight, halfDepth);  // Bottom-back-left
                    corners[4] = new Vector3(-halfWidth, halfHeight, -halfDepth);  // Top-front-left
                    corners[5] = new Vector3(halfWidth, halfHeight, -halfDepth);   // Top-front-right
                    corners[6] = new Vector3(halfWidth, halfHeight, halfDepth);    // Top-back-right
                    corners[7] = new Vector3(-halfWidth, halfHeight, halfDepth);   // Top-back-left

                    Vector3[] positions = new Vector3[24]
                    {
                    // Bottom edges
                    corners[0], corners[1],
                    corners[1], corners[2],
                    corners[2], corners[3],
                    corners[3], corners[0],
                    // Top edges
                    corners[4], corners[5],
                    corners[5], corners[6],
                    corners[6], corners[7],
                    corners[7], corners[4],
                    // Vertical edges
                    corners[0], corners[4],
                    corners[1], corners[5],
                    corners[2], corners[6],
                    corners[3], corners[7]
                    };

                    lineRenderer.SetPositions(positions);

                    box.transform.position = vrrig.transform.position;

                    GameObject.Destroy(lineRenderer, Time.deltaTime);
                    GameObject.Destroy(box, Time.deltaTime);
                }
            }
        }

        public static void InfectionTracersHand()
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                GameObject lineRendererObject = new GameObject("InfectionTracer");

                LineRenderer lineRenderer = lineRendererObject.AddComponent<LineRenderer>();

                lineRenderer.positionCount = 2;
                lineRenderer.SetPosition(0, GorillaTagger.Instance.rightHandTransform.position);
                lineRenderer.SetPosition(1, vrrig.head.rigTarget.position);
                lineRenderer.startWidth = 0.15f;
                lineRenderer.endWidth = 0.15f;
                lineRenderer.material = new Material(Shader.Find("GUI/Text Shader")); // You can set your own material here
                if (vrrig.mainSkin.material.name.Contains("fected"))
                {
                    lineRenderer.startColor = Color.red;
                    lineRenderer.endColor = Color.red;
                } else
                {
                    lineRenderer.startColor = Color.green;
                    lineRenderer.endColor = Color.green;
                }
                UnityEngine.Object.Destroy(lineRenderer, Time.deltaTime);
                GameObject.Destroy(lineRendererObject, Time.deltaTime);
            }
        }
    }
}
