using Microsoft.AspNetCore.Mvc;
using ModelService.Hypercare;
using TeamProfilesInterfaces;
using TeamProfilesService.BLL;

namespace TeamProfilesAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ILogger _logger = (new LoggerFactory()).CreateLogger<TeamController>();
        private static ITeamProfileService TeamP => new TeamProfile();

        [HttpGet]
        public async Task<IList<HypercareResponsibleTeam>> GetAllResponsibleTeam()
        {
            _logger.LogInformation("GetResponsibleTeam called");
            return await TeamP.GetResponsibleTeam();
        }

        [HttpGet]
        public async Task<IList<HypercareResponsibleTeam>> GetResourceByModueName(string moduleName)
        {
            _logger.LogInformation("GetResourceByModueName called");
            return await TeamP.GetResourceByModueName(moduleName);
        }

        [HttpGet]
        public async Task<IList<HypercareResponsibleTeam>> GetModuleDataByResourceName(string resourceName)
        {
            _logger.LogInformation("GetModuleDataByResourceName called");
            return await TeamP.GetModuleDataByResourceName(resourceName);
        }

        [HttpPost]
        public async Task<bool> AddResponsibleTeam(HypercareResponsibleTeam responsibleTeam)
        {
            _logger.LogInformation("AddResponsibleTeam called");
            return await TeamP.AddResponsibleTeam(responsibleTeam);
        }

        [HttpPut]
        public async Task<bool> UpdateResponsibleTeam(HypercareResponsibleTeam responsibleTeam)
        {
            _logger.LogInformation("UpdateResponsibleTeam called");
            return await TeamP.UpdateResponsibleTeam(responsibleTeam);
        }

    }
}
