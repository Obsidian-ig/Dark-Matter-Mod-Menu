using StupidTemplate.Menu;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace StupidTemplate.CodeTemplates
{
    internal class Gun
    {
        public Gun()
        {
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

                if (Main.rightTrigger == 1f)
                {
                    pointer.GetComponent<Renderer>().material.color = UnityEngine.Color.HSVToRGB(Main.h, 1f, 1f);
                    // run activation code here
                    GameObject.Destroy(pointer, Time.deltaTime);
                }
                GameObject.Destroy(pointer, Time.deltaTime);
            }
        }
    }
}
