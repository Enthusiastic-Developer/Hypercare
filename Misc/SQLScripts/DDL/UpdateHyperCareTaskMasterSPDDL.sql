 /**********************************************************************************                                                                                                             
Procedure Name    : [HYPERCARE].[UpdateHyperCareTaskMaster]                                   
Created By        : Nikhil                                
Created Date      : 31-12-2023                                                                                                      
Purpose           : To Update data into HyperCareTaskMaster table                             
Called From       : CareOpsManagerService                                     
***********************************************************************************                                                                                                           
Modified By            :                                       
Modified Date          :                                       
Modified Reason        :                                       
************************************************************************************                                   
Execution :  
DECLARE @Success BIT
 BEGIN TRAn EXEC HYPERCARE.[UpdateHyperCareTaskMaster] 120,'Escheatment job failed','Escheatment job failed',1000,2000,'High','Critical','Account Mgmt','Day1',NULL,NULL,NULL,1,24,NULL,'>','TEST@TEST.COM',NULL,NULL,NULL,NULL,0,0,0,0,'MASTERDATA',@Success OUTPUT
 SELECT @Success      
***********************************************************************************/
CREATE OR ALTER PROCEDURE HYPERCARE.UpdateHyperCareTaskMaster
    @HcTaskId INT,
    @TaskName NVARCHAR(MAX) = NULL,
    @TaskDesc NVARCHAR(MAX) = NULL,
    @ThresholdFromRange INT = NULL,
    @ThresholdToRange INT = NULL,
    @Priority varchar(20) = NULL,
    @Severity varchar(20) = NULL,
    @ModuleName NVARCHAR(MAX) = NULL,
    @Operations NVARCHAR(MAX) = NULL,
    @Purpose NVARCHAR(MAX) = NULL,
    @WhatToMonitor NVARCHAR(MAX) = NULL,
    @DependsOn NVARCHAR(MAX) = NULL,
    @IsActive BIT = NULL,
    @Threshold INT = NULL,
    @ResponsibleTeam NVARCHAR(MAX) = NULL,
    @Operator NVARCHAR(MAX) = NULL,
    @EmailTo NVARCHAR(MAX) = NULL,
    @EmailCC NVARCHAR(MAX) = NULL,
    @MonitoredBy NVARCHAR(MAX) = NULL,
    @Method NVARCHAR(MAX) = NULL,
    @Frequency NVARCHAR(MAX) = NULL,
    @FrequencyCount1 INT = NULL,
    @FrequencyCount2 INT = NULL,
    @MinuteCount1 INT = NULL,
    @MinuteCount2 INT = NULL,
    @UpdatedUser NVARCHAR(MAX) = NULL,
    @Success BIT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        -- Update the main table based on HcTaskId
        UPDATE HYPERCARE.HyperCareTaskMaster
        SET
            TaskName = ISNULL(@TaskName, TaskName),
            TaskDesc = ISNULL(@TaskDesc, TaskDesc),
            ThresholdFromRange = ISNULL(@ThresholdFromRange, ThresholdFromRange),
            ThresholdToRange = ISNULL(@ThresholdToRange, ThresholdToRange),
            Priority = ISNULL(@Priority, Priority),
            Severity = ISNULL(@Severity, Severity),
            ModuleName = ISNULL(@ModuleName, ModuleName),
            Operations = ISNULL(@Operations, Operations),
            Purpose = ISNULL(@Purpose, Purpose),
            WhatToMonitor = ISNULL(@WhatToMonitor, WhatToMonitor),
            DependsOn = ISNULL(@DependsOn, DependsOn),
            IsActive = ISNULL(@IsActive, IsActive),
            Threshold = ISNULL(@Threshold, Threshold),
            ResponsibleTeam = ISNULL(@ResponsibleTeam, ResponsibleTeam),
            Operator = ISNULL(@Operator, Operator),
            EmailTo = ISNULL(@EmailTo, EmailTo),
            EmailCC = ISNULL(@EmailCC, EmailCC),
            MonitoredBy = ISNULL(@MonitoredBy, MonitoredBy),
            Method = ISNULL(@Method, Method),
            Frequency = ISNULL(@Frequency, Frequency),
            FrequencyCount1 = ISNULL(@FrequencyCount1, FrequencyCount1),
            FrequencyCount2 = ISNULL(@FrequencyCount2, FrequencyCount2),
            MinuteCount1 = ISNULL(@MinuteCount1, MinuteCount1),
            MinuteCount2 = ISNULL(@MinuteCount2, MinuteCount2),
            UpdatedDate = GETDATE(),
            UpdatedUser = ISNULL(@UpdatedUser, UpdatedUser)
        WHERE HcTaskId = @HcTaskId;

        -- Log the successful update into the AuditLog
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
            ISNULL(@UpdatedUser, ''),
            'UPDATE record',
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
            'HYPERCARE.UpdateHyperCareTaskMaster',
            ''
        );
    END CATCH;
END;