using ModelService.Common;
using ModelService.Hypercare;

namespace HistoryInterfaces
{
    public interface IHistoryService
    {
        Task<IList<HyperCareTracker>> GetHistory(Pagination pagination);
        Task<IList<HyperCareTracker>> GetHistoryByTaskId(Pagination pagination, int taskId);
        Task<IList<HyperCareTracker>> GetHistoryByScheduleId(Pagination pagination, int scheduleId);
        Task<IList<HyperCareTracker>> GetHistoryBasedonDate(Pagination pagination, DateTime fromDate, DateTime toDate);
    }
}
