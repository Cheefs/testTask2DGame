using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace WindowsFormsGame
{
    class Unit
    {
        private readonly Image imgRight;
        private readonly Image imgLeft;
        private readonly Image imgUp;
        private readonly Image imgDown;

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
            pbs();
        }
        public  virtual void pbs ()
        {
            pb = new ProgressBar
            {
                Left = player.Left,
                Top=player.Top-player.Height/4,
                Width=player.Width,
                Height=10,
                Value=100,
                ForeColor=Color.Green
            };
            form.Controls.Add(pb);     
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

        public virtual bool IsHited()
        {
            if (form._blt.bullet.Bounds.IntersectsWith(form._cpu.player.Bounds))
            {
                if (form._cpu.pb.Value > 0)
                {
                    form._cpu.pb.Value -= 10;
                    SystemSounds.Exclamation.Play();
                }
                else
                {
                    Application.Restart();
                    MessageBox.Show("asd");
                }
                 
                return true;
            }
            return false;
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
    }
}
