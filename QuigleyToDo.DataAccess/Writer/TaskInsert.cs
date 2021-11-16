using QuigleyToDo.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;

namespace QuigleyToDo.DataAccess.Writer
{
    public class TaskInsert : SqlObjectWriter
    {
        #region FIELDS

        string _connString;
        QTDTask _task;
        string _appUser;

        //string _taskDesc;
        //DateTime _dueDate;
       
        //int _taskStatusID;
        //int _reminderID;
        //DateTime? _finishDate;

        #endregion

        #region CTOR

        public TaskInsert(string connString, QTDTask t, string appUser)
        {
            _connString = connString;
            _appUser = appUser;

            _task = new QTDTask()
            {
                TaskID = t.TaskID,
                TaskDesc = t.TaskDesc,
                StartDate = t.StartDate,
                FinishDate = t.FinishDate,
                DueDate = t.DueDate,
                AppUserID = t.AppUserID,
                TaskStatusID = t.TaskStatusID,
                ReminderID = t.ReminderID,
                TaskStatus = t.TaskStatus,
                Reminder = t.Reminder
            };
        }

        #endregion
        protected override string CommandText
        {
            get { return "[qtd].[SaveTask]"; }
        }
        protected override CommandType CommandType
        {
            get { return System.Data.CommandType.StoredProcedure; }
        }
        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            Collection<IDataParameter> collection = new Collection<IDataParameter>();
            collection.Add(GetParameter(command, "@taskDesc", _task.TaskDesc));
            collection.Add(GetParameter(command, "@dueDate", _task.DueDate));
            collection.Add(GetParameter(command, "@finishDate", _task.FinishDate));
            collection.Add(GetParameter(command, "@appUser", _appUser));
            collection.Add(GetParameter(command, "@taskStatusID", _task.TaskStatusID));
            collection.Add(GetParameter(command, "@reminderID", _task.ReminderID));

            return collection;
        }
        protected override string ConnectionString
        {
            get { return _connString; }
        }
    }
}
