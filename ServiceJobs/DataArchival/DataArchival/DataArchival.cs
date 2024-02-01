using DataArchival.Services;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using ServiceJob.Helper;

namespace DataArchival
{
    public class DataArchival : BaseService
    {
        private readonly ILogger _logger = (new NLogLoggerFactory()).CreateLogger<DataArchival>();

        public override bool StartProcess(string[] args)
        {
            try
            {
                string processType = args[0];
                _logger.LogInformation("DataArchival Started");
                ServiceFactory(processType);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error while Performing DataArchival: {ex}", ex);
                return false;
            }
        }

        //Declare the service factory here based on the args we have to change the class
        public static void ServiceFactory(string processType)
        {
            switch (processType)
            {
                case "DataDump":
                    DataDump.StartProcess();
                    break;
                case "JsonCreation":
                    JsonFileCreation.StartProcess();
                    break;
                case "InsertJson":
                    InsertJsonData.StartProcess();
                    break;
                default:
                    break;
            }
        }
    }
}
