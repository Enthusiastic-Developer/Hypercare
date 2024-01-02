 /**********************************************************************************                                                                                                             
Procedure Name    : [HYPERCARE].[UpdateHypercareTaskSchedulerMap]                                   
Created By        : Nikhil                                
Created Date      : 31-12-2023                                                                                                      
Purpose           : To Update data into HypercareTaskSchedulerMap table                             
Called From       : MappingEngineService                                     
***********************************************************************************                                                                                                           
Modified By            :                                       
Modified Date          :                                       
Modified Reason        :                                       
************************************************************************************                                   
Execution :  
DECLARE @Success BIT
 BEGIN TRAn EXEC HYPERCARE.[UpdateHypercareTaskSchedulerMap] 138,1,2,'TEST','2024-01-02 07:03:43.583','2024-01-02 07:03:43.583',1,@Success OUTPUT
 SELECT @Success      
***********************************************************************************/
CREATE OR ALTER PROCEDURE HYPERCARE.UpdateHypercareTaskSchedulerMap
    @HcTsId BIGINT,
    @HcTaskId INT,
    @HcSchId INT,
    @UpdatedUser VARCHAR(50),
    @StartDate DATETIME = NULL,
    @EndDate DATETIME = NULL,
    @IsActive BIT = NULL,
    @Success BIT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        -- Update the main table
        UPDATE HYPERCARE.HypercareTaskSchedulerMap
        SET
            HcTaskId = @HcTaskId,
            HcSchId = @HcSchId,
            UpdatedDate = GETDATE(),
            UpdatedUser = NULLIF(@UpdatedUser, ''),
            StartDate = NULLIF(@StartDate, '17530101'), -- Assuming '17530101' as a minimal date (NULL value)
            EndDate = NULLIF(@EndDate, '99991231'), -- Assuming '99991231' as a maximal date (NULL value)
            IsActive = NULLIF(@IsActive, 0) -- Assuming 0 for FALSE
        WHERE
            HcTsId = @HcTsId;

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
            @UpdatedUser,
            'UPDATE record',
            'HYPERCARE.HypercareTaskSchedulerMap'
        );

        SET @Success = 1; -- Set to success
    END TRY
    BEGIN CATCH
        -- Log or handle the exception as needed

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
            'HYPERCARE.UpdateHypercareTaskSchedulerMap',
            ''
        );

        SET @Success = 0; -- Set to failure
    END CATCH;
END;