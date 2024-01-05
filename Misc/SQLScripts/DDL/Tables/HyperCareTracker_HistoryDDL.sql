IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'HISTORY' AND TABLE_NAME = 'HyperCareTracker_History')
BEGIN
    CREATE TABLE [HISTORY].[HyperCareTracker_History](
        [HisId] [bigint] IDENTITY(1,1) NOT NULL,
        [HcId] [bigint] NULL,
        [HcTaskId] [int] NULL,
        [HcSchId] [int] NULL,
        [ResponsibleTeam] [varchar](50) NULL,
        [ExecutionDate] [date] NULL,
        [ExecutionTime] [time](7) NULL,
        [RecordCount] [int] NULL,
        [Priority] [varchar](10) NULL,
        [CreatedDate] [datetime] NOT NULL,
        [CreatedUser] [varchar](50) NOT NULL,
        [HisDate] [datetime] NOT NULL DEFAULT GETDATE(),
        [IsThresholdCrossing] [bit] NULL,
        [IsEmailSent] [bit] NULL,
        [IsIncidentCreated] [bit] NULL,
        [RecordDescr] [varchar](250) NULL,
        CONSTRAINT [Pk_HyperCareTracker_HisId] PRIMARY KEY CLUSTERED 
        (
            [HisId] ASC
        ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    );
END