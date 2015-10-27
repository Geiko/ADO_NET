/*
    Создайте приложение для хранения и редактирования пользователей. 

    Необходимо хранить следующие  данные  о  пользователе:  
        логин, 
        пароль,  
        адрес,  
        телефон,  
        признак  админа (логическая переменная).

    При добавлении нового пользователя необходимо проверять, что логин  с таким именем свободен. 
    Для защиты пароля используйте функцию getHashCode у строки. 

    Список пользователей отображается в ListBox. 

    При выполнении двойного щелчка над записью,  содержащей  пользователя,
    открывается  вторая  форма  для  редактирования. 

    Реализовать  добавление  и  удаление  пользователей.  
    Добавление  пользователей реализуется в новом окне.

    Также реализуйте вывод всех зарегистрированных пользователей с фильтрацией администраторов. 
*/



using geiko.ADO_NET_3.DataAccessObject;
using geiko.ADO_NET_3.DataAccessObject.Factory;
using geiko.ADO_NET_3.DataAccessObject.Interface;       
using geiko.ADO_NET_3.Servis;
using geiko.ADO_NET_3.UserServis;
using System;
using System.Windows.Forms;

namespace geiko.ADO_NET_3
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IFactoryDAO factory = new FactoryDAO
            {
                UserID = "sa",
                Password = "KG16011962",
                DataSource = @"BOSS\MSSQLENTERPRISE",
                InitialCatalog = "geikoDbUsers"
            };
                                                                         
            IUserDAO ud = new FactoryUserDAO { factory = factory };
            IContactDAO cd = new FactoryContactDAO { factory = factory };

            IUserServises servises = new UserServises { UserDAO = ud, ContactDAO = cd };

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain ( servises ) );
        }
    }
}
