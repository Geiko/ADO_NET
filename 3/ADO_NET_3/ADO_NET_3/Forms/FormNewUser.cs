using geiko.ADO_NET_3.Entities;    
using geiko.ADO_NET_3.Servis;
using System;
using System.Windows.Forms;

namespace geiko.ADO_NET_3
{                                                                                
    public partial class FormNewUser : Form
    {
        public IUserServises servis;

        public ListBox listBoxUsers;

        public User user;


        //public FormNewUser ( IUserServises servis, ListBox listBoxUsers )
        //{
        //    InitializeComponent ();
        //    this.servis = servis;
        //    this.listBoxUsers = listBoxUsers;
        //}



        public FormNewUser( IUserServises servis, ListBox listBoxUsers, User user)
        {
            InitializeComponent();

            this.servis = servis;
            this.listBoxUsers = listBoxUsers;
            this.user = user;
                
            this.Text = "Edit this User";
            this.textBoxLogin.Text = user.Login;
            this.textBoxPassword.Text = user.Password.ToString();
            this.textBoxAddress.Text = user.Contact.Address;
            this.textBoxPhone.Text = user.Contact.Phone;
            this.checkBoxAdmin.Checked = user.IsAdmin;
        }



        private void buttonOk_Click ( object sender, System.EventArgs e )
        {
            UserDTO newPacket = new UserDTO
            {
                Id = -1,
                ContactId = -1,              
                Login = textBoxLogin.Text,
                Password = textBoxPassword.Text.GetHashCode(),        //////     GetHashCode()
                Address = textBoxAddress.Text,
                Phone = textBoxPhone.Text,
                IsAdmin = checkBoxAdmin.Checked
            };

            if ( user == null )
            {
                try
                {
                    servis.Save ( newPacket );
                }
                catch ( Exception ex)
                {
                    MessageBox.Show ( ex.Message );
                }
                listBoxUsers.Items.Clear ();
                servis.FindAll ( listBoxUsers, true, false );
                Close ();
            }
            else
            {
                newPacket.Id = user.Id;
                newPacket.ContactId = user.ContactId;
                servis.Update ( newPacket );
                listBoxUsers.Items.Clear ();
                servis.FindAll ( listBoxUsers, true, false );
                Close ();
            }
        }    



        private void buttonCancel_Click ( object sender, System.EventArgs e )
        {                                           
            this.Close ();
        }
    }
}
