IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'HYPERCARE' AND TABLE_NAME = 'HypercareTaskSchedulerMap')
BEGIN
    CREATE TABLE [HYPERCARE].[HypercareTaskSchedulerMap](
        [HcTsId] [bigint] IDENTITY(1,1) NOT NULL,
        [HcTaskId] [int] NOT NULL,
        [HcSchId] [int] NOT NULL,
        [CreatedDate] [datetime] NOT NULL DEFAULT GETDATE(),
        [CreatedUser] [varchar](50) NOT NULL DEFAULT '',
        [UpdatedDate] [datetime] NOT NULL DEFAULT GETDATE(),
        [UpdatedUser] [varchar](50) NOT NULL DEFAULT '',
        [StartDate] [datetime] NULL,
        [EndDate] [datetime] NULL,
        [IsActive] [bit] NULL DEFAULT NULL,
        CONSTRAINT [PK_HypercareTaskSchedulerMap_HcTsId] PRIMARY KEY CLUSTERED 
        (
            [HcTsId] ASC
        ),
        CONSTRAINT [FK_HypercareTaskSchedulerMap_HyperCareScheduler] FOREIGN KEY([HcSchId]) REFERENCES [HYPERCARE].[HyperCareScheduler] ([HcSchId]),
        CONSTRAINT [FK_HypercareTaskSchedulerMap_HyperCareTaskMaster] FOREIGN KEY([HcTaskId]) REFERENCES [HYPERCARE].[HyperCareTaskMaster] ([HcTaskId])
    );
END