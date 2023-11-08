using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace ValheimHack223
{
    public class Loader
    {
        public static GameObject load_object;

        public static void Load()
        {
            Loader.load_object = new GameObject();
            Loader.load_object.AddComponent<Main>();
            UnityEngine.Object.DontDestroyOnLoad(Loader.load_object);
        }

        public static void Dispose()
        {
            UnityEngine.Object.Destroy(load_object);
        }
    }
}