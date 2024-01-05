/**********************************************************************************                                                                                                             
Procedure Name    : [HYPERCARE].[InsertHyperCareScheduler]                                   
Created By        : Nikhil                                
Created Date      : 02-01-2023                                                                                                      
Purpose           : To Insert data into HyperCareScheduler table                             
Called From       : CronCraftService                                     
***********************************************************************************                                                                                                           
Modified By            :                                       
Modified Date          :                                       
Modified Reason        :                                       
************************************************************************************                                   
Execution :  
DECLARE @Success BIT
EXEC HYPERCARE.[InsertHyperCareScheduler] 'Test-1','Test','2024-01-02 07:03:43.583','2024-01-02 07:03:43.583','2024-01-02 07:03:43.583','TEST','TEST',1,NULL,NULL,NULL,NULL,NULL,@Success OUTPUT
SELECT @Success      
***********************************************************************************/
CREATE OR ALTER PROCEDURE HYPERCARE.InsertHyperCareScheduler
    @SchedulerName VARCHAR(150) = NULL,
    @SchedulerDesc VARCHAR(250) = NULL,
    @StartDate DATETIME = NULL,
    @EndDate DATETIME = NULL,
    @ScheduleTime DATETIME = NULL,
    @CreatedUser VARCHAR(50),
    @UpdatedUser VARCHAR(50) = NULL,
    @IsActive BIT = NULL,
    @Frequency VARCHAR(10) = NULL,
    @FrequencyStartDay TINYINT = NULL,
    @FrequencyEndDay TINYINT = NULL,
    @FrequencyStartDayName VARCHAR(10) = NULL,
    @IsOneOff BIT = NULL,
    @Success BIT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        -- Insert into the main table
        INSERT INTO HYPERCARE.HyperCareScheduler
        (
            SchedulerName,
            SchedulerDesc,
            StartDate,
            EndDate,
            ScheduleTime,
            CreatedDate,
            CreatedUser,
            UpdatedDate,
            UpdatedUser,
            IsActive,
            Frequency,
            FrequencyStartDay,
            FrequencyEndDay,
            FrequencyStartDayName,
            IsOneOff
        )
        VALUES
        (
            NULLIF(@SchedulerName, ''),
            NULLIF(@SchedulerDesc, ''),
            NULLIF(@StartDate, '17530101'), -- Assuming '17530101' as a minimal date (NULL value)
            NULLIF(@EndDate, '99991231'), -- Assuming '99991231' as a maximal date (NULL value)
            NULLIF(@ScheduleTime, '17530101'),
            GETDATE(),
            NULLIF(@CreatedUser, ''),
            GETDATE(), -- Use GETDATE() for UpdatedDate
            NULLIF(@UpdatedUser, ''),
            NULLIF(@IsActive, 0), -- Assuming 0 for FALSE
            NULLIF(@Frequency, ''),
            NULLIF(@FrequencyStartDay, 0), -- Assuming 0 for FALSE
            NULLIF(@FrequencyEndDay, 0), -- Assuming 0 for FALSE
            NULLIF(@FrequencyStartDayName, ''),
            NULLIF(@IsOneOff, 0) -- Assuming 0 for FALSE
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
            NULLIF(@CreatedUser, ''),
            'INSERT new record',
            'HYPERCARE.HyperCareScheduler'
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
            'HYPERCARE.InsertHyperCareScheduler',
            ''
        );

        SET @Success = 0; -- Set to failure
    END CATCH;
END;