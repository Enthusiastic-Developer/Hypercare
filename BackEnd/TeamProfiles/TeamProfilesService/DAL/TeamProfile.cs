using ConfigurationService;
using Dapper;
using Microsoft.Extensions.Logging;
using ModelService.Hypercare;
using NLog.Extensions.Logging;
using System.Data;

namespace TeamProfilesService.DAL
{
    public class TeamProfile
    {
        private readonly ILogger _logger = (new NLogLoggerFactory()).CreateLogger<TeamProfile>();
        public Task<IList<HypercareResponsibleTeam>> GetResponsibleTeam()
        {
            try
            {
                using (IDbConnection con = ConnectionManager.GetLocalConnectionString())
                {
                    var sQuery = "SELECT Module,ResponsibleTeam,ActionType,NumberOfTasks,OnsiteTeam,PrimaryResource,SecondaryResource FROM HypercareResponsibleTeam WITH(NOLOCK)";
                    IList<HypercareResponsibleTeam> responsibleTeams = con.Query<HypercareResponsibleTeam>(sQuery).ToList();
                    return Task.FromResult(responsibleTeams);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in TeamProfile.GetResponsibleTeam()" + DateTime.Now.ToString() + ex.StackTrace);
                throw;
            }
        }
    }
}
