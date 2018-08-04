using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsGame
{
    /// <summary>
    /// Класс, логики поведения игрового персонажа
    /// </summary>
    class Unit
    {
        #region Resourses
        protected readonly Image imgRight;
        protected readonly Image imgLeft;
        protected readonly Image imgUp;
        protected readonly Image imgDown;
        #endregion

        private IAccess access;
        public readonly int speed = 10;
        public PictureBox player;
        public int points = 0; 
        public DIRECTION dir;
        public Form1 form;
        public ProgressBar pb;

        public Unit(Form1 form, IAccess access)
        {
            this.form = form;
            this.access = access;

        #region Resourses
            imgRight = Image.FromFile("unitRight.png");
            imgLeft = Image.FromFile("unitLeft.png");
            imgUp = Image.FromFile("unitUp.png");
            imgDown = Image.FromFile("unitDown.png");
            #endregion

            Create();
            HealthPoints();
        }
        /// <summary>
        /// Метод создания персонажа
        /// </summary>
        public virtual void Create()
        {
            player= new PictureBox
            {
                Image = imgLeft,
                Left = 50,
                Top = 50,
                SizeMode = PictureBoxSizeMode.AutoSize
            };
            form.Controls.Add(player);
        }
        /// <summary>
        /// Метод добавления шкалы здоровья
        /// </summary>
        public virtual void HealthPoints()
        {
            pb = new ProgressBar
            {
                Left = player.Left,
                Top = player.Top - player.Height / 4,
                Width = player.Width,
                Height = 10,
                Value = 100,
                ForeColor = Color.Green
            };
            form.Controls.Add(pb);
        }
        /// <summary>
        /// Перемещение игрока в лево
        /// </summary>
        /// <param name="dir"> направление</param>
        public virtual void Left(DIRECTION dir)
        {
            this.dir = dir;
            player.Left -= speed;
            player.Image = imgLeft;

            if (pb != null)
            {
                pb.Left = player.Left;
                pb.Top = player.Top - player.Height / 4;
            }
        }
        /// <summary>
        /// Перемещение игрока в право
        /// </summary>
        /// <param name="dir"> направление</param>
        public virtual void Right(DIRECTION dir)
        {
            this.dir = dir;
            player.Left += speed;
            player.Image = imgRight;


            if (pb != null)
            {
                pb.Left = player.Left;
                pb.Top = player.Top - player.Height / 4;
            }
        }
        /// <summary>
        /// Перемещение игрока в верх
        /// </summary>
        /// <param name="dir"> направление</param>
        public virtual void Up(DIRECTION dir)
        {
            this.dir = dir;
            player.Top -= speed;
            player.Image = imgUp;

            if (pb != null)
            {
                pb.Left = player.Left -10;
                pb.Top = player.Top +100;
            }
        }
        /// <summary>
        /// Перемещение игрока в низ
        /// </summary>
        /// <param name="dir"> направление</param>
        public virtual void Down(DIRECTION dir)
        {
            this.dir = dir;
            player.Top += speed;
            player.Image = imgDown;

            if (pb != null)
            {
                pb.Left = player.Left-10;
                pb.Top = player.Top - player.Height/4;
            }
        }
        /// <summary>
        /// Осуществление стрельбы(коэфициенты подобраны изза кривых картинок, и неудобства PictureBox
        /// </summary>
        /// <param name="player">атакующий персонаж</param>
        /// <param name="dir">направление</param>
        public virtual void Shot(PictureBox player, DIRECTION dir)
        {
            this.dir = dir;

            access.Blt = new Bullet(form,access);

            if (dir == DIRECTION.LEFT) access.Blt.Shot(player.Left-20, player.Top - 3 + player.Height / 2, dir);
            if (dir == DIRECTION.RIGHT) access.Blt.Shot(player.Left+100, player.Top - 3 + player.Height / 2, dir);
            if (dir == DIRECTION.UP) access.Blt.Shot(player.Left - 7 + player.Width / 2, player.Top - 20, dir);
            if (dir == DIRECTION.DOWN) access.Blt.Shot(player.Left - 7 + player.Width / 2, player.Top + 100, dir);
        }
        /// <summary>
        /// Столкновение с препядствием/противником
        /// </summary>
        /// <param name="element">персонаж</param>
        /// <param name="intersectElement">обьект столкновения</param>
        public void InteractWith(PictureBox element, PictureBox intersectElement)
        {
            if (intersectElement ==access.Obj.obstacle)
            {
                foreach (var el in access.Obj._obstacles)
                {
                    if ((element.Bounds.IntersectsWith(el.Bounds)))
                    {
                        if (dir == DIRECTION.LEFT) element.Left += 15;
                        else if (dir == DIRECTION.RIGHT) element.Left -= 15;
                        if (dir == DIRECTION.UP) element.Top += 15;
                        else if (dir == DIRECTION.DOWN) element.Top -= 15;
                    }
                }
            }
            else
            {
                if ((element.Bounds.IntersectsWith(intersectElement.Bounds)))
                {
                    if (dir == DIRECTION.LEFT) element.Left -= 15;
                    else if (dir == DIRECTION.RIGHT) element.Left += 15;
                    if (dir == DIRECTION.UP) element.Top -= 15;
                    else if (dir == DIRECTION.DOWN) element.Top += 15;
                }
            }
        }
    }
}
