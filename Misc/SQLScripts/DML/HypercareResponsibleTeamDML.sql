IF NOT EXISTS (SELECT * FROM sys.triggers WHERE name = 'trg_UpdateNumberOfTasks')
BEGIN
    EXEC('
        CREATE TRIGGER trg_UpdateNumberOfTasks
        ON [HYPERCARE].[HyperCareTaskMaster]
        AFTER INSERT, UPDATE, DELETE
        AS
        BEGIN
            SET NOCOUNT ON;

            UPDATE ht
            SET NumberOfTasks = (
                SELECT COUNT(*)
                FROM [HYPERCARE].[HyperCareTaskMaster] tm
                WHERE tm.ModuleName = ht.Module
            )
            FROM [HYPERCARE].[HypercareResponsibleTeam] ht
            JOIN inserted i ON ht.Module = i.ModuleName
            OR ht.Module = (SELECT ModuleName FROM deleted);
        END;
    ');
END