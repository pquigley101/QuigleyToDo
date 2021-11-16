using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace QuigleyToDo.DataAccess.Reader
{
    public abstract class SqlObjectReader<T> : ObjectReaderBase<T>
    {   
        protected override System.Data.IDbConnection GetConnection()
        {
            IDbConnection connection = new SqlConnection(ConnectionString);
            return connection;
        }
    }
}
