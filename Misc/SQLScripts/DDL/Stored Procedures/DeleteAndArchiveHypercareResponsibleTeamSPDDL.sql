/**********************************************************************************                                                                                                             
Procedure Name    : [HYPERCARE].[DeleteAndArchiveHypercareResponsibleTeam]                                 
Created By        : [NIKHIL]                                
Created Date      : [06-01-2024]                                                                                                      
Purpose           : To Delete data from HYPERCARE.HypercareResponsibleTeam and Archive it in HISTORY.HypercareResponsibleTeam_History                             
Called From       : [TeamProfilesService]                                     
***********************************************************************************                                                                                                           
Modified By            :                                       
Modified Date          :                                       
Modified Reason        :                                       
************************************************************************************                                   
Execution :  
DECLARE @Success BIT
EXEC [HYPERCARE].[DeleteAndArchiveHypercareResponsibleTeam] 12, '[NIKHIL]', @Success OUTPUT
SELECT @Success     
***********************************************************************************/
CREATE OR ALTER PROCEDURE [HYPERCARE].[DeleteAndArchiveHypercareResponsibleTeam]
    @SNo INT,
    @DeletedBy NVARCHAR(100),
    @Success BIT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    -- Declare variable for storing historical data
    DECLARE @HistoryID INT;

    BEGIN TRY
        -- Insert into history table before deletion
        INSERT INTO HISTORY.HypercareResponsibleTeam_History (
            MainTableSNo,
            Module,
            ResponsibleTeam,
            ActionType,
            NumberOfTasks,
            OnsiteTeam,
            PrimaryResource,
            SecondaryResource,
            EffectiveStartDate,
            EffectiveEndDate,
            CreatedDate,
            CreatedUser
        )
        SELECT
            SNo,
            Module,
            ResponsibleTeam,
            ActionType,
            NumberOfTasks,
            OnsiteTeam,
            PrimaryResource,
            SecondaryResource,
            GETDATE() AS EffectiveStartDate,
            NULL AS EffectiveEndDate,
            CreatedDate,
            CreatedUser
        FROM HYPERCARE.HypercareResponsibleTeam
        WHERE SNo = @SNo;

        -- Retrieve the HistoryID of the inserted record
        SELECT @HistoryID = SCOPE_IDENTITY();

        -- Delete from the main table
        DELETE FROM HYPERCARE.HypercareResponsibleTeam
        WHERE SNo = @SNo;

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
            'HYPERCARE.HypercareResponsibleTeam'
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
            'HYPERCARE.DeleteAndArchiveHypercareResponsibleTeam',
            'SNo = ' + CAST(@SNo AS NVARCHAR(20))
        );

        SET @Success = 0; -- Set to failure
    END CATCH;
END;