IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'HYPERCARE' AND TABLE_NAME = 'HyperCareScheduler')
BEGIN
    CREATE TABLE [HYPERCARE].[HyperCareScheduler](
        [HcSchId] [int] IDENTITY(1,1) NOT NULL,
        [SchedulerName] [varchar](150) NULL,
        [SchedulerDesc] [varchar](250) NULL,
        [StartDate] [datetime] NULL,
        [EndDate] [datetime] NULL,
        [ScheduleTime] [datetime] NULL,
        [CreatedDate] [datetime] NOT NULL DEFAULT GETDATE(),
        [CreatedUser] [varchar](50) NOT NULL,
        [UpdatedDate] [datetime] NOT NULL DEFAULT GETDATE(),
        [UpdatedUser] [varchar](50) NULL,
        [IsActive] [bit] NOT NULL DEFAULT ((1)),
        [Frequency] [varchar](10) NULL,
        [FrequencyStartDay] [tinyint] NULL,
        [FrequencyEndDay] [tinyint] NULL,
        [FrequencyStartDayName] [varchar](10) NULL,
        [IsOneOff] [bit] NULL,
        CONSTRAINT [Pk_HyperCareSchedulerr_HcSchId] PRIMARY KEY CLUSTERED 
        (
            [HcSchId] ASC
        ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    );
END