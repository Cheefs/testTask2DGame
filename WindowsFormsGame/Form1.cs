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

            this.KeyDown += KeyIsPress;
            this.KeyUp += FireUp;
           
            
            _obj = new Obstacles(this);
            unit = new Unit(this);
           
        }
 
        private void FireUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                _blt = new Bullet();
                if (unit.dir == DIRECTION.LEFT || unit.dir == DIRECTION.RIGHT) _blt.Shot(unit.player.Left, unit.player.Top - 3 + unit.player.Height / 2, unit.dir);
                if (unit.dir == DIRECTION.UP || unit.dir == DIRECTION.DOWN) _blt.Shot(unit.player.Left - 7 + unit.player.Width / 2, unit.player.Top, unit.dir);
               Controls.Add(_blt.bullet);
            }
        }

        private void KeyIsPress(object sender, KeyEventArgs e)
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
            Interact();
        }

        public void Interact ()
        {
            foreach (var el in _obj._obstacles)
            {
                if ((unit.player.Bounds.IntersectsWith(el.Bounds)))
                {
                    if (unit.dir == DIRECTION.LEFT) unit.player.Left += 15;
                    else
                        unit.player.Left -= 15;
                    
                }
                if ((unit.player.Bounds.IntersectsWith(el.Bounds)))
                {
                    if (unit.dir == DIRECTION.UP) unit.player.Top += 15;
                    else unit.player.Top -= 15;
                } 
            }
           
        }

    }
}
