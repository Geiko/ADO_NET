using geiko.ADO_NET_3.Entities;
using System.Windows.Forms;

namespace geiko.ADO_NET_3.Servis
{
    public interface IUserServises
    {
        void FindAll ( ListBox listBoxUsers, bool isAll, bool isAdm );
        void Save ( UserDTO packet );                                              
        void Delete (User user);
        void Update ( UserDTO newPacket );
    }
}
