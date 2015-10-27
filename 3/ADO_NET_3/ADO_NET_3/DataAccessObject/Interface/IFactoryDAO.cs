using System.Data.Common;             

namespace geiko.ADO_NET_3.DataAccessObject.Interface
{
    public interface IFactoryDAO
    {
        DbConnection CreateDbConnection ();
    }
}
