using System.Windows.Forms;

namespace WindowsFormsGame
{
   /// <summary>
   /// Организация доступа к данным
   /// </summary>
    interface IAccess
    {
        /// <summary>
        /// Коллекция препядствий
        /// </summary>
        Obstacles Obj { get; set; }
        /// <summary>
        /// Данные обьекта класса персонажа
        /// </summary>
        Unit Unit { get; set; }
        /// <summary>
        /// Данные обьекта класса пули
        /// </summary>
        Bullet Blt { get; set; }
        /// <summary>
        /// Даннные обьекта класса - персонаж компьютера
        /// </summary>
        CPU Cpu { get; set; }
        /// <summary>
        /// Вывод позиции персонажей по осям
        /// </summary>
        Label Pos { get; set; }
        /// <summary>
        /// Вывод игрового счета
        /// </summary>
        Label Points { get; set; }
        /// <summary>
        /// Данные обьекта класса базы данных
        /// </summary>
        DataBase db { get; set; }
    }
}
