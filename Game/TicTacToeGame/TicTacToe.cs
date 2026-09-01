using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Game.TicTacToeGame
{
    public partial class TicTacToe : Form
    {
        public TicTacToe()
        {
            InitializeComponent();
            Random random = new Random();
            int[,] fieldStatus =
            {
                {0, 0, 0},
                {0, 0, 0},
                {0, 0, 0}
            };
            
        }









        private void btnExit_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void TicTacToe_Load(object sender, EventArgs e)
        {

        }
    }
}
