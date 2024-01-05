IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'HYPERCARE' AND TABLE_NAME = 'HypercareResponsibleTeam')
BEGIN
    CREATE TABLE [HYPERCARE].[HypercareResponsibleTeam](
        [SNo] [int] IDENTITY(1,1) NOT NULL,
        [Module] [nvarchar](100) NULL,
        [ResponsibleTeam] [nvarchar](100) NULL,
        [ActionType] [nvarchar](100) NULL,
        [NumberOfTasks] [int] NULL,
        [OnsiteTeam] [nvarchar](100) NULL,
        [PrimaryResource] [nvarchar](100) NULL,
        [SecondaryResource] [nvarchar](100) NULL,
        [CreatedDate] [datetime] NOT NULL DEFAULT GETDATE(),
        [CreatedUser] [nvarchar](50) NOT NULL,
        [UpdatedDate] [datetime] NOT NULL DEFAULT GETDATE(),
        [UpdatedUser] [nvarchar](50) NULL,
        CONSTRAINT [PK_HypercareResponsibleTeam_SNo] PRIMARY KEY CLUSTERED 
        (
            [SNo] ASC
        ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY];
END