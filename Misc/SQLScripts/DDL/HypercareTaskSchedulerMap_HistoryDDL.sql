IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'HISTORY' AND TABLE_NAME = 'HypercareTaskSchedulerMap_History')
BEGIN
    CREATE TABLE [HISTORY].[HypercareTaskSchedulerMap_History](
        [HistoryID] [bigint] IDENTITY(1,1) NOT NULL,
        [MainTableHcTsId] [bigint] NOT NULL,  -- Foreign key referencing HcTsId in main table
        [HcTaskId] [int] NOT NULL,
        [HcSchId] [int] NOT NULL,
        [CreatedDate] [datetime] NOT NULL DEFAULT GETDATE(),
        [CreatedUser] [varchar](50) NOT NULL DEFAULT '',
        [UpdatedDate] [datetime] NOT NULL DEFAULT GETDATE(),
        [UpdatedUser] [varchar](50) NOT NULL DEFAULT '',
        [StartDate] [datetime] NULL,
        [EndDate] [datetime] NULL,
        [IsActive] [bit] NULL,
        [EffectiveStartDate] [datetime] NOT NULL,
        [EffectiveEndDate] [datetime] NULL,
        CONSTRAINT [PK_HypercareTaskSchedulerMap_History] PRIMARY KEY CLUSTERED 
        (
            [HistoryID] ASC
        ),
        CONSTRAINT [FK_HypercareTaskSchedulerMap_History_MainTable] FOREIGN KEY([MainTableHcTsId]) REFERENCES [HYPERCARE].[HypercareTaskSchedulerMap] ([HcTsId]),
        CONSTRAINT [FK_HypercareTaskSchedulerMap_HyperCareScheduler_History] FOREIGN KEY([HcSchId]) REFERENCES [HISTORY].[HyperCareScheduler_History] ([HistoryID]),
        CONSTRAINT [FK_HypercareTaskSchedulerMap_HyperCareTaskMaster_History] FOREIGN KEY([HcTaskId]) REFERENCES [HISTORY].[HyperCareTaskMaster_History] ([HistoryID])
    );
END