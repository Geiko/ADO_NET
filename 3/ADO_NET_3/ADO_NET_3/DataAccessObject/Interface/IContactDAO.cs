using geiko.ADO_NET_3.Entities;

namespace geiko.ADO_NET_3.DataAccessObject.Interface
{
    public interface IContactDAO : IDAO<Contact>
    {                                             
        void Save ( Contact contact );
        void Delete ( Contact contact );
        int Update ( User user );
        void Delete ( int idToDelete );
    }
}
