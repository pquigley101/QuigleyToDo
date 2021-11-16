using QuigleyToDo.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;

namespace QuigleyToDo.DataAccess.Writer
{
    public class AttachmentInsert : SqlObjectWriter
    {
        #region FIELDS

        string _connString;
        QTDAttachment _attachment;
        string _appUser;

        #endregion

        #region CTOR

        public AttachmentInsert(string connString, QTDAttachment t)
        {
            _connString = connString;

            _attachment = new QTDAttachment()
            {
                TaskID = t.TaskID,
                TaskAttachmentLink = t.TaskAttachmentLink,
                TaskAttachmentFileName = t.TaskAttachmentFileName,
                TaskAttachmentID = t.TaskAttachmentID,
                DateCreated = t.DateCreated,
                ContentBytes = t.ContentBytes,
                FileType = t.FileType,
                FileSize = t.FileSize,
                TaskAttachmentLinkFriendly = t.TaskAttachmentLinkFriendly
            };
        }

        #endregion
        protected override string CommandText
        {
            get { return "[qtd].[SaveAttachment]"; }
        }
        protected override CommandType CommandType
        {
            get { return System.Data.CommandType.StoredProcedure; }
        }
        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            Collection<IDataParameter> collection = new Collection<IDataParameter>();
            collection.Add(GetParameter(command, "@taskID", _attachment.TaskID));
            collection.Add(GetParameter(command, "@taskAttachmentLink", _attachment.TaskAttachmentLink));
            collection.Add(GetParameter(command, "@taskAttachmentFileName", _attachment.TaskAttachmentFileName));
            collection.Add(GetParameter(command, "@dateCreated", _attachment.DateCreated));
            collection.Add(GetParameter(command, "@content", _attachment.ContentBytes));
            collection.Add(GetParameter(command, "@fileType", _attachment.FileType));
            collection.Add(GetParameter(command, "@fileSize", _attachment.FileSize));
            collection.Add(GetParameter(command, "@friendly", _attachment.TaskAttachmentLinkFriendly));

            return collection;
        }
        protected override string ConnectionString
        {
            get { return _connString; }
        }
    }
}
