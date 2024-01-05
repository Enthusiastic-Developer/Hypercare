/**********************************************************************************                                                                                                             
Procedure Name    : [HYPERCARE].[DeleteAndArchiveHyperCareTaskMaster]                                 
Created By        : Nikhil                                
Created Date      : 05-01-2024                                                                                                      
Purpose           : To Delete data from HYPERCARE.HyperCareTaskMaster and Archive it in HISTORY.HyperCareTaskMaster_History                             
Called From       : CareOpsManagerService                                     
***********************************************************************************                                                                                                           
Modified By            :                                       
Modified Date          :                                       
Modified Reason        :                                       
************************************************************************************                                   
Execution :  
DECLARE @Success BIT
EXEC [HYPERCARE].[DeleteAndArchiveHyperCareTaskMaster] 125,'NIKHIL',@Success OUTPUT
SELECT @Success     
***********************************************************************************/
CREATE OR ALTER PROCEDURE [HYPERCARE].[DeleteAndArchiveHyperCareTaskMaster]
    @HcTaskId INT,
    @DeletedBy NVARCHAR(100),
    @Success BIT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    -- Declare variable for storing historical data
    DECLARE @HistoryID INT;

    BEGIN TRY
        -- Insert into history table before deletion
        INSERT INTO HISTORY.HyperCareTaskMaster_History (
            MainTableHcTaskId,
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
            MinuteCount2,
            EffectiveStartDate,
            EffectiveEndDate
        )
        SELECT
            HcTaskId,
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
            MinuteCount2,
            GETDATE() AS EffectiveStartDate,
            NULL AS EffectiveEndDate
        FROM HYPERCARE.HyperCareTaskMaster
        WHERE HcTaskId = @HcTaskId;

        -- Retrieve the HistoryID of the inserted record
        SELECT @HistoryID = SCOPE_IDENTITY();

        -- Delete from the main table
        DELETE FROM HYPERCARE.HyperCareTaskMaster
        WHERE HcTaskId = @HcTaskId;

        -- Update the EffectiveEndDate in the history table
        UPDATE HISTORY.HyperCareTaskMaster_History
        SET EffectiveEndDate = GETDATE()
        WHERE HistoryID = @HistoryID;

        -- Log the successful delete and archive in the AuditLog
        INSERT INTO Logs.AuditLog (
            LogDate,
            PerformedBy,
            ActionDescription,
            AffectedEntity
        )
        VALUES (
            GETDATE(),
            @DeletedBy,
            'DELETE and ARCHIVE record',
            'HYPERCARE.HyperCareTaskMaster'
        );

        SET @Success = 1; -- Set to success
    END TRY
    BEGIN CATCH
        -- Log or handle the exception as needed

        -- Log error information into the Logs.ErrorLog table
        INSERT INTO Logs.ErrorLog (
            LogDate,
            ErrorMessage,
            ProcedureName,
            ParametersInfo
        )
        VALUES (
            GETDATE(),
            ERROR_MESSAGE(),
            'HYPERCARE.DeleteAndArchiveHyperCareTaskMaster',
            'HcTaskId = ' + CAST(@HcTaskId AS NVARCHAR(20))
        );

        SET @Success = 0; -- Set to failure
    END CATCH;
END;