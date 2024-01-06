using ModelService.Hypercare;

namespace CronCraftInterfaces
{
    public interface ICronCraftService
    {
        Task<bool> UpdateCronCraft(HyperCareScheduler taskSchedulerMap);
        Task<bool> AddCronCraft(HyperCareScheduler taskSchedulerMap);
        Task<IList<HyperCareScheduler>> GetCronCraft();
        Task<IList<HyperCareScheduler>> GetCronCraftById(int scheduleId);
        Task<bool> DeleteCronCraft(int scheduleId, string deletedBy);
    }
}
