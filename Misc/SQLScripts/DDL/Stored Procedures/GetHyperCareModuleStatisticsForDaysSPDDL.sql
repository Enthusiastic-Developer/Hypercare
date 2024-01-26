/**********************************************************************************                                                 
Procedure Name    : [HYPERCARE].[GetHyperCareModuleStatisticsForDays]                                   
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
EXEC [HYPERCARE].[GetHyperCareModuleStatisticsForDays] 
    @fromDate = '2023-11-24' ,@toDate = '2024-01-25'     
***********************************************************************************/

CREATE OR ALTER PROCEDURE [HYPERCARE].[GetHyperCareModuleStatisticsForDays]
    @fromDate DATETIME,
    @toDate DATETIME
AS
BEGIN
	
    SELECT
            COUNT(1) AS TotalCount,
			ModuleName,
            Operations,
			HTM.ResponsibleTeam
        FROM
            HISTORY.HyperCareTracker_History HT WITH (NOLOCK)
            JOIN HYPERCARE.HyperCareTaskMaster HTM WITH (NOLOCK) ON HT.HcTaskId = HTM.HcTaskId
        WHERE
            HT.ExecutionDate BETWEEN @fromDate AND @toDate
        GROUP BY
            ModuleName,Operations,HTM.ResponsibleTeam
    
END;