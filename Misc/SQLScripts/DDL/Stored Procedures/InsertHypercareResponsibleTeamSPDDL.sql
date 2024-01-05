 /**********************************************************************************                                                                                                             
Procedure Name    : [HYPERCARE].[InsertHyperCareTaskMaster]                                   
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
EXEC HYPERCARE.[InsertHyperCareTaskMaster] 'TEST','TEST','TEST',20,'TEST',NULL,NULL,'TEST,'TEST',@Success OUTPUT
SELECT @Success     
***********************************************************************************/
CREATE PROCEDURE HYPERCARE.InsertHypercareResponsibleTeam
    @Module NVARCHAR(200) = NULL,
    @ResponsibleTeam NVARCHAR(200) = NULL,
    @ActionType NVARCHAR(200) = NULL,
    @NumberOfTasks INT = NULL,
    @OnsiteTeam NVARCHAR(200) = NULL,
    @PrimaryResource NVARCHAR(200) = NULL,
    @SecondaryResource NVARCHAR(200) = NULL,
    @CreatedUser NVARCHAR(100),
    @UpdatedUser NVARCHAR(100) = NULL,
    @Success BIT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        INSERT INTO HYPERCARE.HypercareResponsibleTeam
        (
            Module,
            ResponsibleTeam,
            ActionType,
            NumberOfTasks,
            OnsiteTeam,
            PrimaryResource,
            SecondaryResource,
            CreatedDate,
            CreatedUser,
            UpdatedDate,
            UpdatedUser
        )
        VALUES
        (
            NULLIF(@Module, ''),
            NULLIF(@ResponsibleTeam, ''),
            NULLIF(@ActionType, ''),
            NULLIF(@NumberOfTasks, 0), -- Assuming 0 for NULL
            NULLIF(@OnsiteTeam, ''),
            NULLIF(@PrimaryResource, ''),
            NULLIF(@SecondaryResource, ''),
            GETDATE(),
            NULLIF(@CreatedUser, ''),
            GETDATE(),
            NULLIF(@UpdatedUser, '')
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
            'HYPERCARE.InsertHypercareResponsibleTeam',
            ''
        );

        SET @Success = 0; -- Set to failure
    END CATCH;
END;