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
        public CPU(Form1 form):base(form)
        {
        }
        public override bool IsHited()
        {
            if (form._blt.bullet.Bounds.IntersectsWith(player.Bounds))
            {
                form._unit.pb.Value -= 10;
                return true;
            }
            return false;
        }
        public override void Create()
        {
            player = new PictureBox
            {
               
                Left = form.Width / 2,
                Top = form.Height / 2,
                SizeMode = PictureBoxSizeMode.AutoSize
            };
            Left(DIRECTION.LEFT);
            form.Controls.Add(player);
        }
    }
}
