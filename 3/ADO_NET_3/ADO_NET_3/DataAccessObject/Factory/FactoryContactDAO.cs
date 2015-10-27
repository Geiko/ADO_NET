using geiko.ADO_NET_3.DataAccessObject.Interface;
using System;
using geiko.ADO_NET_3.Entities;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Windows.Forms;

namespace geiko.ADO_NET_3.DataAccessObject.Factory
{
    class FactoryContactDAO : IContactDAO
    {
        public const string TABLENAME = "Contact";      
        public IFactoryDAO factory{ get; set; }      
        private DbConnection connection;


                                            
        public Collection<Contact> FindAll ()
        {
            using ( connection = factory.CreateDbConnection () )
            {
                if ( isTableExists () == false )
                {                                                                                    
                    return new Collection<Contact> ();
                }                                                          
                return readContacts ();
            }
        }



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



        private Collection<Contact> readContacts ()
        {
            Collection<Contact> contactS = new Collection<Contact> ();

            DbCommand cmd = connection.CreateCommand ();
            cmd.CommandText = "select * from [Contact]";
            cmd.Connection = connection;

            using ( DbDataReader reader = cmd.ExecuteReader () )
            {
                if ( reader.HasRows )
                {
                    while ( reader.Read () )
                    {
                        contactS.Add ( new Contact
                        {
                            Id = ( int ) reader [ "Id" ],
                            Address = reader [ "Address" ].ToString (),
                            Phone = reader [ "Phone" ].ToString ()     
                        } );                                                        
                    }
                }
                else
                {
                    MessageBox.Show ( "The table [" + TABLENAME + "] is empty." );
                }
            }
            return contactS;
        }



        private void createTable ()
        {
            try
            {
                DbCommand cmd = connection.CreateCommand ();
                cmd.CommandText = ( "CREATE TABLE [" + TABLENAME + "]("
                                              + "[ID] [int] PRIMARY KEY IDENTITY NOT NULL,"                                  
                                              + "[Address] [nvarchar](64) NOT NULL,"
                                              + "[Phone] [nvarchar](64) NOT NULL)" );
                cmd.ExecuteNonQuery ();
            }
            catch ( Exception ex )
            {
                MessageBox.Show ( ex.Message );
            }
        }



        public void Save ( Contact contact )
        {
            using ( connection = factory.CreateDbConnection () )
            {
                if ( isTableExists () == false )
                {
                    createTable ();
                }

                if ( isContactExists ( contact ) == false )
                {
                    insertContact ( contact );
                }
            }
        }



        private void insertContact ( Contact contact )
        {
            try
            {
                DbCommand cmd = connection.CreateCommand ();
                cmd.CommandText = @"INSERT INTO [" + TABLENAME + @"] 
                                            ( [Address], [Phone])
                                            VALUES (@country, @Phone)";
                cmd.Connection = connection;
                FactoryUtility.AddParameterWithValue ( cmd, "@country", contact.Address );      
                FactoryUtility.AddParameterWithValue ( cmd, "@phone", contact.Phone );
                cmd.ExecuteNonQuery ();

                contact.Id = getLastId ();
            }
            catch ( Exception ex )
            {
                MessageBox.Show ( ex.Message );
            }
        }



        private int getLastId ()
        {
            DbCommand com = connection.CreateCommand ();
            com.CommandText = "SELECT @@IDENTITY";

            object identityObj = com.ExecuteScalar ();
            int identityKey;
            bool result = int.TryParse ( identityObj.ToString (), out identityKey );

            if ( result == true )
            {                                                         
                return identityKey;
            }
            MessageBox.Show ( "IdentityKey of Contact is not found." );
            return 0;
        }



        private bool isContactExists ( Contact contact )
        {
            try
            {
                DbCommand cmd = connection.CreateCommand ();
                cmd.CommandText = "SELECT COUNT( *) from [" + TABLENAME + @"] where 
                        [Address] like @address AND    
                        [Phone] like @phone";
                FactoryUtility.AddParameterWithValue ( cmd, "@address", contact.Address );
                FactoryUtility.AddParameterWithValue ( cmd, "@phone", contact.Phone );       
                cmd.Connection = connection;
                int addressCount = ( int ) cmd.ExecuteScalar ();
                if ( addressCount > 0 )
                {
                    contact.Id = getExistingId ( contact );
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



        private int getExistingId ( Contact contact )
        {
            try
            {
                DbCommand cmd = connection.CreateCommand ();
                cmd.CommandText = "SELECT [ID] from [" + TABLENAME + @"] where     
                        [Address] like @address AND    
                        [Phone] like @phone";
                FactoryUtility.AddParameterWithValue ( cmd, "@address", contact.Address );
                FactoryUtility.AddParameterWithValue ( cmd, "@phone", contact.Phone );
                cmd.Connection = connection;
                int addressID = ( int ) cmd.ExecuteScalar ();
                if ( addressID > 0 )
                {
                    return addressID;
                }
                return -1;
            }
            catch ( Exception ex )
            {
                MessageBox.Show ( ex.Message );
                return -1;
            }
        }



        public void Delete ( Contact contact )
        {
            using ( connection = factory.CreateDbConnection () )
            {
                try
                {
                    DbCommand cmd = connection.CreateCommand ();

                    cmd.CommandText = "DELETE FROM [" + TABLENAME + @"]
                                       WHERE    [Address] like @address AND    
                                                [Phone] like @phone";
                    FactoryUtility.AddParameterWithValue ( cmd, "@address", contact.Address );
                    FactoryUtility.AddParameterWithValue ( cmd, "@phone", contact.Phone );
                    cmd.Connection = connection;

                    cmd.ExecuteNonQuery ();
                }
                catch ( Exception ex )
                {
                    MessageBox.Show ( ex.Message );     
                }
            }
        }



        public int Update ( User user )
        {
            using ( connection = factory.CreateDbConnection () )
            {
                try
                {
                    if ( isContactExists ( user.Contact ) == false )
                    {
                        DbCommand cmd = connection.CreateCommand ();

                        cmd.CommandText = "UPDATE [" + TABLENAME + @"]       
                                       SET    [Address] = @address ,       
                                              [Phone] = @phone          
                                       WHERE  [Id] = @Id";
                        FactoryUtility.AddParameterWithValue ( cmd, "@Id", user.Contact.Id );
                        FactoryUtility.AddParameterWithValue ( cmd, "@address", user.Contact.Address );
                        FactoryUtility.AddParameterWithValue ( cmd, "@phone", user.Contact.Phone );
                        cmd.Connection = connection;
                        cmd.ExecuteNonQuery ();
                        return -1;
                    }
                    else
                    {
                        if ( user.ContactId != user.Contact.Id )
                        {
                            return user.ContactId;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                }
                catch ( Exception ex )
                {
                    MessageBox.Show ( ex.Message );
                    return -1;
                }                      
            }
        }


                                               
        public void Delete ( int IdToDelete )
        {
            using ( connection = factory.CreateDbConnection () )
            {
                try
                {
                    DbCommand cmd = connection.CreateCommand ();

                    cmd.CommandText = "DELETE FROM [" + TABLENAME + @"]
                                       WHERE    [Id] like @contactId";
                    FactoryUtility.AddParameterWithValue ( cmd, "@contactId", IdToDelete );  
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
