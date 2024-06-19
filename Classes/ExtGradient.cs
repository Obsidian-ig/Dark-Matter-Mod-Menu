using System;
using UnityEngine;

namespace StupidTemplate.Classes
{
    public class ExtGradient
    {
        public GradientColorKey[] colors = new GradientColorKey[]
        {
            new GradientColorKey(Color.black, 0f),
            new GradientColorKey(Color.magenta, 0.2f),
            new GradientColorKey(Color.black, 1f)
        };

        public GradientColorKey[] darkmatter = new GradientColorKey[]
        {
            new GradientColorKey(Color.black, 0f),
            new GradientColorKey(Color.white, 0.2f),
            new GradientColorKey(Color.black, 0.2f)
        };

        public GradientColorKey[] colors2 = new GradientColorKey[]
        {
            new GradientColorKey(Color.black, 0f),
            new GradientColorKey(Color.red, 0.2f),
            new GradientColorKey(Color.black, 1f)
        };

        public GradientColorKey[] colors3 = new GradientColorKey[]
        {
            new GradientColorKey(Color.black, 0f),
            new GradientColorKey(Color.blue, 0.2f),
            new GradientColorKey(Color.black, 1f)
        };

        public GradientColorKey[] colors4 = new GradientColorKey[]
        {
            new GradientColorKey(Color.black, 0f),
            new GradientColorKey(Color.clear, 0.2f),
            new GradientColorKey(Color.black, 1f)
        };

        public GradientColorKey[] colors5 = new GradientColorKey[]
        {
            new GradientColorKey(Color.black, 0f),
            new GradientColorKey(Color.green, 0.2f),
            new GradientColorKey(Color.black, 1f)
        };

        public GradientColorKey[] colors6 = new GradientColorKey[]
        {
            new GradientColorKey(Color.black, 0f),
            new GradientColorKey(Color.yellow, 0.2f),
            new GradientColorKey(Color.black, 1f)
        };

        public bool isRainbow = false;
        public bool copyRigColors = false;
    }
}
