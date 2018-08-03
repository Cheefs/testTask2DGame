using System.Windows.Forms;

namespace WindowsFormsGame
{
    interface IAccess
    {
        Obstacles Obj { get; set; }
        Unit Unit { get; set; }
        Bullet Blt { get; set; }
        CPU Cpu { get; set; }
        Label Pos { get; set; }
        Label Points { get; set; }
        DataBase db { get; set; }
    }
}
