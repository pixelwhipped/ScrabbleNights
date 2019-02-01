namespace Scrabble
{
    partial class Options
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Options));
            this.DefaultsGroupBox = new System.Windows.Forms.GroupBox();
            this.Player3DefalutNameLabel = new System.Windows.Forms.Label();
            this.Player3DefaultTextBox = new System.Windows.Forms.TextBox();
            this.Player2DefalutNameLabel = new System.Windows.Forms.Label();
            this.Player2DefaultTextBox = new System.Windows.Forms.TextBox();
            this.Player1DefalutNameLabel = new System.Windows.Forms.Label();
            this.Player1DefaultTextBox = new System.Windows.Forms.TextBox();
            this.OptionsGroupBox = new System.Windows.Forms.GroupBox();
            this.EnableSoundCheckBox = new System.Windows.Forms.CheckBox();
            this.DifficultyLabel = new System.Windows.Forms.Label();
            this.DifficultyTrackBar = new System.Windows.Forms.TrackBar();
            this.OkButton = new System.Windows.Forms.Button();
            this.Player4DefalutNameLabel = new System.Windows.Forms.Label();
            this.Player4DefaultTextBox = new System.Windows.Forms.TextBox();
            this.AllowBlanksCheckBox = new System.Windows.Forms.CheckBox();
            this.FullScreenCheckBox = new System.Windows.Forms.CheckBox();
            this.DefaultsGroupBox.SuspendLayout();
            this.OptionsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DifficultyTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // DefaultsGroupBox
            // 
            this.DefaultsGroupBox.Controls.Add(this.Player3DefalutNameLabel);
            this.DefaultsGroupBox.Controls.Add(this.Player3DefaultTextBox);
            this.DefaultsGroupBox.Controls.Add(this.Player2DefalutNameLabel);
            this.DefaultsGroupBox.Controls.Add(this.Player2DefaultTextBox);
            this.DefaultsGroupBox.Controls.Add(this.Player1DefalutNameLabel);
            this.DefaultsGroupBox.Controls.Add(this.Player1DefaultTextBox);
            this.DefaultsGroupBox.Location = new System.Drawing.Point(7, 7);
            this.DefaultsGroupBox.Name = "DefaultsGroupBox";
            this.DefaultsGroupBox.Size = new System.Drawing.Size(335, 126);
            this.DefaultsGroupBox.TabIndex = 0;
            this.DefaultsGroupBox.TabStop = false;
            this.DefaultsGroupBox.Text = "Defaults";
            // 
            // Player3DefalutNameLabel
            // 
            this.Player3DefalutNameLabel.AutoSize = true;
            this.Player3DefalutNameLabel.Location = new System.Drawing.Point(118, 75);
            this.Player3DefalutNameLabel.Name = "Player3DefalutNameLabel";
            this.Player3DefalutNameLabel.Size = new System.Drawing.Size(76, 13);
            this.Player3DefalutNameLabel.TabIndex = 5;
            this.Player3DefalutNameLabel.Text = "Player 3 Name";
            // 
            // Player3DefaultTextBox
            // 
            this.Player3DefaultTextBox.Location = new System.Drawing.Point(12, 72);
            this.Player3DefaultTextBox.Name = "Player3DefaultTextBox";
            this.Player3DefaultTextBox.Size = new System.Drawing.Size(100, 20);
            this.Player3DefaultTextBox.TabIndex = 4;
            this.Player3DefaultTextBox.TextChanged += new System.EventHandler(this.Player3DefaultTextBoxTextChanged);
            // 
            // Player2DefalutNameLabel
            // 
            this.Player2DefalutNameLabel.AutoSize = true;
            this.Player2DefalutNameLabel.Location = new System.Drawing.Point(118, 49);
            this.Player2DefalutNameLabel.Name = "Player2DefalutNameLabel";
            this.Player2DefalutNameLabel.Size = new System.Drawing.Size(76, 13);
            this.Player2DefalutNameLabel.TabIndex = 3;
            this.Player2DefalutNameLabel.Text = "Player 2 Name";
            // 
            // Player2DefaultTextBox
            // 
            this.Player2DefaultTextBox.Location = new System.Drawing.Point(12, 46);
            this.Player2DefaultTextBox.Name = "Player2DefaultTextBox";
            this.Player2DefaultTextBox.Size = new System.Drawing.Size(100, 20);
            this.Player2DefaultTextBox.TabIndex = 2;
            this.Player2DefaultTextBox.TextChanged += new System.EventHandler(this.Player2DefaultTextBoxTextChanged);
            // 
            // Player1DefalutNameLabel
            // 
            this.Player1DefalutNameLabel.AutoSize = true;
            this.Player1DefalutNameLabel.Location = new System.Drawing.Point(118, 23);
            this.Player1DefalutNameLabel.Name = "Player1DefalutNameLabel";
            this.Player1DefalutNameLabel.Size = new System.Drawing.Size(76, 13);
            this.Player1DefalutNameLabel.TabIndex = 1;
            this.Player1DefalutNameLabel.Text = "Player 1 Name";
            // 
            // Player1DefaultTextBox
            // 
            this.Player1DefaultTextBox.Location = new System.Drawing.Point(12, 20);
            this.Player1DefaultTextBox.Name = "Player1DefaultTextBox";
            this.Player1DefaultTextBox.Size = new System.Drawing.Size(100, 20);
            this.Player1DefaultTextBox.TabIndex = 0;
            this.Player1DefaultTextBox.TextChanged += new System.EventHandler(this.Player1DefaultTextBoxTextChanged);
            // 
            // OptionsGroupBox
            // 
            this.OptionsGroupBox.Controls.Add(this.FullScreenCheckBox);
            this.OptionsGroupBox.Controls.Add(this.AllowBlanksCheckBox);
            this.OptionsGroupBox.Controls.Add(this.EnableSoundCheckBox);
            this.OptionsGroupBox.Controls.Add(this.DifficultyLabel);
            this.OptionsGroupBox.Controls.Add(this.DifficultyTrackBar);
            this.OptionsGroupBox.Location = new System.Drawing.Point(9, 139);
            this.OptionsGroupBox.Name = "OptionsGroupBox";
            this.OptionsGroupBox.Size = new System.Drawing.Size(332, 121);
            this.OptionsGroupBox.TabIndex = 1;
            this.OptionsGroupBox.TabStop = false;
            this.OptionsGroupBox.Text = "Options";
            // 
            // EnableSoundCheckBox
            // 
            this.EnableSoundCheckBox.AutoSize = true;
            this.EnableSoundCheckBox.Checked = true;
            this.EnableSoundCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.EnableSoundCheckBox.Location = new System.Drawing.Point(14, 55);
            this.EnableSoundCheckBox.Name = "EnableSoundCheckBox";
            this.EnableSoundCheckBox.Size = new System.Drawing.Size(93, 17);
            this.EnableSoundCheckBox.TabIndex = 7;
            this.EnableSoundCheckBox.Text = "Enable Sound";
            this.EnableSoundCheckBox.UseVisualStyleBackColor = true;
            this.EnableSoundCheckBox.CheckedChanged += new System.EventHandler(this.EnableMusicCheckBoxCheckedChanged);
            // 
            // DifficultyLabel
            // 
            this.DifficultyLabel.AutoSize = true;
            this.DifficultyLabel.Location = new System.Drawing.Point(149, 16);
            this.DifficultyLabel.Name = "DifficultyLabel";
            this.DifficultyLabel.Size = new System.Drawing.Size(47, 13);
            this.DifficultyLabel.TabIndex = 6;
            this.DifficultyLabel.Text = "Difficulty";
            // 
            // DifficultyTrackBar
            // 
            this.DifficultyTrackBar.LargeChange = 1;
            this.DifficultyTrackBar.Location = new System.Drawing.Point(7, 16);
            this.DifficultyTrackBar.Maximum = 2;
            this.DifficultyTrackBar.Name = "DifficultyTrackBar";
            this.DifficultyTrackBar.Size = new System.Drawing.Size(136, 45);
            this.DifficultyTrackBar.TabIndex = 5;
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(267, 266);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 2;
            this.OkButton.Text = "Ok";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButtonClick);
            // 
            // Player4DefalutNameLabel
            // 
            this.Player4DefalutNameLabel.AutoSize = true;
            this.Player4DefalutNameLabel.Location = new System.Drawing.Point(125, 108);
            this.Player4DefalutNameLabel.Name = "Player4DefalutNameLabel";
            this.Player4DefalutNameLabel.Size = new System.Drawing.Size(76, 13);
            this.Player4DefalutNameLabel.TabIndex = 7;
            this.Player4DefalutNameLabel.Text = "Player 4 Name";
            // 
            // Player4DefaultTextBox
            // 
            this.Player4DefaultTextBox.Location = new System.Drawing.Point(19, 105);
            this.Player4DefaultTextBox.Name = "Player4DefaultTextBox";
            this.Player4DefaultTextBox.Size = new System.Drawing.Size(100, 20);
            this.Player4DefaultTextBox.TabIndex = 6;
            this.Player4DefaultTextBox.TextChanged += new System.EventHandler(this.Player4DefaultTextBoxTextChanged);
            // 
            // AllowBlanksCheckBox
            // 
            this.AllowBlanksCheckBox.AutoSize = true;
            this.AllowBlanksCheckBox.Location = new System.Drawing.Point(119, 55);
            this.AllowBlanksCheckBox.Name = "AllowBlanksCheckBox";
            this.AllowBlanksCheckBox.Size = new System.Drawing.Size(132, 17);
            this.AllowBlanksCheckBox.TabIndex = 8;
            this.AllowBlanksCheckBox.Text = "Allow Blanks on Board";
            this.AllowBlanksCheckBox.UseVisualStyleBackColor = true;
            this.AllowBlanksCheckBox.CheckedChanged += new System.EventHandler(this.AllowBlanksCheckBox_CheckedChanged);
            // 
            // FullScreenCheckBox
            // 
            this.FullScreenCheckBox.AutoSize = true;
            this.FullScreenCheckBox.Location = new System.Drawing.Point(15, 83);
            this.FullScreenCheckBox.Name = "FullScreenCheckBox";
            this.FullScreenCheckBox.Size = new System.Drawing.Size(79, 17);
            this.FullScreenCheckBox.TabIndex = 9;
            this.FullScreenCheckBox.Text = "Full Screen";
            this.FullScreenCheckBox.UseVisualStyleBackColor = true;
            this.FullScreenCheckBox.CheckedChanged += new System.EventHandler(this.FullScreenCheckBox_CheckedChanged);
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 294);
            this.Controls.Add(this.Player4DefalutNameLabel);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.Player4DefaultTextBox);
            this.Controls.Add(this.OptionsGroupBox);
            this.Controls.Add(this.DefaultsGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Options";
            this.Text = "Options";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OptionsFormClosing);
            this.DefaultsGroupBox.ResumeLayout(false);
            this.DefaultsGroupBox.PerformLayout();
            this.OptionsGroupBox.ResumeLayout(false);
            this.OptionsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DifficultyTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox DefaultsGroupBox;
        private System.Windows.Forms.GroupBox OptionsGroupBox;
        private System.Windows.Forms.Label DifficultyLabel;
        private System.Windows.Forms.TrackBar DifficultyTrackBar;
        private System.Windows.Forms.Label Player3DefalutNameLabel;
        private System.Windows.Forms.TextBox Player3DefaultTextBox;
        private System.Windows.Forms.Label Player2DefalutNameLabel;
        private System.Windows.Forms.TextBox Player2DefaultTextBox;
        private System.Windows.Forms.Label Player1DefalutNameLabel;
        private System.Windows.Forms.TextBox Player1DefaultTextBox;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Label Player4DefalutNameLabel;
        private System.Windows.Forms.TextBox Player4DefaultTextBox;
        private System.Windows.Forms.CheckBox EnableSoundCheckBox;
        private System.Windows.Forms.CheckBox AllowBlanksCheckBox;
        private System.Windows.Forms.CheckBox FullScreenCheckBox;
    }
}