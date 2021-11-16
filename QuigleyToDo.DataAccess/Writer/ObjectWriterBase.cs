using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;

namespace QuigleyToDo.DataAccess.Writer
{
    public enum WriterOperation { Insert, Update, Delete }
    
    public abstract class ObjectWriterBase
    {
        protected abstract IDbConnection GetConnection();
        protected abstract string CommandText { get; }
        protected abstract CommandType CommandType { get; }
        protected abstract Collection<IDataParameter> GetParameters(IDbCommand command);
        protected abstract string ConnectionString { get; }
        public void ExecuteNonQuery()
        {
            using (IDbConnection connection = GetConnection())
            {
                IDbCommand command = connection.CreateCommand();
                command.Connection = connection;
                command.CommandText = this.CommandText;
                command.CommandType = this.CommandType;

                foreach (IDataParameter param in this.GetParameters(command))
                    command.Parameters.Add(param);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public object ExecuteScalar()
        {
            using (IDbConnection connection = GetConnection())
            {
                IDbCommand command = connection.CreateCommand();
                command.Connection = connection;
                command.CommandText = this.CommandText;
                command.CommandType = this.CommandType;

                foreach (IDataParameter param in this.GetParameters(command))
                    command.Parameters.Add(param);

                try
                {
                    connection.Open();
                    return command.ExecuteScalar();
                }
                catch
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
       protected IDataParameter GetParameter(IDbCommand command, string paramName, object paramValue)
       {
            IDataParameter param1 = command.CreateParameter();
            param1.ParameterName = paramName;
            param1.Value = paramValue;
            return param1;
        }

    }
}
