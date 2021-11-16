using QuigleyToDo.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using QuigleyToDo.DataAccess.Utilities;

namespace QuigleyToDo.DataAccess.Mapper
{
    public class QTDTaskMapper : MapperBase<QTDTask>
    {
        protected override QTDTask Map(IDataRecord record)
        {
            QTDTask item = new QTDTask();
            item.TaskID = FieldHelper.GetInt(record["TaskID"]);
            item.TaskDesc = FieldHelper.GetString(record["TaskDesc"]);
            item.StartDate = FieldHelper.GetNullableDateTime(record["StartDate"]);
            item.FinishDate = FieldHelper.GetNullableDateTime(record["FinishDate"]);
            item.DueDate = FieldHelper.GetDateTime(record["DueDate"]);
            item.AppUserID = FieldHelper.GetInt(record["AppUserID"]);
            item.TaskStatusID = FieldHelper.GetInt(record["TaskStatusID"]);
            item.ReminderID = FieldHelper.GetInt(record["ReminderID"]);
            item.TaskStatus = FieldHelper.GetString(record["TaskStatus"]);
            item.Reminder = FieldHelper.GetString(record["ReminderScheduleDesc"]);
            return item;
        }
    }
}
