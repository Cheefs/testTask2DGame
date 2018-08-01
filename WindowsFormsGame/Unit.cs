using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace WindowsFormsGame
{
    class Unit
    {
       protected readonly Image imgRight;
        protected readonly Image imgLeft;
        protected readonly Image imgUp;
        protected readonly Image imgDown;

        public readonly int speed = 10;
        public PictureBox player;
    
        public DIRECTION dir;
        public Form1 form;
        public ProgressBar pb;

        public Unit(Form1 form)
        {
            this.form = form;
   
            imgRight = Image.FromFile("unitRight.png");
            imgLeft = Image.FromFile("unitLeft.png");
            imgUp = Image.FromFile("unitUp.png");
            imgDown = Image.FromFile("unitDown.png");

            Create();
            HealthPoints();
        }

        public virtual void Create()
        {
            player= new PictureBox
            {
                Image = imgRight,
                Left = 50,
                Top = 50,
                SizeMode = PictureBoxSizeMode.AutoSize
            };
            form.Controls.Add(player);
        }

        public virtual void HealthPoints()
        {
            pb = new ProgressBar
            {
                Left = player.Left,
                Top = player.Top - player.Height / 4,
                Width = player.Width,
                Height = 10,
                Value = 100,
                ForeColor = Color.Green
            };
            form.Controls.Add(pb);
        }

        public virtual void Left(DIRECTION dir)
        {
            this.dir = dir;
            player.Left -= speed;
            player.Image = imgLeft;
            if (pb != null)
            {
                pb.Left = player.Left;
                pb.Top = player.Top - player.Height / 4;
            }
        }
        public virtual void Right(DIRECTION dir)
        {
            this.dir = dir;
            player.Left += speed;
            player.Image = imgRight;


            if (pb != null)
            {
                pb.Left = player.Left-30;
                pb.Top = player.Top - player.Height / 4;
            }
            pb.Left = player.Left;
        }
        public virtual void Up(DIRECTION dir)
        {
            this.dir = dir;
            player.Top -= speed;
            player.Image = imgUp;

            if (pb != null)
            {
                pb.Left = player.Left -10;
                pb.Top = player.Top - player.Height /2;
            }
            if (pb != null) pb.Top = player.Top+100;
        }
        public virtual void Down(DIRECTION dir)
        {
            this.dir = dir;
            player.Top += speed;
            player.Image = imgDown;

            if (pb != null)
            {
                pb.Left = player.Left-10;
                pb.Top = player.Top - player.Height/4;
            }
        }

        public virtual void Shot(PictureBox player, DIRECTION dir)
        {
            this.dir = dir;
            form._blt = new Bullet(form);
            if (dir == DIRECTION.LEFT
                /*|| dir == DIRECTION.RIGHT*/) form._blt.Shot(player.Left-20, player.Top - 3 + player.Height / 2, dir);
            if (/*dir == DIRECTION.LEFT*/
               /*||*/ dir == DIRECTION.RIGHT) form._blt.Shot(player.Left+100, player.Top - 3 + player.Height / 2, dir);
            if (dir == DIRECTION.UP
                /*|| dir == DIRECTION.DOWN*/) form._blt.Shot(player.Left - 7 + player.Width / 2, player.Top - 20, dir);
            if (/*dir == DIRECTION.UP*/
               /*||*/ dir == DIRECTION.DOWN) form._blt.Shot(player.Left - 7 + player.Width / 2, player.Top + 100, dir);
        }

        public virtual bool IsHited()
        {
            if (form._blt.bullet.Bounds.IntersectsWith(player.Bounds))
            {
                if (pb.Value > 0)
                {
                    pb.Value -= 10;
                    SystemSounds.Exclamation.Play();
                }
            
                return true;
            }
            //if (form._blt.bullet.Bounds.IntersectsWith(form._cpu.player.Bounds))
            //{
            //    if (form._unit.pb.Value > 0)
            //    {
            //        form._unit.pb.Value -= 10;
            //        SystemSounds.Exclamation.Play();
            //    }
            //    return true;
            //}

            //if (target == "unit")
            //{
            //    if (form._blt.bullet.Bounds.IntersectsWith(player.Bounds) & form._unit.pb.Value > 0)
            //    {
            //        form._unit.pb.Value -= 10;
            //        SystemSounds.Exclamation.Play();
            //        return true;
            //    }

            //}
            //if (target == "cpu")
            //{
            //    if (form._blt.bullet.Bounds.IntersectsWith(form._cpu.player.Bounds) & form._cpu.pb.Value > 0)
            //    {
            //        form._cpu.pb.Value -= 10;
            //        SystemSounds.Exclamation.Play();
            //        return true;
            //    }
            //}
            return false;
        }

        public void InteractWith(PictureBox element, PictureBox intersectElement)
        {
            if (intersectElement == form._obj.obstacle)
            {
                foreach (var el in form._obj._obstacles)
                {
                    if ((element.Bounds.IntersectsWith(el.Bounds)))
                    {
                        if (dir == DIRECTION.LEFT) element.Left += 15;
                        else if (dir == DIRECTION.RIGHT) element.Left -= 15;
                        if (dir == DIRECTION.UP) element.Top += 15;
                        else if (dir == DIRECTION.DOWN) element.Top -= 15;
                    }
                }
            }
            else
            {
                if ((element.Bounds.IntersectsWith(intersectElement.Bounds)))
                {
                    if (dir == DIRECTION.LEFT) element.Left += 15;
                    else if (dir == DIRECTION.RIGHT) element.Left -= 15;
                    if (dir == DIRECTION.UP) element.Top += 15;
                    else if (dir == DIRECTION.DOWN) element.Top -= 15;
                }
            }
        }
    }
}
