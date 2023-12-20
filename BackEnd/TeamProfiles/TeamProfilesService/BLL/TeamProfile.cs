using Microsoft.Extensions.Logging;
using ModelService.Hypercare;
using NLog.Extensions.Logging;
using TeamProfilesInterfaces;

namespace TeamProfilesService.BLL
{
    public class TeamProfile : ITeamProfileService
    {
        private readonly ILogger _logger = (new NLogLoggerFactory()).CreateLogger<TeamProfile>();
        public Task<IList<HypercareResponsibleTeam>> GetResponsibleTeam()
        {
            try
            {
                _logger.LogInformation("GetResponsibleTeam called");
                return BusinessObjects.TeamProfile.GetResponsibleTeam();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetResponsibleTeam failed");
                throw;
            }
        }

        public Task<IList<HypercareResponsibleTeam>> GetResourceByModueName(string moduleName)
        {
            try
            {
                _logger.LogInformation("GetResourceByModueName called");
                return BusinessObjects.TeamProfile.GetResourceByModueName(moduleName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetResourceByModueName failed");
                throw;
            }
        }

        public Task<IList<HypercareResponsibleTeam>> GetModuleDataByResourceName(string resourceName)
        {
            try
            {
                _logger.LogInformation("GetResourceByModueName called");
                return BusinessObjects.TeamProfile.GetModuleDataByResourceName(resourceName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetModuleDataByResourceName failed");
                throw;
            }
        }

        public Task<bool> AddResponsibleTeam(HypercareResponsibleTeam responsibleTeam)
        {
            try
            {
                _logger.LogInformation("AddResponsibleTeam called");
                return BusinessObjects.TeamProfile.AddResponsibleTeam(responsibleTeam);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "AddResponsibleTeam failed");
                throw;
            }
        }

        public Task<bool> UpdateResponsibleTeam(HypercareResponsibleTeam responsibleTeam)
        {
            try
            {
                _logger.LogInformation("UpdateResponsibleTeam called");
                return BusinessObjects.TeamProfile.UpdateResponsibleTeam(responsibleTeam);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "UpdateResponsibleTeam failed");
                throw;
            }
        }
    }
}
