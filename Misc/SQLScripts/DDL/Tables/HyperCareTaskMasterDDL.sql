IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'HYPERCARE' AND TABLE_NAME = 'HyperCareTaskMaster')
BEGIN
    CREATE TABLE [HYPERCARE].[HyperCareTaskMaster](
        [HcTaskId] [int] IDENTITY(1,1) NOT NULL,
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
        [IsActive] [bit] NOT NULL DEFAULT ((1)),
        [Threshold] [varchar](15) NULL,
        [ResponsibleTeam] [nvarchar](100) NULL,
        [Operator] [varchar](5) NULL,
        [EmailTo] [varchar](500) NULL,
        [EmailCC] [varchar](500) NULL,
        [MonitoredBy] [varchar](50) NULL,
        [Method] [varchar](500) NULL,
        [Frequency] [varchar](20) NULL DEFAULT (' '),
        [FrequencyCount1] [bigint] NULL DEFAULT ((0)),
        [FrequencyCount2] [bigint] NULL DEFAULT ((0)),
        [MinuteCount1] [bigint] NULL DEFAULT ((0)),
        [MinuteCount2] [bigint] NULL DEFAULT ((0)),
        CONSTRAINT [Pk_HyperCareTaskMaster_HcTaskId] PRIMARY KEY CLUSTERED 
        (
            [HcTaskId] ASC
        ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
    ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY];
END