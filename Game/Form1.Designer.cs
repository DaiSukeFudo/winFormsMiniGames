namespace Game
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Phon1 = new System.Windows.Forms.PictureBox();
            this.Car = new System.Windows.Forms.PictureBox();
            this.Phon2 = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.Sop1 = new System.Windows.Forms.PictureBox();
            this.Sop2 = new System.Windows.Forms.PictureBox();
            this.bitoc = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Phon1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Car)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Phon2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sop1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sop2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bitoc)).BeginInit();
            this.SuspendLayout();
            // 
            // Phon1
            // 
            this.Phon1.Image = ((System.Drawing.Image)(resources.GetObject("Phon1.Image")));
            this.Phon1.Location = new System.Drawing.Point(0, 0);
            this.Phon1.Name = "Phon1";
            this.Phon1.Size = new System.Drawing.Size(840, 600);
            this.Phon1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Phon1.TabIndex = 0;
            this.Phon1.TabStop = false;
            // 
            // Car
            // 
            this.Car.BackColor = System.Drawing.Color.Transparent;
            this.Car.Image = ((System.Drawing.Image)(resources.GetObject("Car.Image")));
            this.Car.Location = new System.Drawing.Point(442, 407);
            this.Car.Name = "Car";
            this.Car.Size = new System.Drawing.Size(81, 155);
            this.Car.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Car.TabIndex = 1;
            this.Car.TabStop = false;
            // 
            // Phon2
            // 
            this.Phon2.Image = ((System.Drawing.Image)(resources.GetObject("Phon2.Image")));
            this.Phon2.Location = new System.Drawing.Point(0, -600);
            this.Phon2.Name = "Phon2";
            this.Phon2.Size = new System.Drawing.Size(840, 600);
            this.Phon2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Phon2.TabIndex = 2;
            this.Phon2.TabStop = false;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 15;
            this.timer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Sop1
            // 
            this.Sop1.BackColor = System.Drawing.Color.Transparent;
            this.Sop1.Image = ((System.Drawing.Image)(resources.GetObject("Sop1.Image")));
            this.Sop1.Location = new System.Drawing.Point(188, -200);
            this.Sop1.Name = "Sop1";
            this.Sop1.Size = new System.Drawing.Size(81, 155);
            this.Sop1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Sop1.TabIndex = 3;
            this.Sop1.TabStop = false;
            // 
            // Sop2
            // 
            this.Sop2.BackColor = System.Drawing.Color.Transparent;
            this.Sop2.Image = ((System.Drawing.Image)(resources.GetObject("Sop2.Image")));
            this.Sop2.Location = new System.Drawing.Point(575, -400);
            this.Sop2.Name = "Sop2";
            this.Sop2.Size = new System.Drawing.Size(81, 155);
            this.Sop2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Sop2.TabIndex = 4;
            this.Sop2.TabStop = false;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.bitoc);
            this.Controls.Add(this.Sop2);
            this.Controls.Add(this.Sop1);
            this.Controls.Add(this.Car);
            this.Controls.Add(this.Phon1);
            this.Controls.Add(this.Phon2);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp_1);
            ((System.ComponentModel.ISupportInitialize)(this.Phon1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Car)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Phon2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sop1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sop2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bitoc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Phon1;
        private System.Windows.Forms.PictureBox Car;
        private System.Windows.Forms.PictureBox Phon2;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.PictureBox Sop1;
        private System.Windows.Forms.PictureBox Sop2;
        private System.Windows.Forms.PictureBox bitoc;
    }
}

