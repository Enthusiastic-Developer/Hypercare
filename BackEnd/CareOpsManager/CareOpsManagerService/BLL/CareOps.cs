using CareOpsManagerInterfaces;
using Microsoft.Extensions.Logging;
using ModelService.Hypercare;
using NLog.Extensions.Logging;

namespace CareOpsManagerService.BLL
{
    public class CareOps : ICareOpsManagerService
    {
        private readonly ILogger _logger = new NLogLoggerFactory().CreateLogger<CareOps>();
        public Task<bool> AddCareOpsManager(HyperCareTaskMaster careTaskMaster)
        {
            try
            {
                _logger.LogInformation("AddCareOpsManager called");
                return BusinessObjects.CareOps.AddCareOpsManager(careTaskMaster);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "AddCareOpsManager failed");
                throw;
            }
        }

        public Task<IList<HyperCareTaskMaster>> GetCareOpsManager()
        {
            try
            {
                _logger.LogInformation("GetCareOpsManager called");
                return BusinessObjects.CareOps.GetCareOpsManager();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetCareOpsManager failed");
                throw;
            }
        }

        public Task<IList<HyperCareTaskMaster>> GetCareOpsManagerById(int taskId)
        {
            try
            {
                _logger.LogInformation("GetCareOpsManagerById called");
                return BusinessObjects.CareOps.GetCareOpsManagerById(taskId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetCareOpsManagerById failed");
                throw;
            }
        }

        public Task<bool> UpdateCareOpsManager(HyperCareTaskMaster careTaskMaster)
        {
            try
            {
                _logger.LogInformation("UpdateCareOpsManager called");
                return BusinessObjects.CareOps.UpdateCareOpsManager(careTaskMaster);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "UpdateCareOpsManager failed");
                throw;
            }
        }

        public Task<bool> DeleteCareOpsManager(int taskId, string deletedBy)
        {
            try
            {
                _logger.LogInformation("DeleteCareOpsManager called");
                return BusinessObjects.CareOps.DeleteCareOpsManager(taskId, deletedBy);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "DeleteCareOpsManager failed");
                throw;
            }
        }
    }
}
