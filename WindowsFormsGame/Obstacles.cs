using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WindowsFormsGame
{
    class Obstacles
    {
        public List<PictureBox> _obstacles;
        public Obstacles( Form form)
        {
            _obstacles = new List<PictureBox>
            {
                Create(Color.Gray,107,183,271,100),
                Create(Color.Gray,724,200,254,270),
                Create(Color.Gray,602,837,50,292),
                Create(Color.Gray,1600,872,50,100),
                Create(Color.Gray,1400,400,100,60),
                Create(Color.Gray,1548,81,100,80)
            };

          

           AddToForm(form);
        }
        /// <summary>
        /// Создание обьектов(препятствий) на основе PictureBox
        /// </summary>
        /// <param name="color">Цвет обьекта</param>
        /// <param name="posX">Позиция по оси Х</param>
        /// <param name="posY">Позиция по оси Y</param>
        /// <param name="height">Высота обьекта</param>
        /// <param name="width">Ширина обьекта</param>
        /// <returns></returns>
        private PictureBox Create(Color color, int posX, int posY,int height, int width)
        {
            return new PictureBox
            {
                BackColor = color,
                Left = posX,
                Top = posY,
                Height = height,
                Width = width
            };
        }

        /// <summary>
        /// Добавить колекцию элементов на форму
        /// </summary>
        /// <param name="form">Форма, на которую добавляется элемент управления</param>
        private void AddToForm( Form form)
        {
            foreach (var el in _obstacles)
                form.Controls.Add(el);
        }

        
    }
}
