namespace Scrabble
{
    partial class Register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            this.RegLabel = new System.Windows.Forms.Label();
            this.RegCode = new System.Windows.Forms.TextBox();
            this.RigisterButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // RegLabel
            // 
            this.RegLabel.AutoSize = true;
            this.RegLabel.Location = new System.Drawing.Point(12, 16);
            this.RegLabel.Name = "RegLabel";
            this.RegLabel.Size = new System.Drawing.Size(119, 13);
            this.RegLabel.TabIndex = 0;
            this.RegLabel.Text = "Enter Registration Code";
            // 
            // RegCode
            // 
            this.RegCode.Location = new System.Drawing.Point(137, 16);
            this.RegCode.Name = "RegCode";
            this.RegCode.Size = new System.Drawing.Size(385, 20);
            this.RegCode.TabIndex = 1;
            // 
            // RigisterButton
            // 
            this.RigisterButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.RigisterButton.Location = new System.Drawing.Point(366, 53);
            this.RigisterButton.Name = "RigisterButton";
            this.RigisterButton.Size = new System.Drawing.Size(75, 23);
            this.RigisterButton.TabIndex = 2;
            this.RigisterButton.Text = "Register";
            this.RigisterButton.UseVisualStyleBackColor = true;
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(447, 53);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 3;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(12, 53);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(306, 13);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://badkiddevelopment.blogspot.com/p/scrabble-nights.html";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1LinkClicked);
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 88);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.RigisterButton);
            this.Controls.Add(this.RegCode);
            this.Controls.Add(this.RegLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Register";
            this.Text = "Register";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label RegLabel;
        private System.Windows.Forms.Button RigisterButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.LinkLabel linkLabel1;
        public System.Windows.Forms.TextBox RegCode;
    }
}