using QuigleyToDo.DataAccess.Mapper;
using QuigleyToDo.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;

namespace QuigleyToDo.DataAccess.Reader
{
    public class QTDTaskStatusReader : SqlObjectReader<QTDTaskStatus>
    {
        #region FIELDS

        string _connString;

        #endregion

        #region CTOR

        public QTDTaskStatusReader(string connString)
        {
            _connString = connString;
        }

        #endregion
        protected override string ConnectionString
        {
            get { return _connString; }
        }

        protected override string CommandText
        {
            get { return "[qtd].[GetStatusOptions]"; }
        }

        protected override CommandType CommandType
        {
            get { return System.Data.CommandType.StoredProcedure; }
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            return new Collection<IDataParameter>();
        }

        protected override MapperBase<QTDTaskStatus> GetMapper()
        {
            MapperBase<QTDTaskStatus> mapper = new QTDTaskStatusMapper();
            return mapper;
        }
    }
}
