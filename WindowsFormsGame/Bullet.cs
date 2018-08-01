﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsGame
{
    class Bullet
    {
        public  PictureBox bullet;
        private readonly int speed = 30;
        public  DIRECTION dir;
        private int dx = 5, dy = 5;

        private int tmpX;
        private  int tmpY;

        Timer timer = new Timer();
        Form1 form;

        public Bullet(Form1 form)
        {
            this.form = form;

            timer.Interval = speed;
            timer.Tick += new EventHandler(TimerFrames);
            timer.Start();
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

        private bool CheckAttack(PictureBox element, PictureBox target)
        {
            if(target==form._obj.obstacle)
            {
                foreach (var el in form._obj._obstacles)
                {
                    if ((element.Bounds.IntersectsWith(el.Bounds)))
                    {
                        tmpX = bullet.Left;
                        tmpY = bullet.Top;
                        return true;
                    }
                }
            }
            return false;
        }

       private void TimerFrames(Object sender, EventArgs e)
        {
            CheckAttack(bullet,form._obj.obstacle);
            if (dir == DIRECTION.LEFT)
            {
                if (!(CheckAttack(bullet, form._obj.obstacle)))
                {
                    form._unit.IsHited();
                    bullet.Left -= speed;
                }
                else if (CheckAttack(bullet, form._obj.obstacle))
                {
                    Hit(tmpX + 10, tmpY, DIRECTION.RIGHT);
                    for (int i = 0; i < 5; i++)
                    {
                        dx += i;
                        dy += i;
                        bullet.Left += dx;
                        bullet.Top -= dy;
                    }
                }
            }

            if (dir == DIRECTION.RIGHT)
            {
                if (!(CheckAttack(bullet, form._obj.obstacle)))
                {
                    form._unit.IsHited();
                    bullet.Left += speed;
                }
                else if (CheckAttack(bullet, form._obj.obstacle))
                {
                    Hit(tmpX - 10, tmpY, DIRECTION.LEFT);
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
                if (!(CheckAttack(bullet, form._obj.obstacle)))
                {
                    form._unit.IsHited();
                    bullet.Top -= speed;
                }
                else if (CheckAttack(bullet, form._obj.obstacle))
                {
                    Hit(tmpX, tmpY + 10, DIRECTION.DOWN);
                    for (int i = 0; i < 2; i++)
                    {
                        dx += i;
                        dy += i;
                        bullet.Left += dx;
                        bullet.Top += dy;
                    }
                }
            }

            if (dir == DIRECTION.DOWN)
            {
                if (!(CheckAttack(bullet, form._obj.obstacle)))
                {
                    form._unit.IsHited();
                    bullet.Top += speed;
                } 
                else if (CheckAttack(bullet, form._obj.obstacle))
                {
                    Hit(tmpX, tmpY + 10, DIRECTION.UP);
                    for (int i = 0; i < 5; i++)
                    {
                        dx += i;
                        dy += i;
                        bullet.Left += dx;
                        bullet.Top -= dy;
                    }
                }
            }
            if (  bullet.Left<0 
                || bullet.Left>form.Width 
                || bullet.Top < 0 
                || bullet.Top > form.Height 
                || (form._unit.IsHited()))
            {
                Clear();
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


        private void Clear()
        {
            bullet.Dispose();
            timer.Dispose();
        }
    }
}
