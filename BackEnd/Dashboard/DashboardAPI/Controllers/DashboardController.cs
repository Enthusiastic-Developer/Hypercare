using DashboardInterfaces;
using DashboardService.BLL;
using Microsoft.AspNetCore.Mvc;
using ModelService.Dashboard;

namespace DashboardAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly ILogger _logger = new LoggerFactory().CreateLogger<DashboardController>();
        private static IDashboardService DashboardService => new Dashboard();

        [HttpGet]
        public async Task<IList<DailyCount>> GetCountForTDay(DateTime dateTime)
        {
            _logger.LogInformation("GetCountForTDay called");
            return await DashboardService.GetCountForTDay(dateTime);
        }

        [HttpGet]
        public async Task<IList<DailyCount>> GetCountForDay(DateTime fromDate, DateTime toDate)
        {
            _logger.LogInformation("GetCountForDay called");
            return await DashboardService.GetCountForDay(fromDate, toDate);
        }

        [HttpGet]
        public async Task<IssueStatistics> GetIssueStatisticsForTDay(DateTime dateTime)
        {
            _logger.LogInformation("GetIssueStatisticsForTDay called");
            return await DashboardService.GetIssueStatisticsForTDay(dateTime);
        }

        [HttpGet]
        public async Task<IssueStatistics> GetIssueStatistics(DateTime fromDate, DateTime toDate)
        {
            _logger.LogInformation("GetIssueStatistics called");
            return await DashboardService.GetIssueStatistics(fromDate, toDate);
        }

        [HttpGet]
        public async Task<IList<ModuleStatistics>> GetModuleStatisticsForTDay(DateTime dateTime)
        {
            _logger.LogInformation("GetModuleStatisticsForTDay called");
            return await DashboardService.GetModuleStatisticsForTDay(dateTime);
        }

        [HttpGet]
        public async Task<IList<ModuleStatistics>> GetModuleStatistics(DateTime fromDate, DateTime toDate)
        {
            _logger.LogInformation("GetModuleStatistics called");
            return await DashboardService.GetModuleStatistics(fromDate, toDate);
        }
    }
}
