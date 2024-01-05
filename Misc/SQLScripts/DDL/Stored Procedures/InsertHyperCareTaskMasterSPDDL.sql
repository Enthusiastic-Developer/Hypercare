 /**********************************************************************************                                                                                                             
Procedure Name    : [HYPERCARE].[InsertHyperCareTaskMaster]                                   
Created By        : Nikhil                                
Created Date      : 31-12-2023                                                                                                      
Purpose           : To Insert data into InsertHyperCareTaskMaster table                             
Called From       : CareOpsManagerService                                     
***********************************************************************************                                                                                                           
Modified By            :                                       
Modified Date          :                                       
Modified Reason        :                                       
************************************************************************************                                   
Execution :  
DECLARE @Success BIT
 BEGIN TRAn EXEC HYPERCARE.[InsertHyperCareTaskMaster] 'Escheatment job failed','Escheatment job failed',1000,2000,'High','Critical','Account Mgmt','Day1',NULL,NULL,NULL,1,24,NULL,'>','TEST@TEST.COM',NULL,NULL,NULL,NULL,0,0,0,0,'MASTERDATA','MASTERDATA',@Success OUTPUT
 SELECT @Success AS OutputParam1      
***********************************************************************************/
CREATE OR ALTER PROCEDURE HYPERCARE.InsertHyperCareTaskMaster
    @TaskName NVARCHAR(MAX),
    @TaskDesc NVARCHAR(MAX),
    @ThresholdFromRange INT,
    @ThresholdToRange INT,
    @Priority varchar(20),
    @Severity varchar(20),
    @ModuleName NVARCHAR(MAX),
    @Operations NVARCHAR(MAX),
    @Purpose NVARCHAR(MAX),
    @WhatToMonitor NVARCHAR(MAX),
    @DependsOn NVARCHAR(MAX),
    @IsActive BIT,
    @Threshold INT,
    @ResponsibleTeam NVARCHAR(MAX),
    @Operator NVARCHAR(MAX),
    @EmailTo NVARCHAR(MAX),
    @EmailCC NVARCHAR(MAX),
    @MonitoredBy NVARCHAR(MAX),
    @Method NVARCHAR(MAX),
    @Frequency NVARCHAR(MAX),
    @FrequencyCount1 INT,
    @FrequencyCount2 INT,
    @MinuteCount1 INT,
    @MinuteCount2 INT,
    @CreatedUser NVARCHAR(MAX),
    @UpdatedUser NVARCHAR(MAX),
    @Success BIT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        -- Insert into the main table
        INSERT INTO HYPERCARE.HyperCareTaskMaster
        (
            TaskName,
            TaskDesc,
            ThresholdFromRange,
            ThresholdToRange,
            CreatedDate,
            CreatedUser,
            UpdatedDate,
            UpdatedUser,
            Priority,
            Severity,
            ModuleName,
            Operations,
            Purpose,
            WhatToMonitor,
            DependsOn,
            IsActive,
            Threshold,
            ResponsibleTeam,
            Operator,
            EmailTo,
            EmailCC,
            MonitoredBy,
            Method,
            Frequency,
            FrequencyCount1,
            FrequencyCount2,
            MinuteCount1,
            MinuteCount2
        )
        VALUES
        (
            @TaskName,
            @TaskDesc,
            @ThresholdFromRange,
            @ThresholdToRange,
            GETDATE(),
            @CreatedUser,
            GETDATE(),
            @UpdatedUser,
            @Priority,
            @Severity,
            @ModuleName,
            @Operations,
            @Purpose,
            @WhatToMonitor,
            @DependsOn,
            @IsActive,
            @Threshold,
            @ResponsibleTeam,
            @Operator,
            @EmailTo,
            @EmailCC,
            @MonitoredBy,
            @Method,
            @Frequency,
            @FrequencyCount1,
            @FrequencyCount2,
            @MinuteCount1,
            @MinuteCount2
        );

        -- Log the successful insert into the AuditLog
        INSERT INTO Logs.AuditLog
        (
            LogDate,
            PerformedBy,
            ActionDescription,
            AffectedEntity
        )
        VALUES
        (
            GETDATE(),
            @CreatedUser,
            'INSERT new record',
            'HYPERCARE.HyperCareTaskMaster'
        );

        SET @Success = 1;  -- Set to success
    END TRY
    BEGIN CATCH
        -- Log or handle the exception as needed
        SET @Success = 0;  -- Set to failure

        -- Log error information into the Logs.ErrorLog table
        INSERT INTO Logs.ErrorLog
        (
            LogDate,
            ErrorMessage,
            ProcedureName,
            ParametersInfo
        )
        VALUES
        (
            GETDATE(),
            ERROR_MESSAGE(),
            'HYPERCARE.InsertHyperCareTaskMaster',
            ''
        );
    END CATCH;
END;