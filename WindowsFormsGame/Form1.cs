using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsGame
{
    public partial class Form1 : Form
    {
        Obstacles o = new Obstacles();
        Unit unit = new Unit();

      
        //private bool horizontal;
        //private bool vertical;
        bool flagL = false;
        bool flagD = false;
        public Form1()
        {
            InitializeComponent();
            foreach (var el in o._obstacles)
            {
                Controls.Add(el);
            }
            unit.CreatePlayer();
            Controls.Add(unit.player);

        }
        //private bool Horizontal()
        //{
        //    horizontal = true;
        //    vertical = false;
        //    return true;
        //}
        //private bool Vertical()
        //{
        //    horizontal = false;
        //    vertical = true;
        //    return true;
        //}

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //pictureBox1.Image = Image.FromFile("unit.png");
            //pictureBox1.SizeMode=PictureBoxSizeMode.AutoSize;

            if (e.KeyCode == Keys.D)
            {
                //Horizontal();
                unit.Right();
                flagL = false;
                //unit.player.Left += speed;
              //  pictureBox1.Left += speed;
            }

            if (e.KeyCode == Keys.A)
            {
                //Horizontal();
                flagL = true;
                unit.Left();
                //unit.player.Left -= speed;
                //pictureBox1.Left -= speed;
            }

            if (e.KeyCode == Keys.W)
            {
                //Vertical();
                flagD = true;
                unit.Up();
                //unit.player.Top -= speed;
                //pictureBox1.Top -= speed;
            }

            if (e.KeyCode == Keys.S)
            {
               
                //Vertical();
                flagD = false;
                unit.Down();
               // unit.player.Top += speed;
                //pictureBox1.Top += speed;
            }

            foreach (var el in o._obstacles)
            {
                if ((unit.player.Bounds.IntersectsWith(el.Bounds)) /*& Horizontal()*/)
                {
                    if (flagL == true) unit.player.Left += 10; //pictureBox1.Left += 10;
                    else
                        unit.player.Left -= 10;
                    //pictureBox1.Left -= 10;
                }
                if ((unit.player.Bounds.IntersectsWith(el.Bounds)) /*& Vertical()*/)
                {
                    if (flagD == true) unit.player.Top += 10; // pictureBox1.Top += 10;
                    else unit.player.Top -= 10; // pictureBox1.Top -= 10;

                }

            }
        }
    }
}
