/**********************************************************************************                                                                                                             
Procedure Name    : [HYPERCARE].[InsertHypercareTaskSchedulerMap]                                   
Created By        : Nikhil                                
Created Date      : 02-01-2023                                                                                                      
Purpose           : To Insert data into HypercareTaskSchedulerMap table                             
Called From       : MappingEngineService                                     
***********************************************************************************                                                                                                           
Modified By            :                                       
Modified Date          :                                       
Modified Reason        :                                       
************************************************************************************                                   
Execution :  
DECLARE @Success BIT
EXEC HYPERCARE.[InsertHypercareTaskSchedulerMap] 1,2,'TEST','TEST','2024-01-02 07:03:43.583','2024-01-02 07:03:43.583',1,@Success OUTPUT
SELECT @Success      
***********************************************************************************/
CREATE OR ALTER PROCEDURE HYPERCARE.InsertHypercareTaskSchedulerMap
    @HcTaskId INT,
    @HcSchId INT,
    @CreatedUser VARCHAR(50),
    @UpdatedUser VARCHAR(50) = NULL,
    @StartDate DATETIME = NULL,
    @EndDate DATETIME = NULL,
    @IsActive BIT = NULL,
    @Success BIT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        -- Insert into the main table
        INSERT INTO HYPERCARE.HypercareTaskSchedulerMap
        (
            HcTaskId,
            HcSchId,
            CreatedDate,
            CreatedUser,
            UpdatedDate,
            UpdatedUser,
            StartDate,
            EndDate,
            IsActive
        )
        VALUES
        (
            @HcTaskId,
            @HcSchId,
            GETDATE(),
            @CreatedUser,
            NULLIF(GETDATE(), '17530101'), -- Assuming '17530101' as a minimal date (NULL value)
            NULLIF(@UpdatedUser, ''),
            NULLIF(@StartDate, '17530101'), -- Assuming '17530101' as a minimal date (NULL value)
            NULLIF(@EndDate, '99991231'), -- Assuming '99991231' as a maximal date (NULL value)
            NULLIF(@IsActive, 0) -- Assuming 0 for FALSE
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
            'HYPERCARE.InsertHypercareTaskSchedulerMap',
            ''
        );

        SET @Success = 0; -- Set to failure
    END CATCH;
END;
