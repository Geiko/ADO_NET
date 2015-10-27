using GemDb.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using GemDb.Entities;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;
using System.Collections.ObjectModel;

namespace GemDb.DAO.XML
{
    class XMLGemDAO : IGemDAO
    {
        public string XmlGemFilePath { get; set; }

        public Gem Gem { get; set; }



        public void Save ( Gem gem )
        {
            this.Gem = gem;

            if ( isTableExists () == false )
            {
                createTable ();
            }

            if ( isGemExists () == false )
            {
                saveGem ();
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
                if ( File.Exists ( XmlGemFilePath ) == true )
                {
                    XDocument doc = XDocument.Load ( this.XmlGemFilePath );

                    if ( doc.Root.Elements ( "Gem" ).Count () > 0 )
                    {
                        return int.Parse ( doc.Root.Elements ( "Gem" ).Elements ( "Id" ).Last ().Value );
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
                XDocument doc = new XDocument ( new XElement ( "Gems" ) );
                doc.Save ( this.XmlGemFilePath );
            }
            catch ( Exception ex )
            {
                MessageBox.Show ( ex.Message );
            }
        }



        private bool isGemExists ()
        {
            IEnumerable<int> gemS =    

                            from gem in XDocument.Load ( this.XmlGemFilePath ).Descendants ( "Gem" )

                            where ( string ) gem.Element ( "Name" ) == this.Gem.Name &&
                                  ( bool ) gem.Element ( "Transparency" ) == this.Gem.Transparency &&
                                  ( string ) gem.Element ( "Type" ) == this.Gem.Type.ToString () &&
                                  ( string ) gem.Element ( "Description" ) == this.Gem.Description

                            select int.Parse ( gem.Element ( "Id" ).Value );

            int first = gemS.FirstOrDefault ();

            if ( first == 0 )
            {
                return false;
            }

            this.Gem.Id = first;
            return true;
        }



        private void saveGem ()
        {
            try
            {                  
                this.Gem.Id = getLastId () + 1;

                XDocument doc = XDocument.Load ( this.XmlGemFilePath );

                XElement colorNode = new XElement ( "Gem",
                                    new XElement ( "Id", this.Gem.Id ),
                                    new XElement ( "ColorId", this.Gem.Color.Id ),
                                    new XElement ( "Name", this.Gem.Name ),
                                    new XElement ( "Transparency", this.Gem.Transparency ),
                                    new XElement ( "Type", this.Gem.Type ),
                                    new XElement ( "Description", this.Gem.Description ));

                doc.Root.Add ( colorNode );
                doc.Save ( this.XmlGemFilePath );    
            }
            catch ( Exception ex )
            {
                MessageBox.Show ( ex.Message );
            }
        }



        public Collection<Gem> FindAll ()
        {
            if ( isTableExists () == false )
            {                                                                         
                return new Collection<Gem>();
            }
            return readGems ();
        }



        private Collection<Gem> readGems ()
        {
            Collection<Gem> gemS = new Collection<Gem> ();

            IEnumerable<Gem> gemCollection = from gem in XDocument.Load ( this.XmlGemFilePath )
                                                            .Descendants ( "Gem" )
                                    select new Gem
                                    {
                                        Id = ( int ) gem.Element ( "Id" ),
                                        ColorId = ( int ) gem.Element ( "ColorId" ),
                                        Name = ( string ) gem.Element ( "Name" ),
                                        Transparency = ( bool ) gem.Element ( "Transparency" ),    
                                        Type = getGemType ((string) gem.Element ( "Type" )),    
                                        Description = ( string ) gem.Element ( "Description" )
                                    };

            foreach ( Gem gem in gemCollection )
            {
                gemS.Add ( gem );
            }
            return gemS;
        }



        private Gem.Types getGemType ( string gemType )
        {
            if ( gemType == "ORNAMENTAL" )
            {
                return Gem.Types.ORNAMENTAL;
            }
            else if ( gemType == "SEMIPRECIOUS" )
            {
                return Gem.Types.SEMIPRECIOUS;
            }
            else if ( gemType == "PRECIOUS" )
            {
                return Gem.Types.PRECIOUS;
            }
            return Gem.Types.UNKNOWN;
        }                
    }
}                                     
