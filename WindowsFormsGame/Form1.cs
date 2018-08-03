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
    partial class Form1 : Form, IAccess
    {
        #region IAccess
        public Obstacles Obj { get; set; }
        public Unit Unit { get; set; }
        public Bullet Blt { get; set; }
        public CPU Cpu { get; set; }
        public Label Pos { get; set; }
        public Label Points { get; set; }
        public DataBase db { get; set; }

        #endregion



        /// <summary>
        /// Инициализация всех игровых обьектов
        /// </summary>
        public Form1()
        { 
            InitializeComponent();
           
            this.KeyDown += KeyIsPress;
            this.KeyUp += ButtonUp;


            Obj = new Obstacles(this);
            Unit = new Unit(this, this);
            Cpu = new CPU(this, this);
            db = new DataBase(this);

            UI();
            FormClosing += delegate { db?.Write(); };
          
        }
        /// <summary>
        /// Событие отжатия кнопки(как только отпускает пользователь нажатую клавишу)
        /// </summary>
        /// <param name="sender">обьект инициализирующий событие</param>
        /// <param name="e">агрументы события</param>
        private void ButtonUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space) Unit.Shot(Unit.player,Unit.dir);
        }

        /// <summary>
        /// Событие нажатия кнопки( событие происходит непосредственно при нажании клавиши)
        /// </summary>
        /// <param name="sender">обьект инициализирующий событие</param>
        /// <param name="e">агрументы события</param>
        private void KeyIsPress(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right) Unit.Right(DIRECTION.RIGHT);
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left) Unit.Left(DIRECTION.LEFT);
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up) Unit.Up(DIRECTION.UP);
            if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down) Unit.Down(DIRECTION.DOWN);
       
           Unit.InteractWith(Unit.player,Obj.obstacle);
           Unit.InteractWith(Unit.player, Cpu.player);
        }
        /// <summary>
        /// Элементы игрового интерфейса
        /// </summary>
        private void UI()
        {
            Pos = new Label{ AutoSize = true, Left = 780, Top = 280};
            //Points = new Label {Text=$"Player: {db?.points[0]}\t CPU: {db?.points[1]}", AutoSize = true, Left = 780,Top = 50};
            Controls.Add(Points);
            Controls.Add(Pos);
           
        }
    }
}
