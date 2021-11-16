﻿using QuigleyToDo.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;
using QuigleyToDo.DataAccess.Mapper;

namespace QuigleyToDo.DataAccess.Reader
{
    public class QTDReminderReader : SqlObjectReader<QTDReminder>
    {
        #region FIELDS

        string _connString;

        #endregion

        #region CTOR

        public QTDReminderReader(string connString)
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
            get { return "[qtd].[GetRemiderOptions]"; }
        }

        protected override CommandType CommandType
        {
            get { return System.Data.CommandType.StoredProcedure; }
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            return new Collection<IDataParameter>();
        }

        protected override MapperBase<QTDReminder> GetMapper()
        {
            MapperBase<QTDReminder> mapper = new QTDReminderMapper();
            return mapper;
        }
    }
}
