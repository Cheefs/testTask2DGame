using System;
using System.Windows.Forms;

namespace WindowsFormsGame
{
    /// <summary>
    /// Класс персонажа управляемого компьютером, наследование от персонажа
    /// </summary>
    class CPU : Unit
    {
        /// <summary>
        /// Организация доступа к данным
        /// </summary>
        private readonly IAccess access;
        /// <summary>
        /// Таймер
        /// </summary>
        private readonly Timer tm = new Timer();
        /// <summary>
        /// Флаг запоминаюший напралвнение игрока при столкновении с препядствием
        /// </summary>
        private string flag;
        /// <summary>
        /// Корректируюший коеффициент
        /// </summary>
        private readonly int correctiveCoef = 30;

        /// <summary>
        /// Конструктор класса, инициализация всей автоматики персонажа
        /// </summary>
        /// <param name="form"> форма вывода инфрмации </param>
        /// <param name="access">реализация доступа к данным </param>
        public CPU(Form1 form, IAccess access) : base(form, access)
        {
            this.access = access;
            tm.Interval = speed;
            tm.Tick += new EventHandler(Automatics);
            tm.Interval = 60;
            tm.Start();
        }

        /// <summary>
        /// СОздание, и расположение обьекта на карте
        /// </summary>
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

        /// <summary>
        /// Реализация простой автоматики управления
        /// </summary>
        /// <param name="sender">обьект инициализатор события</param>
        /// <param name="e"> аргументы события</param>
        public void Automatics(object sender, EventArgs e)
        {
            AutoAtack(form.Unit.player, player, form.Unit.dir);
            if (!(player.Bounds.IntersectsWith(form.Unit.player.Bounds)))
            {
                if (form.Unit.player.Left <= player.Left - correctiveCoef)
                {
                    if (Obstacle()) flag = "left";
                    else Left(DIRECTION.LEFT);
                }

                if (form.Unit.player.Left >= player.Left + correctiveCoef)
                {
                    if (Obstacle()) flag = "right";
                    else Right(DIRECTION.RIGHT);
                }

                if (form.Unit.player.Top >= player.Top + correctiveCoef)
                {
                    if (Obstacle()) flag = "down";
                    else Down(DIRECTION.DOWN);
                }
                if (form.Unit.player.Top <= player.Top - correctiveCoef)
                {
                    if (Obstacle()) flag = "up";
                    else Up(DIRECTION.UP);
                }
            }

            Find();
            access.Pos.Text = $"Позиция X игрока: {access.Unit.player.Left}\n Позиция Y игрока: {access.Unit.player.Top}" +
                $"\n Позиция X противника: {player.Left}\n Позиция Y противника: {player.Top} ";
        }

        /// <summary>
        /// Реализация простой автоматики атаки
        /// </summary>
        /// <param name="target">Цель</param>
        /// <param name="cpuPlayer"> игрок компьютера </param>
        /// <param name="targetDir"> направление цели </param>
        public void AutoAtack(PictureBox target, PictureBox cpuPlayer, DIRECTION targetDir)
        {
            if (!(Obstacle()))
            {
                if (target.Left - correctiveCoef == cpuPlayer.Left & target.Top < player.Top || target.Left + correctiveCoef == cpuPlayer.Left & target.Top < player.Top ||
                    target.Left == cpuPlayer.Left & target.Top < player.Top)
                {
                    player.Image = imgUp;
                    Shot(player, DIRECTION.UP);

                }
                if (target.Left - correctiveCoef == cpuPlayer.Left & target.Top > player.Top || target.Left + correctiveCoef == cpuPlayer.Left & target.Top > player.Top
                    || target.Left == cpuPlayer.Left & target.Top > player.Top)
                {
                    player.Image = imgDown;
                    Shot(player, DIRECTION.DOWN);

                }
                if (target.Top - correctiveCoef == cpuPlayer.Top & target.Left < player.Left || target.Top + correctiveCoef == cpuPlayer.Top & target.Left < player.Left
                    || target.Top == cpuPlayer.Top & target.Left < player.Left)
                {
                    player.Image = imgLeft;
                    Shot(player, DIRECTION.LEFT);


                }
                if (target.Top - correctiveCoef == cpuPlayer.Top & target.Left > player.Left || target.Top + correctiveCoef == cpuPlayer.Top & target.Left > player.Left
                    || target.Top == cpuPlayer.Top & target.Left > player.Left)
                {
                    player.Image = imgRight;
                    Shot(player, DIRECTION.RIGHT);
                }
            }
        }

        /// <summary>
        /// При столкновении с препядствием, простой поиск направления
        /// </summary>
        public void Find()
        {
            if (flag == "left") Up(DIRECTION.UP);
            if (flag == "right") Up(DIRECTION.DOWN);
            if (flag == "down") Right(DIRECTION.RIGHT);
            if (flag == "up") Left(DIRECTION.LEFT);
            flag = null;
        }
        /// <summary>
        /// Проверка - было ли столкновение с препядствием
        /// </summary>
        /// <returns> Возвращает истинну если столкновение произошло, в противном случае возвращает лож </returns>
        public bool Obstacle()
        {
            foreach (var el in form.Obj._obstacles)
                if (el.Bounds.IntersectsWith(player.Bounds)) return true;
            return false;
        }

    }
}
