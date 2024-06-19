
using StupidTemplate.Menu;
using UnityEngine;

namespace StupidTemplate.Classes
{
    public class ColorChanger : TimedBehaviour
    {
        public override void Start()
        {
            base.Start();
            renderer = base.GetComponent<Renderer>();
            Update();
        }

        public override void Update()
        {
            base.Update();
            if (colorInfo != null)
            {
                if (!colorInfo.copyRigColors)
                {
                    Color color = new Gradient { colorKeys = colorInfo.darkmatter }.Evaluate((Time.time / 2f) % 1);
                    if (Main.currentTheme == 0)
                    {
                        color = new Gradient { colorKeys = colorInfo.colors }.Evaluate((Time.time / 2f) % 1);
                    } else if (Main.currentTheme == 1)
                    {
                        color = new Gradient { colorKeys = colorInfo.darkmatter }.Evaluate((Time.time / 2f) % 1);
                    } else if (Main.currentTheme == 2)
                    {
                        color = new Gradient { colorKeys = colorInfo.colors2 }.Evaluate((Time.time / 2f) % 1);
                    } else if (Main.currentTheme == 3)
                    {
                        color = new Gradient { colorKeys = colorInfo.colors3 }.Evaluate((Time.time / 2f) % 1);
                    } else if (Main.currentTheme == 4)
                    {
                        color = new Gradient { colorKeys = colorInfo.colors4 }.Evaluate((Time.time / 2f) % 1);
                    } else if (Main.currentTheme == 5)
                    {
                        color = new Gradient { colorKeys = colorInfo.colors5 }.Evaluate((Time.time / 2f) % 1);
                    } else if (Main.currentTheme == 6)
                    {
                        color = new Gradient { colorKeys = colorInfo.colors6 }.Evaluate((Time.time / 2f) % 1);
                    }
                    
                    if (colorInfo.isRainbow)
                    {
                        float h = (Time.frameCount / 180f) % 1f;
                        color = UnityEngine.Color.HSVToRGB(h, 1f, 1f);
                    }
                    renderer.material.color = color;
                }
                else
                {
                    renderer.material = GorillaTagger.Instance.offlineVRRig.mainSkin.material;
                }
            }
        }

        public Renderer renderer;
        public ExtGradient colorInfo;
    }
}
