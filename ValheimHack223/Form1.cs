using System;
using System.Windows.Forms;
using UnityEngine;
using System.Threading.Tasks;

namespace ValheimHack223
{
    public partial class Form1 : Form
    {
        public static int counter = 0;
        public static bool exitFlag = false;

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
            int level = 1;

            try
            {
                Player localPlayer = GameFunctions.GetLocalPlayer();
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

        private void button3_Click(object sender, EventArgs e)
        {
            Player localPlayer = GameFunctions.GetLocalPlayer();
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
            GameFunctions.SpawnMobs();
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

        private void CMDArena_Click(object sender, EventArgs e)
        {
            GameFunctions.SpawnArena();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int pointsToNuke = 10000;
            if (Main.points >= pointsToNuke) {
                Main.points -= pointsToNuke;
                SpawnSystem.KillZombies();
            }
            
        }

        //Spawn zombies
        private void button8_Click(object sender, EventArgs e)
        {
            SpawnSystem.Start(1);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            GameFunctions.StartMap();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            GameFunctions.DeleteMapIfExists();
        }

        public void button11_Click(object sender, EventArgs e)
        {
            counter = 0;
            exitFlag = false;

            GameFunctions.GetLocalPlayer().Message(MessageHud.MessageType.Center, "Invincibility has started!");
            InvincibilityCycle();
        }

        public async void InvincibilityCycle()
        {
            while (exitFlag == false)
            {
                GameFunctions.ChangeSkinColour();
                GameFunctions.AlwaysHeal();
                counter++;

                if (counter > 10)
                    exitFlag = true;

                await Task.Delay(1000).ConfigureAwait(false);
            }

            GameFunctions.GetLocalPlayer().Message(MessageHud.MessageType.Center, "Invincibility has ended!");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Player localPlayer = GameFunctions.GetLocalPlayer();
            //10 for testing
            //50000 normally
            int PointsToWin = 10;
            if (Main.points >= PointsToWin)
            {
                SpawnSystem.finished = true;
                localPlayer.Message(MessageHud.MessageType.Center, "Congratulations you have won the game of Zombies! Thanks for playing!");
                
                GameFunctions.QuitTheGame();
            }
            else 
            {
                string message = $"You do not have {PointsToWin} points in order to end the game!";
                localPlayer.Message(MessageHud.MessageType.Center, message);
            }
        }

        private void button13_Click(object sender, EventArgs e) {
            if (Main.points >= 10)
            {
                Main.points -= 10;
                GameFunctions.RaiseSkillLevel();
            }

        }

        //All players in game?
        private void CMDStartgame_Click(object sender, EventArgs e)
        {
            GameFunctions.DestroyAllTrees();
            GameFunctions.SpawnArena();
            SelectDifficulty();
        }

        public void SelectDifficulty()
        {
            button14.Show();
            button15.Show();
            button16.Show();
        }

        private void CBXItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            LBLcost.Text = GameFunctions.itemShop[CBXItems.Text].cost.ToString();
        }

        private void CMDBuy_Click(object sender, EventArgs e)
        {
            GameFunctions.BuyItem(CBXItems.Text);
        }

        //Easy button
        private void button14_Click(object sender, EventArgs e)
        {
            button14.Hide();
            button15.Hide();
            button16.Hide();

            //Set difficulty multiplier to 1
            GameFunctions.StartGame(1);
        }

        //Medium button
        private void button15_Click(object sender, EventArgs e)
        {
            button14.Hide();
            button15.Hide();
            button16.Hide();

            //Set difficulty multiplier to 2
            GameFunctions.StartGame(2);
        }

        //Hard button
        private void button16_Click(object sender, EventArgs e)
        {
            button14.Hide();
            button15.Hide();
            button16.Hide();

            //Set difficulty multiplier to 3
            GameFunctions.StartGame(3);
        }
    }
}
