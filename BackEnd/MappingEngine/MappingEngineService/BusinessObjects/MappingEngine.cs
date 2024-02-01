using ModelService.Hypercare;

namespace MappingEngineService.BusinessObjects
{
    public static class MappingEngine
    {
        public static async Task<IList<HypercareTaskSchedulerMap>> GetMappingEngine()
        {
            return await Task.Run(() =>
            {
                return new DAL.MappingEngine().GetMappingEngine();
            });
        }

        public static async Task<IList<HypercareTaskSchedulerMap>> GetMappingEngineByTaskId(int taskId)
        {
            return await Task.Run(() =>
            {
                return new DAL.MappingEngine().GetMappingEngineByTaskId(taskId);
            });
        }

        public static async Task<IList<HypercareTaskSchedulerMap>> GetMappingEngineByScheduleId(int scheduleId)
        {
            return await Task.Run(() =>
            {
                return new DAL.MappingEngine().GetMappingEngineByScheduleId(scheduleId);
            });
        }

        public static async Task<bool> AddMappingEngine(HypercareTaskSchedulerMap taskSchedulerMap)
        {
            return await Task.Run(() =>
            {
                return new DAL.MappingEngine().AddMappingEngine(taskSchedulerMap);
            });
        }

        public static async Task<bool> UpdateMappingEngine(HypercareTaskSchedulerMap taskSchedulerMap)
        {
            return await Task.Run(() =>
            {
                return new DAL.MappingEngine().UpdateMappingEngine(taskSchedulerMap);
            });
        }

        public static async Task<bool> DeleteMappingEngine(int mappingId, string deletedBy)
        {
            return await Task.Run(() =>
            {
                return new DAL.MappingEngine().DeleteMappingEngine(mappingId, deletedBy);
            });
        }
    }
}
