using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsGame
{
    class Bullet
    {
        public PictureBox bullet;
        private readonly int speed = 30;

        public DIRECTION dir;
        int dx = 5, dy = 5;

        int TEMPX;
        int TEMPY;

        Timer timer = new Timer();
        Form form;

        Obstacles _obj;

        public Bullet(Form form)
        {
            this.form = form;

            timer.Interval = speed;
            timer.Tick += new EventHandler(TimerFrames);
            timer.Start();

            _obj = new Obstacles(form);
        }

        public void Shot(int posX, int posY, DIRECTION dir)
        {
            this.dir = dir;
            bullet = new PictureBox
            {
                BackColor = Color.Red,
                Left = posX,
                Top = posY,
                Width = 10,
                Height = 10
            };
            form.Controls.Add(bullet);
        }

        public bool CheckAttack(PictureBox element, PictureBox target)
        {
            if(target==_obj.obstacle)
            {
                foreach (var el in _obj._obstacles)
                {
                    if ((element.Bounds.IntersectsWith(el.Bounds)))
                    {
                        TEMPX = bullet.Left;
                        TEMPY = bullet.Top;
                        return true;
                    }
                }
            }
            else
            {


                return true;
            }
         
            return false;
        }

        public void TimerFrames(Object sender, EventArgs e)
        {
            CheckAttack(bullet,_obj.obstacle);
            if (dir == DIRECTION.LEFT)
            {
                if (!(CheckAttack(bullet, _obj.obstacle))) bullet.Left -= speed;
                else if (CheckAttack(bullet, _obj.obstacle))
                {
                    Hit(TEMPX + 10, TEMPY, DIRECTION.RIGHT);
                    for (int i = 0; i < 5; i++)
                    {
                        dx += i;
                        dy += i;
                        bullet.Left += dx;
                        bullet.Top -= dy;
                    }
                }
                else
                {

                }
            }

            if (dir == DIRECTION.RIGHT)
            {
                if (!(CheckAttack(bullet, _obj.obstacle))) bullet.Left += speed;
                else if (CheckAttack(bullet, _obj.obstacle))
                {
                    Hit(TEMPX - 10, TEMPY, DIRECTION.LEFT);
                    for (int i = 0; i < 5; i++)
                    {
                        dx += i;
                        dy += i;
                        bullet.Left -= dx - 1;
                        bullet.Top -= dy;
                    }
                }
            }

            if (dir == DIRECTION.UP)
            {
                if (!(CheckAttack(bullet, _obj.obstacle))) bullet.Top -= speed;
                else if (CheckAttack(bullet, _obj.obstacle))
                {
                    Hit(TEMPX, TEMPY + 10, DIRECTION.DOWN);
                    for (int i = 0; i < 2; i++)
                    {
                        dx += i;
                        dy += i;
                        bullet.Left += dx;
                        bullet.Top += dy;
                    }
                }
                else
                {

                }
            }


            if (dir == DIRECTION.DOWN)
            {
                if (!(CheckAttack(bullet, _obj.obstacle))) bullet.Top += speed;
                else if (CheckAttack(bullet, _obj.obstacle))
                {
                    Hit(TEMPX, TEMPY + 10, DIRECTION.UP);
                    for (int i = 0; i < 5; i++)
                    {
                        dx += i;
                        dy += i;
                        bullet.Left += dx;
                        bullet.Top -= dy;
                    }
                }
                else
                {

                }
            }
        }


        public void Hit(int x, int y, DIRECTION dir)
        {
            bullet.Dispose();
            timer.Dispose();

            Shot(x, y, dir);
            timer.Interval = speed;

            timer.Tick += new EventHandler(TimerFrames);
            timer.Start();

            bullet.BackColor = Color.DarkBlue;
        }

    }
}
