    using System;
using System.Diagnostics;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Game
{
    public partial class Main_Menu : Form
    {   
        private Settings settingsForm = new Settings();
        private Server serverForm = new Server();
        private Client clientForm = new Client();
        private Games gamesForm = new Games();


        public Main_Menu()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            Sound.CreateMenuMusic();
            Sound.PlayMenuMusic();

            // child form settings:
            gamesForm.TopLevel = false;
            gamesForm.FormBorderStyle = FormBorderStyle.None;
            Controls.Add(gamesForm);
            gamesForm.BringToFront();

            settingsForm.TopLevel = false;
            settingsForm.FormBorderStyle = FormBorderStyle.None;
            Controls.Add(settingsForm);
            settingsForm.BringToFront();

            serverForm.TopLevel = false;
            serverForm.FormBorderStyle = FormBorderStyle.None;
            Controls.Add(serverForm);
            serverForm.BringToFront();

            clientForm.TopLevel = false;
            clientForm.FormBorderStyle = FormBorderStyle.None;
            Controls.Add(clientForm);
            clientForm.BringToFront();


            //new backgound:
            pictureBox1.Image = Properties.Resources.background;
            pictureBox1.Dock = DockStyle.Fill;
        }


        private void Play_Click(object sender, EventArgs e)
        {
            Sound.RemoveMenuMusic();
            Hide();
            using (Race gameForm = new Race())
            {
                gameForm.ShowDialog();
            }
            Show();
            Sound.CreateMenuMusic();
            Sound.PlayMenuMusic();
            Debug.WriteLine("Main_Menu: race closed");
        }


        private void Settings_Click(object sender, EventArgs e)
        {
            settingsForm.Show();
        }


        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void Main_Menu_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.DrawImage(backgound, 0, 0, this.Size.Width, this.Size.Height);
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            //Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            serverForm.Show();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            clientForm.Show();
        }

        private void btnGames_Click(object sender, EventArgs e)
        {
            gamesForm.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/DaiSukeFudo/Race.git",
                //UseShellExecute = true // Обязательно для .NET Core / .NET 5+
            });
        }
    }
}