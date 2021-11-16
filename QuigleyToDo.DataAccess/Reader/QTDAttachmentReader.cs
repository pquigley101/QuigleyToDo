using QuigleyToDo.DataAccess.Mapper;
using QuigleyToDo.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;

namespace QuigleyToDo.DataAccess.Reader
{
    public class QTDAttachmentReader : SqlObjectReader<QTDAttachment>
    {
        #region FIELDS

        string _connString;
        int _taskID;

        #endregion

        #region CTOR

        public QTDAttachmentReader(string connString, int taskId)
        {
            _connString = connString;
            _taskID = taskId;
        }

        #endregion
        protected override string ConnectionString
        {
            get { return _connString; }
        }

        protected override string CommandText
        {
            get { return "[qtd].[GetTaskAttachments]"; }
        }

        protected override CommandType CommandType
        {
            get { return System.Data.CommandType.StoredProcedure; }
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            Collection<IDataParameter> collection = new Collection<IDataParameter>();

            IDataParameter param1 = command.CreateParameter();
            param1.ParameterName = "@taskID";
            param1.Value = _taskID;
            collection.Add(param1);

            return collection;
        }

        protected override MapperBase<QTDAttachment> GetMapper()
        {
            MapperBase<QTDAttachment> mapper = new QTDAttachmentMapper();
            return mapper;
        }
    }
}
