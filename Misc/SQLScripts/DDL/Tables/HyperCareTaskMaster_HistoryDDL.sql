IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'HISTORY' AND TABLE_NAME = 'HyperCareTaskMaster_History')
BEGIN
    CREATE TABLE [HISTORY].[HyperCareTaskMaster_History](
        [HistoryID] [int] IDENTITY(1,1) NOT NULL,
        [MainTableHcTaskId] [int] NOT NULL, 
        [TaskName] [varchar](250) NULL,
        [TaskDesc] [varchar](250) NULL,
        [ThresholdFromRange] [int] NULL,
        [ThresholdToRange] [int] NULL,
        [CreatedDate] [datetime] NOT NULL DEFAULT GETDATE(),
        [CreatedUser] [varchar](50) NOT NULL,
        [UpdatedDate] [datetime] NOT NULL DEFAULT GETDATE(),
        [UpdatedUser] [varchar](50) NULL,
        [Priority] [varchar](20) NULL,
        [Severity] [varchar](20) NULL,
        [ModuleName] [nvarchar](100) NULL,
        [Operations] [varchar](10) NULL,
        [Purpose] [varchar](4000) NULL,
        [WhatToMonitor] [varchar](max) NULL,
        [DependsOn] [varchar](1000) NULL,
        [IsActive] [bit] NOT NULL,
        [Threshold] [varchar](15) NULL,
        [ResponsibleTeam] [nvarchar](100) NULL,
        [Operator] [varchar](5) NULL,
        [EmailTo] [varchar](500) NULL,
        [EmailCC] [varchar](500) NULL,
        [MonitoredBy] [varchar](50) NULL,
        [Method] [varchar](500) NULL,
        [Frequency] [varchar](20) NULL,
        [FrequencyCount1] [bigint] NULL,
        [FrequencyCount2] [bigint] NULL,
        [MinuteCount1] [bigint] NULL,
        [MinuteCount2] [bigint] NULL,
        [EffectiveStartDate] [datetime] NOT NULL,
        [EffectiveEndDate] [datetime] NULL,
        CONSTRAINT [PK_HyperCareTaskMaster_History] PRIMARY KEY CLUSTERED 
        (
            [HistoryID] ASC
        ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
        CONSTRAINT [FK_HyperCareTaskMaster_History_MainTable] FOREIGN KEY ([MainTableHcTaskId]) REFERENCES [HYPERCARE].[HyperCareTaskMaster]([HcTaskId])
        ON DELETE CASCADE 
    );
END