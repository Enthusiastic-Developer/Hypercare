using ModelService.Dashboard;

namespace DashboardService.BusinessObjects
{
    public class Dashboard
    {
        public static async Task<IList<DailyCount>> GetCountForDay(DateTime fromDate, DateTime toDate)
        {
            return await Task.Run(() =>
            {
                return new DAL.Dashboard().GetCountForDay(fromDate, toDate);
            });
        }

        public static async Task<IList<DailyCount>> GetCountForTDay(DateTime dateTime)
        {
            return await Task.Run(() =>
            {
                return new DAL.Dashboard().GetCountForTDay(dateTime);
            });
        }

        public static async Task<IssueStatistics> GetIssueStatistics(DateTime fromDate, DateTime toDate)
        {
            return await Task.Run(() =>
            {
                return new DAL.Dashboard().GetIssueStatistics(fromDate, toDate);
            });
        }

        public static async Task<IssueStatistics> GetIssueStatisticsForTDay(DateTime dateTime)
        {
            return await Task.Run(() =>
            {
                return new DAL.Dashboard().GetIssueStatisticsForTDay(dateTime);
            });
        }

        public static async Task<IList<ModuleStatistics>> GetModuleStatistics(DateTime fromDate, DateTime toDate)
        {
            return await Task.Run(() =>
            {
                return new DAL.Dashboard().GetModuleStatistics(fromDate, toDate);
            });
        }

        public static async Task<IList<ModuleStatistics>> GetModuleStatisticsForTDay(DateTime dateTime)
        {
            return await Task.Run(() =>
            {
                return new DAL.Dashboard().GetModuleStatisticsForTDay(dateTime);
            });
        }
    }
}
