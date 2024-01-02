namespace MappingEngineService.NunitTest
{
    [TestFixture]
    public class MappingControllerTest
    {
        private const string _baseApiUrl = "http://localhost:5128";
        private MappingEngineClient _client;
        readonly List<string> _passedTests = new();
        readonly List<string> _failedTests = new();

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
                    TrackAssertionResult(() =>
                    {
                        Assert.That(map.HcTsId, Is.GreaterThanOrEqualTo(0), $"HcTsId should be greater than or equal to 0 for mapping {map.HcTsId}");
                    }, "HcTsId", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(map.HcSchId, Is.GreaterThanOrEqualTo(0), $"HcSchId should be greater than or equal to 0 for mapping {map.HcSchId}");
                    }, "HcSchId", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(map.HcTaskId, Is.GreaterThanOrEqualTo(0), $"HcTaskId should be greater than or equal to 0 for mapping {map.HcTaskId}");
                    }, "HcTaskId", _passedTests, _failedTests);

                });
            }
            TestContext.WriteLine("Test results:");
            TestContext.WriteLine($"Passed tests: {string.Join(", ", _passedTests)}");
            TestContext.WriteLine($"Failed tests: {string.Join(", ", _failedTests)}");
            Assert.That(_failedTests, Is.Empty, "One or more tests failed.");
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
                    TrackAssertionResult(() =>
                    {
                        Assert.That(map.HcTsId, Is.GreaterThanOrEqualTo(0), $"HcTsId should be greater than or equal to 0 for mapping {map.HcTsId}");
                    }, "HcTsId", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(map.HcSchId, Is.GreaterThanOrEqualTo(0), $"HcSchId should be greater than or equal to 0 for mapping {map.HcSchId}");
                    }, "HcSchId", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(map.HcTaskId, Is.GreaterThanOrEqualTo(0), $"HcTaskId should be greater than or equal to 0 for mapping {map.HcTaskId}");
                    }, "HcTaskId", _passedTests, _failedTests);

                });
            }
            TestContext.WriteLine("Test results:");
            TestContext.WriteLine($"Passed tests: {string.Join(", ", _passedTests)}");
            TestContext.WriteLine($"Failed tests: {string.Join(", ", _failedTests)}");
            Assert.That(_failedTests, Is.Empty, "One or more tests failed.");
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
                    TrackAssertionResult(() =>
                    {
                        Assert.That(map.HcTsId, Is.GreaterThanOrEqualTo(0), $"HcTsId should be greater than or equal to 0 for mapping {map.HcTsId}");
                    }, "HcTsId", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(map.HcSchId, Is.GreaterThanOrEqualTo(0), $"HcSchId should be greater than or equal to 0 for mapping {map.HcSchId}");
                    }, "HcSchId", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(map.HcTaskId, Is.GreaterThanOrEqualTo(0), $"HcTaskId should be greater than or equal to 0 for mapping {map.HcTaskId}");
                    }, "HcTaskId", _passedTests, _failedTests);

                });
            }
            TestContext.WriteLine("Test results:");
            TestContext.WriteLine($"Passed tests: {string.Join(", ", _passedTests)}");
            TestContext.WriteLine($"Failed tests: {string.Join(", ", _failedTests)}");
            Assert.That(_failedTests, Is.Empty, "One or more tests failed.");
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

        private static void TrackAssertionResult(Action assertion, string testName, List<string> passedTests, List<string> failedTests)
        {
            try
            {
                assertion.Invoke();
                passedTests.Add(testName);
            }
            catch (Exception ex)
            {
                failedTests.Add(testName);
                TestContext.WriteLine($"Assertion failed for {testName}: {ex.Message}");
            }
        }
    }
}
