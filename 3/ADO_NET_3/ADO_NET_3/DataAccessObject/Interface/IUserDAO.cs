using geiko.ADO_NET_3.Entities;

namespace geiko.ADO_NET_3.DataAccessObject.Interface
{
    public interface IUserDAO : IDAO<User>
    {                                           
        void Save ( User user );
        bool isLoginExists ( User user );
        void Delete ( User user );
        int ReferenceToThisContact ( User user );
        void Update ( User user );
    }
}
