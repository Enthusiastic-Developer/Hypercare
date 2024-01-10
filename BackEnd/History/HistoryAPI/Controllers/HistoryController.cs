using HistoryInterfaces;
using HistoryService.BLL;
using Microsoft.AspNetCore.Mvc;
using ModelService.Common;

namespace HistoryAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly ILogger _logger = new LoggerFactory().CreateLogger<HistoryController>();
        private static IHistoryService _historyService => new History();

        [HttpPost]
        public async Task<IActionResult> GetHistory(Pagination pagination)
        {
            _logger.LogInformation("GetHistory Called");
            OkObjectResult result = new(await _historyService.GetHistory(pagination));
            return result;
        }

        [HttpPost]
        public async Task<IActionResult> GetHistoryByTaskId(Pagination pagination, int taskId)
        {
            _logger.LogInformation("GetHistory Called");
            OkObjectResult result = new(await _historyService.GetHistoryByTaskId(pagination, taskId));
            return result;
        }

        [HttpPost]
        public async Task<IActionResult> GetHistoryByScheduleId(Pagination pagination, int scheduleId)
        {
            _logger.LogInformation("GetHistoryByScheduleId Called");
            OkObjectResult result = new(await _historyService.GetHistoryByScheduleId(pagination, scheduleId));
            return result;
        }

        [HttpPost]
        public async Task<IActionResult> GetHistoryBasedonDate(Pagination pagination, DateTime fromDate, DateTime toDate)
        {
            _logger.LogInformation("GetHistoryBasedonDate Called");
            OkObjectResult result = new(await _historyService.GetHistoryBasedonDate(pagination, fromDate, toDate));
            return result;
        }
    }
}
