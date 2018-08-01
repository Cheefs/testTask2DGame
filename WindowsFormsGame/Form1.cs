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

    partial class Form1 : Form
    {
        public Obstacles _obj;
        public Unit _unit;
        public Bullet _blt;
        public CPU _cpu;

        public Form1()
        {
            InitializeComponent();

            this.KeyDown += KeyIsPress;
            this.KeyUp += ButtonUp;

            _obj = new Obstacles(this);
            _unit = new Unit(this);           
            _cpu = new CPU(this);
        }
 
        private void ButtonUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space) _unit.Shot(_unit.player,_unit.dir);
        }

        private void KeyIsPress(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.D) _unit.Right(DIRECTION.RIGHT);
            if (e.KeyCode == Keys.A) _unit.Left(DIRECTION.LEFT);
            if (e.KeyCode == Keys.W) _unit.Up(DIRECTION.UP);
            if (e.KeyCode == Keys.S) _unit.Down(DIRECTION.DOWN);
       
           _unit.InteractWith(_unit.player,_obj.obstacle);
           _unit.InteractWith(_unit.player, _cpu.player);
        }
    }
}
