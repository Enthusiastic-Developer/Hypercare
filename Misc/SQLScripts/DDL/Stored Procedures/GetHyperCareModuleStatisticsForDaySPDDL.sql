/**********************************************************************************                                                 
Procedure Name    : [HYPERCARE].[GetHyperCareModuleStatisticsForDay]                                   
Created By        : Nikhil                                
Created Date      : 25-01-2024                                                                                                      
Purpose           : To Get HyperCareTracker table data based on Date                          
Called From       : DashboardService                                     
***********************************************************************************                                                                                                           
Modified By            :                                       
Modified Date          :                                       
Modified Reason        :                                       
************************************************************************************                                   
Execution :  
EXEC [HYPERCARE].[GetHyperCareModuleStatisticsForDay] 
    @TargetDate = '2023-11-24'   
***********************************************************************************/

CREATE OR ALTER PROCEDURE [HYPERCARE].[GetHyperCareModuleStatisticsForDay]
    @TargetDate DATETIME
AS
BEGIN
	
    SELECT
            COUNT(1) AS TotalCount,
			ModuleName,
            Operations,
			HTM.ResponsibleTeam
        FROM
            HYPERCARE.HyperCareTracker HT WITH (NOLOCK)
            JOIN HYPERCARE.HyperCareTaskMaster HTM WITH (NOLOCK) ON HT.HcTaskId = HTM.HcTaskId
        WHERE
            CAST(HT.ExecutionDate AS DATE) = CAST(@TargetDate AS DATE)
        GROUP BY
            ModuleName,Operations,HTM.ResponsibleTeam
    
END;