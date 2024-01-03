IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'HISTORY' AND TABLE_NAME = 'HyperCareScheduler_History')
BEGIN
    CREATE TABLE [HISTORY].[HyperCareScheduler_History](
        [HistoryID] [int] IDENTITY(1,1) NOT NULL,
        [MainTableHcSchId] [int] NOT NULL,  -- Foreign key referencing HcSchId in main table
        [SchedulerName] [varchar](150) NULL,
        [SchedulerDesc] [varchar](250) NULL,
        [StartDate] [datetime] NULL,
        [EndDate] [datetime] NULL,
        [ScheduleTime] [datetime] NULL,
        [EffectiveStartDate] [datetime] NOT NULL,
        [EffectiveEndDate] [datetime] NULL,
        [CreatedDate] [datetime] NOT NULL DEFAULT GETDATE(),
        [CreatedUser] [varchar](50) NOT NULL,
        CONSTRAINT [PK_HyperCareScheduler_History] PRIMARY KEY CLUSTERED 
        (
            [HistoryID] ASC
        ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
        CONSTRAINT [FK_HyperCareScheduler_History_MainTable] FOREIGN KEY ([MainTableHcSchId]) REFERENCES [HYPERCARE].[HyperCareScheduler]([HcSchId])
    );
END