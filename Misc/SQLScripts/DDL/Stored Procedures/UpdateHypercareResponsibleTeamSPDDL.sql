 /**********************************************************************************                                                                                                             
Procedure Name    : [HYPERCARE].[UpdateHypercareResponsibleTeam]                                   
Created By        : Nikhil                                
Created Date      : 31-12-2023                                                                                                      
Purpose           : To Insert data into HypercareResponsibleTeam table                             
Called From       : TeamProfilesService                                     
***********************************************************************************                                                                                                           
Modified By            :                                       
Modified Date          :                                       
Modified Reason        :                                       
************************************************************************************                                   
Execution :  
DECLARE @Success BIT
EXEC HYPERCARE.[UpdateHypercareResponsibleTeam] 16,'TEST','TEST','TEST',20,'TEST',NULL,NULL,'TEST,@Success OUTPUT
SELECT @Success     
***********************************************************************************/
CREATE PROCEDURE HYPERCARE.UpdateHypercareResponsibleTeam
    @SNo INT,
    @Module NVARCHAR(200) = NULL,
    @ResponsibleTeam NVARCHAR(200) = NULL,
    @ActionType NVARCHAR(200) = NULL,
    @NumberOfTasks INT = NULL,
    @OnsiteTeam NVARCHAR(200) = NULL,
    @PrimaryResource NVARCHAR(200) = NULL,
    @SecondaryResource NVARCHAR(200) = NULL,
    @UpdatedUser NVARCHAR(100) = NULL,
    @Success BIT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        UPDATE HYPERCARE.HypercareResponsibleTeam
        SET
            Module = NULLIF(@Module, ''),
            ResponsibleTeam = NULLIF(@ResponsibleTeam, ''),
            ActionType = NULLIF(@ActionType, ''),
            NumberOfTasks = NULLIF(@NumberOfTasks, 0), -- Assuming 0 for NULL
            OnsiteTeam = NULLIF(@OnsiteTeam, ''),
            PrimaryResource = NULLIF(@PrimaryResource, ''),
            SecondaryResource = NULLIF(@SecondaryResource, ''),
            UpdatedDate = GETDATE(),
            UpdatedUser = NULLIF(@UpdatedUser, '')
        WHERE
            SNo = @SNo;

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
            'HYPERCARE.HypercareResponsibleTeam'
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
            'HYPERCARE.UpdateHypercareResponsibleTeam',
            ''
        );

        SET @Success = 0; -- Set to failure
    END CATCH;
END;