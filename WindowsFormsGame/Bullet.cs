using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsGame
{
    /// <summary>
    /// Класс отвечающий за создание, и все зависимости обьекта "Пуля"
    /// </summary>
    class Bullet
    {
        private IAccess access; //Реализация доступа к полям
        public PictureBox bullet; //Элемент Пуля
        private readonly int speed = 30; //Скорость пули
        public DIRECTION dir;// Направление
        int dx = 5, dy = 5; //Прирост координаты по оси X и оси Y
        int tmpX, tmpY; //Временные ячейки, храняшие данные последних координат пули, перед очисткой и генирацией новой(использщуется для рикошета)

        private Timer timer = new Timer();
        private Form1 form;

        /// <summary>
        /// Конструктор класса, запускает таймер(обновление обьекта пули)
        /// </summary>
        /// <param name="form">форма вывода графических данных</param>
        /// /// <param name="access">доступ к данным</param>
        public Bullet(Form1 form, IAccess access)
        {
            this.form = form;
            this.access = access;

            timer.Interval = speed;
            timer.Tick += new EventHandler(TimerFrames);
            timer.Start();
        }
        /// <summary>
        /// Стрельба
        /// </summary>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        /// <param name="dir"></param>
        public void Shot(int posX, int posY, DIRECTION dir)
        {
            this.dir = dir;
            bullet = new PictureBox
            {
                BackColor = Color.Red,
                Left = posX,
                Top = posY,
                Width = 10,
                Height = 10
            };
            form.Controls.Add(bullet);
        }
        /// <summary>
        /// Проверяет, сопрекосновение пули и препядствий
        /// </summary>
        /// <param name="element">Пуля</param>
        /// <returns> Возвращает истину если столкновение произошло, в противном случае возвращает лож</returns>
        public bool CheckAttack(PictureBox element)
        {
            foreach (var el in access.Obj._obstacles)
            {
                if ((element.Bounds.IntersectsWith(el.Bounds)))
                {
                    tmpX = bullet.Left;
                    tmpY = bullet.Top;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Проверка, не столкнулась ли пуля, с противником/персонажем
        /// </summary>
        /// <param name="obj">цель атаки</param>
        /// <param name="pb">Здоровье цели</param>
        /// <returns> Возвращает истину если столкновение произошло, в противном случае возвращает лож </returns>
        private bool IsHited(PictureBox obj, ProgressBar pb)
        {
            if (bullet.Bounds.IntersectsWith(obj.Bounds) & pb.Value > 0)
            {
                pb.Value -= 10;
                System.Media.SystemSounds.Exclamation.Play();
             
            }
            else if (pb.Value<10)
            {
                if (obj == access.Cpu.player)
                {
                    access.db.points[0] += 1;
                    form.Close();
                }

                if (obj == access.Unit.player)
                {
                    access.db.points[1] += 1;
                    form.Close();
                }
                return true;
            }
            return false;
        }
        /// <summary>
        /// Проверка всех обьектов, на возможность получения урона (чтоб не дублировать много строк)
        /// </summary>
        private void Attack()
        {
            IsHited(access.Unit.player, access.Unit.pb);
            IsHited(access.Cpu.player, access.Cpu.pb);
        }
        /// <summary>
        /// Отрисовка пули по кадрам, и организация всех ее зависимостей
        /// </summary>
        /// <param name="sender"> инициализаток события</param>
        /// <param name="e"> агрументы события</param>
        public void TimerFrames(Object sender, EventArgs e)
        {
          

            CheckAttack(bullet);
            if (dir == DIRECTION.LEFT)
            {
                if (!(CheckAttack(bullet)))
                {
                    Attack();
                    bullet.Left -= speed;
                }
                else if (CheckAttack(bullet))
                {
                    Hit(tmpX + 10, tmpY, DIRECTION.RIGHT);
                    for (int i = 0; i < 5; i++)
                    {
                        dx += i;
                        dy += i;
                        bullet.Left += dx;
                        bullet.Top -= dy;
                    }
                }
            }

            if (dir == DIRECTION.RIGHT)
            {
                if (!(CheckAttack(bullet)))
                {
                    Attack();
                    bullet.Left += speed;
                }
                else if (CheckAttack(bullet))
                {
                    Hit(tmpX - 10, tmpY, DIRECTION.LEFT);
                    for (int i = 0; i < 5; i++)
                    {
                        dx += i;
                        dy += i;
                        bullet.Left -= dx - 1;
                        bullet.Top -= dy;
                    }
                }
            }

            if (dir == DIRECTION.UP)
            {
                if (!(CheckAttack(bullet)))
                {

                    Attack();
                    bullet.Top -= speed;
                }
                else if (CheckAttack(bullet))
                {
                    Hit(tmpX, tmpY + 10, DIRECTION.DOWN);
                    for (int i = 0; i < 2; i++)
                    {
                        dx += i;
                        dy += i;
                        bullet.Left += dx;
                        bullet.Top += dy;
                    }
                }
            }

            if (dir == DIRECTION.DOWN)
            {
                if (!(CheckAttack(bullet)))
                {
                    Attack();
                    bullet.Top += speed;
                }
                else if (CheckAttack(bullet))
                {
                    Hit(tmpX, tmpY + 10, DIRECTION.UP);
                    for (int i = 0; i < 5; i++)
                    {
                        dx += i;
                        dy += i;
                        bullet.Left += dx;
                        bullet.Top -= dy;
                    }
                }
            }
            if (bullet.Left < 0
                || bullet.Left > form.Width || bullet.Top < 0 || bullet.Top > form.Height
                || IsHited(access.Unit.player, access.Unit.pb)|| IsHited(access.Cpu.player, access.Cpu.pb)) Clear();


           

        }


        /// <summary>
        /// Очистка стека от пули, и таймера
        /// </summary>
        public void Clear()
        {
            bullet.Dispose();
            timer.Dispose();
        }

        /// <summary>
        /// Действие при попадании пули в препятствие
        /// </summary>
        /// <param name="x"> Позиция Х пули при столкновении</param>
        /// <param name="y">Позиция Y пули при столкновении </param>
        /// <param name="dir"> Направление пули при столкновении</param>
        public void Hit(int x, int y, DIRECTION dir)
        {
            Clear();

            Shot(x, y, dir);
            timer.Interval = speed;

            timer.Tick += new EventHandler(TimerFrames);
            timer.Start();

            bullet.BackColor = Color.DarkBlue;
        }

    }
}
