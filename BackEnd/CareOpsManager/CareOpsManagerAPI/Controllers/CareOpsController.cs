using CareOpsManagerInterfaces;
using CareOpsManagerService.BLL;
using Microsoft.AspNetCore.Mvc;
using ModelService.Hypercare;

namespace CareOpsManagerAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CareOpsController : ControllerBase
    {
        private readonly ILogger _logger = (new LoggerFactory()).CreateLogger<CareOpsController>();
        private static ICareOpsManagerService _careOpsService => new CareOps();

        [HttpGet]
        public async Task<IList<HyperCareTaskMaster>> GetCareOps()
        {
            _logger.LogInformation("GetCareOps called");
            return await _careOpsService.GetCareOpsManager();
        }

        [HttpGet]
        public async Task<IList<HyperCareTaskMaster>> GetCareOpsManagerById(int taskId)
        {
            _logger.LogInformation("GetCareOpsById called");
            return await _careOpsService.GetCareOpsManagerById(taskId);
        }

        [HttpPost]
        public async Task<bool> AddCareOpsManager(HyperCareTaskMaster careTaskMaster)
        {
            _logger.LogInformation("AddCareOpsManager called");
            return await _careOpsService.AddCareOpsManager(careTaskMaster);
        }

        [HttpPut]
        public async Task<bool> UpdateCareOpsManager(HyperCareTaskMaster careTaskMaster)
        {
            _logger.LogInformation("UpdateCareOpsManager called");
            return await _careOpsService.UpdateCareOpsManager(careTaskMaster);
        }
    }
}
