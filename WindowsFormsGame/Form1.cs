using System.Windows.Forms;

namespace WindowsFormsGame
{
    enum DIRECTION
    {
        LEFT,
        RIGHT,
        UP,
        DOWN
    };

    public partial class Form1 : Form
    {
        private  Obstacles _obj;
        private  Unit _unit;
        private Bullet _blt;
        private CPU _cpu;
    

        public Form1()
        {
            InitializeComponent();

            this.KeyDown += KeyIsPress;
            this.KeyUp += FireUp;
           
            
            _obj = new Obstacles(this);
            _unit = new Unit(this);
            _cpu = new CPU(this);
           
        }
 
        private void FireUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                _blt = new Bullet(this);
                if (_unit.dir == DIRECTION.LEFT || _unit.dir == DIRECTION.RIGHT) _blt.Shot(_unit.player.Left, _unit.player.Top - 3 + _unit.player.Height / 2, _unit.dir);
                if (_unit.dir == DIRECTION.UP || _unit.dir == DIRECTION.DOWN) _blt.Shot(_unit.player.Left - 7 + _unit.player.Width / 2, _unit.player.Top, _unit.dir); 
            }
        }

        private void KeyIsPress(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.D) _unit.Right(DIRECTION.RIGHT);
            if (e.KeyCode == Keys.A) _unit.Left(DIRECTION.LEFT);
            if (e.KeyCode == Keys.W) _unit.Up(DIRECTION.UP);
            if (e.KeyCode == Keys.S) _unit.Down(DIRECTION.DOWN);
       
            InteractWith(_unit.player,_obj.obstacle);
            InteractWith(_unit.player, _cpu.player);
        }

        /// <summary>
        /// Перенести в клас игрок
        /// 
        /// </summary>
        /// <param name="element"></param>
        public void InteractWith(PictureBox element, PictureBox intersectElement)
        {
            if(intersectElement==_obj.obstacle)
            {
                foreach (var el in _obj._obstacles)
                {
                    if ((element.Bounds.IntersectsWith(el.Bounds)))
                    {
                        if (_unit.dir == DIRECTION.LEFT) element.Left += 15;
                        else if (_unit.dir == DIRECTION.RIGHT) element.Left -= 15;
                        if (_unit.dir == DIRECTION.UP) element.Top += 15;
                        else if (_unit.dir == DIRECTION.DOWN) element.Top -= 15;
                    }
                }
            }
            else
            {
                if ((element.Bounds.IntersectsWith(intersectElement.Bounds)))
                {
                    if (_unit.dir == DIRECTION.LEFT) element.Left += 15;
                    else if (_unit.dir == DIRECTION.RIGHT) element.Left -= 15;
                    if (_unit.dir == DIRECTION.UP) element.Top += 15;
                    else if (_unit.dir == DIRECTION.DOWN) element.Top -= 15;
                }
            }
           
        }
     
    }
}
