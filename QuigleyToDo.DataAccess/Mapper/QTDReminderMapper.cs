using QuigleyToDo.DataAccess.Model;
using QuigleyToDo.DataAccess.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace QuigleyToDo.DataAccess.Mapper
{   public class QTDReminderMapper : MapperBase<QTDReminder>
    {
        protected override QTDReminder Map(IDataRecord record)
        {
            QTDReminder item = new QTDReminder();
            item.ReminderID = FieldHelper.GetInt(record["ReminderID"]);
            item.ReminderScheduleDesc = FieldHelper.GetString(record["ReminderScheduleDesc"]);
            return item;
        }
    }
}
