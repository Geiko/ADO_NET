using geiko.ADO_NET_3.DataAccessObject.Interface;
using geiko.ADO_NET_3.Entities;
using geiko.ADO_NET_3.Servis;
using System;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace geiko.ADO_NET_3.UserServis
{
    class UserServises : IUserServises
    {
        public IContactDAO ContactDAO { get; set; }
        public IUserDAO UserDAO { get; set; }    

        

        public void FindAll ( ListBox listBoxUsers, bool isAll, bool isAdm )
        {                                                        
            Collection<User> userS = UserDAO.FindAll ();
            Collection<Contact> contactS = ContactDAO.FindAll ();

            foreach (User user in userS)
            {
                Contact currentContact = getContact ( contactS, user.ContactId );
                user.Contact = currentContact;
                listBoxUsers.DisplayMember = "Login" ;

                if ( isAll == true )
                {
                    listBoxUsers.Items.Add ( user );
                }
                else
                {
                    if ( isAdm == false )
                    {
                        if ( user.IsAdmin == false )
                        {
                            listBoxUsers.Items.Add ( user );
                        }
                    }
                    else
                    {
                        if ( user.IsAdmin == true )
                        {
                            listBoxUsers.Items.Add ( user );
                        }
                    }
                }
            }               
        }



        private Contact getContact ( Collection<Contact> contacts, int contactsId )
        {
            foreach ( Contact contact in contacts )
            {
                if ( contact.Id == contactsId )
                {
                    return contact;
                }
            }
            MessageBox.Show ( "There is no ContactId." );
            return null;
        }



        public void Save ( UserDTO packet )                             
        {
            Validate ( packet );

            Contact contact = FormateContact ( packet );
            User user = FormateUser ( packet, contact );

            if ( UserDAO.isLoginExists (user) == false )
            {
                ContactDAO.Save ( contact );
                UserDAO.Save ( user );
            }
            else
            {
                MessageBox.Show ( "This Login exists in DB already." );
            }
        }



        private void Validate ( UserDTO packet )
        {
            if ( string.IsNullOrWhiteSpace ( packet.Login ) )
                throw new ArgumentException ( "Login is not determined." );                  

            if ( string.IsNullOrWhiteSpace ( packet.Password.ToString() ) )
                throw new ArgumentException ( "Passworde is not determined." );                 
                                                                                              
            if ( string.IsNullOrWhiteSpace ( packet.Address ) )
                throw new ArgumentException ( "Address name is not determined." );             

            if ( string.IsNullOrWhiteSpace ( packet.Phone ) )
                throw new ArgumentException ( "Phone number is not determined." );
            Regex rgx =  new Regex ( @"[+0-9][0-9]*" );
            if ( rgx.IsMatch ( packet.Phone ) == false )
                throw new ArgumentException ( "Phone is not valid. Use only digits and \"+\"." );            
        }
             


        private User FormateUser ( UserDTO packet, Contact contact )
        {
            return new User
            {
                Contact = contact,

                Id = packet.Id,
                ContactId=packet.ContactId,
                                    
                Login = packet.Login,
                Password = packet.Password,
                IsAdmin=packet.IsAdmin
            };               
        }



        private Contact FormateContact ( UserDTO packet )
        {
            return new Contact
            {
                Id = packet.Id,
                Address = packet.Address,
                Phone = packet.Phone
            };
        }



        public void Delete (User user)
        {
            UserDAO.Delete ( user );                         

            if ( UserDAO.ReferenceToThisContact ( user ) == 0 )
            {
                ContactDAO.Delete ( user.Contact );
            }
        }



        public void Update ( UserDTO newPacket )
        {
            Validate ( newPacket );

            Contact contact = FormateContact ( newPacket );
            User user = FormateUser ( newPacket, contact );

            int ContactIdToDelete = -1;
            if ( UserDAO.ReferenceToThisContact ( user ) > 1 )
            {
                ContactDAO.Save ( contact );         
                user.ContactId = contact.Id;     
            }
            else
            {                                     
                ContactIdToDelete = ContactDAO.Update ( user );
                user.ContactId = contact.Id;
            }                        

            UserDAO.Update ( user );  
            if( ContactIdToDelete > 0 )
            {
                ContactDAO.Delete ( ContactIdToDelete );
            }      
        }
    }                      
}
