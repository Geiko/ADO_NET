using System.Collections.ObjectModel;
using GemDb.Entities;

namespace GemDb.Interface
{
    public interface IColorDAO : IDAO<Color>
    {
        void Save ( Color color );    
    }
}
