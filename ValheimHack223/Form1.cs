using System;
using System.Windows.Forms;
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

        //Injection Disposal
        private void DisposeOfInjector_Click(object sender, EventArgs e)
        {
            Loader.Dispose();
            label6.Show();
        }

        //Map Management
        private void StartMap_Click(object sender, EventArgs e)
        {
            GameFunctions.StartMap();
        }

        private void DeleteMap_Click(object sender, EventArgs e)
        {
            GameFunctions.DeleteMapIfExists();
        }

        //Shop/Purchase
        private void CBXItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            LBLcost.Text = GameFunctions.itemShop[CBXItems.Text].cost.ToString();
        }

        private void CMDBuy_Click(object sender, EventArgs e)
        {
            int cost = GameFunctions.Update_Cost_Label(CBXItems.Text);
            this.LBLcost.Text = cost.ToString();
            GameFunctions.BuyItem(CBXItems.Text);
        }

        private void NukeButton_Click(object sender, EventArgs e)
        {
            Player localPlayer = GameFunctions.GetLocalPlayer();
            //10 for testing
            int pointsToNuke = 30;
            this.LBLcost.Text = pointsToNuke.ToString();
            if (Main.points >= pointsToNuke) 
            {
                Main.points -= pointsToNuke;
                SpawnSystem.KillZombies();
            }
            else
            {
                string message = $"You do not have {pointsToNuke} points in order to nuke!";
                localPlayer.Message(MessageHud.MessageType.Center, message);
            }
        }

        private void EndGameButton_Click(object sender, EventArgs e)
        {
            Player localPlayer = GameFunctions.GetLocalPlayer();
            //10 for testing
            int pointsToWin = 500;
            this.LBLcost.Text = pointsToWin.ToString();
            if (Main.points >= pointsToWin)
            {
                Main.points -= pointsToWin;
                SpawnSystem.finished = true;
                GameFunctions.DestroyAllMobs();
                localPlayer.Message(MessageHud.MessageType.Center, "Congratulations you have won the game of Zombies! Thanks for playing!");
                
                GameFunctions.QuitTheGame();
            }
            else 
            {
                string message = $"You do not have {pointsToWin} points in order to end the game!";
                localPlayer.Message(MessageHud.MessageType.Center, message);
            }
        }

        private void SkillLevel_Click(object sender, EventArgs e) 
        {
            Player localPlayer = GameFunctions.GetLocalPlayer();
            int pointsToIncreaseSkill = 10;
            this.LBLcost.Text = pointsToIncreaseSkill.ToString();
            if (Main.points >= pointsToIncreaseSkill)
            {
                Main.points -= pointsToIncreaseSkill;
                GameFunctions.RaiseSkillLevel();
            }
            else
            {
                string message = $"You do not have {pointsToIncreaseSkill} points in order to increase your skill level!";
                localPlayer.Message(MessageHud.MessageType.Center, message);
            }
        }

        public void InvincibilityButton_Click(object sender, EventArgs e)
        {
            Player localPlayer = GameFunctions.GetLocalPlayer();
            counter = 0;
            exitFlag = false;
            int pointsForInvincibility = 10;

            this.LBLcost.Text = pointsForInvincibility.ToString();
            if (Main.points >= pointsForInvincibility) 
            {
                Main.points -= pointsForInvincibility;
                GameFunctions.GetLocalPlayer().Message(MessageHud.MessageType.Center, "Invincibility has started!");
                InvincibilityCycle();
            }
            else
            {
                string message = $"You do not have {pointsForInvincibility} points in order to become invincible!";
                localPlayer.Message(MessageHud.MessageType.Center, message);
            }
        }

        public async void InvincibilityCycle()
        {
            while (exitFlag == false)
            {
                GameFunctions.ChangeSkinColour();
                GameFunctions.AlwaysHeal();
                counter++;

                //Exits out of invincibility after ten seconds
                if (counter > 10)
                    exitFlag = true;

                await Task.Delay(1000).ConfigureAwait(false);
            }

            GameFunctions.GetLocalPlayer().Message(MessageHud.MessageType.Center, "Invincibility has ended!");
        }

        //Game start
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

        private void EasyButton_Click(object sender, EventArgs e)
        {
            button14.Hide();
            button15.Hide();
            button16.Hide();

            //Set difficulty multiplier to 1
            GameFunctions.StartGame(1);
        }

        private void MediumButton_Click(object sender, EventArgs e)
        {
            button14.Hide();
            button15.Hide();
            button16.Hide();

            //Set difficulty multiplier to 2
            GameFunctions.StartGame(2);
        }

        private void HardButton_Click(object sender, EventArgs e)
        {
            button14.Hide();
            button15.Hide();
            button16.Hide();

            //Set difficulty multiplier to 3
            GameFunctions.StartGame(3);
        }
    }
}
