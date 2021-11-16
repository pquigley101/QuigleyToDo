using QuigleyToDo.DataAccess.Model;
using QuigleyToDo.DataAccess.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace QuigleyToDo.DataAccess.Mapper
{
    public class QTDAttachmentMapper : MapperBase<QTDAttachment>
    {   
        protected override QTDAttachment Map(IDataRecord record)
        {
            QTDAttachment item = new QTDAttachment();
            item.TaskID = FieldHelper.GetInt(record["TaskID"]);
            item.TaskAttachmentID = FieldHelper.GetInt(record["TaskAttachmentID"]);
            item.TaskAttachmentLink = FieldHelper.GetString(record["TaskAttachmentLink"]);
            item.TaskAttachmentFileName = FieldHelper.GetString(record["TaskAttachmentFileName"]);
            item.DateCreated = FieldHelper.GetDateTime(record["DateCreated"]);
            item.ContentBytes = record["ContentBytes"] as byte[];
            item.FileType = FieldHelper.GetString(record["FileType"]);
            item.FileSize = FieldHelper.GetLong(record["FileSize"]);
            item.TaskAttachmentLinkFriendly = FieldHelper.GetString(record["TaskAttachmentLinkFriendly"]);

            return item;
        }
    }
}
