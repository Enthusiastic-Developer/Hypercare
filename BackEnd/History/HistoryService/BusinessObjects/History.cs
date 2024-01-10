using ModelService.Common;
using ModelService.Hypercare;

namespace HistoryService.BusinessObjects
{
    public class History
    {
        public static async Task<IList<HyperCareTracker>> GetHistory(Pagination pagination)
        {
            return await Task.Run(() =>
            {
                return new DAL.History().GetHistory(pagination);
            });
        }

        public static async Task<IList<HyperCareTracker>> GetHistoryBasedonDate(Pagination pagination, DateTime fromDate, DateTime toDate)
        {
            return await Task.Run(() =>
            {
                return new DAL.History().GetHistoryBasedonDate(pagination, fromDate, toDate);
            });
        }

        public static async Task<IList<HyperCareTracker>> GetHistoryByScheduleId(Pagination pagination, int scheduleId)
        {
            return await Task.Run(() =>
            {
                return new DAL.History().GetHistoryByScheduleId(pagination, scheduleId);
            });
        }

        public static async Task<IList<HyperCareTracker>> GetHistoryByTaskId(Pagination pagination, int taskId)
        {
            return await Task.Run(() =>
            {
                return new DAL.History().GetHistoryByTaskId(pagination, taskId);
            });
        }
    }
}
