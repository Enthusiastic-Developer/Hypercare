using System.Net.Http.Json;

namespace MappingEngineService.NunitTest
{
    public class MappingEngineClient
    {
        private readonly string _apiBaseUrl;
        private static readonly ILogger<MappingEngineClient> _logger = new NLogLoggerFactory().CreateLogger<MappingEngineClient>();

        public MappingEngineClient(string baseApiUrl)
        {
            _apiBaseUrl = baseApiUrl;
        }

        public async Task<IList<HypercareTaskSchedulerMap>> GetAllMappingEngine()
        {
            _logger.LogInformation("GetAllMappingEngine called");
            string url = $"{_apiBaseUrl}/api/Mapping/GetAllMappingEngine";
            using HttpClient client = new();
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IList<HypercareTaskSchedulerMap>>(result);
            }
            else
            {
                _logger.LogError("Error occurred: {ReasonPhrase}", response.ReasonPhrase);
                throw new Exception(response.ReasonPhrase);
            }
        }

        public async Task<IList<HypercareTaskSchedulerMap>> GetMappingEngineByScheduleId(int scheduleId)
        {
            _logger.LogInformation("GetMappingEngineByScheduleId called");
            string url = $"{_apiBaseUrl}/api/Mapping/GetMappingEngineByScheduleId?scheduleId={scheduleId}";
            using HttpClient client = new();
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IList<HypercareTaskSchedulerMap>>(result);
            }
            else
            {
                _logger.LogError("Error occurred: {ReasonPhrase}", response.ReasonPhrase);
                throw new Exception(response.ReasonPhrase);
            }
        }

        public async Task<IList<HypercareTaskSchedulerMap>> GetMappingEngineByTaskId(int taskId)
        {
            _logger.LogInformation("GetMappingEngineByTaskId called");
            string url = $"{_apiBaseUrl}/api/Mapping/GetMappingEngineByTaskId?taskId={taskId}";
            using HttpClient client = new();
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IList<HypercareTaskSchedulerMap>>(result);
            }
            else
            {
                _logger.LogError("Error occurred: {ReasonPhrase}", response.ReasonPhrase);
                throw new Exception(response.ReasonPhrase);
            }
        }

        public async Task<bool> AddMappingEngine(HypercareTaskSchedulerMap taskSchedulerMap)
        {
            _logger.LogInformation("GetMappingEngineByTaskId called");
            string url = $"{_apiBaseUrl}/api/Mapping/AddMappingEngine";
            using HttpClient client = new();
            var response = await client.PostAsJsonAsync(url, taskSchedulerMap);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<bool>(result);
            }
            else
            {
                _logger.LogError("Error occurred: {ReasonPhrase}", response.ReasonPhrase);
                throw new Exception(response.ReasonPhrase);
            }
        }

        public async Task<bool> UpdateMappingEngine(HypercareTaskSchedulerMap taskSchedulerMap)
        {
            _logger.LogInformation("GetMappingEngineByTaskId called");
            string url = $"{_apiBaseUrl}/api/Mapping/UpdateMappingEngine";
            using HttpClient client = new();
            var response = await client.PutAsJsonAsync(url, taskSchedulerMap);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<bool>(result);
            }
            else
            {
                _logger.LogError("Error occurred: {ReasonPhrase}", response.ReasonPhrase);
                throw new Exception(response.ReasonPhrase);
            }
        }

        public async Task<bool> DeleteMappingEngine(int mappingId, string deletedBy)
        {
            _logger.LogInformation("GetMappingEngineByTaskId called");
            string url = $"{_apiBaseUrl}/api/Mapping/DeleteMappingEngine?mappingId={mappingId}&deletedBy={deletedBy}";
            using HttpClient client = new();
            var response = await client.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<bool>(result);
            }
            else
            {
                _logger.LogError("Error occurred: {ReasonPhrase}", response.ReasonPhrase);
                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}
