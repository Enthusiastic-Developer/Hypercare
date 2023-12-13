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
                _logger.LogInformation("Error while Performing DataArchival {0}", ex);
                return false;
            }
        }

        //Declare the service factory here based on the args we have to change the class
        public void ServiceFactory(string processType)
        {
            switch (processType)
            {
                case "DataDump":
                    DataDump dataDump = new DataDump();
                    dataDump.StartProcess();
                    break;
                case "JsonCreation":
                    JsonFileCreation jsonFileCreation = new JsonFileCreation();
                    jsonFileCreation.StartProcess();
                    break;
                case "InsertJson":
                    InsertJsonData insertJsonData = new InsertJsonData();
                    insertJsonData.StartProcess();
                    break;
                default:
                    break;
            }
        }
    }
}
