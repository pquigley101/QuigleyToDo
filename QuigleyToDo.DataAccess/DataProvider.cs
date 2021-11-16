using Microsoft.Extensions.Configuration;
using QuigleyToDo.DataAccess.Model;
using QuigleyToDo.DataAccess.Reader;
using QuigleyToDo.DataAccess.Writer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace QuigleyToDo.DataAccess
{
    public class DataProvider
    {
        private readonly IConfiguration _config;
        private string _connStr;

        public string ConnectionStringName { get; set; } = "Default";
        public DataProvider(IConfiguration config)
        {
            _config = config;
            _connStr = _config.GetConnectionString(ConnectionStringName);
        }
        public Collection<QTDTask> GetTasks(string appUser, bool showAll)
        {
            QTDTaskReader r = new QTDTaskReader(appUser, showAll, _connStr);
            return r.Execute();
        }

        public Collection<QTDReminder> GetReminders()
        {
            QTDReminderReader r = new QTDReminderReader(_connStr);
            return r.Execute();
        }

        public Collection<QTDTaskStatus> GetTaskStatusOptions()
        {
            QTDTaskStatusReader r = new QTDTaskStatusReader(_connStr);
            return r.Execute();
        }
        public int SaveTask(string appUser, QTDTask t)
        {
            TaskInsert tw = new TaskInsert(_connStr, t, appUser);
            object newTaskID = tw.ExecuteScalar();

            if (newTaskID == null)
                throw new Exception("Task saved. Refresh grid to continue");

            int actualTaskID = 0;
            bool isValid = int.TryParse(newTaskID.ToString(), out actualTaskID);

            if (isValid == false)
                throw new Exception("Task saved. Refresh grid to continue");

            return actualTaskID;
        }

        public void EditTask(string appUser, QTDTask t)
        {
            TaskUpdate tu = new TaskUpdate(_connStr, t, appUser);
            tu.ExecuteNonQuery();
        }

        public void DeleteTask(string appUser, int taskID)
        {
            TaskDelete tu = new TaskDelete(_connStr, taskID, appUser);
            tu.ExecuteNonQuery();
        }

        public Collection<QTDAttachment> GetTaskAttachments(int taskID)
        {
            QTDAttachmentReader r = new QTDAttachmentReader(_connStr, taskID);
            return r.Execute();
        }

        public int SaveAttachment(QTDAttachment t)
        {
            AttachmentInsert tw = new AttachmentInsert(_connStr, t);
            object newID = tw.ExecuteScalar();

            if (newID == null)
                throw new Exception("Attachment saved");

            int actualID = 0;
            bool isValid = int.TryParse(newID.ToString(), out actualID);

            if (isValid == false)
                throw new Exception("Attachment saved. Refresh grid to continue");

            return actualID;
        }

        public byte[] GetAtachmentContent(int taskAttachmentID)
        {
            QTDAttachmentContentReader r = new QTDAttachmentContentReader(_connStr, taskAttachmentID);
            Collection<QTDAttachmentContent> fileContent = r.Execute();
            if ((fileContent != null) && (fileContent.Count > 0))
                return fileContent[0].ContentBytes;
            else
                return null;
        }
        public Collection<QTDTaskAlert> GetTaskAlerts(string appUser)
        {
            QTDTaskAlertReader r = new QTDTaskAlertReader(_connStr, appUser);
            return r.Execute();
        }

    }
}
