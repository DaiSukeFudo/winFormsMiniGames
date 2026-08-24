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


        private void OpenFormInPanel(Form childForm)
        {
            Controls.Clear(); // Удаляем старую форму
            childForm.TopLevel = false;  // Превращаем форму в «контрол»
            childForm.FormBorderStyle = FormBorderStyle.None; // Убираем рамки
            childForm.Dock = DockStyle.Fill; // Заполняем всю панель
            Controls.Add(childForm);
            childForm.Show();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //System.Windows.Forms.Application.Restart();
            OpenFormInPanel(new Main_Menu());
        }
    }
}
