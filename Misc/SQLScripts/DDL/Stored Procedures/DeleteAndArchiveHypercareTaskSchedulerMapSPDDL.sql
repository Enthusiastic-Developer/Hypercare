/**********************************************************************************                                                                                                             
Procedure Name    : [HYPERCARE].[DeleteAndArchiveHypercareTaskSchedulerMap]                                 
Created By        : [NIKHIL]                                
Created Date      : [06-01-2024]                                                                                                      
Purpose           : To Delete data from HYPERCARE.HypercareTaskSchedulerMap and Archive it in HISTORY.HypercareTaskSchedulerMap_History                             
Called From       : [MappingEngineService]                                     
***********************************************************************************                                                                                                           
Modified By            :                                       
Modified Date          :                                       
Modified Reason        :                                       
************************************************************************************                                   
Execution :  
DECLARE @Success BIT
EXEC [HYPERCARE].[DeleteAndArchiveHypercareTaskSchedulerMap] 137, '[NIKHIL]', @Success OUTPUT
SELECT @Success     
***********************************************************************************/
CREATE OR ALTER PROCEDURE [HYPERCARE].[DeleteAndArchiveHypercareTaskSchedulerMap]
    @HcTsId BIGINT,
    @DeletedBy NVARCHAR(100),
    @Success BIT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    -- Declare variable for storing historical data
    DECLARE @HistoryID BIGINT;

    BEGIN TRY
        -- Insert into history table before deletion
        INSERT INTO HISTORY.HypercareTaskSchedulerMap_History (
            MainTableHcTsId,
            HcTaskId,
            HcSchId,
            CreatedDate,
            CreatedUser,
            UpdatedDate,
            UpdatedUser,
            StartDate,
            EndDate,
            IsActive,
            EffectiveStartDate,
            EffectiveEndDate
        )
        SELECT
            HcTsId,
            HcTaskId,
            HcSchId,
            CreatedDate,
            CreatedUser,
            UpdatedDate,
            UpdatedUser,
            StartDate,
            EndDate,
            IsActive,
            GETDATE() AS EffectiveStartDate,
            NULL AS EffectiveEndDate
        FROM HYPERCARE.HypercareTaskSchedulerMap
        WHERE HcTsId = @HcTsId;

        -- Retrieve the HistoryID of the inserted record
        SELECT @HistoryID = SCOPE_IDENTITY();

        -- Delete from the main table
        DELETE FROM HYPERCARE.HypercareTaskSchedulerMap
        WHERE HcTsId = @HcTsId;

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
            'HYPERCARE.HypercareTaskSchedulerMap'
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
            'HYPERCARE.DeleteAndArchiveHypercareTaskSchedulerMap',
            'HcTsId = ' + CAST(@HcTsId AS NVARCHAR(20))
        );

        SET @Success = 0; -- Set to failure
    END CATCH;
END;