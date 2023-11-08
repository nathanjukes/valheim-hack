using System;
using UnityEngine;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine.Windows;

namespace ValheimHack223
{
    public class Main : MonoBehaviour
    {
        public Rect MenuWindow = new Rect(20f, 20f, 180f, 290f);

        private void Start()
        {
            Form1 r = new Form1();
            r.Show();
        }

        public void Update()
        {
            /*            foreach (var p in Player.GetAllPlayers())
                        {
                            p.SetHealth(50f);
                            p.SetMaxStamina(100f, true);
                            p.AddStamina(100f);
                            p.Heal(100f, true);
                            p.SetLevel(p.GetLevel() + 1);
                        }*/
        }

        private void OnGUI()
        {
            //FPS Counter
            GUI.color = Color.green;
            GUI.Label(new Rect(300f, 0f, 600f, 40f), "FPSCOUNT");
        }
    }
}
