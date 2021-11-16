--CREATE SCHEMA qtd

-- ************************************** [dbo].[AppUser]
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'AppUser' AND TABLE_SCHEMA = 'dbo')
	DROP TABLE [dbo].[AppUser];
CREATE TABLE [dbo].[AppUser]
(
 [AppUsername]    varchar(50) NOT NULL ,
 [Firstname]      varchar(100) NOT NULL ,
 [Lastname]       varchar(100) NOT NULL ,
 [CreatedOn]      datetime NOT NULL ,
 [LastModifiedOn] datetime NOT NULL ,
 [CreatedBy]      varchar(100) NOT NULL ,
 [LastModifiedBy] varchar(100) NOT NULL ,
 [AppUserID]      int IDENTITY (1, 1) NOT NULL ,


 CONSTRAINT [PK_17] PRIMARY KEY CLUSTERED ([AppUserID] ASC)
);
GO


-- ************************************** [qtd].[LookUpTaskStatus]
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'LookUpTaskStatus' AND TABLE_SCHEMA = 'qtd')
	DROP TABLE [qtd].[LookUpTaskStatus];
CREATE TABLE [qtd].[LookUpTaskStatus]
(
 [TaskStatusID]   int IDENTITY (1, 1) NOT NULL ,
 [TaskStatusCode] varchar(30) NOT NULL ,
 [TaskStatusDesc] varchar(30) NOT NULL ,


 CONSTRAINT [PK_46] PRIMARY KEY CLUSTERED ([TaskStatusID] ASC)
);
GO


-- ************************************** [qtd].[Reminder]
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Reminder' AND TABLE_SCHEMA = 'qtd')
	DROP TABLE [qtd].[Reminder];
CREATE TABLE [qtd].[Reminder]
(
 [ReminderID]           int IDENTITY (1, 1) NOT NULL ,
 [ReminderScheduleCode] varchar(30) NOT NULL ,
 [ReminderScheduleDesc] varchar(100) NOT NULL ,


 CONSTRAINT [PK_89] PRIMARY KEY CLUSTERED ([ReminderID] ASC)
);
GO


-- ************************************** [qtd].[Task]
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Task' AND TABLE_SCHEMA = 'qtd')
	DROP TABLE [qtd].[Task];
CREATE TABLE [qtd].[Task]
(
 [TaskDesc]     varchar(512) NOT NULL ,
 [StartDate]    date NULL ,
 [FinishDate]   date NULL ,
 [DueDate]      date NULL ,
 [AppUserID]    int NOT NULL ,
 [TaskStatusID] int NOT NULL ,
 [ReminderID]   int NOT NULL ,
 [TaskID]       int IDENTITY (1, 1) NOT NULL ,


 CONSTRAINT [PK_21] PRIMARY KEY CLUSTERED ([TaskID] ASC),
 CONSTRAINT [FK_50] FOREIGN KEY ([TaskStatusID])  REFERENCES [qtd].[LookUpTaskStatus]([TaskStatusID]),
 CONSTRAINT [FK_93] FOREIGN KEY ([ReminderID])  REFERENCES [qtd].[Reminder]([ReminderID]),
 CONSTRAINT [FK_AppUser_Task] FOREIGN KEY ([AppUserID])  REFERENCES [dbo].[AppUser]([AppUserID])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_35] ON [qtd].[Task] 
 (
  [AppUserID] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_52] ON [qtd].[Task] 
 (
  [TaskStatusID] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_95] ON [qtd].[Task] 
 (
  [ReminderID] ASC
 )

GO


-- ************************************** [qtd].[TaskAttachment]
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'TaskAttachment' AND TABLE_SCHEMA = 'qtd')
	DROP TABLE [qtd].[TaskAttachment];
CREATE TABLE [qtd].[TaskAttachment]
(
 [TaskID]                 int NOT NULL ,
 [TaskAttachmentLink]     varchar(100) NOT NULL ,
 [TaskAttachmentFileName] varchar(100) NOT NULL ,
 [TaskAttachmentID]       int IDENTITY (1, 1) NOT NULL ,


 CONSTRAINT [PK_55] PRIMARY KEY CLUSTERED ([TaskAttachmentID] ASC),
 CONSTRAINT [FK_56] FOREIGN KEY ([TaskID])  REFERENCES [qtd].[Task]([TaskID])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_58] ON [qtd].[TaskAttachment] 
 (
  [TaskID] ASC
 )

GO


-- ************************************** [qtd].[TaskStep]
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'TaskStep' AND TABLE_SCHEMA = 'qtd')
	DROP TABLE [qtd].[TaskStep];
CREATE TABLE [qtd].[TaskStep]
(
 [TaskID]       int NOT NULL ,
 [TaskStepDesc] varchar(512) NOT NULL ,
 [IsComplete]   bit NOT NULL ,
 [TaskStepID]   int IDENTITY (1, 1) NOT NULL ,


 CONSTRAINT [PK_38] PRIMARY KEY CLUSTERED ([TaskStepID] ASC),
 CONSTRAINT [FK_39] FOREIGN KEY ([TaskID])  REFERENCES [qtd].[Task]([TaskID])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_41] ON [qtd].[TaskStep] 
 (
  [TaskID] ASC
 )

GO


/*
	EXEC [qtd].[GetTasks]
		@appUser = 'pquigley',
		@dueDate = '11/16/2021',
		@taskStatus = NULL
		
*/
CREATE OR ALTER PROCEDURE [qtd].[GetTasks]
	@appUser VARCHAR(50),
	@dueDate DATE,
	@taskStatus INT = NULL
AS
BEGIN
	SELECT 
		TaskID,
		TaskDesc,
		StartDate,
        FinishDate,
        DueDate,
		t.AppUserID,
		t.TaskStatusID,
		t.ReminderID,
		s.TaskStatusDesc AS TaskStatus,
		r.ReminderScheduleDesc
	FROM
		[qtd].[Task] t
			INNER JOIN [dbo].[AppUser] au ON au.AppUserID = t.AppUserID
			INNER JOIN [qtd].[LookUpTaskStatus] s ON t.TaskStatusID = s.TaskStatusID
			LEFT OUTER JOIN [qtd].[Reminder] r ON r.ReminderID = t.ReminderID
	WHERE
		au.AppUsername = @appUser
		AND
		t.DueDate <= @dueDate
		AND
		( @taskStatus IS NULL OR t.TaskStatusID = @taskStatus )
END



