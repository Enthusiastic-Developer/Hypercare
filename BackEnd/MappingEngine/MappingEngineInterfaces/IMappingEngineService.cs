using ModelService.Hypercare;

namespace MappingEngineInterfaces
{
    public interface IMappingEngineService
    {
        Task<bool> UpdateMappingEngine(HypercareTaskSchedulerMap taskSchedulerMap);
        Task<bool> AddMappingEngine(HypercareTaskSchedulerMap taskSchedulerMap);
        Task<IList<HypercareTaskSchedulerMap>> GetMappingEngine();
        Task<IList<HypercareTaskSchedulerMap>> GetMappingEngineByTaskId(int taskId);
        Task<IList<HypercareTaskSchedulerMap>> GetMappingEngineByScheduleId(int scheduleId);
        Task<bool> DeleteMappingEngine(int mappingId, string deletedBy);
    }
}
