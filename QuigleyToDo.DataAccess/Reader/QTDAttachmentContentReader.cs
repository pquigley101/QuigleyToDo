using QuigleyToDo.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;
using QuigleyToDo.DataAccess.Mapper;

namespace QuigleyToDo.DataAccess.Reader
{
    public class QTDAttachmentContentReader : SqlObjectReader<QTDAttachmentContent>
    {
        #region FIELDS

        string _connString;
        int? _reqAttachmentID;

        #endregion

        #region CTOR

        public QTDAttachmentContentReader(string connString, int? attachmentID = null)
        {
            _connString = connString;
            _reqAttachmentID = attachmentID;
        }

        #endregion
        protected override string ConnectionString
        {
            get { return _connString; }
        }

        protected override string CommandText
        {
            get { return "[qtd].[GetAttachmentContent]"; }
        }

        protected override CommandType CommandType
        {
            get { return System.Data.CommandType.StoredProcedure; }
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            var collection = new Collection<IDataParameter>();
            if (_reqAttachmentID.HasValue)
            {
                IDataParameter param1 = command.CreateParameter();
                param1.ParameterName = "@taskAttachmentID";
                param1.Value = _reqAttachmentID;
                collection.Add(param1);
            }

            return collection;
        }

        protected override MapperBase<QTDAttachmentContent> GetMapper()
        {
            MapperBase<QTDAttachmentContent> mapper = new QTDAttachmentContentMapper();
            return mapper;
        }
    }
}
