using geiko.ADO_NET_3.Entities;
using geiko.ADO_NET_3.Servis;             
using System.Windows.Forms;
using System;                   

namespace geiko.ADO_NET_3
{
    public partial class FormMain : Form                                 
    {
        public IUserServises servis; 



        public FormMain (IUserServises servis )
        {
            InitializeComponent ();   
            this.servis = servis;
            listBoxUsers.Items.Clear ();
            servis.FindAll ( listBoxUsers, true, false );
        }         



        private void listBoxUsers_MouseDoubleClick ( object sender, MouseEventArgs e )
        {
            if ( this.listBoxUsers.Items.Count != 0 )
            {
                if ( this.listBoxUsers.SelectedItem != null )
                {
                    FormNewUser formEdit = new FormNewUser ( servis, this.listBoxUsers, ( User ) this.listBoxUsers.SelectedItem );
                    formEdit.Show ();                                       
                }
            }
        }



        private void buttonAllUsers_Click ( object sender, EventArgs e )
        {
            listBoxUsers.Items.Clear ();
            servis.FindAll ( listBoxUsers, true, false );
        }



        private void buttonShowUsers_Click ( object sender, EventArgs e )
        {
            listBoxUsers.Items.Clear ();
            servis.FindAll ( listBoxUsers, false, false );
        }



        private void buttonShowAdmins_Click ( object sender, EventArgs e )
        {
            listBoxUsers.Items.Clear ();
            servis.FindAll ( listBoxUsers, false, true );
        }



        private void buttonAdd_Click ( object sender, EventArgs e )
        {
            FormNewUser formEdit = new FormNewUser ( servis, listBoxUsers );
            formEdit.Show ();                                               
        }



        private void buttonDelete_Click ( object sender, EventArgs e )
        {
            if ( this.listBoxUsers.Items.Count != 0 )
            {
                if ( this.listBoxUsers.SelectedItem != null )
                {
                    servis.Delete ( ( User ) this.listBoxUsers.SelectedItem );   

                    listBoxUsers.Items.Clear ();
                    servis.FindAll ( listBoxUsers, true, true );
                }
            }
        }
    }
}
