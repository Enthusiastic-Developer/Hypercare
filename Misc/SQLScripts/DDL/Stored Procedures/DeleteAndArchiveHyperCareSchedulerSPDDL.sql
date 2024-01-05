/**********************************************************************************                                                                                                             
Procedure Name    : [HYPERCARE].[DeleteAndArchiveHyperCareScheduler]                                 
Created By        : [NIKHIL]                                
Created Date      : [05-01-2024]                                                                                                      
Purpose           : To Delete data from HYPERCARE.HyperCareScheduler and Archive it in HISTORY.HyperCareScheduler_History                             
Called From       : [CronCraftService]                                     
***********************************************************************************                                                                                                           
Modified By            :                                       
Modified Date          :                                       
Modified Reason        :                                       
************************************************************************************                                   
Execution :  
DECLARE @Success BIT
EXEC [HYPERCARE].[DeleteAndArchiveHyperCareScheduler] 125,'[NIKHIL]',@Success OUTPUT
SELECT @Success     
***********************************************************************************/
CREATE OR ALTER PROCEDURE [HYPERCARE].[DeleteAndArchiveHyperCareScheduler]
    @HcSchId INT,
    @DeletedBy NVARCHAR(100),
    @Success BIT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    -- Declare variable for storing historical data
    DECLARE @HistoryID INT;

    BEGIN TRY
        -- Insert into history table before deletion
        INSERT INTO HISTORY.HyperCareScheduler_History (
            MainTableHcSchId,
            SchedulerName,
            SchedulerDesc,
            StartDate,
            EndDate,
            ScheduleTime,
            EffectiveStartDate,
            EffectiveEndDate,
            CreatedDate,
            CreatedUser
        )
        SELECT
            HcSchId,
            SchedulerName,
            SchedulerDesc,
            StartDate,
            EndDate,
            ScheduleTime,
            GETDATE() AS EffectiveStartDate,
            NULL AS EffectiveEndDate,
            CreatedDate,
            CreatedUser
        FROM HYPERCARE.HyperCareScheduler
        WHERE HcSchId = @HcSchId;

        -- Retrieve the HistoryID of the inserted record
        SELECT @HistoryID = SCOPE_IDENTITY();

        -- Delete from the main table
        DELETE FROM HYPERCARE.HyperCareScheduler
        WHERE HcSchId = @HcSchId;

        -- Log the successful delete in the AuditLog
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
            'HYPERCARE.HyperCareScheduler'
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
            '[HYPERCARE].[DeleteAndArchiveHyperCareScheduler]',
            'HcSchId = ' + CAST(@HcSchId AS NVARCHAR(20))
        );

        SET @Success = 0; -- Set to failure
    END CATCH;
END;