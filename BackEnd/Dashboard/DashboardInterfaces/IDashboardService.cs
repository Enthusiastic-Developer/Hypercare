using ModelService.Dashboard;

namespace DashboardInterfaces
{
    public interface IDashboardService
    {
        Task<IssueStatistics> GetIssueStatisticsForTDay(DateTime dateTime);
        Task<IssueStatistics> GetIssueStatistics(DateTime fromDate, DateTime toDate);
        Task<IList<DailyCount>> GetCountForDay(DateTime fromDate, DateTime toDate);
        Task<IList<DailyCount>> GetCountForTDay(DateTime dateTime);
        Task<IList<ModuleStatistics>> GetModuleStatistics(DateTime fromDate, DateTime toDate);
        Task<IList<ModuleStatistics>> GetModuleStatisticsForTDay(DateTime dateTime);
    }
}
