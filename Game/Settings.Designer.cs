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
            this.button1 = new System.Windows.Forms.Button();
            this.soundMixer = new System.Windows.Forms.TrackBar();
            this.fps = new System.Windows.Forms.ComboBox();
            this.cbMainMenuMusic = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.soundMixer)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button1.BackColor = System.Drawing.Color.RosyBrown;
            this.button1.Location = new System.Drawing.Point(697, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "exit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Exit_Click);
            // 
            // soundMixer
            // 
            this.soundMixer.Location = new System.Drawing.Point(300, 200);
            this.soundMixer.Name = "soundMixer";
            this.soundMixer.Size = new System.Drawing.Size(107, 45);
            this.soundMixer.TabIndex = 1;
            // 
            // fps
            // 
            this.fps.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fps.FormattingEnabled = true;
            this.fps.Location = new System.Drawing.Point(300, 100);
            this.fps.Name = "fps";
            this.fps.Size = new System.Drawing.Size(107, 21);
            this.fps.TabIndex = 3;
            // 
            // cbMainMenuMusic
            // 
            this.cbMainMenuMusic.AutoSize = true;
            this.cbMainMenuMusic.Checked = true;
            this.cbMainMenuMusic.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbMainMenuMusic.Location = new System.Drawing.Point(300, 150);
            this.cbMainMenuMusic.Name = "cbMainMenuMusic";
            this.cbMainMenuMusic.Size = new System.Drawing.Size(107, 17);
            this.cbMainMenuMusic.TabIndex = 4;
            this.cbMainMenuMusic.Text = "main menu music";
            this.cbMainMenuMusic.UseVisualStyleBackColor = true;
            this.cbMainMenuMusic.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.cbMainMenuMusic);
            this.Controls.Add(this.fps);
            this.Controls.Add(this.soundMixer);
            this.Controls.Add(this.button1);
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.soundMixer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TrackBar soundMixer;
        private System.Windows.Forms.ComboBox fps;
        private System.Windows.Forms.CheckBox cbMainMenuMusic;
    }
}