using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsGame
{
    class Obstacles
    {
        public List<PictureBox> _obstacles;

        public Obstacles()
        {
            _obstacles = new List<PictureBox>
            {
                Create(Color.Gray,107,183,271,100),
                Create(Color.Gray,724,200,254,270),
                Create(Color.Gray,602,837,50,292),
                Create(Color.Gray,1600,872,50,100),
                Create(Color.Gray,1400,400,100,60),
                Create(Color.Gray,1548,81,100,80)

                //new PictureBox
                //{
                //    BackColor = Color.Red,
                //    Left = 107,
                //    Top = 183,
                //    Height = 271,
                //    Width = 100
                //},
              
                //new PictureBox
                //{
                //    BackColor = Color.Red,
                //    Left = 724,
                //    Top = 200,
                //    Height = 254,
                //    Width = 270
                //},
                
                //new PictureBox
                //{
                //    BackColor = Color.Red,
                //    Left = 602,
                //    Top = 837,
                //    Height = 50,
                //    Width =292
                //},
              
                //new PictureBox
                //{
                //    BackColor = Color.Red,
                //    Left = 1600,
                //    Top = 872,
                //    Height = 50,
                //    Width =100
                //},
                //new PictureBox
                //{
                //    BackColor = Color.Red,
                //    Left = 1400,
                //    Top = 400,
                //    Height = 100,
                //    Width =60
                //},
              
                //new PictureBox
                //{
                //    BackColor = Color.Red,
                //    Left = 1548 ,
                //    Top = 81,
                //    Height = 100,
                //    Width =80

                //},
                
            };
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
    }
}
