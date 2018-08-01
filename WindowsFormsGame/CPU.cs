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
        public CPU(Form1 form):base(form)
        {

            tm.Interval = speed;
            tm.Tick += new EventHandler(Automatics);
            tm.Interval = 60;
            tm.Start();
        }


        public override bool IsHited()
        {

            if (form._blt.bullet.Bounds.IntersectsWith(form._unit.player.Bounds) & form._unit.pb.Value > 0)
            {
                form._unit.pb.Value -= 10;
                SystemSounds.Exclamation.Play();
                return true;
            }



            return false;
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

            if ((form._unit.player.Left < player.Left & (!(Obstacle())))) Shot(player, form._unit.dir);
            if ((form._unit.player.Top < player.Top & (!(Obstacle())))) Shot(player, form._unit.dir);
            if (form._unit.player.Left < player.Left+500 & (!(Obstacle())) )
                Left(DIRECTION.LEFT);
            if (form._unit.player.Left > player.Left-500 & (!(Obstacle())) ) Right(DIRECTION.RIGHT);
          
            if (form._unit.player.Top > player.Top+500 & (!(Obstacle())) ) Down(DIRECTION.DOWN);
            if (form._unit.player.Top < player.Top-500 & (!(Obstacle())) ) Up(DIRECTION.UP);

            if (Obstacle()) Right(DIRECTION.RIGHT);
            if (Obstacle()) Left(DIRECTION.LEFT);
         
           
            if (Obstacle()) Down(DIRECTION.DOWN);
            if (Obstacle()) Up(DIRECTION.UP);



            if (/*form._unit.player.Left < player.Left ||*/ form._unit.player.Top < player.Top)
               
            {
                
               // Up(DIRECTION.UP);
               
                //Left(DIRECTION.LEFT);
                //
               
               // Shot(player,dir);
            }

            //else //Up(DIRECTION.UP);
        }

        public override void Shot(PictureBox player, DIRECTION dir)
        {
            this.player = player;
            this.dir = dir;
            base.Shot(player, dir);
        }




        public bool Obstacle()
        {
            foreach (var el in form._obj._obstacles)
               if (el.Bounds.IntersectsWith(player.Bounds)) return true;
            return false;
        }

    }
}
