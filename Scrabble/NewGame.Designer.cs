namespace Scrabble
{
    partial class NewGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewGame));
            this.RememberPlayer1CheckBox = new System.Windows.Forms.CheckBox();
            this.Player1NameTextBox = new System.Windows.Forms.TextBox();
            this.Cancel = new System.Windows.Forms.Button();
            this.Begin = new System.Windows.Forms.Button();
            this.Player1IsHumanCheckBox = new System.Windows.Forms.CheckBox();
            this.Player2IsHumanCheckBox = new System.Windows.Forms.CheckBox();
            this.RememberPlayer2CheckBox = new System.Windows.Forms.CheckBox();
            this.Player2NameTextBox = new System.Windows.Forms.TextBox();
            this.Player3IsHumanCheckBox = new System.Windows.Forms.CheckBox();
            this.RememberPlayer3CheckBox = new System.Windows.Forms.CheckBox();
            this.Player3NameTextBox = new System.Windows.Forms.TextBox();
            this.Player4IsHumanCheckBox = new System.Windows.Forms.CheckBox();
            this.RememberPlayer4CheckBox = new System.Windows.Forms.CheckBox();
            this.Player4NameTextBox = new System.Windows.Forms.TextBox();
            this.Player3EnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.Player4EnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // RememberPlayer1CheckBox
            // 
            this.RememberPlayer1CheckBox.AutoSize = true;
            this.RememberPlayer1CheckBox.Checked = true;
            this.RememberPlayer1CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RememberPlayer1CheckBox.Location = new System.Drawing.Point(15, 2);
            this.RememberPlayer1CheckBox.Name = "RememberPlayer1CheckBox";
            this.RememberPlayer1CheckBox.Size = new System.Drawing.Size(108, 17);
            this.RememberPlayer1CheckBox.TabIndex = 9;
            this.RememberPlayer1CheckBox.Text = "Remember Name";
            this.RememberPlayer1CheckBox.UseVisualStyleBackColor = true;
            // 
            // Player1NameTextBox
            // 
            this.Player1NameTextBox.Location = new System.Drawing.Point(15, 25);
            this.Player1NameTextBox.Name = "Player1NameTextBox";
            this.Player1NameTextBox.Size = new System.Drawing.Size(170, 20);
            this.Player1NameTextBox.TabIndex = 7;
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(169, 198);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(86, 24);
            this.Cancel.TabIndex = 6;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.CancelClick);
            // 
            // Begin
            // 
            this.Begin.Location = new System.Drawing.Point(77, 198);
            this.Begin.Name = "Begin";
            this.Begin.Size = new System.Drawing.Size(86, 24);
            this.Begin.TabIndex = 5;
            this.Begin.Text = "Begin";
            this.Begin.UseVisualStyleBackColor = true;
            this.Begin.Click += new System.EventHandler(this.BeginClick);
            // 
            // Player1IsHumanCheckBox
            // 
            this.Player1IsHumanCheckBox.AutoSize = true;
            this.Player1IsHumanCheckBox.Checked = true;
            this.Player1IsHumanCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Player1IsHumanCheckBox.Location = new System.Drawing.Point(195, 26);
            this.Player1IsHumanCheckBox.Name = "Player1IsHumanCheckBox";
            this.Player1IsHumanCheckBox.Size = new System.Drawing.Size(60, 17);
            this.Player1IsHumanCheckBox.TabIndex = 10;
            this.Player1IsHumanCheckBox.Text = "Human";
            this.Player1IsHumanCheckBox.UseVisualStyleBackColor = true;
            this.Player1IsHumanCheckBox.CheckedChanged += new System.EventHandler(this.Player1IsHumanCheckBoxCheckedChanged);
            // 
            // Player2IsHumanCheckBox
            // 
            this.Player2IsHumanCheckBox.AutoSize = true;
            this.Player2IsHumanCheckBox.Location = new System.Drawing.Point(195, 75);
            this.Player2IsHumanCheckBox.Name = "Player2IsHumanCheckBox";
            this.Player2IsHumanCheckBox.Size = new System.Drawing.Size(60, 17);
            this.Player2IsHumanCheckBox.TabIndex = 13;
            this.Player2IsHumanCheckBox.Text = "Human";
            this.Player2IsHumanCheckBox.UseVisualStyleBackColor = true;
            this.Player2IsHumanCheckBox.CheckedChanged += new System.EventHandler(this.Player2IsHumanCheckBoxCheckedChanged);
            // 
            // RememberPlayer2CheckBox
            // 
            this.RememberPlayer2CheckBox.AutoSize = true;
            this.RememberPlayer2CheckBox.Enabled = false;
            this.RememberPlayer2CheckBox.Location = new System.Drawing.Point(15, 51);
            this.RememberPlayer2CheckBox.Name = "RememberPlayer2CheckBox";
            this.RememberPlayer2CheckBox.Size = new System.Drawing.Size(108, 17);
            this.RememberPlayer2CheckBox.TabIndex = 12;
            this.RememberPlayer2CheckBox.Text = "Remember Name";
            this.RememberPlayer2CheckBox.UseVisualStyleBackColor = true;
            // 
            // Player2NameTextBox
            // 
            this.Player2NameTextBox.Enabled = false;
            this.Player2NameTextBox.Location = new System.Drawing.Point(15, 74);
            this.Player2NameTextBox.Name = "Player2NameTextBox";
            this.Player2NameTextBox.Size = new System.Drawing.Size(170, 20);
            this.Player2NameTextBox.TabIndex = 11;
            // 
            // Player3IsHumanCheckBox
            // 
            this.Player3IsHumanCheckBox.AutoSize = true;
            this.Player3IsHumanCheckBox.Location = new System.Drawing.Point(195, 124);
            this.Player3IsHumanCheckBox.Name = "Player3IsHumanCheckBox";
            this.Player3IsHumanCheckBox.Size = new System.Drawing.Size(60, 17);
            this.Player3IsHumanCheckBox.TabIndex = 16;
            this.Player3IsHumanCheckBox.Text = "Human";
            this.Player3IsHumanCheckBox.UseVisualStyleBackColor = true;
            this.Player3IsHumanCheckBox.CheckedChanged += new System.EventHandler(this.Player3IsHumanCheckBoxCheckedChanged);
            // 
            // RememberPlayer3CheckBox
            // 
            this.RememberPlayer3CheckBox.AutoSize = true;
            this.RememberPlayer3CheckBox.Enabled = false;
            this.RememberPlayer3CheckBox.Location = new System.Drawing.Point(15, 100);
            this.RememberPlayer3CheckBox.Name = "RememberPlayer3CheckBox";
            this.RememberPlayer3CheckBox.Size = new System.Drawing.Size(108, 17);
            this.RememberPlayer3CheckBox.TabIndex = 15;
            this.RememberPlayer3CheckBox.Text = "Remember Name";
            this.RememberPlayer3CheckBox.UseVisualStyleBackColor = true;
            // 
            // Player3NameTextBox
            // 
            this.Player3NameTextBox.Enabled = false;
            this.Player3NameTextBox.Location = new System.Drawing.Point(15, 123);
            this.Player3NameTextBox.Name = "Player3NameTextBox";
            this.Player3NameTextBox.Size = new System.Drawing.Size(170, 20);
            this.Player3NameTextBox.TabIndex = 14;
            // 
            // Player4IsHumanCheckBox
            // 
            this.Player4IsHumanCheckBox.AutoSize = true;
            this.Player4IsHumanCheckBox.Location = new System.Drawing.Point(195, 173);
            this.Player4IsHumanCheckBox.Name = "Player4IsHumanCheckBox";
            this.Player4IsHumanCheckBox.Size = new System.Drawing.Size(60, 17);
            this.Player4IsHumanCheckBox.TabIndex = 19;
            this.Player4IsHumanCheckBox.Text = "Human";
            this.Player4IsHumanCheckBox.UseVisualStyleBackColor = true;
            this.Player4IsHumanCheckBox.CheckedChanged += new System.EventHandler(this.Player4IsHumanCheckBoxCheckedChanged);
            // 
            // RememberPlayer4CheckBox
            // 
            this.RememberPlayer4CheckBox.AutoSize = true;
            this.RememberPlayer4CheckBox.Enabled = false;
            this.RememberPlayer4CheckBox.Location = new System.Drawing.Point(15, 149);
            this.RememberPlayer4CheckBox.Name = "RememberPlayer4CheckBox";
            this.RememberPlayer4CheckBox.Size = new System.Drawing.Size(108, 17);
            this.RememberPlayer4CheckBox.TabIndex = 18;
            this.RememberPlayer4CheckBox.Text = "Remember Name";
            this.RememberPlayer4CheckBox.UseVisualStyleBackColor = true;
            // 
            // Player4NameTextBox
            // 
            this.Player4NameTextBox.Enabled = false;
            this.Player4NameTextBox.Location = new System.Drawing.Point(15, 172);
            this.Player4NameTextBox.Name = "Player4NameTextBox";
            this.Player4NameTextBox.Size = new System.Drawing.Size(170, 20);
            this.Player4NameTextBox.TabIndex = 17;
            // 
            // Player3EnabledCheckBox
            // 
            this.Player3EnabledCheckBox.AutoSize = true;
            this.Player3EnabledCheckBox.Checked = true;
            this.Player3EnabledCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Player3EnabledCheckBox.Location = new System.Drawing.Point(261, 125);
            this.Player3EnabledCheckBox.Name = "Player3EnabledCheckBox";
            this.Player3EnabledCheckBox.Size = new System.Drawing.Size(59, 17);
            this.Player3EnabledCheckBox.TabIndex = 20;
            this.Player3EnabledCheckBox.Text = "Enable";
            this.Player3EnabledCheckBox.UseVisualStyleBackColor = true;
            // 
            // Player4EnabledCheckBox
            // 
            this.Player4EnabledCheckBox.AutoSize = true;
            this.Player4EnabledCheckBox.Checked = true;
            this.Player4EnabledCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Player4EnabledCheckBox.Location = new System.Drawing.Point(261, 175);
            this.Player4EnabledCheckBox.Name = "Player4EnabledCheckBox";
            this.Player4EnabledCheckBox.Size = new System.Drawing.Size(59, 17);
            this.Player4EnabledCheckBox.TabIndex = 21;
            this.Player4EnabledCheckBox.Text = "Enable";
            this.Player4EnabledCheckBox.UseVisualStyleBackColor = true;
            // 
            // NewGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 228);
            this.Controls.Add(this.Player4EnabledCheckBox);
            this.Controls.Add(this.Player3EnabledCheckBox);
            this.Controls.Add(this.Player4IsHumanCheckBox);
            this.Controls.Add(this.RememberPlayer4CheckBox);
            this.Controls.Add(this.Player4NameTextBox);
            this.Controls.Add(this.Player3IsHumanCheckBox);
            this.Controls.Add(this.RememberPlayer3CheckBox);
            this.Controls.Add(this.Player3NameTextBox);
            this.Controls.Add(this.Player2IsHumanCheckBox);
            this.Controls.Add(this.RememberPlayer2CheckBox);
            this.Controls.Add(this.Player2NameTextBox);
            this.Controls.Add(this.Player1IsHumanCheckBox);
            this.Controls.Add(this.RememberPlayer1CheckBox);
            this.Controls.Add(this.Player1NameTextBox);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Begin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox RememberPlayer1CheckBox;
        public System.Windows.Forms.TextBox Player1NameTextBox;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button Begin;
        private System.Windows.Forms.CheckBox RememberPlayer2CheckBox;
        public System.Windows.Forms.TextBox Player2NameTextBox;
        private System.Windows.Forms.CheckBox RememberPlayer3CheckBox;
        public System.Windows.Forms.TextBox Player3NameTextBox;
        private System.Windows.Forms.CheckBox RememberPlayer4CheckBox;
        public System.Windows.Forms.TextBox Player4NameTextBox;
        public System.Windows.Forms.CheckBox Player1IsHumanCheckBox;
        public System.Windows.Forms.CheckBox Player2IsHumanCheckBox;
        public System.Windows.Forms.CheckBox Player3IsHumanCheckBox;
        public System.Windows.Forms.CheckBox Player4IsHumanCheckBox;
        public System.Windows.Forms.CheckBox Player3EnabledCheckBox;
        public System.Windows.Forms.CheckBox Player4EnabledCheckBox;
    }
}