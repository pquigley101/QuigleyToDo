using QuigleyToDo.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;
using QuigleyToDo.DataAccess.Mapper;
namespace QuigleyToDo.DataAccess.Reader
{
    public class QTDTaskAlertReader : SqlObjectReader<QTDTaskAlert>
    {
        #region FIELDS

        string _connString;
        string _appUser;

        #endregion

        #region CTOR

        public QTDTaskAlertReader(string connString, string appUser)
        {
            _connString = connString;
            _appUser = appUser;
        }

        #endregion
        protected override string ConnectionString
        {
            get { return _connString; }
        }

        protected override string CommandText
        {
            get { return "[qtd].[RunAlertSchedule]"; }
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

            return collection;
        }

        protected override MapperBase<QTDTaskAlert> GetMapper()
        {
            MapperBase<QTDTaskAlert> mapper = new QTDTaskAlertMapper();
            return mapper;
        }
    }
}
