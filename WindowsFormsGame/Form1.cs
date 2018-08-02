using System.Windows.Forms;

namespace WindowsFormsGame
{
    /// <summary>
    /// Направление движения
    /// </summary>
    enum DIRECTION
    {
        LEFT,
        RIGHT,
        UP,
        DOWN
    };

    /// <summary>
    /// Класс представления игровых елементов
    /// </summary>
    partial class Form1 : Form
    {
        public Obstacles _obj;
        public Unit _unit;
        public Bullet _blt;
        public CPU _cpu;
       public Label label;

        /// <summary>
        /// Инициализация всех игровых обьектов
        /// </summary>
        public Form1()
        {
            label = new Label
            {
                AutoSize = true,
                Left = 780,
                Top = 280
            };


           Controls.Add(label);

            InitializeComponent();

            this.KeyDown += KeyIsPress;
            this.KeyUp += ButtonUp;

            _obj = new Obstacles(this);
            _unit = new Unit(this);           
            _cpu = new CPU(this);

        }
        /// <summary>
        /// Событие отжатия кнопки(как только отпускает пользователь нажатую клавишу)
        /// </summary>
        /// <param name="sender">обьект инициализирующий событие</param>
        /// <param name="e">агрументы события</param>
        private void ButtonUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space) _unit.Shot(_unit.player,_unit.dir);
        }

        /// <summary>
        /// Событие нажатия кнопки( событие происходит непосредственно при нажании клавиши)
        /// </summary>
        /// <param name="sender">обьект инициализирующий событие</param>
        /// <param name="e">агрументы события</param>
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
