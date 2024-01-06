using ModelService.Hypercare;

namespace CronCraftService.BusinessObjects
{
    public class CronCraft
    {
        public static async Task<IList<HyperCareScheduler>> GetCronCraft()
        {
            return await Task.Run(() =>
            {
                return new DAL.CronCraft().GetCronCraft();
            });
        }

        public static async Task<IList<HyperCareScheduler>> GetCronCraftById(int scheduleId)
        {
            return await Task.Run(() =>
            {
                return new DAL.CronCraft().GetCronCraftById(scheduleId);
            });
        }

        public static async Task<bool> AddCronCraft(HyperCareScheduler taskSchedulerMap)
        {
            return await Task.Run(() =>
            {
                return new DAL.CronCraft().AddCronCraft(taskSchedulerMap);
            });
        }

        public static async Task<bool> UpdateCronCraft(HyperCareScheduler taskSchedulerMap)
        {
            return await Task.Run(() =>
            {
                return new DAL.CronCraft().UpdateCronCraft(taskSchedulerMap);
            });
        }

        public static Task<bool> DeleteCronCraft(int scheduleId, string deletedBy)
        {
            return Task.Run(() =>
            {
                return new DAL.CronCraft().DeleteCronCraft(scheduleId, deletedBy);
            });
        }
    }
}
