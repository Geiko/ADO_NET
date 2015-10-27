using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemDb.Entities
{
    public class Gem
    {
        public Color Color { get; set; }                     

        public int Id { get; set; }                  
        public int ColorId { get; set; }

        public string Name { get; set; }               
        public bool Transparency   { get; set; }       
        public Types Type  { get; set; }               
        public string Description { get; set; }



        public Gem ()
        {
            this.Id = -1;
            this.ColorId = -1;
            this.Name = "unknown";
            this.Transparency = false;
            this.Type = Gem.Types.UNKNOWN;
            this.Description = string.Empty;        
        }



        public enum Types
        {
            ORNAMENTAL, SEMIPRECIOUS, PRECIOUS, UNKNOWN
        };
    }
}
                                            