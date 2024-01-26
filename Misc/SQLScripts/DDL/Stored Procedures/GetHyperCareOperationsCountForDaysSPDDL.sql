/**********************************************************************************                                                 
Procedure Name    : [HYPERCARE].[GetHyperCareOperationsCountForDays]                                   
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
EXEC [HYPERCARE].[GetHyperCareOperationsCountForDays] 
    @fromDate = '2023-11-24' ,@toDate = '2024-01-25'     
***********************************************************************************/

CREATE OR ALTER PROCEDURE [HYPERCARE].[GetHyperCareOperationsCountForDays]
    @fromDate DATETIME,
    @toDate DATETIME
AS
BEGIN
	
    SELECT
            COUNT(1) AS TotalCount,
            Operations
        FROM
            HISTORY.HyperCareTracker_History HT WITH (NOLOCK)
            JOIN HYPERCARE.HyperCareTaskMaster HTM WITH (NOLOCK) ON HT.HcTaskId = HTM.HcTaskId
            JOIN HYPERCARE.HyperCareScheduler HS WITH (NOLOCK) ON HT.HcSchId = HS.HcSchId
        WHERE
            HT.ExecutionDate BETWEEN @fromDate AND @toDate
        GROUP BY
            Operations;
    
END;