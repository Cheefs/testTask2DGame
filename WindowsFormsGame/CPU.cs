using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace WindowsFormsGame
{
    class CPU : Unit
    {
        private Timer tm;

        public CPU(Form form):base(form)
        {

            player.Left = form.Width/2;
            player.Top = form.Height/2;

           // tm.Interval = speed;
           //// tm.Tick += new EventHandler(TimerFrames);
           // tm.Start();
        }

    }
}
