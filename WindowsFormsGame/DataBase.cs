using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace WindowsFormsGame
{
    class DataBase
    {
        private IAccess access;
        public int [] points;

   
        private readonly string path = "points.dat";

        public DataBase( IAccess access)
        {
            this.access = access;
        }
        public void Write()
        {
            points= new int[] { access.Unit.points, access.Cpu.points };
            //File.WriteAllLines(path, points);
        }

        public int Read()
        {
           string [] tmp = File.ReadAllLines(path);

            points[0] = Convert.ToInt32(tmp[0]);
            points[1] = Convert.ToInt32(tmp[1]);

            return points [2];
        }

    }
}
