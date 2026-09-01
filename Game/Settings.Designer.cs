namespace Game
{
    partial class Settings
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
            this.btnExit = new System.Windows.Forms.Button();
            this.cbMainMenuMusic = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.RosyBrown;
            this.btnExit.Location = new System.Drawing.Point(720, 10);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(50, 25);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "close";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // cbMainMenuMusic
            // 
            this.cbMainMenuMusic.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbMainMenuMusic.AutoSize = true;
            this.cbMainMenuMusic.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbMainMenuMusic.Checked = true;
            this.cbMainMenuMusic.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbMainMenuMusic.Location = new System.Drawing.Point(25, 75);
            this.cbMainMenuMusic.Name = "cbMainMenuMusic";
            this.cbMainMenuMusic.Size = new System.Drawing.Size(107, 17);
            this.cbMainMenuMusic.TabIndex = 4;
            this.cbMainMenuMusic.Text = "main menu music";
            this.cbMainMenuMusic.UseVisualStyleBackColor = false;
            this.cbMainMenuMusic.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Book Antiqua", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(25, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 35);
            this.label1.TabIndex = 6;
            this.label1.Text = "SETTINGS:";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.BackgroundImage = global::Game.Properties.Resources.cross;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbMainMenuMusic);
            this.Controls.Add(this.btnExit);
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.CheckBox cbMainMenuMusic;
        private System.Windows.Forms.Label label1;
    }
}