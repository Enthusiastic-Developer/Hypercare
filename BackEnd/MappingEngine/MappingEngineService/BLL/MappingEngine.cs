using MappingEngineInterfaces;
using Microsoft.Extensions.Logging;
using ModelService.Hypercare;
using NLog.Extensions.Logging;

namespace MappingEngineService.BLL
{
    public class MappingEngine : IMappingEngineService
    {
        private readonly ILogger _logger = new NLogLoggerFactory().CreateLogger<MappingEngine>();
        public Task<bool> AddMappingEngine(HypercareTaskSchedulerMap taskSchedulerMap)
        {
            try
            {
                _logger.LogInformation("AddMappingEngine called");
                return BusinessObjects.MappingEngine.AddMappingEngine(taskSchedulerMap);
            }
            catch (Exception ex)
            {
                _logger.LogError("AddMappingEngine failed: {Error}", ex.Message);
                throw;
            }
        }

        public Task<bool> DeleteMappingEngine(int mappingId, string deletedBy)
        {
            try
            {
                _logger.LogInformation("DeleteMappingEngine called");
                return BusinessObjects.MappingEngine.DeleteMappingEngine(mappingId, deletedBy);
            }
            catch (Exception ex)
            {
                _logger.LogError("DeleteMappingEngine failed: {Error}", ex.Message);
                throw;
            }
        }

        public Task<IList<HypercareTaskSchedulerMap>> GetMappingEngine()
        {
            try
            {
                _logger.LogInformation("GetMappingEngine called");
                return BusinessObjects.MappingEngine.GetMappingEngine();
            }
            catch (Exception ex)
            {
                _logger.LogError("GetMappingEngine failed: {Error}", ex.Message);
                throw;
            }
        }

        public Task<IList<HypercareTaskSchedulerMap>> GetMappingEngineByScheduleId(int scheduleId)
        {
            try
            {
                _logger.LogInformation("GetMappingEngineByScheduleId called");
                return BusinessObjects.MappingEngine.GetMappingEngineByScheduleId(scheduleId);
            }
            catch (Exception ex)
            {
                _logger.LogError("GetMappingEngineByScheduleId failed: {Error}", ex.Message);
                throw;
            }
        }

        public Task<IList<HypercareTaskSchedulerMap>> GetMappingEngineByTaskId(int taskId)
        {
            try
            {
                _logger.LogInformation("GetMappingEngineByTaskId called");
                return BusinessObjects.MappingEngine.GetMappingEngineByTaskId(taskId);
            }
            catch (Exception ex)
            {
                _logger.LogError("GetMappingEngineByTaskId failed: {Error}", ex.Message);
                throw;
            }
        }

        public Task<bool> UpdateMappingEngine(HypercareTaskSchedulerMap taskSchedulerMap)
        {
            try
            {
                _logger.LogInformation("UpdateMappingEngine called");
                return BusinessObjects.MappingEngine.UpdateMappingEngine(taskSchedulerMap);
            }
            catch (Exception ex)
            {
                _logger.LogError("UpdateMappingEngine failed: {Error}", ex.Message);
                throw;
            }
        }
    }
}
