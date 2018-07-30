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
        private  Unit unit;
        private  Bullet _blt;

        public Form1()
        {
            InitializeComponent();
            unit = new Unit(this);
            _obj = new Obstacles(this);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D)
            {
                 unit.Right(DIRECTION.RIGHT);
            }

            if (e.KeyCode == Keys.A)
            {
                unit.Left(DIRECTION.LEFT);
            }

            if (e.KeyCode == Keys.W)
            {
                unit.Up(DIRECTION.UP);
            }

            if (e.KeyCode == Keys.S)
            {
                unit.Down(DIRECTION.DOWN);
            }

            if (e.KeyCode == Keys.Space)
            {
                _blt = new Bullet();
                _blt.Shot(unit.player.Left, unit.player.Top, unit.dir);
                Controls.Add(_blt.bullet);
                if (unit.dir == DIRECTION.LEFT)
                {
                    var r = unit.player.Left;
                }
            }

            foreach (var el in _obj._obstacles)
            {
                if ((unit.player.Bounds.IntersectsWith(el.Bounds)))
                {
                    if (unit.dir==DIRECTION.LEFT) unit.player.Left += 10;
                    else
                        unit.player.Left -= 10;
                }
                if ((unit.player.Bounds.IntersectsWith(el.Bounds)))
                {
                    if (unit.dir==DIRECTION.UP) unit.player.Top += 10;
                    else unit.player.Top -= 10;
                }
            }
        }
    }
}
