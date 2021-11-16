using System;
using System.Collections.Generic;
using System.Text;

namespace QuigleyToDo.DataAccess.Model
{
    public class QTDTask
    {
        public int TaskID { get; set; }
        public string TaskDesc { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public DateTime DueDate { get; set; }
        public int AppUserID { get; set; }
        public int TaskStatusID { get; set; }
        public int ReminderID { get; set; }
        public string TaskStatus { get; set; }
        public string Reminder { get; set; }

        public QTDTask()
        {

        }

        public QTDTask(QTDTask src)
        {
            this.TaskID = src.TaskID;
            this.TaskDesc = src.TaskDesc;
            this.StartDate = src.StartDate;
            this.FinishDate = src.FinishDate;
            this.DueDate = src.DueDate;
            this.AppUserID = src.AppUserID;
            this.TaskStatusID = src.TaskStatusID;
            this.ReminderID = src.ReminderID;
            this.TaskStatus = src.TaskStatus;
            this.Reminder = src.Reminder;
        }
    }
}
