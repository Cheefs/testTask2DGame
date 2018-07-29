using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsGame
{
    class Unit
    {
        Image img;
        readonly Image imgLeft;
        readonly Image imgUp;
        readonly Image imgDown;
        private readonly int speed = 10;
        public PictureBox player;
        public Unit()
        {
            img = Image.FromFile("unitRight.png");
            imgLeft = Image.FromFile("unitLeft.png");
            imgUp = Image.FromFile("unitUp.png");
            imgDown = Image.FromFile("unitDown.png");
        }

        public virtual void CreatePlayer()
        {
            player= new PictureBox
            {
                Image = img,
                Left = 50,
                Top = 50,
                SizeMode = PictureBoxSizeMode.AutoSize

            };
        }

        public virtual void Left()
        {
            player.Left -= speed;
            player.Image = imgLeft;
        }
        public virtual void Right()
        {
            player.Left += speed;
            player.Image = img;
        }
        public virtual void Up()
        {
            player.Top -= speed;
            player.Image = imgUp;

        }
        public virtual void Down()
        {
            player.Top += speed;
            player.Image = imgDown;
        }
    }
}
