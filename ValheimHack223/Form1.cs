using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

namespace ValheimHack223
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Ship = -1245442852 item prefab

            GameObject prefab = ZNetScene.instance.GetPrefab(-1245442852);
            int amount = 10;
            float gap = 20f;
            int level = 1;

            try
            {
                Player localPlayer = GetLocalPlayer();
                DateTime now = DateTime.Now;

                for (int i = 0; i < amount; i++)
                {
                    Character component = UnityEngine.Object.Instantiate<GameObject>(prefab, localPlayer.transform.position + localPlayer.transform.up * 10.0f + Vector3.up + (UnityEngine.Random.insideUnitSphere * 0.5f), Quaternion.identity).GetComponent<Character>();
                }

                string message = $"Spawned x{amount} of {prefab.name} (Level {level})";
                localPlayer.Message(MessageHud.MessageType.Center, message);

            } catch
            {

            }
        }

        public Player GetLocalPlayer()
        {
            return Player.m_localPlayer;
        }

        public bool KillPlayer(string name)
        {
            Player targetPlayer = GetPlayerFromName(name);

            if (targetPlayer != null)
            {
                HitData hit = new HitData();
                hit.m_damage.m_damage = 9999.0f;
                targetPlayer.ApplyDamage(hit, true, true);
                return true;
            }

            return false;
        }


        public Player GetPlayerFromName(string name, bool aliveOnly = true)
        {
            List<Player> players = Player.GetAllPlayers();
            foreach (Player i in players)
            {
                if (aliveOnly && i.IsDead())
                    continue;

                if (!i.GetPlayerName().Contains(name))
                    continue;

                return i;
            }

            return null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Player localPlayer = GetLocalPlayer();
            GameObject prefab = ZNetScene.instance.GetPrefab(-1245442852);


            // UnityEngine.Object.Instantiate<GameObject>(prefab, localPlayer.transform.position + localPlayer.transform.up * 10.0f + Vector3.up + (UnityEngine.Random.insideUnitSphere * 0.5f), Quaternion.identity).GetComponent<Character>();

            //UnityEngine.Object.Instantiate<GameObject>(prefab, localPlayer.transform.position + localPlayer.transform.forward * 10.0f, Quaternion.identity).GetComponent<Character>();

            int objectCount = 50;
            for (int i = 0; i < objectCount; i++)
            {
                float angle = i * 360.0f / objectCount; // Calculate the angle between objects
                Vector3 spawnPosition = localPlayer.transform.position + Quaternion.Euler(0, angle, 0) * localPlayer.transform.forward * 75.0f + Quaternion.Euler(0, angle, 0) * localPlayer.transform.up * 30.0f;

                // Instantiate the prefab at the calculated position
                UnityEngine.Object.Instantiate<GameObject>(prefab, spawnPosition, Quaternion.identity);
            }
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            GameFunctions.SpawnMob();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ShipConstructor[] ships = UnityEngine.Object.FindObjectsOfType(typeof(ShipConstructor)) as ShipConstructor[];

            // Loop through all instances and destroy them
            foreach (var s in ships)
            {
                GameObject.DestroyImmediate(s.gameObject);
            }

            MessageBox.Show("Num of ships: " + ships.Length);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Loader.Dispose();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TreeBase[] trees = UnityEngine.Object.FindObjectsOfType(typeof(TreeBase)) as TreeBase[];

            // Loop through all instances and destroy them
            foreach (var s in trees)
            {
                GameObject.DestroyImmediate(s.gameObject);
            }

            MessageBox.Show("Num of trees: " + trees.Length);
        }
    }
}
