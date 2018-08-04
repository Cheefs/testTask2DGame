using System.Windows.Forms;

namespace WindowsFormsGame
{
    /// <summary>
    /// Главное меню игры
    /// </summary>
    partial class MainMenu : Form
    {
        Form1 form;
        public MainMenu()
        {
            InitializeComponent();

            btnPlay.Click += delegate 
            {
              DialogResult result =  MessageBox.Show("Весь ваш прогресс будет удален, продолжить?", "Новая игра", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    form = new Form1();
                    form.db.ClearDB();
                    form.Show();

                    form.FormClosing += delegate { Visible = true; };
                }     
            };

            btnContinue.Click += delegate
            {

                Visible = false;
                form = new Form1();
                form.Show();
                form.db.Read();
                form.FormClosing += delegate { Visible = true; };
               
            }; 
        }
    }
}
