using System;
using System.Collections.Generic;
using System.Text;

namespace QuigleyToDo.DataAccess.Model
{
    public class QTDTaskAlert
    {
        public int TaskID { get; set; }
        public int ReminderID { get; set; }
        public string TaskDesc { get; set; }
        public DateTime DueDate { get; set; }
        public string AppUser { get; set; }
        public bool IsDismissed { get; set; }

    }
}
