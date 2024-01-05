IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'HYPERCARE' AND TABLE_NAME = 'HyperCareTracker')
BEGIN
    CREATE TABLE [HYPERCARE].[HyperCareTracker](
        [HcId] [bigint] IDENTITY(1,1) NOT NULL,
        [HcTaskId] [int] NULL,
        [HcSchId] [int] NULL,
        [ResponsibleTeam] [varchar](50) NULL,
        [ExecutionDate] [date] NULL,
        [ExecutionTime] [time](7) NULL,
        [RecordCount] [int] NULL,
        [Priority] [varchar](10) NULL,
        [CreatedDate] [datetime] NOT NULL DEFAULT GETDATE(),
        [CreatedUser] [varchar](50) NOT NULL DEFAULT '',
        [IsEmailSent] [bit] NOT NULL DEFAULT ((0)),
        [IsIncidentCreated] [bit] NOT NULL DEFAULT ((0)),
        [IsThresholdCrossing] [bit] NULL,
        [RecordDescr] [varchar](250) NULL,
        CONSTRAINT [Pk_HyperCareTracker_HcId] PRIMARY KEY CLUSTERED 
        (
            [HcId] ASC
        ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    );
END