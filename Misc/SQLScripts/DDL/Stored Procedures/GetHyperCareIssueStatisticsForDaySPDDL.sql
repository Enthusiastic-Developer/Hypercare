/**********************************************************************************                                                 
Procedure Name    : [HYPERCARE].[GetHyperCareIssueStatisticsForDay]                                   
Created By        : Nikhil                                
Created Date      : 25-01-2024                                                                                                      
Purpose           : To Get HyperCareTracker table data based on dates                          
Called From       : DashboardService                                     
***********************************************************************************                                                                                                           
Modified By            :                                       
Modified Date          :                                       
Modified Reason        :                                       
************************************************************************************                                   
Execution :  
EXEC [HYPERCARE].[GetHyperCareIssueStatisticsForDay] 
    @TargetDate = '2023-11-24'    
***********************************************************************************/

CREATE OR ALTER PROCEDURE [HYPERCARE].[GetHyperCareIssueStatisticsForDay]
    @TargetDate DATETIME
AS
BEGIN
	
    DECLARE @TotalIssueCountToday INT,
            @TotalIssueCountOverall INT,
            @BusinessCriticalCount INT,
            @WarningCount INT;

    -- Query 1: TotalIssueCountToday
    SELECT @TotalIssueCountToday = COUNT(*)
    FROM HYPERCARE.HyperCareTracker WITH(NOLOCK)
    WHERE IsThresholdCrossing = 1 AND CAST(ExecutionDate AS DATE) = CAST(@TargetDate AS DATE);

    -- Query 2: TotalIssueCountOverall
    SELECT @TotalIssueCountOverall = COUNT(*)
    FROM HYPERCARE.HyperCareTracker WITH(NOLOCK)
    WHERE IsThresholdCrossing = 1;

    -- Query 3: BusinessCriticalCount
    SELECT @BusinessCriticalCount = COUNT(*)
    FROM HYPERCARE.HyperCareTracker HT WITH(NOLOCK)
    JOIN HYPERCARE.HyperCareTaskMaster HTM WITH(NOLOCK) ON HT.HcTaskId = HTM.HcTaskId
    WHERE IsThresholdCrossing = 1 AND Severity = 'Critical';

    -- Query 4: WarningCount
    SELECT @WarningCount = COUNT(*)
    FROM HYPERCARE.HyperCareTracker HT WITH(NOLOCK)
    JOIN HYPERCARE.HyperCareTaskMaster HTM WITH(NOLOCK) ON HT.HcTaskId = HTM.HcTaskId
    WHERE IsThresholdCrossing = 1 AND Severity = 'Warning';

    -- Return the results
    SELECT TotalIssueCountToday = @TotalIssueCountToday,
           TotalIssueCountOverall = @TotalIssueCountOverall,
           BusinessCriticalCount = @BusinessCriticalCount,
           WarningCount = @WarningCount;
    
END;