using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsGame
{
    class Bullet
    {
        public PictureBox bullet;
        private readonly int speed=30;
        private DIRECTION dir;
        //private int _width;
        //private int _height;
        Timer timer = new Timer();
        public Bullet()
        {
            timer.Interval = speed; // set the timer interval to speed
            timer.Tick += new EventHandler(TimerFrames); // assignment the timer with an event
            timer.Start(); // start the timer
        }

        public PictureBox Shot(int posX,int posY, DIRECTION dir)
        {
            this.dir = dir;

            return bullet = new PictureBox
            {
                BackColor = Color.Red,
                Left = posX,
                Top = posY,

                Width = 10,
                Height=10

            };
        }

        public void TimerFrames (Object sender, EventArgs e)
        {
            if(dir==DIRECTION.LEFT) bullet.Left -= speed;
            //bullet.BringToFront();
            if (dir == DIRECTION.RIGHT) bullet.Left += speed;
            if (dir == DIRECTION.UP) bullet.Top -= speed;

            if (dir == DIRECTION.DOWN) bullet.Top += speed;


        }
    }
}
