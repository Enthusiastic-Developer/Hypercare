/**********************************************************************************                                                 
Procedure Name    : [HYPERCARE].[GetUniqueTeamResources]                                   
Created By        : Nikhil                                
Created Date      : 28-03-2024                                                                                                      
Purpose           : To Get HyperCareTeam Names                         
Called From       : TeamProfilesService                                     
***********************************************************************************                                                                                                           
Modified By            :                                       
Modified Date          :                                       
Modified Reason        :                                       
************************************************************************************                                   
Execution :  
EXEC [HYPERCARE].[GetUniqueTeamResources]    
***********************************************************************************/
CREATE OR ALTER PROCEDURE [HYPERCARE].[GetUniqueTeamResources]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT DISTINCT TeamResource
    FROM (
        SELECT OnsiteTeam AS TeamResource
        FROM HYPERCARE.HypercareResponsibleTeam
        WHERE OnsiteTeam IS NOT NULL AND OnsiteTeam <> '' AND OnsiteTeam NOT LIKE '%/%'
        
        UNION
        
        SELECT PrimaryResource AS TeamResource
        FROM HYPERCARE.HypercareResponsibleTeam
        WHERE PrimaryResource IS NOT NULL AND PrimaryResource <> '' AND PrimaryResource NOT LIKE '%/%'
        
        UNION
        
        SELECT SecondaryResource AS TeamResource
        FROM HYPERCARE.HypercareResponsibleTeam
        WHERE SecondaryResource IS NOT NULL AND SecondaryResource <> '' AND SecondaryResource NOT LIKE '%/%'
    ) AS UniqueTeamResources;
END;