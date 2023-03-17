CREATE TABLE dbo.Lessons
	(
	Id bigint NOT NULL IDENTITY (1, 1),
	Name varchar(50) NULL,
	TimeEst varchar(50) NULL,
	EverySpecificDayOfWeek varchar(50) NULL,
	DanceGroup varchar(50) NULL,
	Description varchar(50) NULL,
	TeacherId varchar(50) NULL,
	IsValid bit NULL,
	ModifiedOn datetimeoffset(7) NULL,
	ModifiedBy bigint NULL,
	CreatedOn datetimeoffset(7) NULL,
	CreatedBy bigint NULL
	)  ON [PRIMARY];
	
ALTER TABLE dbo.Lessons ADD CONSTRAINT
	PK_Lessons PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY];
	
ALTER TABLE dbo.Lessons SET (LOCK_ESCALATION = TABLE);