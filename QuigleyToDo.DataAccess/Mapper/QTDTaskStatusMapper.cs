using QuigleyToDo.DataAccess.Model;
using QuigleyToDo.DataAccess.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace QuigleyToDo.DataAccess.Mapper
{
    public class QTDTaskStatusMapper : MapperBase<QTDTaskStatus>
    {
        protected override QTDTaskStatus Map(IDataRecord record)
        {
            QTDTaskStatus item = new QTDTaskStatus();
            item.TaskStatusID = FieldHelper.GetInt(record["TaskStatusID"]);
            item.TaskStatusDesc = FieldHelper.GetString(record["TaskStatusDesc"]);
            return item;
        }

            
    }
}
