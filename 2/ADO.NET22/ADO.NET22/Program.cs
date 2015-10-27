/*
    2) Создайте свой расширяющий метод для класса String, 
    который будет принимать регулярное выражение для проверки e-mail, 
    и проверять сопоставлять ее со строкой экземпляра.  

        string email = "toha222@mail.ru";  
        bool result = email.CheckEmail("регулярное_выражение"); 
        if (result)  
        {  
            Console.WriteLine("Проверка прошла!");  
        }  
        else  
        {  
            Console.WriteLine("Проверка не прошла");  
        }
*/

using System;
using System.Windows.Forms;

namespace ADO.NET22
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
