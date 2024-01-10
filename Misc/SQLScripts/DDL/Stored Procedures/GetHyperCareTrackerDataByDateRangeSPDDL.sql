/**********************************************************************************                                                 
Procedure Name    : [HYPERCARE].[GetHyperCareTrackerDataByDateRange]                                   
Created By        : Nikhil                                
Created Date      : 06-01-2024                                                                                                      
Purpose           : To Get HyperCareTracker table data based on Date with Pagination                          
Called From       : HistoryService                                     
***********************************************************************************                                                                                                           
Modified By            :                                       
Modified Date          :                                       
Modified Reason        :                                       
************************************************************************************                                   
Execution :  
EXEC [HYPERCARE].[GetHyperCareTrackerDataByDateRange] 
    @FromDate = '2023-01-01', 
    @ToDate = '2023-12-31',
    @IN_PAGESIZE = 10,
    @IN_PAGENUMBER = 2,
    @SortColumn = N'ExecutionDate', 
    @SortDir = 1;    
***********************************************************************************/

CREATE OR ALTER PROCEDURE [HYPERCARE].[GetHyperCareTrackerDataByDateRange]
    @FromDate DATETIME,
    @ToDate DATETIME,
    @IN_PAGESIZE INT,
    @IN_PAGENUMBER INT,
    @SortColumn NVARCHAR(100) = 'ExecutionDate',
    @SortDir SMALLINT
AS
BEGIN
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

    -- Insert data from HYPERCARE.HyperCareTracker within the specified date range
    INSERT INTO #CombinedData
    SELECT
        HcId, HcTaskId, HcSchId, ResponsibleTeam, ExecutionDate,
        RecordCount, Priority, IsThresholdCrossing, RecordDescr
    FROM HYPERCARE.HyperCareTracker
    WHERE ExecutionDate BETWEEN @FromDate AND @ToDate;

    -- Insert data from HISTORY.HyperCareTracker_History within the specified date range
    INSERT INTO #CombinedData
    SELECT
        HcId, HcTaskId, HcSchId, ResponsibleTeam, ExecutionDate,
        RecordCount, Priority, IsThresholdCrossing, RecordDescr
    FROM HISTORY.HyperCareTracker_History
    WHERE ExecutionDate BETWEEN @FromDate AND @ToDate;

    -- Pagination
    DECLARE @LV_OFFSET INT = (@IN_PAGENUMBER - 1) * @IN_PAGESIZE;
    DECLARE @LV_SORT_COLUMN NVARCHAR(100) = QUOTENAME(@SortColumn);
    DECLARE @LV_SORT_DIRECTION NVARCHAR(50) = CASE WHEN @SortDir = 0 THEN 'ASC' ELSE 'DESC' END;

    -- Select data based on the provided parameters and apply pagination
    DECLARE @SQL NVARCHAR(MAX);
    SET @SQL = '
        SELECT
            HcId, HcTaskId, HcSchId, ResponsibleTeam, ExecutionDate,
            RecordCount, Priority, IsThresholdCrossing, RecordDescr
        FROM (
            SELECT
                HcId, HcTaskId, HcSchId, ResponsibleTeam, ExecutionDate,
                RecordCount, Priority, IsThresholdCrossing, RecordDescr,
                ROW_NUMBER() OVER (ORDER BY ' + @LV_SORT_COLUMN + ' ' + @LV_SORT_DIRECTION + ') AS RowNum
            FROM #CombinedData
        ) AS NumberedRows
        WHERE RowNum > ' + CAST(@LV_OFFSET AS NVARCHAR(10)) +
    ' AND RowNum <= ' + CAST(@LV_OFFSET + @IN_PAGESIZE AS NVARCHAR(10)) +
    ' ORDER BY ' + @LV_SORT_COLUMN + ' ' + @LV_SORT_DIRECTION + ';';

    -- Execute the dynamic SQL
    EXEC sp_executesql @SQL;

    -- Drop the temporary table
    DROP TABLE #CombinedData;
END;