using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsGame
{
    class Bullet
    {
        public PictureBox bullet;
        //Unit unit = new Unit();
        public Bullet()
        {
        }

        public PictureBox Shot(int posX,int posY, DIRECTION dir)
        {
            return bullet = new PictureBox
            {
                BackColor = Color.Red,
                Left = posX,
                Top = posY,
                Width = 53,
                Height=23

            };
        }
    }
}
