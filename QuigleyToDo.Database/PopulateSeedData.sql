DELETE FROM qtd.LookUpTaskStatus
INSERT INTO qtd.LookUpTaskStatus ( TaskStatusCode, TaskStatusDesc )
VALUES 
	('NOT_STARTED', 'Not Started'), 
	('IN_PROGRESS', 'In Progress'), 
	('COMPLETED', 'Completed'), 
	('CANCELLED', 'Cancelled'),
	('PAUSED', 'Paused')

DELETE FROM [qtd].[Reminder]
INSERT INTO [qtd].[Reminder] ( ReminderScheduleCode, ReminderScheduleDesc )
VALUES
	('ON_TIME_OF_EVENT', 'At time of event'),
	('ON_FIVE', '5 minutes before'),
	('ON_FIFTEEN', '15 minutes before'),
	('ON_THIRTY', '30 minutes before'),
	('ON_SIXTY', '1 hour before'),
	('NEVER', 'Never')





