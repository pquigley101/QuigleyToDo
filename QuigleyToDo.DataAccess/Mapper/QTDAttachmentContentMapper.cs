using QuigleyToDo.DataAccess.Model;
using QuigleyToDo.DataAccess.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace QuigleyToDo.DataAccess.Mapper
{
    public class QTDAttachmentContentMapper : MapperBase<QTDAttachmentContent>
    {
        protected override QTDAttachmentContent Map(IDataRecord record)
        {
            QTDAttachmentContent item = new QTDAttachmentContent();
            item.TaskAttachmentID = FieldHelper.GetInt(record["TaskAttachmentID"]);
            item.ContentBytes = record["ContentBytes"] as byte[];
            return item;
        }
    }
}
