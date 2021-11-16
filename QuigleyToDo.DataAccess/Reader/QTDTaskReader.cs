using QuigleyToDo.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;
using QuigleyToDo.DataAccess.Mapper;

namespace QuigleyToDo.DataAccess.Reader
{
    public class QTDTaskReader : SqlObjectReader<QTDTask>
    {
        #region FIELDS

        string _appUser;
        bool _showAll;
        string _connString;
        
        #endregion

        #region CTOR

        public QTDTaskReader(string appUser, bool showAll, string connString)
        {
            _appUser = appUser;
            _showAll = showAll;
            _connString = connString;
        }

        #endregion
        protected override string ConnectionString
        {
            get { return _connString; }
        }

        protected override string CommandText
        {
            get { return "[qtd].[GetTasks]"; }
        }

        protected override CommandType CommandType
        {
            get { return System.Data.CommandType.StoredProcedure; }
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            Collection<IDataParameter> collection = new Collection<IDataParameter>();

            IDataParameter param1 = command.CreateParameter();
            param1.ParameterName = "@appUser";
            param1.Value = _appUser;
            collection.Add(param1);

            IDataParameter param2 = command.CreateParameter();
            param2.ParameterName = "@showAll";
            param2.Value = _showAll;
            collection.Add(param2);

            return collection;
        }

        protected override MapperBase<QTDTask> GetMapper()
        {
            MapperBase<QTDTask> mapper = new QTDTaskMapper();
            return mapper;
        }

        
    }
}
