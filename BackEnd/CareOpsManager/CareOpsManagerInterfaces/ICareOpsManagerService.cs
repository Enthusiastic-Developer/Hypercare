using ModelService.Hypercare;

namespace CareOpsManagerInterfaces
{
    public interface ICareOpsManagerService
    {
        Task<bool> UpdateCareOpsManager(HyperCareTaskMaster careTaskMaster);
        Task<bool> AddCareOpsManager(HyperCareTaskMaster careTaskMaster);
        Task<IList<HyperCareTaskMaster>> GetCareOpsManager();
        Task<IList<HyperCareTaskMaster>> GetCareOpsManagerById(int taskId);
        Task<bool> DeleteCareOpsManager(int taskId, string deletedBy);
    }
}
