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

        private void button1_Click(object sender, EventArgs e)
        {

            /*// Teleports local player to spawn location
            Player localPlayer = GetLocalPlayer();

            var myVector = new Vector3(0.0f, 1.0f, 0.0f);
            var rotationVector = new Vector3(0, 30, 0);
            var myQuaternion = Quaternion.Euler(rotationVector);
            localPlayer.TeleportTo(myVector, myQuaternion, true);

            // Teleports other players in the game to the local player
            foreach (ZNetPeer znetPeer in ZNet.instance.GetPeers())
            {
  
                Chat.instance.TeleportPlayer(znetPeer.m_uid, Player.m_localPlayer.transform.position, 
                    Player.m_localPlayer.transform.rotation, true);
            }


            // Adds item to local player
            Inventory inventory = Player.m_localPlayer.GetInventory();
            // Can be selected from cheat menu
            GameObject pickaxePrefab = ZNetScene.instance.GetPrefab("PickaxeIron");
            inventory.AddItem(pickaxePrefab, 10);


            //Set local run speed
            Character myCharacter = new Character();
            if (!myCharacter.IsPlayer() && input == "Killer") {
                myCharacter.m_runSpeed = 5
            }
            else {
                myCharacter.m_runSpeed = 10
            }
            */

            // Arena creation with ships
            Player localPlayer = GetLocalPlayer();
            GameObject prefabShip = ZNetScene.instance.GetPrefab(-1245442852);

            int objectCount = 50;
            for (int i = 0; i < objectCount; i++)
            {
                float angle = i * 360.0f / objectCount; // Calculate the angle between objects
                Vector3 spawnPosition = localPlayer.transform.position + Quaternion.Euler(0, angle, 0) * localPlayer.transform.forward * 75.0f + localPlayer.transform.up * 30.0f;

                // Instantiate the prefab at the calculated position
                UnityEngine.Object.Instantiate<GameObject>(prefabShip, spawnPosition, Quaternion.identity);
            }



        }
        public Player GetLocalPlayer()
        {
            return Player.m_localPlayer;
        }
    }
}
