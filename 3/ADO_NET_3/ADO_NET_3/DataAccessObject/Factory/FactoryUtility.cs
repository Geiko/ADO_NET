using System.Data.Common;

namespace geiko.ADO_NET_3.DataAccessObject.Factory
{
    class FactoryUtility
    {
        public const string SQLPROVIDER = "System.Data.SqlClient";


        public static void AddParameterWithValue ( DbCommand command, string parameterName, object parameterValue )
        {
            var parameter = command.CreateParameter ();
            parameter.ParameterName = parameterName;
            parameter.Value = parameterValue;
            command.Parameters.Add ( parameter );
        }
    }
}
