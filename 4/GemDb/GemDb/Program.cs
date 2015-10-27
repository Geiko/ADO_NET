/*
           2.  Разработайте XML файл, содержащий описание драгоценных камней 

                - название, 
                - цвет, 
                - признак прозрачности (да/нет), 
                - тип (поделочный, драгоценный, полудрагоценный), 
                - описание. 
        
        Напишите программу, которая будет отображать список камней по выбранному цвету. 
*/


using GemDb.DAO;
using GemDb.DAO.XML;
using GemDb.Interface;
using GemDb.Servis;
using System;
using System.Windows.Forms;

namespace GemDb
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main ()
        {
            IColorDAO colorDao = new XMLColorDAO { XmlColorFilePath = "..\\..\\Color.xml" };
            IGemDAO gemDao = new XMLGemDAO { XmlGemFilePath = "..\\..\\Gem.xml" };

            IGemServis servis = new GemServis { ColorDAO = colorDao, GemDAO = gemDao }; 

            Application.EnableVisualStyles ();
            Application.SetCompatibleTextRenderingDefault ( false );
            Application.Run ( new MainForm (servis) );
        }
    }
}
