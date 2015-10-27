using GemDb.Entities;
using GemDb.Servis;
using System;
using System.Windows.Forms;

namespace GemDb
{
    public partial class MainForm : Form
    {
        IGemServis servis;


        public MainForm (IGemServis servis)
        {
            InitializeComponent ();
            this.servis = servis;
        }



        private void MainForm_Load ( object sender, EventArgs e )
        {                                    
            listBoxGem.Items.Clear ();              
            servis.FindAll ( listBoxGem );

            comboBoxColor.Items.Clear ();                   
            servis.GetExistingColors ( comboBoxColor );

            if ( this.comboBoxColor.Items.Count != 0 )
            {
                if ( this.comboBoxColor.SelectedItem != null )
                {
                    this.comboBoxColor.SelectedIndex = 0;
                }
            }
        }



        private void buttonAdd_Click ( object sender, EventArgs e )
        {
            GemFeatureForm gemForm = new GemFeatureForm (servis, listBoxGem, comboBoxColor);
            gemForm.Show ();
        }



        private void listBoxGem_MouseDoubleClick ( object sender, MouseEventArgs e )
        {
            if ( this.listBoxGem.Items.Count != 0 )
            {
                if ( this.listBoxGem.SelectedItem != null )
                {
                    GemFeatureForm formEdit = new GemFeatureForm ( servis, listBoxGem, comboBoxColor, ( Gem ) this.listBoxGem.SelectedItem );
                    formEdit.Show ();
                }
            }
        }



        private void buttonShowAll_Click ( object sender, EventArgs e )
        {
            listBoxGem.Items.Clear ();
            servis.FindAll ( listBoxGem );
        }



        private void buttonShowColor_Click ( object sender, EventArgs e )
        {
            listBoxGem.Items.Clear ();
            servis.FindGemWithColor ( (string) comboBoxColor.SelectedItem, listBoxGem );
        }
    }
}
