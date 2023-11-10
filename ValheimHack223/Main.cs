using System;
using UnityEngine;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine.Windows;
using System.Windows.Forms;
using static UnityEngine.GraphicsBuffer;
using System.Reflection;

namespace ValheimHack223
{
    public class Main : MonoBehaviour
    {
        public Rect MenuWindow = new Rect(20f, 20f, 180f, 290f);
        public static int points = 0;

        private void Start()
        {
            Form1 r = new Form1();
            r.Show();

            Player.m_localPlayer.SetHealth(50f);
        }

        public void Update()
        {
            Player localPlayer = Player.m_localPlayer;

            // Add points for a player attacking a zombie
            if (localPlayer.InAttack() && localPlayer.GetTimeSinceLastAttack() > 0.3)// && localPlayer.GetTimeSinceLastAttack() > 0.1f)
            {
                GameFunctions.AddPointsIfNeeded(localPlayer);
            }
        }

        private void OnGUI()
        {
            //FPS Counter
            GUI.color = Color.yellow;
            GUI.Label(new Rect(300f, 0f, 600f, 40f), "Score: " + points); // This re-renders when points changes btw
        }
    }
}
