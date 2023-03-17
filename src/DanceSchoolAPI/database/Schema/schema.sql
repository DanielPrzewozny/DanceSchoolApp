CREATE TABLE dbo.Version
	(
	Id bigint IDENTITY(1,1) NOT NULL,
	Version bigint NOT NULL,
	IsValid bit NULL,
	ModifiedOn datetimeoffset(7) NULL,
	ModifiedBy bigint NULL,
	CreatedOn datetimeoffset(7) NULL,
	CreatedBy bigint NULL,
 CONSTRAINT PK_Version PRIMARY KEY CLUSTERED 
(
	Id ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY];

INSERT INTO dbo.Version (Version, IsValid, ModifiedOn, ModifiedBy, CreatedOn, CreatedBy) VALUES ('0', 1, GETDATE(), 0, GETDATE(), 0);

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

CREATE TABLE dbo.Apprentices
	(
	Id bigint IDENTITY(1,1) NOT NULL,
	UserId bigint NULL,
	Name varchar(50) NULL,
	Surname varchar(50) NULL,
	City varchar(50) NULL,
	Country varchar(50) NULL,
	ClubCardId varchar(50) NULL,
	IsValid bit NULL,
	ModifiedOn datetimeoffset(7) NULL,
	ModifiedBy bigint NULL,
	CreatedOn datetimeoffset(7) NULL,
	CreatedBy bigint NULL,
	Role varchar(50) NULL,
	DanceGroup varchar(50) NULL,
 CONSTRAINT PK_Apprentices PRIMARY KEY CLUSTERED 
(
	Id ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY];

CREATE TABLE dbo.ClubCards(
	Id bigint IDENTITY(1,1) NOT NULL,
	UserId bigint NULL,
	DanceGroup varchar(50) NULL,
	ValidFromDate datetimeoffset(7) NULL,
	ExpirationDate datetimeoffset(7) NULL,
	IsValid bit NOT NULL,
	ModifiedOn datetimeoffset(7) NULL,
	ModifiedBy bigint NULL,
	CreatedOn datetimeoffset(7) NULL,
	CreatedBy bigint NULL,
 CONSTRAINT PK_ClubCards PRIMARY KEY CLUSTERED 
(
	Id ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY];

CREATE TABLE dbo.Teachers (
	Id bigint IDENTITY(1,1) NOT NULL,
	UserId bigint NULL,
	Name varchar (50) NULL,
	Surname varchar (50) NULL,
	City varchar (50) NULL,
	Country varchar (50) NULL,
	ClubCardId varchar (50) NULL,
	IsValid bit NULL,
	ModifiedOn datetimeoffset (7) NULL,
	ModifiedBy bigint NULL,
	CreatedOn datetimeoffset (7) NULL,
	CreatedBy bigint NULL,
	DanceGroup varchar (50) NULL,
	Role varchar (50) NULL,
 CONSTRAINT PK_Teachers PRIMARY KEY CLUSTERED 
(
	Id ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY];