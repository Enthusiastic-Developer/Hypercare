/**********************************************************************************                                                 
Procedure Name    : [HYPERCARE].[GetHyperCareIssueStatisticsForDays]                                   
Created By        : Nikhil                                
Created Date      : 25-01-2024                                                                                                      
Purpose           : To Get HyperCareTracker table data based on from and to dates                          
Called From       : DashboardService                                     
***********************************************************************************                                                                                                           
Modified By            :                                       
Modified Date          :                                       
Modified Reason        :                                       
************************************************************************************                                   
Execution :  
EXEC [HYPERCARE].[GetHyperCareIssueStatisticsForDays] 
    @fromDate = '2023-11-24' ,@toDate = '2024-01-25'    
***********************************************************************************/

CREATE OR ALTER PROCEDURE [HYPERCARE].[GetHyperCareIssueStatisticsForDays]
    @fromDate DATETIME,
    @toDate DATETIME
AS
BEGIN
	
    DECLARE @TotalIssueCountToday INT,
            @TotalIssueCountOverall INT,
            @BusinessCriticalCount INT,
            @WarningCount INT;

    -- Query 1: TotalIssueCountToday
    SELECT @TotalIssueCountToday = COUNT(*)
    FROM HISTORY.HyperCareTracker_History WITH(NOLOCK)
    WHERE IsThresholdCrossing = 1 AND ExecutionDate BETWEEN @fromDate AND @toDate

    -- Query 2: TotalIssueCountOverall
    SELECT @TotalIssueCountOverall = COUNT(*)
    FROM HISTORY.HyperCareTracker_History WITH(NOLOCK)
    WHERE IsThresholdCrossing = 1;

    -- Query 3: BusinessCriticalCount
    SELECT @BusinessCriticalCount = COUNT(*)
    FROM HISTORY.HyperCareTracker_History HT WITH(NOLOCK)
    JOIN HYPERCARE.HyperCareTaskMaster HTM WITH(NOLOCK) ON HT.HcTaskId = HTM.HcTaskId
    WHERE IsThresholdCrossing = 1 AND Severity = 'Critical';

    -- Query 4: WarningCount
    SELECT @WarningCount = COUNT(*)
    FROM HISTORY.HyperCareTracker_History HT WITH(NOLOCK)
    JOIN HYPERCARE.HyperCareTaskMaster HTM WITH(NOLOCK) ON HT.HcTaskId = HTM.HcTaskId
    WHERE IsThresholdCrossing = 1 AND Severity = 'Warning';

    -- Return the results
    SELECT TotalIssueCountToday = @TotalIssueCountToday,
           TotalIssueCountOverall = @TotalIssueCountOverall,
           BusinessCriticalCount = @BusinessCriticalCount,
           WarningCount = @WarningCount;
    
END;