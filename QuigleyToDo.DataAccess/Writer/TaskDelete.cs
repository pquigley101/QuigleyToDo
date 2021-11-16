using QuigleyToDo.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;

namespace QuigleyToDo.DataAccess.Writer
{
    public class TaskDelete : SqlObjectWriter
    {
        #region FIELDS

        string _connString;
        string _appUser;
        int _taskID;

        #endregion

        #region CTOR
        public TaskDelete(string connString, int taskID, string appUser)
        {
            _connString = connString;
            _appUser = appUser;
            _taskID = taskID;
        }

        #endregion
        protected override string CommandText
        {
            get { return "[qtd].[DeleteTask]"; }
        }
        protected override CommandType CommandType
        {
            get { return System.Data.CommandType.StoredProcedure; }
        }
        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            Collection<IDataParameter> collection = new Collection<IDataParameter>();
            collection.Add(GetParameter(command, "@taskID", _taskID));
            
            return collection;
        }
        protected override string ConnectionString
        {
            get { return _connString; }
        }
    }
}
