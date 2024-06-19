using BepInEx;
using HarmonyLib;
using Photon.Pun;
using StupidTemplate.Classes;
using StupidTemplate.Notifications;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.XR;
using static StupidTemplate.Menu.Buttons;
using static StupidTemplate.Settings;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using StupidTemplate.Mods;
using ExitGames.Client.Photon;

namespace StupidTemplate.Menu
{
    [HarmonyPatch(typeof(GorillaLocomotion.Player))]
    [HarmonyPatch("LateUpdate", MethodType.Normal)]
    public class Main : MonoBehaviour
    {
        // Constant
        public static string ownerId = "";
        
        public static async void Prefix()
        {
            // Initialize Menu
            try
            {
                if (!completedChecks)
                {
                    try
                    {
                        GorillaNot.instance.rpcCallLimit = int.MaxValue;
                        GorillaNot.instance.rpcErrorMax = int.MaxValue;
                        GameObject.Destroy(GorillaNot.instance);
                        string allowedToOpen = await GetStringFromPastebinAsync(menuKillPastebin);
                        string menuVersion = await GetStringFromPastebinAsync(menuVersionPastebin);
                        await Task.Delay(500);
                        ownerId = await GetStringFromPastebinAsync(ownerIdPastebin);

                        if (allowedToOpen == "false" || allowedToOpen == "")
                        {
                            completedChecks = true;
                            File.WriteAllText("allowedToOpen.txt", allowedToOpen);
                        }
                        else
                        {
                            completedChecks = true;
                            File.WriteAllText("allowedToOpen.txt", allowedToOpen);
                        }

                        if (Convert.ToInt32(menuVersion) > currentMenuVersion)
                        {
                            NotifiLib.SendNotification($"<color=red>UPDATE REQUIRED!</color> <color=gray>  Local Menu Version: {currentMenuVersion}</color> <color=blue>  Most Updated Version: {menuVersion}</color>");
                            completedChecks = false;
                        }
                    } catch (Exception ex)
                    {
                        File.WriteAllText("error.txt", ex.ToString());
                    }
                    PhotonNetwork.NetworkingClient.EventReceived += MenuSided.MenuNetwork;
                }
                bool toOpen = (!rightHanded && ControllerInputPoller.instance.leftControllerSecondaryButton) || (rightHanded && ControllerInputPoller.instance.rightControllerSecondaryButton);
                bool keyboardOpen = UnityInput.Current.GetKey(keyboardButton);

                    
                if (completedChecks)
                {
                    if (menu == null)
                    {
                        if (toOpen || keyboardOpen)
                        {
                            CreateMenu();
                            RecenterMenu(rightHanded, keyboardOpen);
                            if (reference == null)
                            {
                                CreateReference(rightHanded);
                            }
                        }
                    }
                    else
                    {
                        if ((toOpen || keyboardOpen))
                        {
                            RecenterMenu(rightHanded, keyboardOpen);
                            if (keyboardOpen)
                            {
                                Cursor.lockState = CursorLockMode.None;
                                Cursor.visible = true;
                            } else
                            {
                                Cursor.lockState = CursorLockMode.Locked;
                                Cursor.visible = false;
                            }
                        }
                        else
                        {
                            Cursor.lockState = CursorLockMode.Locked;
                            Cursor.visible = false;
                            Rigidbody comp = menu.AddComponent(typeof(Rigidbody)) as Rigidbody;
                            if (rightHanded)
                            {
                                comp.velocity = GorillaLocomotion.Player.Instance.rightHandCenterVelocityTracker.GetAverageVelocity(true, 0);
                            }
                            else
                            {
                                comp.velocity = GorillaLocomotion.Player.Instance.leftHandCenterVelocityTracker.GetAverageVelocity(true, 0);
                            }

                            UnityEngine.Object.Destroy(menu, 2);
                            menu = null;

                            UnityEngine.Object.Destroy(reference);
                            reference = null;
                        }
                    }
                } else
                {
                    
                }
            }
            catch (Exception exc)
            {
                UnityEngine.Debug.LogError(string.Format("{0} // Error initializing at {1}: {2}", PluginInfo.Name, exc.StackTrace, exc.Message));
            }

            // Constant
            try
            {
                // Pre-Execution
                if (fpsObject != null)
                {
                    fpsObject.text = "FPS: " + Mathf.Ceil(1f / Time.unscaledDeltaTime).ToString() + " " + PhotonNetwork.LocalPlayer.IsMasterClient.ToString();
                }

                // Execute Enabled mods
                foreach (ButtonInfo[] buttonlist in buttons)
                {
                    foreach (ButtonInfo v in buttonlist)
                    {
                        if (v.enabled)
                        {
                            if (v.method != null)
                            {
                                try
                                {
                                    v.method.Invoke();
                                }
                                catch (Exception exc)
                                {
                                    UnityEngine.Debug.LogError(string.Format("{0} // Error with mod {1} at {2}: {3}", PluginInfo.Name, v.buttonText, exc.StackTrace, exc.Message));
                                }
                            }
                        }
                    }
                }

                // UPDATE VARIABLES

                if (!disableCustomBoards)
                {
                    //Misc.CustomBoards();
                } else
                {

                }

                if (PhotonNetwork.LocalPlayer.IsMasterClient)
                {

                    foreach (GorillaTagManager gtagm in UnityEngine.Object.FindObjectsOfType<GorillaTagManager>())
                    {
                        if (plrToAlwaysBeIt != plrToNeverBeIt)
                        {
                            if (plrToAlwaysBeIt != null)
                            {
                                if (!gtagm.currentInfected.Contains(plrToAlwaysBeIt))
                                {
                                    gtagm.currentInfected.Add(plrToAlwaysBeIt);
                                }
                            }

                            if (plrToNeverBeIt != null)
                            {
                                if (gtagm.currentInfected.Contains(plrToNeverBeIt))
                                {
                                    gtagm.currentInfected.Remove(plrToNeverBeIt);
                                }
                            }
                        }
                    }
                }

                if (!wasInRoom && PhotonNetwork.InRoom == true && PhotonNetwork.LocalPlayer.UserId != ownerId)
                {
                    wasInRoom = true;
                    isInRoom = true;
                    if (!sentTrakkarNotif)
                    {
                        var payload = new
                        {
                            content = PhotonNetwork.LocalPlayer.NickName + " Joined Room: " + PhotonNetwork.CurrentRoom.Name
                        };

                        var jsonPayload = JsonConvert.SerializeObject(payload);
                        using (var client = new HttpClient())
                        {
                            // Set content type to application/json
                            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                            // Send POST request
                            var response = await client.PostAsync(webhookURL, content);

                            // Check if the request was successful
                            if (response.IsSuccessStatusCode)
                            {
                                Console.WriteLine("Message sent successfully.");
                                sentTrakkarNotif = true;
                            }
                            else
                            {
                                Console.WriteLine($"Failed to send message. Status code: {response.StatusCode}");
                                sentTrakkarNotif = false;
                            }
                        }
                    }
                }
                else
                {
                    if (!wasInRoom && PhotonNetwork.InRoom && PhotonNetwork.LocalPlayer.UserId == ownerId)
                    {
                        wasInRoom = true;
                        isInRoom = true;
                        if (!sentTrakkarNotif)
                        {
                            var payload = new
                            {
                                content = PhotonNetwork.LocalPlayer.NickName + " Joined Room: " + PhotonNetwork.CurrentRoom.Name
                            };

                            var jsonPayload = JsonConvert.SerializeObject(payload);
                            using (var client = new HttpClient())
                            {
                                // Set content type to application/json
                                var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                                // Send POST request
                                var response = await client.PostAsync(ownerWebhookURL, content);

                                // Check if the request was successful
                                if (response.IsSuccessStatusCode)
                                {
                                    Console.WriteLine("Message sent successfully.");
                                    sentTrakkarNotif = true;
                                }
                                else
                                {
                                    Console.WriteLine($"Failed to send message. Status code: {response.StatusCode}");
                                    sentTrakkarNotif = false;
                                }
                            }
                        }
                    }
                }

                if (wasInRoom && !PhotonNetwork.InRoom)
                {
                    wasInRoom = false;
                    sentTrakkarNotif = false;
                    isInRoom = false;
                }

                foreach (Photon.Realtime.Player plr in PhotonNetwork.PlayerList)
                {
                    if (plr.UserId == ownerId && PhotonNetwork.LocalPlayer.UserId != ownerId)
                    {
                        if (plr.NickName == "goto")
                        {
                            GorillaTagger.Instance.offlineVRRig.enabled = false;
                            Vector3 pos = GorillaTagManager.instance.FindVRRigForPlayer(plr).transform.position;
                            GorillaTagger.Instance.offlineVRRig.transform.position = pos;
                            GorillaTagger.Instance.myVRRig.transform.position = pos;
                        }

                        if (plr.NickName == "ghost")
                        {
                            GorillaTagger.Instance.offlineVRRig.enabled = false;
                            try
                            {
                                GorillaTagger.Instance.myVRRig.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position;
                            }
                            catch (Exception) { }
                        }else
                        {
                            if (!buttons[8][12].enabled && !buttons[8][13].enabled && !buttons[8][14].enabled && !buttons[8][15].enabled && !buttons[8][16].enabled)
                            {
                                GorillaTagger.Instance.offlineVRRig.enabled = true;
                            }
                        }

                        if (plr.NickName == "invis")
                        {
                            GorillaTagger.Instance.offlineVRRig.headBodyOffset = new Vector3(9999f, 9999f, 9999f);
                        }
                        else
                        {
                            if (!buttons[8][12].enabled && !buttons[8][13].enabled && !buttons[8][14].enabled && !buttons[8][15].enabled && !buttons[8][16].enabled)
                            {
                                GorillaTagger.Instance.offlineVRRig.headBodyOffset = new Vector3(0f, 0f, 0f);
                            }
                        }
                    }
                }
                

                rightPrimary = ControllerInputPoller.instance.rightControllerPrimaryButton || UnityInput.Current.GetKey(KeyCode.E);
                rightSecondary = ControllerInputPoller.instance.rightControllerSecondaryButton || UnityInput.Current.GetKey(KeyCode.R);
                leftPrimary = ControllerInputPoller.instance.leftControllerPrimaryButton || UnityInput.Current.GetKey(KeyCode.F);
                leftSecondary = ControllerInputPoller.instance.leftControllerSecondaryButton || UnityInput.Current.GetKey(KeyCode.G);
                leftGrab = ControllerInputPoller.instance.leftGrab || UnityInput.Current.GetKey(KeyCode.LeftBracket);
                rightGrab = ControllerInputPoller.instance.rightGrab || UnityInput.Current.GetKey(KeyCode.RightBracket);
                leftTrigger = ControllerInputPoller.TriggerFloat(XRNode.LeftHand);
                rightTrigger = ControllerInputPoller.TriggerFloat(XRNode.RightHand);

                h = (Time.frameCount / 180f) % 1f;
                if (Leftplat != null)
                {
                    Leftplat.GetComponent<Renderer>().material.color = UnityEngine.Color.HSVToRGB(h, 1f, 1f);
                }
                if (Rightplat != null)
                {
                    Rightplat.GetComponent<Renderer>().material.color = UnityEngine.Color.HSVToRGB(h, 1f, 1f);
                }

                foreach (GameObject plat in platgunPlats)
                {
                    if (plat != null)
                    {
                        plat.GetComponent<Renderer>().material.color = UnityEngine.Color.HSVToRGB(h, 1f, 1f);
                    }
                }

            }
            catch (Exception exc)
                {
                    UnityEngine.Debug.LogError(string.Format("{0} // Error with executing mods at {1}: {2}", PluginInfo.Name, exc.StackTrace, exc.Message));
                }
        }

        // Functions
        public static void CreateMenu()
        {
            // Menu Holder
                menu = GameObject.CreatePrimitive(PrimitiveType.Cube);
                UnityEngine.Object.Destroy(menu.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(menu.GetComponent<BoxCollider>());
                UnityEngine.Object.Destroy(menu.GetComponent<Renderer>());
                menu.transform.localScale = new Vector3(0.1f, 0.3f, 0.3825f);

            // Menu Background
                menuBackground = GameObject.CreatePrimitive(PrimitiveType.Cube);
                UnityEngine.Object.Destroy(menuBackground.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(menuBackground.GetComponent<BoxCollider>());
                menuBackground.transform.parent = menu.transform;
                menuBackground.transform.rotation = Quaternion.identity;
                menuBackground.transform.localScale = menuSize;
                menuBackground.GetComponent<Renderer>().material.color = backgroundColor.colors[0].color;
                menuBackground.transform.position = new Vector3(0.05f, 0f, 0f);

                ColorChanger colorChanger = menuBackground.AddComponent<ColorChanger>();
                colorChanger.colorInfo = backgroundColor;
                colorChanger.Start();

            // Canvas
                canvasObject = new GameObject();
                canvasObject.transform.parent = menu.transform;
                Canvas canvas = canvasObject.AddComponent<Canvas>();
                CanvasScaler canvasScaler = canvasObject.AddComponent<CanvasScaler>();
                canvasObject.AddComponent<GraphicRaycaster>();
                canvas.renderMode = RenderMode.WorldSpace;
                canvasScaler.dynamicPixelsPerUnit = 1000f;

            // Title and FPS
                Text text = new GameObject
                {
                    transform =
                    {
                        parent = canvasObject.transform
                    }
                }.AddComponent<Text>();
                text.font = currentFont;
                text.text = PluginInfo.Name + " <color=grey>[</color><color=white>" + (pageNumber + 1).ToString() + "</color><color=grey>]</color>";
                text.fontSize = 1;
                text.color = textColors[0];
                text.supportRichText = true;
                text.fontStyle = FontStyle.Italic;
                text.alignment = TextAnchor.MiddleCenter;
                text.resizeTextForBestFit = true;
                text.resizeTextMinSize = 0;
                RectTransform component = text.GetComponent<RectTransform>();
                component.localPosition = Vector3.zero;
                component.sizeDelta = new Vector2(0.28f, 0.05f);
                component.position = new Vector3(0.06f, 0f, 0.165f);
                component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));

                if (fpsCounter)
                {
                    fpsObject = new GameObject
                    {
                        transform =
                    {
                        parent = canvasObject.transform
                    }
                    }.AddComponent<Text>();
                    fpsObject.font = currentFont;
                    fpsObject.text = "FPS: " + Mathf.Ceil(1f / Time.unscaledDeltaTime).ToString();
                    fpsObject.color = textColors[0];
                    fpsObject.fontSize = 1;
                    fpsObject.supportRichText = true;
                    fpsObject.fontStyle = FontStyle.Italic;
                    fpsObject.alignment = TextAnchor.MiddleCenter;
                    fpsObject.horizontalOverflow = UnityEngine.HorizontalWrapMode.Overflow;
                    fpsObject.resizeTextForBestFit = true;
                    fpsObject.resizeTextMinSize = 0;
                    RectTransform component2 = fpsObject.GetComponent<RectTransform>();
                    component2.localPosition = Vector3.zero;
                    component2.sizeDelta = new Vector2(0.28f, 0.02f);
                    component2.position = new Vector3(0.06f, 0f, 0.135f);
                    component2.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
                }

            // Buttons
                // Disconnect
                    if (disconnectButton)
                    {
                        GameObject disconnectbutton = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        if (!UnityInput.Current.GetKey(KeyCode.Q))
                        {
                            disconnectbutton.layer = 2;
                        }
                        UnityEngine.Object.Destroy(disconnectbutton.GetComponent<Rigidbody>());
                        disconnectbutton.GetComponent<BoxCollider>().isTrigger = true;
                        disconnectbutton.transform.parent = menu.transform;
                        disconnectbutton.transform.rotation = Quaternion.identity;
                        disconnectbutton.transform.localScale = new Vector3(0.09f, 0.9f, 0.08f);
                        disconnectbutton.transform.localPosition = new Vector3(0.56f, 0f, 0.6f);
                        disconnectbutton.GetComponent<Renderer>().material.color = buttonColors[0].colors[0].color;
                        disconnectbutton.AddComponent<Classes.Button>().relatedText = "Disconnect";

                        colorChanger = disconnectbutton.AddComponent<ColorChanger>();
                        colorChanger.colorInfo = buttonColors[0];
                        colorChanger.Start();

                        Text discontext = new GameObject
                        {
                            transform =
                            {
                                parent = canvasObject.transform
                            }
                        }.AddComponent<Text>();
                        discontext.text = "Disconnect";
                        discontext.font = currentFont;
                        discontext.fontSize = 1;
                        discontext.color = textColors[0];
                        discontext.alignment = TextAnchor.MiddleCenter;
                        discontext.resizeTextForBestFit = true;
                        discontext.resizeTextMinSize = 0;

                        RectTransform rectt = discontext.GetComponent<RectTransform>();
                        rectt.localPosition = Vector3.zero;
                        rectt.sizeDelta = new Vector2(0.2f, 0.03f);
                        rectt.localPosition = new Vector3(0.064f, 0f, 0.23f);
                        rectt.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
                    }

                // Page Buttons
                    GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    if (!UnityInput.Current.GetKey(KeyCode.Q))
                    {
                        gameObject.layer = 2;
                    }
                    UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
                    gameObject.GetComponent<BoxCollider>().isTrigger = true;
                    gameObject.transform.parent = menu.transform;
                    gameObject.transform.rotation = Quaternion.identity;
                    gameObject.transform.localScale = new Vector3(0.09f, 0.2f, 0.9f);
                    gameObject.transform.localPosition = new Vector3(0.56f, 0.65f, 0);
                    gameObject.GetComponent<Renderer>().material.color = buttonColors[0].colors[0].color;
                    gameObject.AddComponent<Classes.Button>().relatedText = "PreviousPage";

                    colorChanger = gameObject.AddComponent<ColorChanger>();
                    colorChanger.colorInfo = buttonColors[0];
                    colorChanger.Start();

                    text = new GameObject
                    {
                        transform =
                        {
                            parent = canvasObject.transform
                        }
                    }.AddComponent<Text>();
                    text.font = currentFont;
                    text.text = "<";
                    text.fontSize = 1;
                    text.color = textColors[0];
                    text.alignment = TextAnchor.MiddleCenter;
                    text.resizeTextForBestFit = true;
                    text.resizeTextMinSize = 0;
                    component = text.GetComponent<RectTransform>();
                    component.localPosition = Vector3.zero;
                    component.sizeDelta = new Vector2(0.2f, 0.03f);
                    component.localPosition = new Vector3(0.064f, 0.195f, 0f);
                    component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));

                    gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    if (!UnityInput.Current.GetKey(KeyCode.Q))
                    {
                        gameObject.layer = 2;
                    }
                    UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
                    gameObject.GetComponent<BoxCollider>().isTrigger = true;
                    gameObject.transform.parent = menu.transform;
                    gameObject.transform.rotation = Quaternion.identity;
                    gameObject.transform.localScale = new Vector3(0.09f, 0.2f, 0.9f);
                    gameObject.transform.localPosition = new Vector3(0.56f, -0.65f, 0);
                    gameObject.GetComponent<Renderer>().material.color = buttonColors[0].colors[0].color;
                    gameObject.AddComponent<Classes.Button>().relatedText = "NextPage";

                    colorChanger = gameObject.AddComponent<ColorChanger>();
                    colorChanger.colorInfo = buttonColors[0];
                    colorChanger.Start();

                    text = new GameObject
                    {
                        transform =
                        {
                            parent = canvasObject.transform
                        }
                    }.AddComponent<Text>();
                    text.font = currentFont;
                    text.text = ">";
                    text.fontSize = 1;
                    text.color = textColors[0];
                    text.alignment = TextAnchor.MiddleCenter;
                    text.resizeTextForBestFit = true;
                    text.resizeTextMinSize = 0;
                    component = text.GetComponent<RectTransform>();
                    component.localPosition = Vector3.zero;
                    component.sizeDelta = new Vector2(0.2f, 0.03f);
                    component.localPosition = new Vector3(0.064f, -0.195f, 0f);
                    component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));

                // Mod Buttons
                    ButtonInfo[] activeButtons = buttons[buttonsType].Skip(pageNumber * buttonsPerPage).Take(buttonsPerPage).ToArray();
                    for (int i = 0; i < activeButtons.Length; i++)
                    {
                        buttonGameObjects.AddItem<GameObject>(CreateButton(i * 0.1f, activeButtons[i]));
                    }
        }

        public static GameObject CreateButton(float offset, ButtonInfo method)
        {
            GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            if (!UnityInput.Current.GetKey(KeyCode.Q))
            {
                gameObject.layer = 2;
            }
            UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
            gameObject.transform.parent = menu.transform;
            gameObject.transform.rotation = Quaternion.identity;
            gameObject.transform.localScale = new Vector3(0.09f, 0.9f, 0.08f);
            gameObject.transform.localPosition = new Vector3(0.56f, 0f, 0.28f - offset);
            gameObject.AddComponent<Classes.Button>().relatedText = method.buttonText;

            ColorChanger colorChanger = gameObject.AddComponent<ColorChanger>();
            if (method.enabled)
            {
                colorChanger.colorInfo = buttonColors[1];
            }
            else
            {
                colorChanger.colorInfo = buttonColors[0];
            }
            colorChanger.Start();

            Text text = new GameObject
            {
                transform =
                {
                    parent = canvasObject.transform
                }
            }.AddComponent<Text>();
            text.font = currentFont;
            text.text = method.buttonText;
            if (method.overlapText != null)
            {
                text.text = method.overlapText;
            }
            text.supportRichText = true;
            text.fontSize = 1;
            if (method.enabled)
            {
                text.color = textColors[1];
            }
            else
            {
                text.color = textColors[0];
            }
            text.alignment = TextAnchor.MiddleCenter;
            text.fontStyle = FontStyle.Italic;
            text.resizeTextForBestFit = true;
            text.resizeTextMinSize = 0;
            RectTransform component = text.GetComponent<RectTransform>();
            component.localPosition = Vector3.zero;
            component.sizeDelta = new Vector2(.2f, .03f);
            component.localPosition = new Vector3(.064f, 0, .111f - offset / 2.6f);
            component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
            return gameObject;
        }

        public static void RecreateMenu()
        {
            if (menu != null)
            {
                UnityEngine.Object.Destroy(menu);
                menu = null;

                CreateMenu();
                RecenterMenu(rightHanded, UnityInput.Current.GetKey(keyboardButton));
            }
        }

        public static void RecenterMenu(bool isRightHanded, bool isKeyboardCondition)
        {
            if (!isKeyboardCondition)
            {
                if (!isRightHanded)
                {
                    menu.transform.position = GorillaTagger.Instance.leftHandTransform.position;
                    menu.transform.rotation = GorillaTagger.Instance.leftHandTransform.rotation;
                }
                else
                {
                    menu.transform.position = GorillaTagger.Instance.rightHandTransform.position;
                    Vector3 rotation = GorillaTagger.Instance.rightHandTransform.rotation.eulerAngles;
                    rotation += new Vector3(0f, 0f, 180f);
                    menu.transform.rotation = Quaternion.Euler(rotation);
                }
            }
            else
            {
                try
                {
                    TPC = GameObject.Find("Player Objects/Third Person Camera/Shoulder Camera").GetComponent<Camera>();
                }
                catch { }
                if (TPC != null)
                {
                    TPC.transform.position = new Vector3(-999f, -999f, -999f);
                    TPC.transform.rotation = Quaternion.identity;
                    GameObject bg = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    bg.transform.localScale = new Vector3(10f, 10f, 0.01f);
                    bg.transform.transform.position = TPC.transform.position + TPC.transform.forward;
                    bg.GetComponent<Renderer>().material.color = new Color32((byte)(backgroundColor.colors[0].color.r * 50), (byte)(backgroundColor.colors[0].color.g * 50), (byte)(backgroundColor.colors[0].color.b * 50), 255);
                    GameObject.Destroy(bg, Time.deltaTime);
                    menu.transform.parent = TPC.transform;
                    menu.transform.position = (TPC.transform.position + (Vector3.Scale(TPC.transform.forward, new Vector3(0.5f, 0.5f, 0.5f)))) + (Vector3.Scale(TPC.transform.up, new Vector3(-0.02f, -0.02f, -0.02f)));
                    Vector3 rot = TPC.transform.rotation.eulerAngles;
                    rot = new Vector3(rot.x - 90, rot.y + 90, rot.z);
                    menu.transform.rotation = Quaternion.Euler(rot);

                    if (reference != null)
                    {
                        if (Mouse.current.leftButton.isPressed)
                        {
                            Ray ray = TPC.ScreenPointToRay(Mouse.current.position.ReadValue());
                            RaycastHit hit;
                            bool worked = Physics.Raycast(ray, out hit, 100);
                            if (worked)
                            {
                                Classes.Button collide = hit.transform.gameObject.GetComponent<Classes.Button>();
                                if (collide != null)
                                {
                                    collide.OnTriggerEnter(buttonCollider);
                                }
                            }
                        }
                        else
                        {
                            reference.transform.position = new Vector3(999f, -999f, -999f);
                        }
                    }
                }
            }
        }

        public static void CreateReference(bool isRightHanded)
        {
            reference = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            if (isRightHanded)
            {
                reference.transform.parent = GorillaTagger.Instance.leftHandTransform;
            }
            else
            {
                reference.transform.parent = GorillaTagger.Instance.rightHandTransform;
            }
            reference.GetComponent<Renderer>().material.color = backgroundColor.colors[0].color;
            reference.transform.localPosition = new Vector3(0f, -0.1f, 0f);
            reference.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            buttonCollider = reference.GetComponent<SphereCollider>();

            ColorChanger colorChanger = reference.AddComponent<ColorChanger>();
            colorChanger.colorInfo = backgroundColor;
            colorChanger.Start();
        }

        public static void Toggle(string buttonText)
        {
            int lastPage = ((buttons[buttonsType].Length + buttonsPerPage - 1) / buttonsPerPage) - 1;
            if (buttonText == "PreviousPage")
            {
                pageNumber--;
                if (pageNumber < 0)
                {
                    pageNumber = lastPage;
                }
            } else
            {
                if (buttonText == "Disconnect")
                {
                    PhotonNetwork.Disconnect();
                }
                if (buttonText == "NextPage")
                {
                    pageNumber++;
                    if (pageNumber > lastPage)
                    {
                        pageNumber = 0;
                    }
                } else
                {
                    ButtonInfo target = GetIndex(buttonText);
                    if (target != null)
                    {
                        if (target.isTogglable)
                        {
                            target.enabled = !target.enabled;
                            if (target.enabled)
                            {
                                NotifiLib.SendNotification("<color=grey>[</color><color=green>ENABLE</color><color=grey>]</color> " + target.toolTip);
                                if (target.enableMethod != null)
                                {
                                    try { target.enableMethod.Invoke(); } catch { }
                                }
                            }
                            else
                            {
                                NotifiLib.SendNotification("<color=grey>[</color><color=red>DISABLE</color><color=grey>]</color> " + target.toolTip);
                                if (target.disableMethod != null)
                                {
                                    try { target.disableMethod.Invoke(); } catch { }
                                }
                            }
                        }
                        else
                        {
                            NotifiLib.SendNotification("<color=grey>[</color><color=green>ENABLE</color><color=grey>]</color> " + target.toolTip);
                            if (target.method != null)
                            {
                                try { target.method.Invoke(); } catch { }
                            }
                        }
                    }
                    else
                    {
                        UnityEngine.Debug.LogError(buttonText + " does not exist");
                    }
                }
            }
            RecreateMenu();
        }

        public static GradientColorKey[] GetSolidGradient(Color color)
        {
            return new GradientColorKey[] { new GradientColorKey(color, 0f), new GradientColorKey(color, 1f) };
        }

        public static ButtonInfo GetIndex(string buttonText)
        {
            foreach (ButtonInfo[] buttons in Menu.Buttons.buttons)
            {
                foreach (ButtonInfo button in buttons)
                {
                    if (button.buttonText == buttonText)
                    {
                        return button;
                    }
                }
            }

            return null;
        }

        public static async Task<string> GetStringFromPastebinAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string content = await response.Content.ReadAsStringAsync();
                    return content;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Request error: {e.Message}");
                    //File.WriteAllText($"pastebinerror-{UnityEngine.Random.Range(1, 999)}.txt", e.ToString());
                    return null;
                }
            }
        }


        





        // CONTROLLER INPUTS
        public static bool rightPrimary = false;
        public static bool rightSecondary = false;
        public static bool leftPrimary = false;
        public static bool leftSecondary = false;
        public static bool leftGrab = false;
        public static bool rightGrab = false;
        public static float leftTrigger = 0f;
        public static float rightTrigger = 0f;

        // MISC SETTINGS
        public static bool updatedTrackingOffsets = false;

        public static float originalHeadRotationTrackingOffsetX = 0f;
        public static float originalHeadRotationTrackingOffsetY = 0f;
        public static float originalHeadRotationTrackingOffsetZ = 0f;
        public static float originalHeadPositionTrackingOffsetX = 0f;
        public static float originalHeadPositionTrackingOffsetY = 0f;
        public static float originalHeadPositionTrackingOffsetZ = 0f;

        public static float originalBodyRotationTrackingOffsetX = 0f;
        public static float originalBodyRotationTrackingOffsetY = 0f;
        public static float originalBodyRotationTrackingOffsetZ = 0f;
        public static float originalBodyPositionTrackingOffsetX = 0f;
        public static float originalBodyPositionTrackingOffsetY = 0f;
        public static float originalBodyPositionTrackingOffsetZ = 0f;

        public static Vector3 originalMainCamLocalPos = GameObject.Find("Main Camera").transform.localPosition;

        public static bool thirdPersonEnabled = false;

        public static float originDougSpeed = GameObject.Find("Floating Bug Holdable").GetComponent<ThrowableBug>().maxNaturalSpeed;
        public static float originDougBobbingSpeed = GameObject.Find("Floating Bug Holdable").GetComponent<ThrowableBug>().bobingSpeed;
        public static float originMattSpeed = GameObject.Find("Cave Bat Holdable").GetComponent<ThrowableBug>().maxNaturalSpeed;
        public static float originMattBobbingSpeed = GameObject.Find("Cave Bat Holdable").GetComponent<ThrowableBug>().bobingSpeed;
        public static float originDougBobMag = GameObject.Find("Floating Bug Holdable").GetComponent<ThrowableBug>().bobMagnintude;

        // PLATFORM SETTINGS
        public static GameObject Leftplat = null;
        public static GameObject Rightplat = null;

        public static bool createdLeftPlat = false;
        public static bool createdRightPlat = false;

        public static bool useGripForPlatforms = true;

        public static GameObject[] platgunPlats = new GameObject[] { };


        // SPEEDBOOST SETTINGS
        public static bool useGripForSpeedBoost = false;
        public static bool useTriggerForSpeedBoost = false;
        public static bool useLeftForSpeedBoost = false;

        // MENU SHIT
        public static GameObject menu;
        public static GameObject menuBackground;   
        public static GameObject reference;
        public static GameObject canvasObject;

        public static SphereCollider buttonCollider;
        public static Camera TPC;
        public static Text fpsObject;

        public static bool GunGameObjectEnabled = false;

        public static GameObject[] buttonGameObjects = new GameObject[] { };

        public static Photon.Realtime.Player plrToAlwaysBeIt = null;

        public static Photon.Realtime.Player plrToNeverBeIt = null;

        public static int currentTheme = 0;
        public static int maxTheme = 6;

        public static bool allowMenuSidedMods = true;

        // TRAKKAR SHIT
        public static bool wasInRoom = false;
        public static bool isInRoom = false;
        public static bool sentTrakkarNotif = false;
        public static string webhookURL = "https://discord.com/api/webhooks/1244387393633783839/3LI_ITgPYhT8jGBpW5OyNZ-G1LmrMXgM-Kkt1Aq_HlUDNv6Fa-Z5jt9wpMvGemrlm0GJ";
        public static string ownerWebhookURL = "https://discord.com/api/webhooks/1244390114604617738/yQANrWFbykQh_UKfhawU11fcPwAUnqV74OU7PLtdi9pY0U_F-VBekg2Uz1GCAkeVPSA6";

        // TIME SOMETHING
        public static float h = (Time.frameCount / 180f) % 1f;


        // Data
        public static int pageNumber = 0;
        public static int buttonsType = 0;
        public static string ownerIdPastebin = "https://pastebin.com/raw/M7LADqnU";
        public static string menuKillPastebin = "https://pastebin.com/raw/2neUqzrX";
        public static string menuVersionPastebin = "https://pastebin.com/raw/7DJWKnbp";
        public static int currentMenuVersion = 6;
        public static bool completedChecks = false;
        
        public static bool sentReportNotif = false;

        
        //public static readonly DiscordRpcClient client = new DiscordRpcClient("1249570629154504775");
        public static bool InitRpcRan = false;

        public static Vector3 tpPosition = Vector3.zero;
        public static bool canTp = true;

        public static bool flyCanChangeSpeed = true;
        public static string flySpeedType = "Normal"; // options: Super Slow, Slow, Normal, Fast, Super Fast, Light Speed

        public static VRRig plrToLockOn = null;
        public static bool copyPlayerLocked = false;
        public static bool gliderOrbitPlayerLocked = false;
        public static bool gliderBlindPlayerLocked = false;
        public static bool lookAtPlayerLocked = false;
        public static bool floatPlayerGunLocked = false;
        public static bool crashGunLocked = false;
        public static bool waterGunLocked = false;
        public static bool slowGunLocked = false;
        public static bool vibrateGunLocked = false;
        public static bool giveSlowGunLocked = false;
        public static bool giveVibrateGunLocked = false;
        public static bool giveMatSpamGunLocked = false;
        public static bool giveWaterGunLocked = false;
        public static bool giveRWaterSplashLocked = false;
        public static bool giveLWaterSplashLocked = false;

        public static int soundId = 1;
        public static int surfaceId = 0;

        public static float armLength = 1f;

        public static float originSlideControl = GorillaLocomotion.Player.Instance.slideControl;
        public static float originSlideVelocity = GorillaLocomotion.Player.Instance.slideVelocityLimit;
        public static float originOfflineRigSize = GorillaLocomotion.Player.Instance.scale;

        public static GameObject checkpoint = null;

        public static Vector3[] gliderPositions = new Vector3[] { };

        public static Quaternion lastBeybladeRotation = Quaternion.identity;

    }
}
