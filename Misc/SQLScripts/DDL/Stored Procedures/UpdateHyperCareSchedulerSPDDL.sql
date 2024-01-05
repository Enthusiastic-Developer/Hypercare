/**********************************************************************************                                                                                                             
Procedure Name    : [HYPERCARE].[UpdateHyperCareScheduler]                                   
Created By        : Nikhil                                
Created Date      : 02-01-2023                                                                                                      
Purpose           : To Update data into HyperCareScheduler table                             
Called From       : CronCraftService                                     
***********************************************************************************                                                                                                           
Modified By            :                                       
Modified Date          :                                       
Modified Reason        :                                       
************************************************************************************                                   
Execution :  
DECLARE @Success BIT
EXEC HYPERCARE.[UpdateScheduler] 23,'Test-1','Test','2024-01-02 07:03:43.583','2024-01-02 07:03:43.583','2024-01-02 07:03:43.583','TEST',1,NULL,NULL,NULL,NULL,NULL,@Success OUTPUT
SELECT @Success      
***********************************************************************************/
CREATE OR ALTER PROCEDURE HYPERCARE.UpdateHyperCareScheduler
    @HcSchId INT,
    @SchedulerName VARCHAR(150) = NULL,
    @SchedulerDesc VARCHAR(250) = NULL,
    @StartDate DATETIME = NULL,
    @EndDate DATETIME = NULL,
    @ScheduleTime DATETIME = NULL,
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
        -- Update the main table based on HcSchId
        UPDATE HYPERCARE.HyperCareScheduler
        SET
            SchedulerName = ISNULL(@SchedulerName, SchedulerName),
            SchedulerDesc = ISNULL(@SchedulerDesc, SchedulerDesc),
            StartDate = ISNULL(@StartDate, StartDate),
            EndDate = ISNULL(@EndDate, EndDate),
            ScheduleTime = ISNULL(@ScheduleTime, ScheduleTime),
            UpdatedDate = GETDATE(),
            UpdatedUser = ISNULL(@UpdatedUser, UpdatedUser),
            IsActive = ISNULL(@IsActive, IsActive),
            Frequency = ISNULL(@Frequency, Frequency),
            FrequencyStartDay = ISNULL(@FrequencyStartDay, FrequencyStartDay),
            FrequencyEndDay = ISNULL(@FrequencyEndDay, FrequencyEndDay),
            FrequencyStartDayName = ISNULL(@FrequencyStartDayName, FrequencyStartDayName),
            IsOneOff = ISNULL(@IsOneOff, IsOneOff)
        WHERE HcSchId = @HcSchId;

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
            'HYPERCARE.UpdateHyperCareScheduler',
            ''
        );

        SET @Success = 0; -- Set to failure
    END CATCH;
END;