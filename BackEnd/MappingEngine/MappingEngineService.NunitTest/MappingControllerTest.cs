namespace MappingEngineService.NunitTest
{
    [TestFixture]
    public class MappingControllerTest
    {
        private const string _baseApiUrl = "http://localhost:5128";
        private MappingEngineClient _client;

        [SetUp]
        public void Setup()
        {
            _client = new MappingEngineClient(_baseApiUrl);
        }

        [Test]
        public async Task GetMapping_ShouldReturnMapping()
        {
            var mapping = await _client.GetAllMappingEngine();
            Assert.That(mapping, Is.Not.Null, "The returned list of mapping should not be null");
            Assert.That(mapping, Is.Not.Empty, "The returned list of mapping should have at least one mapping");
            foreach (var map in mapping)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(map.HcTsId, Is.GreaterThanOrEqualTo(0), $"HcTsId should be greater than or equal to 0 for mapping {map.HcTsId}");
                    Assert.That(map.HcSchId, Is.GreaterThanOrEqualTo(0), $"HcSchId should be greater than or equal to 0 for mapping {map.HcSchId}");
                    Assert.That(map.HcTaskId, Is.GreaterThanOrEqualTo(0), $"HcTaskId should be greater than or equal to 0 for mapping {map.HcTaskId}");
                });
            }
        }

        [Test]
        public async Task GetMappingEngineByScheduleId_ShouldReturnMapping()
        {
            var mapping = await _client.GetMappingEngineByScheduleId(21);
            Assert.That(mapping, Is.Not.Null, "The returned list of mapping should not be null");
            Assert.That(mapping, Is.Not.Empty, "The returned list of mapping should have at least one mapping");
            foreach (var map in mapping)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(map.HcTsId, Is.GreaterThanOrEqualTo(0), $"HcTsId should be greater than or equal to 0 for mapping {map.HcTsId}");
                    Assert.That(map.HcSchId, Is.GreaterThanOrEqualTo(0), $"HcSchId should be greater than or equal to 0 for mapping {map.HcSchId}");
                    Assert.That(map.HcTaskId, Is.GreaterThanOrEqualTo(0), $"HcTaskId should be greater than or equal to 0 for mapping {map.HcTaskId}");
                });
            }
        }

        [Test]
        public async Task GetMappingEngineByTaskId_ShouldReturnMapping()
        {
            var mapping = await _client.GetMappingEngineByTaskId(1);
            Assert.That(mapping, Is.Not.Null, "The returned list of mapping should not be null");
            Assert.That(mapping, Is.Not.Empty, "The returned list of mapping should have at least one mapping");
            foreach (var map in mapping)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(map.HcTsId, Is.GreaterThanOrEqualTo(0), $"HcTsId should be greater than or equal to 0 for mapping {map.HcTsId}");
                    Assert.That(map.HcSchId, Is.GreaterThanOrEqualTo(0), $"HcSchId should be greater than or equal to 0 for mapping {map.HcSchId}");
                    Assert.That(map.HcTaskId, Is.GreaterThanOrEqualTo(0), $"HcTaskId should be greater than or equal to 0 for mapping {map.HcTaskId}");
                });
            }
        }

        [Test]
        public async Task AddMappingEngine_ShouldReturnBool()
        {
            var mapping = new HypercareTaskSchedulerMap
            {
                HcSchId = 21,
                HcTaskId = 1,
                CreatedDate = DateTime.Now,
                CreatedUser = "UnitTest",
                UpdatedDate = DateTime.Now,
                UpdatedUser = "UnitTest",
                StartDate = DateTime.Now,
                EndDate = new DateTime(9999, 12, 31, 0, 0, 0, 0),
                IsActive = true
            };
            var result = await _client.AddMappingEngine(mapping);
            Assert.That(result, Is.True, "The returned result should be true");
        }

        [Test]
        public async Task UpdateMappingEngine_ShouldReturnBool()
        {
            var mapping = new HypercareTaskSchedulerMap
            {
                HcTsId = 137,
                HcSchId = 21,
                HcTaskId = 1,
                CreatedDate = DateTime.Now,
                CreatedUser = "UnitTest-1",
                UpdatedDate = DateTime.Now,
                UpdatedUser = "UnitTest-1",
                StartDate = DateTime.Now,
                EndDate = new DateTime(9999, 12, 31, 0, 0, 0, 0),
                IsActive = true
            };
            var result = await _client.UpdateMappingEngine(mapping);
            Assert.That(result, Is.True, "The returned result should be true");
        }

    }
}
