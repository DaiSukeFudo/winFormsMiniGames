namespace Game
{
    partial class Race
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Player Player;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Dispose images held by PictureBox controls to release GDI objects
                try
                {
                    if (this.Road2 != null && this.Road2.Image != null)
                    {
                        this.Road2.Image.Dispose();
                        this.Road2.Image = null;
                    }
                    if (this.Enemy1 != null && this.Enemy1.Image != null)
                    {
                        this.Enemy1.Image.Dispose();
                        this.Enemy1.Image = null;
                    }
                    if (this.Enemy2 != null && this.Enemy2.Image != null)
                    {
                        this.Enemy2.Image.Dispose();
                        this.Enemy2.Image = null;
                    }
                    if (this.bitoc != null && this.bitoc.Image != null)
                    {
                        this.bitoc.Image.Dispose();
                        this.bitoc.Image = null;
                    }
                }
                catch
                {
                    // ignore disposal errors
                }

                if (components != null)
                {
                    components.Dispose();
                }
                // Dispose labels created in Race (they are not added to Controls in current code)
                try
                {
                    if (this.scoreLabel != null)
                    {
                        this.scoreLabel.Dispose();
                        this.scoreLabel = null;
                    }
                    if (this.bitcoinLabel != null)
                    {
                        this.bitcoinLabel.Dispose();
                        this.bitcoinLabel = null;
                    }
                }
                catch
                {
                    // ignore
                }

                // Ensure Player static timers are stopped
                try
                {
                    player.Reset();
                }
                catch
                {
                }
            }

            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Race));
            this.Road2 = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.Enemy1 = new System.Windows.Forms.PictureBox();
            this.Enemy2 = new System.Windows.Forms.PictureBox();
            this.bitoc = new System.Windows.Forms.PictureBox();
            this.exit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Road2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Enemy1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Enemy2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bitoc)).BeginInit();
            this.SuspendLayout();
            // 
            // Road2
            // 
            this.Road2.Image = ((System.Drawing.Image)(resources.GetObject("Road2.Image")));
            this.Road2.Location = new System.Drawing.Point(0, -600);
            this.Road2.Name = "Road2";
            this.Road2.Size = new System.Drawing.Size(840, 600);
            this.Road2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Road2.TabIndex = 2;
            this.Road2.TabStop = false;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 25;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Enemy1
            // 
            this.Enemy1.BackColor = System.Drawing.Color.Transparent;
            this.Enemy1.Image = ((System.Drawing.Image)(resources.GetObject("Enemy1.Image")));
            this.Enemy1.Location = new System.Drawing.Point(188, -200);
            this.Enemy1.Name = "Enemy1";
            this.Enemy1.Size = new System.Drawing.Size(81, 155);
            this.Enemy1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Enemy1.TabIndex = 3;
            this.Enemy1.TabStop = false;
            // 
            // Enemy2
            // 
            this.Enemy2.BackColor = System.Drawing.Color.Transparent;
            this.Enemy2.Image = ((System.Drawing.Image)(resources.GetObject("Enemy2.Image")));
            this.Enemy2.Location = new System.Drawing.Point(575, -400);
            this.Enemy2.Name = "Enemy2";
            this.Enemy2.Size = new System.Drawing.Size(81, 155);
            this.Enemy2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Enemy2.TabIndex = 4;
            this.Enemy2.TabStop = false;
            // 
            // bitoc
            // 
            this.bitoc.BackColor = System.Drawing.Color.Transparent;
            this.bitoc.Image = ((System.Drawing.Image)(resources.GetObject("bitoc.Image")));
            this.bitoc.Location = new System.Drawing.Point(445, -304);
            this.bitoc.Name = "bitoc";
            this.bitoc.Size = new System.Drawing.Size(59, 55);
            this.bitoc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bitoc.TabIndex = 5;
            this.bitoc.TabStop = false;
            // 
            // exit
            // 
            this.exit.BackColor = System.Drawing.Color.RosyBrown;
            this.exit.Location = new System.Drawing.Point(703, 12);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(69, 22);
            this.exit.TabIndex = 6;
            this.exit.Text = "exit";
            this.exit.UseVisualStyleBackColor = false;
            this.exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Race
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.bitoc);
            this.Controls.Add(this.Enemy2);
            this.Controls.Add(this.Enemy1);
            this.Controls.Add(this.Road2);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Race";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Race";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RaceFormKeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.RaceFormKeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.Road2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Enemy1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Enemy2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bitoc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox Road2;
        private System.Windows.Forms.PictureBox Enemy1;
        private System.Windows.Forms.PictureBox Enemy2;
        private System.Windows.Forms.PictureBox bitoc;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button exit;
    }
}

