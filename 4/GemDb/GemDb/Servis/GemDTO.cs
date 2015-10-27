using GemDb.Entities;           

namespace GemDb.Servis
{
    public class GemDTO
    {
        public int Id
        { get; set; }

        public int ColorId
        { get; set; }
                                     

        public string Name                  
        { get; set; }

        public string ColorName
        { get; set; }

        public bool Transparency
        { get; set; }           

        public Gem.Types Type
        { get; set; }

        public string Description
        { get; set; }
    }
}
