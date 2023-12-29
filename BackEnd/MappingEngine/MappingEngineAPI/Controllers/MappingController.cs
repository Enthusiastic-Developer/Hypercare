using MappingEngineInterfaces;
using MappingEngineService.BLL;
using Microsoft.AspNetCore.Mvc;
using ModelService.Hypercare;

namespace MappingEngineAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MappingController : ControllerBase
    {
        private readonly ILogger _logger = (new LoggerFactory()).CreateLogger<MappingController>();
        private static IMappingEngineService MappingP => new MappingEngine();

        [HttpGet]
        public async Task<IList<HypercareTaskSchedulerMap>> GetAllMappingEngine()
        {
            _logger.LogInformation("GetAllMappingEngine called");
            return await MappingP.GetMappingEngine();
        }

        [HttpGet]
        public async Task<IList<HypercareTaskSchedulerMap>> GetMappingEngineByScheduleId(int scheduleId)
        {
            _logger.LogInformation("GetMappingEngineByScheduleId called");
            return await MappingP.GetMappingEngineByScheduleId(scheduleId);
        }

        [HttpGet]
        public async Task<IList<HypercareTaskSchedulerMap>> GetMappingEngineByTaskId(int taskId)
        {
            _logger.LogInformation("GetMappingEngineByTaskId called");
            return await MappingP.GetMappingEngineByTaskId(taskId);
        }

        [HttpPost]
        public async Task<bool> AddMappingEngine(HypercareTaskSchedulerMap taskSchedulerMap)
        {
            _logger.LogInformation("AddMappingEngine called");
            return await MappingP.AddMappingEngine(taskSchedulerMap);
        }

        [HttpPut]
        public async Task<bool> UpdateMappingEngine(HypercareTaskSchedulerMap taskSchedulerMap)
        {
            _logger.LogInformation("UpdateMappingEngine called");
            return await MappingP.UpdateMappingEngine(taskSchedulerMap);
        }
    }
}
