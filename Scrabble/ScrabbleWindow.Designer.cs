using System.Windows.Forms;
using Scrabble.Properties;

namespace Scrabble
{
    partial class ScrabbleWindow
    {
        public new bool Disposing { get; set; }
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
            _windowState.Restore(this);
            this.Disposing = true;
            Game.IsDisposing = true;
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
            
        }

        public void ResetLast()
        {
            this._scrabbleBoard.ResetLast();
        }

        public void ResetHints()
        {
            this._scrabbleBoard.ResetHints();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScrabbleWindow));
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.GameMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewGameMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenGameMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.endGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveGameMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RulesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TilesLabel = new System.Windows.Forms.Label();
            this.TileCount = new System.Windows.Forms.Label();
            this.ExchangeButton = new System.Windows.Forms.Button();
            this.ShuffleButton = new System.Windows.Forms.Button();
            this.PassButton = new System.Windows.Forms.Button();
            this.HighScoreLabel = new System.Windows.Forms.Label();
            this.HighScoreName = new System.Windows.Forms.Label();
            this.HighScoreValue = new System.Windows.Forms.Label();
            this.HintButton = new System.Windows.Forms.Button();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.BackColor = System.Drawing.Color.Transparent;
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GameMenuItem});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(1018, 40);
            this.Menu.TabIndex = 0;
            this.Menu.Text = "Menu";
            // 
            // GameMenuItem
            // 
            this.GameMenuItem.AutoSize = false;
            this.GameMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.GameMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.GameMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewGameMenuItem,
            this.OpenGameMenuItem,
            this.endGameToolStripMenuItem,
            this.SaveGameMenuItem,
            this.RulesMenuItem,
            this.OptionsMenuItem,
            this.aboutToolStripMenuItem,
            this.ExitMenuItem});
            this.GameMenuItem.Image = global::Scrabble.Properties.Resources.MenuGame;
            this.GameMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.GameMenuItem.Name = "GameMenuItem";
            this.GameMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.G)));
            this.GameMenuItem.Size = new System.Drawing.Size(104, 36);
            this.GameMenuItem.Text = "Game";
            // 
            // NewGameMenuItem
            // 
            this.NewGameMenuItem.Name = "NewGameMenuItem";
            this.NewGameMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.NewGameMenuItem.Size = new System.Drawing.Size(180, 22);
            this.NewGameMenuItem.Text = "New Game";
            this.NewGameMenuItem.Click += new System.EventHandler(this.NewGameMenuItemClick);
            // 
            // OpenGameMenuItem
            // 
            this.OpenGameMenuItem.Name = "OpenGameMenuItem";
            this.OpenGameMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OpenGameMenuItem.Size = new System.Drawing.Size(180, 22);
            this.OpenGameMenuItem.Text = "Open Game";
            this.OpenGameMenuItem.Click += new System.EventHandler(this.OpenGameMenuItemClick);
            // 
            // endGameToolStripMenuItem
            // 
            this.endGameToolStripMenuItem.Enabled = false;
            this.endGameToolStripMenuItem.Name = "endGameToolStripMenuItem";
            this.endGameToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.endGameToolStripMenuItem.Text = "End Game";
            this.endGameToolStripMenuItem.Click += new System.EventHandler(this.EndGameToolStripMenuItemClick);
            // 
            // SaveGameMenuItem
            // 
            this.SaveGameMenuItem.Enabled = false;
            this.SaveGameMenuItem.Name = "SaveGameMenuItem";
            this.SaveGameMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveGameMenuItem.Size = new System.Drawing.Size(180, 22);
            this.SaveGameMenuItem.Text = "Save Game";
            this.SaveGameMenuItem.Click += new System.EventHandler(this.SaveGameMenuItemClick);
            // 
            // RulesMenuItem
            // 
            this.RulesMenuItem.Name = "RulesMenuItem";
            this.RulesMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.RulesMenuItem.Size = new System.Drawing.Size(180, 22);
            this.RulesMenuItem.Text = "Rules";
            this.RulesMenuItem.Click += new System.EventHandler(this.RulesMenuItemClick);
            // 
            // OptionsMenuItem
            // 
            this.OptionsMenuItem.Name = "OptionsMenuItem";
            this.OptionsMenuItem.Size = new System.Drawing.Size(180, 22);
            this.OptionsMenuItem.Text = "Options";
            this.OptionsMenuItem.Click += new System.EventHandler(this.OptionsMenuItemClick);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItemClick);
            // 
            // ExitMenuItem
            // 
            this.ExitMenuItem.Name = "ExitMenuItem";
            this.ExitMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.ExitMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ExitMenuItem.Text = "Exit";
            this.ExitMenuItem.Click += new System.EventHandler(this.ExitMenuItemClick);
            // 
            // TilesLabel
            // 
            this.TilesLabel.AutoSize = true;
            this.TilesLabel.BackColor = System.Drawing.Color.Transparent;
            this.TilesLabel.ForeColor = System.Drawing.Color.Moccasin;
            this.TilesLabel.Location = new System.Drawing.Point(102, 615);
            this.TilesLabel.Name = "TilesLabel";
            this.TilesLabel.Size = new System.Drawing.Size(29, 13);
            this.TilesLabel.TabIndex = 4;
            this.TilesLabel.Text = "Tiles";
            // 
            // TileCount
            // 
            this.TileCount.AutoSize = true;
            this.TileCount.BackColor = System.Drawing.Color.Transparent;
            this.TileCount.Font = new System.Drawing.Font("Arial Black", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TileCount.ForeColor = System.Drawing.Color.Moccasin;
            this.TileCount.Location = new System.Drawing.Point(12, 615);
            this.TileCount.Name = "TileCount";
            this.TileCount.Size = new System.Drawing.Size(125, 68);
            this.TileCount.TabIndex = 3;
            this.TileCount.Text = "100";
            // 
            // ExchangeButton
            // 
            this.ExchangeButton.BackColor = System.Drawing.Color.Transparent;
            this.ExchangeButton.Enabled = false;
            this.ExchangeButton.Location = new System.Drawing.Point(143, 615);
            this.ExchangeButton.Name = "ExchangeButton";
            this.ExchangeButton.Size = new System.Drawing.Size(68, 40);
            this.ExchangeButton.TabIndex = 5;
            this.ExchangeButton.Text = "Exchange";
            this.ExchangeButton.UseVisualStyleBackColor = false;
            this.ExchangeButton.Click += new System.EventHandler(this.ExchangeButtonClick);
            // 
            // ShuffleButton
            // 
            this.ShuffleButton.BackColor = System.Drawing.Color.Transparent;
            this.ShuffleButton.Enabled = false;
            this.ShuffleButton.Location = new System.Drawing.Point(217, 615);
            this.ShuffleButton.Name = "ShuffleButton";
            this.ShuffleButton.Size = new System.Drawing.Size(68, 40);
            this.ShuffleButton.TabIndex = 6;
            this.ShuffleButton.Text = "Shuffle";
            this.ShuffleButton.UseVisualStyleBackColor = false;
            this.ShuffleButton.Click += new System.EventHandler(this.ShuffleButtonClick);
            // 
            // PassButton
            // 
            this.PassButton.BackColor = System.Drawing.Color.Transparent;
            this.PassButton.Enabled = false;
            this.PassButton.Location = new System.Drawing.Point(291, 615);
            this.PassButton.Name = "PassButton";
            this.PassButton.Size = new System.Drawing.Size(68, 40);
            this.PassButton.TabIndex = 7;
            this.PassButton.Text = "Pass";
            this.PassButton.UseVisualStyleBackColor = false;
            this.PassButton.Click += new System.EventHandler(this.PassButtonClick);
            // 
            // HighScoreLabel
            // 
            this.HighScoreLabel.AutoSize = true;
            this.HighScoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.HighScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HighScoreLabel.ForeColor = System.Drawing.Color.White;
            this.HighScoreLabel.Location = new System.Drawing.Point(607, 21);
            this.HighScoreLabel.Name = "HighScoreLabel";
            this.HighScoreLabel.Size = new System.Drawing.Size(128, 25);
            this.HighScoreLabel.TabIndex = 8;
            this.HighScoreLabel.Text = "High Score";
            // 
            // HighScoreName
            // 
            this.HighScoreName.AutoSize = true;
            this.HighScoreName.BackColor = System.Drawing.Color.Transparent;
            this.HighScoreName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HighScoreName.ForeColor = System.Drawing.Color.White;
            this.HighScoreName.Location = new System.Drawing.Point(679, 46);
            this.HighScoreName.Name = "HighScoreName";
            this.HighScoreName.Size = new System.Drawing.Size(72, 25);
            this.HighScoreName.TabIndex = 9;
            this.HighScoreName.Text = "Name";
            // 
            // HighScoreValue
            // 
            this.HighScoreValue.AutoSize = true;
            this.HighScoreValue.BackColor = System.Drawing.Color.Transparent;
            this.HighScoreValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HighScoreValue.ForeColor = System.Drawing.Color.White;
            this.HighScoreValue.Location = new System.Drawing.Point(679, 71);
            this.HighScoreValue.Name = "HighScoreValue";
            this.HighScoreValue.Size = new System.Drawing.Size(72, 25);
            this.HighScoreValue.TabIndex = 10;
            this.HighScoreValue.Text = "Value";
            // 
            // HintButton
            // 
            this.HintButton.BackColor = System.Drawing.Color.Transparent;
            this.HintButton.Enabled = false;
            this.HintButton.Location = new System.Drawing.Point(365, 615);
            this.HintButton.Name = "HintButton";
            this.HintButton.Size = new System.Drawing.Size(68, 40);
            this.HintButton.TabIndex = 11;
            this.HintButton.Text = "Hint";
            this.HintButton.UseVisualStyleBackColor = false;
            this.HintButton.Click += new System.EventHandler(this.HintButtonClick);
            // 
            // ScrabbleWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Scrabble.Properties.Resources.Scrabble;
            this.ClientSize = new System.Drawing.Size(1018, 740);
            this.Controls.Add(this.HintButton);
            this.Controls.Add(this.HighScoreValue);
            this.Controls.Add(this.HighScoreName);
            this.Controls.Add(this.HighScoreLabel);
            this.Controls.Add(this.PassButton);
            this.Controls.Add(this.ShuffleButton);
            this.Controls.Add(this.ExchangeButton);
            this.Controls.Add(this.TilesLabel);
            this.Controls.Add(this.TileCount);
            this.Controls.Add(this.Menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.Menu;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1024, 768);
            this.MinimumSize = new System.Drawing.Size(1024, 726);
            this.Name = "ScrabbleWindow";
            this.Text = "Scrabble Nights";
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem GameMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewGameMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenGameMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveGameMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RulesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OptionsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label TilesLabel;
        public System.Windows.Forms.Label TileCount;
        private System.Windows.Forms.ToolStripMenuItem endGameToolStripMenuItem;
        public System.Windows.Forms.Button ExchangeButton;
        public System.Windows.Forms.Button ShuffleButton;
        public System.Windows.Forms.Button PassButton;
        private System.Windows.Forms.Label HighScoreLabel;
        private System.Windows.Forms.Label HighScoreName;
        private System.Windows.Forms.Label HighScoreValue;
        public Button HintButton;
    }
}