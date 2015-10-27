using GemDb.Interface;
using System;
using System.Linq;
using GemDb.Entities;
using System.Xml.Linq;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GemDb.DAO
{
    class XMLColorDAO : IColorDAO
    {
        public string XmlColorFilePath { get; set; }
        public Color Color { get; set; }
        


        public void Save ( Color color )
        {
            this.Color = color;

            if ( isTableExists () == false )
            {
                createTable ();
            }                           

            if ( isColorExists () == false )
            {
                saveColor ();   
            }                                               
        }



        private bool isTableExists ()
        {      
            int lastId = getLastId ();        

            if ( lastId == 0 )
            {
                return false;
            }
            return true;               
        }



        private int getLastId ()
        {
            try
            {
                if ( File.Exists ( XmlColorFilePath ) == true )
                {
                    XDocument doc = XDocument.Load ( this.XmlColorFilePath );

                    if ( doc.Root.Elements ( "Color" ).Count () > 0 )
                    {
                        return int.Parse ( doc.Root.Elements ( "Color" ).Elements ( "Id" ).Last ().Value );
                    }

                    return 0;
                }
                return 0;
            }
            catch ( Exception ex )
            {
                MessageBox.Show ( ex.Message );
                return 0;
            }
        }



        private void createTable ()
        {
            try
            {
                XDocument doc = new XDocument ( new XElement ( "Colors" ) );
                doc.Save ( this.XmlColorFilePath );
            }
            catch ( Exception ex)
            {
                MessageBox.Show ( ex.Message );
            }
        }



        private bool isColorExists ()
        {                                            
            IEnumerable<int> colorS = 
                 
                            from color in XDocument .Load ( this.XmlColorFilePath )
                                                    .Descendants ( "Color" )         
                            where ( string ) color.Element ( "Name" ) == this.Color.Name  
                            select int.Parse ( color.Element ( "Id" ) .Value );

            int first = colorS.FirstOrDefault ();
                                
            if ( first == 0 )
            {
                return false;
            }

            this.Color.Id = first;
            return true;
        }

                        

        private void saveColor ()
        {
            try
            {                   
                this.Color.Id = getLastId () + 1;

                XDocument doc = XDocument.Load ( this.XmlColorFilePath );

                XElement colorNode = new XElement ( "Color",
                                    new XElement ( "Id", Color.Id ),
                                    new XElement ( "Name", Color.Name ) );

                doc.Root.Add ( colorNode );
                doc.Save ( this.XmlColorFilePath );
            }
            catch ( Exception ex)
            {
                MessageBox.Show ( ex.Message );
            }
        }



        public Collection<Color> FindAll ()
        {
            if ( isTableExists () == false )
            {                                                                          
                return new Collection<Color>();
            }
            return readColors ();
        }



        private Collection<Color> readColors ()
        {
            Collection<Color> colorS = new Collection<Color> ();

            IEnumerable<Color> colorCollection = from color in XDocument.Load ( this.XmlColorFilePath )
                                                            .Descendants ( "Color" )
                                    select new Color
                                    {
                                        Id = ( int ) color.Element ( "Id" ),              
                                        Name = ( string ) color.Element ( "Name" )
                                    };

            foreach ( Color color in colorCollection )
            {
                colorS.Add ( color );
            }
            return colorS;
        }
    }
}                           