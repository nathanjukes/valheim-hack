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
            this.button5 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.CMDStartgame = new System.Windows.Forms.Button();
            this.CBXItems = new System.Windows.Forms.ComboBox();
            this.CMDBuy = new System.Windows.Forms.Button();
            this.LBLcost = new System.Windows.Forms.Label();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 355);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 69);
            this.button1.TabIndex = 0;
            this.button1.Text = "Buy Nuke";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.NukeButton_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button5.ForeColor = System.Drawing.Color.Snow;
            this.button5.Location = new System.Drawing.Point(709, 339);
            this.button5.Margin = new System.Windows.Forms.Padding(4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(155, 100);
            this.button5.TabIndex = 4;
            this.button5.Text = "Dispose of injector";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.DisposeOfInjector_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(605, 100);
            this.button9.Margin = new System.Windows.Forms.Padding(4);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(139, 91);
            this.button9.TabIndex = 9;
            this.button9.Text = "Load Map";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.StartMap_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(808, 100);
            this.button10.Margin = new System.Windows.Forms.Padding(4);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(139, 91);
            this.button10.TabIndex = 10;
            this.button10.Text = "Delete Map";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.DeleteMap_Click);
            // 
            // CMDStartgame
            // 
            this.CMDStartgame.BackColor = System.Drawing.SystemColors.Highlight;
            this.CMDStartgame.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.CMDStartgame.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CMDStartgame.Location = new System.Drawing.Point(16, 90);
            this.CMDStartgame.Margin = new System.Windows.Forms.Padding(4);
            this.CMDStartgame.Name = "CMDStartgame";
            this.CMDStartgame.Size = new System.Drawing.Size(390, 100);
            this.CMDStartgame.TabIndex = 11;
            this.CMDStartgame.Text = "Start Game";
            this.CMDStartgame.UseVisualStyleBackColor = false;
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
            this.CBXItems.Location = new System.Drawing.Point(12, 271);
            this.CBXItems.Margin = new System.Windows.Forms.Padding(4);
            this.CBXItems.Name = "CBXItems";
            this.CBXItems.Size = new System.Drawing.Size(160, 24);
            this.CBXItems.TabIndex = 12;
            this.CBXItems.SelectedIndexChanged += new System.EventHandler(this.CBXItems_SelectedIndexChanged);
            // 
            // CMDBuy
            // 
            this.CMDBuy.Location = new System.Drawing.Point(205, 271);
            this.CMDBuy.Margin = new System.Windows.Forms.Padding(4);
            this.CMDBuy.Name = "CMDBuy";
            this.CMDBuy.Size = new System.Drawing.Size(100, 28);
            this.CMDBuy.TabIndex = 13;
            this.CMDBuy.Text = "Buy item";
            this.CMDBuy.UseVisualStyleBackColor = true;
            this.CMDBuy.Click += new System.EventHandler(this.CMDBuy_Click);
            // 
            // LBLcost
            // 
            this.LBLcost.AutoSize = true;
            this.LBLcost.Location = new System.Drawing.Point(624, 475);
            this.LBLcost.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBLcost.Name = "LBLcost";
            this.LBLcost.Size = new System.Drawing.Size(0, 16);
            this.LBLcost.TabIndex = 14;
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(9, 442);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(163, 72);
            this.button11.TabIndex = 15;
            this.button11.Text = "Buy Invincibility";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.InvincibilityButton_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(225, 442);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(144, 72);
            this.button12.TabIndex = 16;
            this.button12.Text = "Buy to end the game";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.EndGameButton_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(225, 355);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(144, 69);
            this.button13.TabIndex = 17;
            this.button13.Text = "Buy Increase Level";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.SkillLevel_Click);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(143, 153);
            this.button14.Margin = new System.Windows.Forms.Padding(4);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(295, 171);
            this.button14.TabIndex = 18;
            this.button14.Text = "Easy";
            this.button14.Hide();
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.EasyButton_Click);
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(476, 155);
            this.button15.Margin = new System.Windows.Forms.Padding(4);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(295, 171);
            this.button15.TabIndex = 19;
            this.button15.Text = "Medium";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Hide();
            this.button15.Click += new System.EventHandler(this.MediumButton_Click);
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(820, 153);
            this.button16.Margin = new System.Windows.Forms.Padding(4);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(295, 171);
            this.button16.TabIndex = 20;
            this.button16.Text = "Hard";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Hide();
            this.button16.Click += new System.EventHandler(this.HardButton_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.Location = new System.Drawing.Point(11, 208);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 59);
            this.label1.TabIndex = 0;
            this.label1.Text = "Item Shop";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label2.Location = new System.Drawing.Point(16, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(438, 39);
            this.label2.TabIndex = 21;
            this.label2.Text = "Zombies Minigame Valheim";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label3.Location = new System.Drawing.Point(620, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(341, 39);
            this.label3.TabIndex = 22;
            this.label3.Text = "Map creation controls";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label4.Location = new System.Drawing.Point(620, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(313, 39);
            this.label4.TabIndex = 23;
            this.label4.Text = "Dispose of injection";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 559);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button16);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.LBLcost);
            this.Controls.Add(this.CMDBuy);
            this.Controls.Add(this.CBXItems);
            this.Controls.Add(this.CMDStartgame);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Zombies Minigame";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button CMDStartgame;
        private System.Windows.Forms.ComboBox CBXItems;
        private System.Windows.Forms.Button CMDBuy;
        private System.Windows.Forms.Label LBLcost;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}