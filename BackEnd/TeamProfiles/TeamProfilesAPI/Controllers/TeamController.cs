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
        private ITeamProfileService _teamProfile => new TeamProfile();

        [HttpGet]
        public async Task<IList<HypercareResponsibleTeam>> GetAllResponsibleTeam()
        {
            _logger.LogInformation("GetResponsibleTeam called");
            return await _teamProfile.GetResponsibleTeam();
        }
    }
}
