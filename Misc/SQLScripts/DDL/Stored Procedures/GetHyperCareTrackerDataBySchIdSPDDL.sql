/**********************************************************************************
Procedure Name    : [HYPERCARE].[GetHyperCareTrackerDataBySchId]
Created By        : Nikhil
Created Date      : 06-01-2024
Purpose           : To Get HyperCareTracker table data based on scheduleId
Called From       : HistoryService
***********************************************************************************
Modified By            :
Modified Date          :
Modified Reason        :
************************************************************************************
Execution :
EXEC [HYPERCARE].[GetHyperCareTrackerDataBySchId] 
    @HcSchId = 13, 
    @IN_PAGENUMBER = 1, 
    @IN_PAGESIZE = 10, 
    @SortColumn = N'ExecutionDate', 
    @SortDir = 1;
***********************************************************************************/
CREATE OR ALTER PROCEDURE [HYPERCARE].[GetHyperCareTrackerDataBySchId]
    @HcSchId INT,
    @IN_PAGENUMBER INT = 1,
    @IN_PAGESIZE INT = 10,
    @SortColumn NVARCHAR(255),
    @SortDir SMALLINT
AS
BEGIN
    DECLARE @IN_WHERECLAUSE VARCHAR(MAX) = NULL;
    
    -- Create a temporary table to store the combined data
    CREATE TABLE #CombinedData (
        HcId BIGINT,
        HcTaskId INT,
        HcSchId INT,
        ResponsibleTeam VARCHAR(255),
        ExecutionDate DATE,
        RecordCount INT,
        Priority VARCHAR(255),
        IsThresholdCrossing BIT,
        RecordDescr VARCHAR(255)
    );

    -- Insert data from HYPERCARE.HyperCareTracker
    INSERT INTO #CombinedData
    SELECT
        HcId, HcTaskId, HcSchId, ResponsibleTeam, ExecutionDate,
        RecordCount, Priority, IsThresholdCrossing, RecordDescr
    FROM HYPERCARE.HyperCareTracker WITH (NOLOCK);

    -- Insert data from HISTORY.HyperCareTracker_History
    INSERT INTO #CombinedData
    SELECT
        HcId, HcTaskId, HcSchId, ResponsibleTeam, ExecutionDate,
        RecordCount, Priority, IsThresholdCrossing, RecordDescr
    FROM HISTORY.HyperCareTracker_History WITH (NOLOCK);

    -- Pagination
    DECLARE @LV_OFFSET INT = (@IN_PAGENUMBER - 1) * @IN_PAGESIZE;
    DECLARE @LV_SORT_COLUMN NVARCHAR(255) = QUOTENAME(@SortColumn);
    DECLARE @LV_SORT_DIRECTION NVARCHAR(50) = CASE WHEN @SortDir = 0 THEN 'ASC' ELSE 'DESC' END;

    -- Select data based on the provided HcSchId and apply pagination
    DECLARE @SQL NVARCHAR(MAX);
    SET @SQL = '
        SELECT
            HcId, HcTaskId, HcSchId, ResponsibleTeam, ExecutionDate,
            RecordCount, Priority, IsThresholdCrossing, RecordDescr
        FROM
        (
            SELECT
                HcId, HcTaskId, HcSchId, ResponsibleTeam, ExecutionDate,
                RecordCount, Priority, IsThresholdCrossing, RecordDescr,
                ROW_NUMBER() OVER (ORDER BY ' + @LV_SORT_COLUMN + ' ' + @LV_SORT_DIRECTION + ') AS RowNum
            FROM #CombinedData
            WHERE HcSchId = @HcSchId '
            + CASE WHEN @IN_WHERECLAUSE IS NOT NULL THEN 'AND ' + @IN_WHERECLAUSE ELSE '' END +
        ') AS NumberedRows
        WHERE RowNum > ' + CAST(@LV_OFFSET AS NVARCHAR(10)) +
        ' AND RowNum <= ' + CAST(@LV_OFFSET + @IN_PAGESIZE AS NVARCHAR(10)) +
        ' ORDER BY ' + @LV_SORT_COLUMN + ' ' + @LV_SORT_DIRECTION;

    -- Execute the dynamic SQL
    EXEC sp_executesql @SQL, N'@HcSchId INT', @HcSchId;

    -- Drop the temporary table
    DROP TABLE #CombinedData;
END;