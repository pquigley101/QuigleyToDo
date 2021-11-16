using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace QuigleyToDo.DataAccess.Writer
{
    public abstract class SqlObjectWriter : ObjectWriterBase
    {
        protected override System.Data.IDbConnection GetConnection()
        {
            IDbConnection connection = new SqlConnection(ConnectionString);
            return connection;
        }
    }
}
