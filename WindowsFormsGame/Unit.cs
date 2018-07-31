using System.Drawing;
using System.Windows.Forms;

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

        public Unit(Form form)
        {
            imgRight = Image.FromFile("unitRight.png");
            imgLeft = Image.FromFile("unitLeft.png");
            imgUp = Image.FromFile("unitUp.png");
            imgDown = Image.FromFile("unitDown.png");

            CreatePlayer();
            form.Controls.Add(player);
        }

        public virtual void CreatePlayer()
        {
            player= new PictureBox
            {
                Image = imgRight,
                Left = 50,
                Top = 50,
                SizeMode = PictureBoxSizeMode.AutoSize
            };
        }

        public virtual void Left(DIRECTION dir)
        {
            this.dir = dir;
            player.Left -= speed;
            player.Image = imgLeft;
        }
        public virtual void Right(DIRECTION dir)
        {
            this.dir = dir;
            player.Left += speed;
            player.Image = imgRight;
        }
        public virtual void Up(DIRECTION dir)
        {
            this.dir = dir;
            player.Top -= speed;
            player.Image = imgUp;

        }
        public virtual void Down(DIRECTION dir)
        {
            this.dir = dir;
            player.Top += speed;
            player.Image = imgDown;
        }
    }
}
