IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'HISTORY' AND TABLE_NAME = 'HypercareResponsibleTeam_History')
BEGIN
    CREATE TABLE [HISTORY].[HypercareResponsibleTeam_History](
        [HistoryID] [int] IDENTITY(1,1) NOT NULL,
        [MainTableSNo] [int] NOT NULL,  
        [Module] [nvarchar](100) NULL,
        [ResponsibleTeam] [nvarchar](100) NULL,
        [ActionType] [nvarchar](100) NULL,
        [NumberOfTasks] [int] NULL,
        [OnsiteTeam] [nvarchar](100) NULL,
        [PrimaryResource] [nvarchar](100) NULL,
        [SecondaryResource] [nvarchar](100) NULL,
        [EffectiveStartDate] [datetime] NOT NULL,
        [EffectiveEndDate] [datetime] NULL,
        [CreatedDate] [datetime] NOT NULL DEFAULT GETDATE(),
        [CreatedUser] [nvarchar](50) NOT NULL,
        CONSTRAINT [PK_HypercareResponsibleTeam_History] PRIMARY KEY CLUSTERED 
        (
            [HistoryID] ASC
        ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]
END