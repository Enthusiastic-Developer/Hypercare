using ModelService.Hypercare;

namespace CareOpsManagerService.BusinessObjects
{
    public class CareOps
    {
        public static async Task<IList<HyperCareTaskMaster>> GetCareOpsManager()
        {
            return await Task.Run(() =>
            {
                return new DAL.CareOps().GetCareOps();
            });
        }

        public static async Task<IList<HyperCareTaskMaster>> GetCareOpsManagerById(int taskId)
        {
            return await Task.Run(() =>
            {
                return new DAL.CareOps().GetCareOpsById(taskId);
            });
        }

        public static async Task<bool> AddCareOpsManager(HyperCareTaskMaster careTaskMaster)
        {
            return await Task.Run(() =>
            {
                return new DAL.CareOps().AddCareOps(careTaskMaster);
            });
        }

        public static async Task<bool> UpdateCareOpsManager(HyperCareTaskMaster careTaskMaster)
        {
            return await Task.Run(() =>
            {
                return new DAL.CareOps().UpdateCareOps(careTaskMaster);
            });
        }

        public static Task<bool> DeleteCareOpsManager(int taskId, string deletedBy)
        {
            return Task.Run(() =>
            {
                return new DAL.CareOps().DeleteCareOps(taskId, deletedBy);
            });
        }
    }
}
