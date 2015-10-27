using geiko.ADO_NET_3.DataAccessObject.Interface;
using System;                      
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Windows.Forms;
using geiko.ADO_NET_3.DataAccessObject.Factory;
using geiko.ADO_NET_3.Entities;

namespace geiko.ADO_NET_3.DataAccessObject
{
    class FactoryUserDAO : IUserDAO
    {
        public const string TABLENAME = "User";       
        public IFactoryDAO factory { get; set; }
        private DbConnection connection;



        public Collection<User> FindAll ()
        {
            using ( connection = factory.CreateDbConnection () )
            {
                if ( isTableExists () == false )
                {
                    MessageBox.Show ( string.Format ( "There is no table \"{0}\"", TABLENAME ) );        
                    return new Collection<User> ();
                }
                return readUsers ();
            }
        }



        #region

        private Collection<User> readUsers ()
        {
            Collection<User> users = new Collection<User> ();

            DbCommand cmd = connection.CreateCommand ();
            cmd.CommandText = "select * from [User]";
            cmd.Connection = connection;

            using ( DbDataReader reader = cmd.ExecuteReader () )
            {
                if ( reader.HasRows )
                {
                    while ( reader.Read () )
                    {
                        users.Add ( new User
                        {
                            Id = ( int ) reader [ "Id" ],
                            ContactId = ( int ) reader [ "ContactId" ],
                            Login = reader [ "Login" ].ToString (),
                            Password = ( int ) reader [ "Password" ],
                            IsAdmin = ( bool ) reader [ "Admin" ]
                        } );
                    }
                }
                else
                {
                    MessageBox.Show ( "The table [" + TABLENAME + "] is empty." );
                }
            }
            return users;
        }

        #endregion



        public void Save ( User user )
        {
            user.ContactId = user.Contact.Id;

            using ( connection = factory.CreateDbConnection () )
            {
                if ( isTableExists () == false )
                {
                    createTable ();
                }

                if ( isUserExists ( user ) == false )
                {
                    insertUser ( user );
                }
            }
        }



        #region                   

        private bool isTableExists ()
        {
            bool result = false;
            try
            {
                DbCommand cmd = connection.CreateCommand ();
                cmd.CommandText = @"IF EXISTS (SELECT 1 
                                                    FROM INFORMATION_SCHEMA.TABLES  
                                                    WHERE TABLE_TYPE = 'BASE TABLE'
                                                    AND TABLE_NAME = @tableName) 
                                            SELECT 1 AS res ELSE SELECT 0 AS res; ";
                cmd.Connection = connection;
                FactoryUtility.AddParameterWithValue ( cmd, "@tableName", TABLENAME );

                result = ( int ) cmd.ExecuteScalar () == 1;
                return result;
            }
            catch ( Exception ex )
            {
                MessageBox.Show ( ex.Message );
                return result;
            }
        }



        private void createTable ()
        {
            try
            {
                DbCommand cmd = connection.CreateCommand ();
                cmd.CommandText = ( "CREATE TABLE [" + TABLENAME + "]("
                                              + "[ID] [int] PRIMARY KEY IDENTITY NOT NULL,"
                                              + "[ContactId] [int] FOREIGN KEY REFERENCES[Contact]([id]),"
                                              + "[Login] [nvarchar](64) NOT NULL,"
                                              + "[Password] [int] NOT NULL,"
                                              + "[Admin] [bit] NOT NULL)"
                                              );
                cmd.ExecuteNonQuery ();
            }
            catch ( Exception ex )
            {
                MessageBox.Show ( ex.Message );
            }
        }



        private bool isUserExists ( User user )
        {
            try
            {
                DbCommand cmd = connection.CreateCommand ();
                cmd.CommandText = "SELECT COUNT( *) from [" + TABLENAME + @"] where 
                        [ContactId] like @contactId AND 
                        [Login] like @login AND       
                        [Password] like @password AND               
                        [Admin] like @isAdmin";
                FactoryUtility.AddParameterWithValue ( cmd, "@contactId", user.Contact.Id );
                FactoryUtility.AddParameterWithValue ( cmd, "@login", user.Login );
                FactoryUtility.AddParameterWithValue ( cmd, "@password", user.Password );
                FactoryUtility.AddParameterWithValue ( cmd, "@isAdmin", user.IsAdmin );
                cmd.Connection = connection;

                int userCount = ( int ) cmd.ExecuteScalar ();
                if ( userCount > 0 )
                {
                    user.Id = getExistingId ( user );
                    return true;
                }
                return false;
            }
            catch ( Exception ex )
            {
                MessageBox.Show ( ex.Message );
                return true;
            }
        }



        private int getExistingId ( User user )
        {
            try
            {
                DbCommand cmd = connection.CreateCommand ();
                cmd.CommandText = "SELECT [ID] from [" + TABLENAME + @"] where               
                        [ContactId] like @contactId AND 
                        [Login] like @login AND       
                        [Password] like @password AND               
                        [Admin] like @isAdmin";
                FactoryUtility.AddParameterWithValue ( cmd, "@contactId", user.Contact.Id );
                FactoryUtility.AddParameterWithValue ( cmd, "@login", user.Login );
                FactoryUtility.AddParameterWithValue ( cmd, "@password", user.Password );
                FactoryUtility.AddParameterWithValue ( cmd, "@isAdmin", user.IsAdmin );
                cmd.Connection = connection;

                int personID = ( int ) cmd.ExecuteScalar ();
                if ( personID > 0 )
                {
                    return personID;
                }
                return -1;
            }
            catch ( Exception ex )
            {
                MessageBox.Show ( ex.Message );
                return -1;
            }
        }



        private void insertUser ( User user )
        {
            DbCommand cmd = connection.CreateCommand ();
            cmd.CommandText = ( @"INSERT INTO [" + TABLENAME + @"] 
                                            ( [ContactId], [Login],[Password],[Admin])
                                            VALUES (
                                               @contactId, @login, @password, @isAdmin)" );

            FactoryUtility.AddParameterWithValue ( cmd, "@contactId", user.Contact.Id );
            FactoryUtility.AddParameterWithValue ( cmd, "@login", user.Login );
            FactoryUtility.AddParameterWithValue ( cmd, "@password", user.Password );
            FactoryUtility.AddParameterWithValue ( cmd, "@isAdmin", user.IsAdmin );
            cmd.Connection = connection;
            cmd.ExecuteNonQuery ();

            user.Id = getLastId ();
        }



        private int getLastId ()
        {
            DbCommand cmd = connection.CreateCommand ();
            cmd.CommandText = ( "SELECT @@IDENTITY" );

            object identityObj = cmd.ExecuteScalar ();
            int identityKey;
            bool result = int.TryParse ( identityObj.ToString (), out identityKey );

            if ( result == true )
            {                                                           
                return identityKey;
            }
            MessageBox.Show ( "IdentityKey of Address is not found." );
            return 0;
        }


        #endregion



        public bool isLoginExists ( User user )
        {
            using ( connection = factory.CreateDbConnection () )
            {
                try
                {
                    if ( isTableExists () == true )
                    {
                        DbCommand cmd = connection.CreateCommand ();
                        cmd.CommandText = "SELECT COUNT( *) from [" + TABLENAME + "] where [Login] like @login";
                        FactoryUtility.AddParameterWithValue ( cmd, "@login", user.Login );
                        cmd.Connection = connection;

                        int loginCount = ( int ) cmd.ExecuteScalar ();
                        if ( loginCount > 0 )
                        {
                            return true;
                        }
                        return false;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch ( Exception ex )
                {
                    MessageBox.Show ( ex.Message );
                    return true;
                }
            }
        }



        public void Delete ( User user )
        {
            using ( connection = factory.CreateDbConnection () )
            {
                try
                {
                    DbCommand cmd = connection.CreateCommand ();    

                    cmd.CommandText = "DELETE FROM [" + TABLENAME + @"]
                                       WHERE    [ContactId] like @contactId AND 
                                                [Login] like @login AND       
                                                [Password] like @password AND               
                                                [Admin] like @isAdmin";                                                                                                  
                    FactoryUtility.AddParameterWithValue ( cmd, "@contactId", user.Contact.Id );
                    FactoryUtility.AddParameterWithValue ( cmd, "@login", user.Login );
                    FactoryUtility.AddParameterWithValue ( cmd, "@password", user.Password );
                    FactoryUtility.AddParameterWithValue ( cmd, "@isAdmin", user.IsAdmin );
                    cmd.Connection = connection;

                    cmd.ExecuteNonQuery ();       
                }
                catch ( Exception ex )
                {
                    MessageBox.Show ( ex.Message );      
                }
            }
        }



        public int ReferenceToThisContact ( User user )
        {
            using ( connection = factory.CreateDbConnection () )
            {
                try
                {
                    DbCommand cmd = connection.CreateCommand ();       
                    cmd.CommandText = "SELECT COUNT( *) from [" + TABLENAME + @"] where [ContactId] like @contactId";    
                    FactoryUtility.AddParameterWithValue ( cmd, "@contactId", user.ContactId );     
                    cmd.Connection = connection;
                                                      
                    return ( int ) cmd.ExecuteScalar ();
                }
                catch ( Exception ex )
                {
                    MessageBox.Show ( ex.Message );
                    return 10;
                }
            }
        }



        public void Update ( User user )
        {
            using ( connection = factory.CreateDbConnection () )
            {
                try
                {
                    DbCommand cmd = connection.CreateCommand ();

                    cmd.CommandText = "UPDATE [" + TABLENAME + @"]       
                                       SET    [ContactId] = @contactId ,
                                              [Login] = @login ,       
                                              [Password] = @password ,             
                                              [Admin] = @isAdmin           
                                       WHERE  [Id] = @Id";                       
                    FactoryUtility.AddParameterWithValue ( cmd, "@Id", user.Id );
                    FactoryUtility.AddParameterWithValue ( cmd, "@contactId", user.ContactId );
                    FactoryUtility.AddParameterWithValue ( cmd, "@login", user.Login );
                    FactoryUtility.AddParameterWithValue ( cmd, "@password", user.Password );
                    FactoryUtility.AddParameterWithValue ( cmd, "@isAdmin", user.IsAdmin );
                    cmd.Connection = connection;      
                    cmd.ExecuteNonQuery ();
                }
                catch ( Exception ex )
                {
                    MessageBox.Show ( ex.Message );      
                }
            }
        }             
    }
}
