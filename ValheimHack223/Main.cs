﻿using System;
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
            Player.m_localPlayer.AddStamina(50f);
        }

        public void Update()
        {
            Player localPlayer = Player.m_localPlayer;
            localPlayer.SetHealth(25f);

            // Add points for a player attacking a zombie
            if (localPlayer.InAttack() && localPlayer.GetTimeSinceLastAttack() > 0.3)// && localPlayer.GetTimeSinceLastAttack() > 0.1f)
            {
                GameFunctions.AddPointsIfNeeded(localPlayer);
            }

            if (SpawnSystem.started)
            {
                if (SpawnSystem.zombieCount == 0 && SpawnSystem.round != 0)
                {
                    // Add time between rounds here
                    GameFunctions.GetLocalPlayer().Message(MessageHud.MessageType.Center, "Next round");
                    SpawnSystem.StartSpawning();
                }
                SpawnSystem.CheckForSkeletonsAlive();
            }
        }

        private void OnGUI()
        {
            //FPS Counter
            GUI.color = Color.yellow;
            GUI.Label(new Rect(300f, 0f, 600f, 40f), "Score: " + points + " Zombies: " + SpawnSystem.zombieCount + " Round: " + SpawnSystem.round); // This re-renders when points changes btw
        }
    }
}
