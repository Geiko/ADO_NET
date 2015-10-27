using System.Collections.ObjectModel;
using GemDb.Entities;

namespace GemDb.Interface
{
    public interface IGemDAO : IDAO<Gem>
    {
        void Save ( Gem gem );       
    }
}
