using GemDb.Entities;
using GemDb.Interface;
using System;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GemDb.Servis
{
    class GemServis : IGemServis
    {
        public IColorDAO ColorDAO { get; set; }
        public IGemDAO GemDAO { get; set; }


        public void Save ( GemDTO packet )
        {
            Validate ( packet );

            Color color = FormateColor ( packet );
            Gem gem = FormateGem ( packet, color );

            ColorDAO.Save ( color );
            GemDAO.Save ( gem );
        }



        private void Validate ( GemDTO packet )
        {    
            Regex rgx = new Regex ( @"[a-zA-Z]*" );
            if ( string.IsNullOrWhiteSpace ( packet.Name ) )
                throw new ArgumentException ( "Name is not determined." );
            if ( rgx.IsMatch ( packet.Name ) == false )
                throw new ArgumentException ( "Name is not valid. Use only letters." );

            if ( string.IsNullOrWhiteSpace ( packet.ColorName ) )
                throw new ArgumentException ( "Color name is not determined." );
            if ( rgx.IsMatch ( packet.ColorName ) == false )
                throw new ArgumentException ( "Color name is not valid. Use only letters." );
        }



        private Color FormateColor ( GemDTO packet )
        {
            return new Color
            {   
                Id = packet.Id,
                Name = packet.ColorName
            };
        }



        private Gem FormateGem ( GemDTO packet, Color color )
        {
            return new Gem
            {
                Color = color,
                Id = packet.Id,
                ColorId = packet.ColorId,
                Name = packet.Name,
                Transparency = packet.Transparency,
                Type = packet.Type,         
                Description = packet.Description
            };
        }



        public void FindAll ( ListBox listBoxGem )
        {
            Collection<Gem> gemS = GemDAO.FindAll ();
            Collection<Color> colorS = ColorDAO.FindAll ();

            foreach ( Gem gem in gemS )
            {
                Color currentColor = getColor ( colorS, gem.ColorId );
                gem.Color = currentColor;

                listBoxGem.DisplayMember = "Name";                        
                listBoxGem.Items.Add ( gem );         
            }
        }



        private Color getColor ( Collection<Color> colorS, int colorId )
        {
            foreach ( Color color in colorS )
            {
                if ( color.Id == colorId )
                {
                    return color;
                }
            }
            MessageBox.Show ( "There is no ColorId." );
            return null;
        }



        public void GetExistingColors ( ComboBox comboBoxColor )
        {
            Collection<Color> colorS = ColorDAO.FindAll ();

            foreach ( Color color in colorS )
            {
                comboBoxColor.Items.Add ( color.Name );
            }
        }



        public void FindGemWithColor ( string selectedItem, ListBox listBoxGem )
        {
            Collection<Gem> gemS = GemDAO.FindAll ();
            Collection<Color> colorS = ColorDAO.FindAll ();

            foreach ( Gem gem in gemS )
            {
                Color currentColor = getColor ( colorS, gem.ColorId );
                gem.Color = currentColor;

                listBoxGem.DisplayMember = "Name";
                if ( selectedItem == gem.Color.Name )
                {
                    listBoxGem.Items.Add ( gem );
                }
            }
        }



    }
}
