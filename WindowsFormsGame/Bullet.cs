using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsGame
{
    class Bullet
    {
        PictureBox _bullet;
        public Bullet()
        {

        }

        public void Shot()
        {
            _bullet = new PictureBox
            {
                BackColor = Color.Red,
                Left = 50,
                Top = 50,
                SizeMode = PictureBoxSizeMode.AutoSize

            };
        }
    }
}
