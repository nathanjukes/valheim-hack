namespace ValheimHack223
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.CMDArena = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.CMDStartgame = new System.Windows.Forms.Button();
            this.CBXItems = new System.Windows.Forms.ComboBox();
            this.CMDBuy = new System.Windows.Forms.Button();
            this.LBLcost = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(436, 220);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(195, 85);
            this.button1.TabIndex = 0;
            this.button1.Text = "Kill Zombies";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(235, 34);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(195, 85);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(34, 34);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(195, 85);
            this.button3.TabIndex = 2;
            this.button3.Text = "spawn wall";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(34, 125);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(195, 85);
            this.button4.TabIndex = 3;
            this.button4.Text = "delete boats";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button5.Location = new System.Drawing.Point(34, 220);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(195, 85);
            this.button5.TabIndex = 4;
            this.button5.Text = "Dispose of injector (Does not fully work)";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(235, 220);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(195, 85);
            this.button6.TabIndex = 5;
            this.button6.Text = "delete trees";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(235, 125);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(195, 85);
            this.button7.TabIndex = 6;
            this.button7.Text = "spawn zombies";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click_1);
            // 
            // CMDArena
            // 
            this.CMDArena.Location = new System.Drawing.Point(436, 9);
            this.CMDArena.Name = "CMDArena";
            this.CMDArena.Size = new System.Drawing.Size(188, 110);
            this.CMDArena.TabIndex = 7;
            this.CMDArena.Text = "Build Arena";
            this.CMDArena.UseVisualStyleBackColor = true;
            this.CMDArena.Click += new System.EventHandler(this.CMDArena_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(630, 9);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(188, 110);
            this.button8.TabIndex = 8;
            this.button8.Text = "Start Spawning Zombies";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(184, 366);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(122, 72);
            this.button9.TabIndex = 9;
            this.button9.Text = "Load Map";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(436, 125);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(195, 89);
            this.button10.TabIndex = 10;
            this.button10.Text = "Delete Map";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // CMDStartgame
            // 
            this.CMDStartgame.Location = new System.Drawing.Point(43, 366);
            this.CMDStartgame.Name = "CMDStartgame";
            this.CMDStartgame.Size = new System.Drawing.Size(135, 72);
            this.CMDStartgame.TabIndex = 11;
            this.CMDStartgame.Text = "All players in game?";
            this.CMDStartgame.UseVisualStyleBackColor = true;
            this.CMDStartgame.Click += new System.EventHandler(this.CMDStartgame_Click);
            // 
            // CBXItems
            // 
            this.CBXItems.FormattingEnabled = true;
            this.CBXItems.Items.AddRange(new object[] {
            "ArmorBronzeChest",
            "ArmorBronzeLegs",
            "ArmorIronChest",
            "ArmorIronLegs",
            "ArmorLeatherLegs",
            "ArmorPaddedCuirass",
            "ArmorPaddedGreaves",
            "ArmorRagsChest",
            "ArmorRagsLegs",
            "ArmorTrollLeatherChest",
            "ArmorTrollLeatherLegs",
            "ArmorWolfChest",
            "ArmorWolfLegs",
            "AtgeirBlackmetal",
            "AtgeirBronze",
            "AtgeirIron",
            "AxeBlackMetal",
            "AxeBronze",
            "AxeFlint",
            "AxeIron",
            "AxeStone",
            "Battleaxe",
            "BowDraugrFang",
            "BowFineWood",
            "BowHuntsman",
            "Bow",
            "Club",
            "KnifeBlackMetal",
            "KnifeChitin",
            "KnifeCopper",
            "KnifeFlint",
            "MaceBronze",
            "MaceIron",
            "MaceNeedle",
            "MaceSilver",
            "ShieldBlackmetal",
            "ShieldBlackmetalTower",
            "ShieldBronzeBuckler",
            "ShieldIronSquare",
            "ShieldIronTower",
            "ShieldKnight",
            "ShieldSerpentscale",
            "ShieldSilver",
            "ShieldWood",
            "ShieldWoodTower",
            "SledgeIron",
            "SledgeStagbreaker",
            "SpearBronze",
            "SpearChitin",
            "SpearElderbark",
            "SpearFlint",
            "SpearWolfFang",
            "Tankard",
            "TankardOdin",
            "Torch",
            "Bread",
            "BloodPudding",
            "Blueberries",
            "Carrot",
            "CarrotSoup",
            "Cloudberry",
            "CookedLoxMeat",
            "CookedMeat",
            "FishCooked",
            "Honey",
            "Mushroom",
            "MushroomBlue",
            "MushroomYellow",
            "NeckTailGrilled",
            "Raspberry",
            "QueensJam",
            "Sausages",
            "SerpentMeatCooked",
            "SerpentStew",
            "Turnip",
            "TurnipStew",
            "ArrowBronze",
            "ArrowFire",
            "ArrowFlint",
            "ArrowFrost",
            "ArrowIron",
            "ArrowNeedle",
            "ArrowObsidian",
            "ArrowPoison",
            "ArrowSilver",
            "ArrowWood"});
            this.CBXItems.Location = new System.Drawing.Point(330, 386);
            this.CBXItems.Name = "CBXItems";
            this.CBXItems.Size = new System.Drawing.Size(121, 21);
            this.CBXItems.TabIndex = 12;
            this.CBXItems.SelectedIndexChanged += new System.EventHandler(this.CBXItems_SelectedIndexChanged);
            // 
            // CMDBuy
            // 
            this.CMDBuy.Location = new System.Drawing.Point(530, 386);
            this.CMDBuy.Name = "CMDBuy";
            this.CMDBuy.Size = new System.Drawing.Size(75, 23);
            this.CMDBuy.TabIndex = 13;
            this.CMDBuy.Text = "Buy item";
            this.CMDBuy.UseVisualStyleBackColor = true;
            this.CMDBuy.Click += new System.EventHandler(this.CMDBuy_Click);
            // 
            // LBLcost
            // 
            this.LBLcost.AutoSize = true;
            this.LBLcost.Location = new System.Drawing.Point(468, 386);
            this.LBLcost.Name = "LBLcost";
            this.LBLcost.Size = new System.Drawing.Size(0, 13);
            this.LBLcost.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 454);
            this.Controls.Add(this.LBLcost);
            this.Controls.Add(this.CMDBuy);
            this.Controls.Add(this.CBXItems);
            this.Controls.Add(this.CMDStartgame);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.CMDArena);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button CMDArena;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button CMDStartgame;
        private System.Windows.Forms.ComboBox CBXItems;
        private System.Windows.Forms.Button CMDBuy;
        private System.Windows.Forms.Label LBLcost;
    }
}