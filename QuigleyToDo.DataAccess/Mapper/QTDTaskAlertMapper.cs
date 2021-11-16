using QuigleyToDo.DataAccess.Model;
using QuigleyToDo.DataAccess.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace QuigleyToDo.DataAccess.Mapper
{
    public class QTDTaskAlertMapper : MapperBase<QTDTaskAlert>
    {
        protected override QTDTaskAlert Map(IDataRecord record)
        {
            QTDTaskAlert item = new QTDTaskAlert();
            item.TaskID = FieldHelper.GetInt(record["TaskID"]);
            item.TaskDesc = FieldHelper.GetString(record["TaskDesc"]);
            item.ReminderID = FieldHelper.GetInt(record["ReminderID"]);
            item.AppUser = FieldHelper.GetString(record["AppUsername"]);
            item.DueDate = FieldHelper.GetDateTime(record["DueDate"]);
            return item;
        }
    }
}
