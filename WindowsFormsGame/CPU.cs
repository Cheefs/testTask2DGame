using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Drawing;



namespace WindowsFormsGame
{
    
    class CPU : Unit
    {
        Timer tm = new Timer();
        string flag;
        int correctiveCoef = 300;


        public CPU(Form1 form):base(form)
        {
         


            tm.Interval = speed;
            tm.Tick += new EventHandler(Automatics);
            tm.Interval = 60;
            tm.Start();
        }

        public override void Create()
        {
            player = new PictureBox
            {
                Image = imgLeft,
                Left = form.Width / 2,
                Top = form.Height / 2,
                SizeMode = PictureBoxSizeMode.AutoSize
            };
            
            form.Controls.Add(player);
        }

        public void Automatics(object sender, EventArgs e)
        {

            AutoAtack(form._unit.player, player, form._unit.dir);

            if (form._unit.player.Left <= player.Left- correctiveCoef)
            {
                if (Obstacle()) flag = "left";
                else  Left(DIRECTION.LEFT);
            }

            if (form._unit.player.Left >= player.Left + correctiveCoef)
            {
                if (Obstacle()) flag = "right";
                else Right(DIRECTION.RIGHT);
            }

            if (form._unit.player.Top >= player.Top + correctiveCoef)
            {
                if (Obstacle()) flag = "down";
                else Down(DIRECTION.DOWN);
            }
            if (form._unit.player.Top <= player.Top - correctiveCoef)
            {
                if (Obstacle()) flag = "up";
                else Up(DIRECTION.UP);
            }

           
            Find();
            CheckDirection();


            form.label.Text = $"Позиция X игрока: {form._unit.player.Left.ToString()}\n Позиция Y игрока: {form._unit.player.Top.ToString()}" +
                $"\n Позиция X противника: {player.Left.ToString()}\n Позиция Y противника: {player.Top.ToString()} " ;
        }



        public void AutoAtack(PictureBox target, PictureBox cpuPlayer, DIRECTION targetDir)
        {
            if(!(Obstacle()))
            {
                if (target.Left <= cpuPlayer.Left & target.Top < player.Top || target.Left <= cpuPlayer.Left & target.Top < player.Top)
                {
                    Up(DIRECTION.UP);
                    Shot(player, DIRECTION.UP);
                }
                if (target.Left >= cpuPlayer.Left & target.Top > player.Top || target.Left >= cpuPlayer.Left & target.Top > player.Top)
                {
                    Down(DIRECTION.DOWN);
                    Shot(player, DIRECTION.DOWN);
                }
                if (target.Top <= cpuPlayer.Top & target.Left < player.Left || target.Top <= cpuPlayer.Top & target.Left < player.Left)
                {
                    Left(DIRECTION.LEFT);
                    Shot(player, DIRECTION.LEFT);
                }
                if (target.Top >= cpuPlayer.Top & target.Left > player.Left || target.Top >= cpuPlayer.Top & target.Left > player.Left)
                {
                    Right(DIRECTION.RIGHT);
                    Shot(player, DIRECTION.RIGHT);
                }
            }
        }

        public override void Shot(PictureBox player, DIRECTION dir)
        {
            this.player = player;
            this.dir = dir;
            base.Shot(player, dir);
        }


        public void Find()
        {
            if (flag == "left") Up(DIRECTION.UP);
            if (flag == "right") Up(DIRECTION.DOWN);
            if (flag == "down") Right(DIRECTION.RIGHT);
            if (flag == "up") Left(DIRECTION.LEFT);
            flag = null;
        }

        public void CheckDirection()
        {
            if (form._unit.dir == DIRECTION.RIGHT & form._unit.player.Left < player.Left) dir = DIRECTION.LEFT;
            if (form._unit.dir == DIRECTION.UP & form._unit.player.Top < player.Top) dir = DIRECTION.DOWN;
        }

        public bool Obstacle()
        {
            foreach (var el in form._obj._obstacles)
               if (el.Bounds.IntersectsWith(player.Bounds)) return true;
            return false;
        }

    }
}
