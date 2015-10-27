using System.Collections.ObjectModel;

namespace GemDb.Interface
{
    public interface IDAO<T>
    {
        Collection<T> FindAll ();
    }
}
