using System.Collections.ObjectModel;

namespace geiko.ADO_NET_3.DataAccessObject
{
    public interface IDAO<T>
    {                
        Collection<T> FindAll ();
    }
}
