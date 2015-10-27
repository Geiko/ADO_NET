/*
    1) Создайте 2 анонимных типа с разными свойствами, 
    и сравните их при помощи метода Equals, 
    а так же получите хэш код каждого из типов. 
    
    Затем создайте 2 типа с одинаковым набором свойств,
    и проинициализируйте свойства обоих типов одинаковыми значениями,    и проделайте вышеуказанные действия.         Сделайте выводы.  */

using System;
using System.Windows.Forms;

namespace geiko.ADO.NET21
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
