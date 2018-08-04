using System;
using System.Collections.Generic;
using System.IO;


namespace WindowsFormsGame
{
    /// <summary>
    /// База данных игры (в данный момент организует роль модели, связывая файл с игровым счетом)
    /// </summary>
    class DataBase
    {
       private IAccess access;
        public List<int> points;
       private readonly string path = "points.dat";

        public DataBase( IAccess access)
        {
            this.access = access; 
        }
        /// <summary>
        /// Записать прогресс в базу данных(в файл)
        /// </summary>
        public void Write()
        {
            using (var sr =new StreamWriter(path))
            {
                sr.AutoFlush=true;
                foreach( var el in points)
                    sr.WriteLine(el);
            }
        }

        /// <summary>
        /// Считывание информации с файла
        /// </summary>
        public void Read()
        {
          points = new List<int>();
          string [] tmp=File.ReadAllLines(path);
            foreach (var e in tmp)
                points.Add(Convert.ToInt32(e));
            access.Points.Text = $"Player: {points[0]}\t CPU: {points[1]}";

        }
        /// <summary>
        /// Очистка игрового счета
        /// </summary>
        public void ClearDB()
        {
            points = new List<int>() { 0,0};
            access.Points.Text = $"Player: {points[0]}\t CPU: {points[1]}";
        }
    }
}
