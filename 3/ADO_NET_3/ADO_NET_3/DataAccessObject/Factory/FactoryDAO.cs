using geiko.ADO_NET_3.DataAccessObject.Interface;
using System;
using System.Data.Common;
using System.Windows.Forms;

namespace geiko.ADO_NET_3.DataAccessObject.Factory
{
    class FactoryDAO : IFactoryDAO
    {
        public string UserID { get; set; }
        public string Password { get; set; }
        public string DataSource { get; set; }
        public string InitialCatalog { get; set; }



        public DbConnection CreateDbConnection ()
        {
            DbConnection connection = null;

            string connectionString = getConnString ( UserID, Password, DataSource, InitialCatalog );

            if ( connectionString != null )
            {
                try
                {
                    DbProviderFactory factory = DbProviderFactories.GetFactory ( FactoryUtility.SQLPROVIDER );

                    connection = factory.CreateConnection ();
                    connection.ConnectionString = connectionString;
                    connection.Open ();                                          
                }
                catch ( Exception ex )
                {
                    if ( connection != null )
                    {
                        connection = null;
                    }
                    MessageBox.Show ( ex.Message );
                }
            }

            return connection;
        }



        private static string getConnString ( string userID, string password, string dataSource, string initialCatalog )
        {
            DbConnectionStringBuilder builder = new DbConnectionStringBuilder ();
            builder [ "Data Source" ] = dataSource;
            builder [ "Initial Catalog" ] = initialCatalog;
            builder [ "User Id" ] = userID;
            builder [ "Password" ] = password;
            return builder.ConnectionString;
        }
    }
}
