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
        private readonly ILogger _logger = new LoggerFactory().CreateLogger<CareOpsController>();
        private static ICareOpsManagerService CareOpsService => new CareOps();

        [HttpGet]
        public async Task<IList<HyperCareTaskMaster>> GetCareOps()
        {
            _logger.LogInformation("GetCareOps called");
            return await CareOpsService.GetCareOpsManager();
        }

        [HttpGet]
        public async Task<IList<HyperCareTaskMaster>> GetCareOpsManagerById(int taskId)
        {
            _logger.LogInformation("GetCareOpsById called");
            return await CareOpsService.GetCareOpsManagerById(taskId);
        }

        [HttpPost]
        public async Task<bool> AddCareOpsManager(HyperCareTaskMaster careTaskMaster)
        {
            _logger.LogInformation("AddCareOpsManager called");
            return await CareOpsService.AddCareOpsManager(careTaskMaster);
        }

        [HttpPut]
        public async Task<bool> UpdateCareOpsManager(HyperCareTaskMaster careTaskMaster)
        {
            _logger.LogInformation("UpdateCareOpsManager called");
            return await CareOpsService.UpdateCareOpsManager(careTaskMaster);
        }

        [HttpDelete]
        public async Task<bool> DeleteCareOpsManager(int taskId, string deletedBy)
        {
            _logger.LogInformation("DeleteCareOpsManager called");
            return await CareOpsService.DeleteCareOpsManager(taskId, deletedBy);
        }
    }
}
