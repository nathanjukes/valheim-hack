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
            foreach (var p in Player.GetAllPlayers())
            {
                p.AddStamina(10f);
            }

            // Ship = -1245442852 item prefab

            GameObject prefab = ZNetScene.instance.GetPrefab(-1245442852);
            int amount = 1;
            int level = 1;

            try
            {
                Player localPlayer = GetLocalPlayer();
                DateTime now = DateTime.Now;

                for (int i = 0; i < amount; i++)
                {
                    Character component = UnityEngine.Object.Instantiate<GameObject>(prefab, localPlayer.transform.position + localPlayer.transform.forward * 2.0f + Vector3.up + (UnityEngine.Random.insideUnitSphere * 0.5f), Quaternion.identity).GetComponent<Character>();

                    if (component & level > 1)
                        component.SetLevel(level);
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
    }
}
