using System;
using System.Windows.Forms;

namespace Game
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }


        private void Exit_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
