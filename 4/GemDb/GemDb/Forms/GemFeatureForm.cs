using GemDb.Entities;
using GemDb.Servis;
using System;
using System.Windows.Forms;

namespace GemDb
{
    public partial class GemFeatureForm : Form
    {
        IGemServis servis;
        ListBox listBoxGem;
        ComboBox comboBoxColor;
        Gem gem;



        public GemFeatureForm ( IGemServis servis, ListBox listBoxGem, ComboBox comboBoxColor )
        {
            InitializeComponent ();
            this.listBoxGem = listBoxGem;
            this.comboBoxColor = comboBoxColor;
            this.gem = null;

            this.comboBoxType.Items.AddRange ( new object [] {
                        "Ornamental",
                        "Semiprecious",
                        "Precious"} );
            this.comboBoxType.SelectedIndex = 0;
            this.servis = servis;
        }



        public GemFeatureForm ( IGemServis servis, ListBox listBoxGem, ComboBox comboBoxColor, Gem gem )
        {
            InitializeComponent ();

            this.servis = servis;
            this.listBoxGem = listBoxGem;
            this.comboBoxColor = comboBoxColor;
            this.gem = gem;

            this.Text = "Gem collection";
            this.textBoxName.Text = gem.Name;
            this.textBoxColor.Text = gem.Color.Name;
            this.checkBoxTransparency.Checked = gem.Transparency;

            this.comboBoxType.Items.AddRange 
                ( 
                    new object [] { "Ornamental", "Semiprecious", "Precious", "Unknown"} 
                );  
            this.comboBoxType.SelectedIndex = getSelectedIndex ( gem.Type.ToString () );

            this.textBoxDescription.Text = gem.Description;
        }



        private int getSelectedIndex ( string v )
        {
            if ( v == "ORNAMENTAL" )
            {
                return 0;
            }
            else if ( v == "SEMIPRECIOUS" )
            {
                return 1;
            }
            else if ( v == "PRECIOUS" )
            {
                return 2;
            }
            return 3;
        }



        private void buttonSave_Click ( object sender, EventArgs e )
        {                                                                   
            GemDTO packet = new GemDTO
            {
                Id = -1,
                ColorId = -1,
                ColorName = textBoxColor.Text,
                Name = textBoxName.Text,
                Transparency = checkBoxTransparency.Checked,      
                Description = textBoxDescription.Text  
            };

            if ( comboBoxType.SelectedIndex == 0 )
            {
                packet.Type = Gem.Types.ORNAMENTAL;
            }
            else if (comboBoxType.SelectedIndex == 1)
            {
                packet.Type = Gem.Types.SEMIPRECIOUS;
            }
            else
            {
                packet.Type = Gem.Types.PRECIOUS;
            }                                        

            try
            {
                if( gem != null )
                {                              
                    this.Close ();
                    return;
                }
                servis.Save ( packet );
                if (listBoxGem.Items.Count > 0 )
                {
                    listBoxGem.Items.Clear ();
                }
                servis.FindAll ( listBoxGem );

                comboBoxColor.Items.Clear ();
                servis.GetExistingColors ( comboBoxColor );

                this.Close ();
            }
            catch ( Exception ex)
            {
                MessageBox.Show ( ex.Message );
            }   
        }



        private void buttonCancel_Click ( object sender, EventArgs e )
        {
            this.Close ();
        }
    }
}
