using Microsoft.Extensions.Logging;
using ModelService.Hypercare;
using NLog.Extensions.Logging;
using TeamProfilesInterfaces;

namespace TeamProfilesService.BLL
{
    public class TeamProfile : ITeamProfileService
    {
        private readonly ILogger _logger = (new NLogLoggerFactory()).CreateLogger<TeamProfile>();
        private BusinessObjects.TeamProfile _teamProfile => new BusinessObjects.TeamProfile();
        public Task<IList<HypercareResponsibleTeam>> GetResponsibleTeam()
        {
            try
            {
                _logger.LogInformation("GetResponsibleTeam called");
                return _teamProfile.GetResponsibleTeam();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetResponsibleTeam failed");
                throw;
            }
        }
    }
}
