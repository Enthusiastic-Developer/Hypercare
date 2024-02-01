namespace CareOpsManagerService.NunitTest
{
    public class CareOpsControllerTest
    {
        private const string _baseApiUrl = "http://localhost:5091";
        private CareOpsManagerClient _client;
        readonly List<string> _passedTests = new();
        readonly List<string> _failedTests = new();

        [SetUp]
        public void Setup()
        {
            _client = new CareOpsManagerClient(_baseApiUrl);
        }

        [Test]
        public async Task GetCareOpsManager_ShouldReturnCareOpsManager()
        {
            var careOpsManager = await _client.GetCareOpsManager();
            Assert.That(careOpsManager, Is.Not.Null, "The returned list of careOpsManager should not be null");
            Assert.That(careOpsManager, Is.Not.Empty, "The returned list of careOpsManager should have at least one careOpsManager");

            foreach (var care in careOpsManager)
            {
                Assert.Multiple(() =>
                {
                    TrackAssertionResult(() =>
                    {
                        Assert.That(care.HcTaskId, Is.GreaterThanOrEqualTo(0), $"HcTaskId should be greater than or equal to 0 for careOpsManager {care.HcTaskId}");
                    }, "HcTaskId", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(care.TaskName, Is.Not.Null, $"TaskName should not be null for careOpsManager {care.TaskName}");
                    }, "TaskName", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(care.TaskDesc, Is.Not.Null, $"TaskDesc should not be null for careOpsManager {care.TaskDesc}");
                    }, "TaskDesc", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(care.Priority, Is.Not.Null, $"Priority should not be null for careOpsManager {care.Priority}");
                    }, "Priority", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(care.Severity, Is.Not.Null, $"Severity should not be null for careOpsManager {care.Severity}");
                    }, "Severity", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(care.ModuleName, Is.Not.Null, $"ModuleName should not be null for careOpsManager {care.ModuleName}");
                    }, "ModuleName", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(care.Operations, Is.Not.Null, $"Operations should not be null for careOpsManager {care.Operations}");
                    }, "Operations", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(care.IsActive, Is.TypeOf<bool>(), $"IsActive should be of type bool for cronCraft {care.IsActive}");
                    }, "IsActive", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(care.MonitoredBy, Is.Not.Null, $"MonitoredBy should not be null for careOpsManager {care.MonitoredBy}");
                    }, "MonitoredBy", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(care.Method, Is.Not.Null, $"Method should not be null for careOpsManager {care.Method}");
                    }, "Method", _passedTests, _failedTests);
                });
            }

            TestContext.WriteLine("Test results:");
            TestContext.WriteLine($"Passed tests: {string.Join(", ", _passedTests)}");
            TestContext.WriteLine($"Failed tests: {string.Join(", ", _failedTests)}");
            Assert.That(_failedTests, Is.Empty, "One or more tests failed.");
        }

        [Test]
        public async Task GetCareOpsManagerById_ShouldReturnCareOpsManager()
        {
            var opsManager = await _client.GetCareOpsManager();
            var careOpsManager = await _client.GetCareOpsManagerById(opsManager[0].HcTaskId);
            Assert.That(careOpsManager, Is.Not.Null, "The returned list of careOpsManager should not be null");
            Assert.That(careOpsManager, Is.Not.Empty, "The returned list of careOpsManager should have at least one careOpsManager");

            foreach (var care in careOpsManager)
            {
                Assert.Multiple(() =>
                {
                    TrackAssertionResult(() =>
                    {
                        Assert.That(care.HcTaskId, Is.GreaterThanOrEqualTo(0), $"HcTaskId should be greater than or equal to 0 for careOpsManager {care.HcTaskId}");
                    }, "HcTaskId", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(care.TaskName, Is.Not.Null, $"TaskName should not be null for careOpsManager {care.TaskName}");
                    }, "TaskName", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(care.TaskDesc, Is.Not.Null, $"TaskDesc should not be null for careOpsManager {care.TaskDesc}");
                    }, "TaskDesc", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(care.Priority, Is.Not.Null, $"Priority should not be null for careOpsManager {care.Priority}");
                    }, "Priority", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(care.Severity, Is.Not.Null, $"Severity should not be null for careOpsManager {care.Severity}");
                    }, "Severity", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(care.ModuleName, Is.Not.Null, $"ModuleName should not be null for careOpsManager {care.ModuleName}");
                    }, "ModuleName", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(care.Operations, Is.Not.Null, $"Operations should not be null for careOpsManager {care.Operations}");
                    }, "Operations", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(care.IsActive, Is.TypeOf<bool>(), $"IsActive should be of type bool for cronCraft {care.IsActive}");
                    }, "IsActive", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(care.MonitoredBy, Is.Not.Null, $"MonitoredBy should not be null for careOpsManager {care.MonitoredBy}");
                    }, "MonitoredBy", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(care.Method, Is.Not.Null, $"Method should not be null for careOpsManager {care.Method}");
                    }, "Method", _passedTests, _failedTests);
                });
            }

            TestContext.WriteLine("Test results:");
            TestContext.WriteLine($"Passed tests: {string.Join(", ", _passedTests)}");
            TestContext.WriteLine($"Failed tests: {string.Join(", ", _failedTests)}");
            Assert.That(_failedTests, Is.Empty, "One or more tests failed.");
        }

        [Test]
        public async Task AddCareOpsManager_ShouldReturnBool()
        {
            var careOpsManager = new HyperCareTaskMaster
            {
                TaskName = "Test",
                TaskDesc = "Test",
                ThresholdFromRange = 1,
                ThresholdToRange = 1,
                CreatedDate = DateTime.Now,
                CreatedUser = "Test",
                UpdatedDate = DateTime.Now,
                UpdatedUser = "Test",
                Priority = "Test",
                Severity = "Test",
                ModuleName = "Test",
                Operations = "Test",
                Purpose = "Test",
                WhatToMonitor = "Test",
                DependsOn = "Test",
                IsActive = true,
                Threshold = "45",
                ResponsibleTeam = "Test",
                Operator = ">",
                EmailCC = "Test",
                EmailTo = "Test",
                MonitoredBy = "Test",
                Method = "Test",
                Frequency = "Test",
                FrequencyCount1 = 1,
                FrequencyCount2 = 1,
                MinuteCount1 = 1,
                MinuteCount2 = 1,
            };
            var result = await _client.AddCareOpsManager(careOpsManager);
            Assert.That(result, Is.True, "The returned result should be true");
        }

        [Test]
        public async Task UpdateCareOpsManager_ShouldReturnBool()
        {
            var opsManager = await _client.GetCareOpsManager();
            var careOpsManager = new HyperCareTaskMaster
            {
                HcTaskId = opsManager[0].HcTaskId,
                TaskName = "Test -1",
                TaskDesc = "Test -1",
                ThresholdFromRange = 1,
                ThresholdToRange = 1,
                UpdatedUser = "Test -1",
                Priority = "Test",
                Severity = "Test",
                ModuleName = "Test",
                Operations = "Test",
                Purpose = "Test",
                WhatToMonitor = "Test",
                DependsOn = "Test",
                IsActive = true,
                Threshold = "45",
                ResponsibleTeam = "Test",
                Operator = ">",
                EmailCC = "Test",
                EmailTo = "Test",
                MonitoredBy = "Test",
                Method = "Test",
                Frequency = "Test",
                FrequencyCount1 = 1,
                FrequencyCount2 = 1,
                MinuteCount1 = 1,
                MinuteCount2 = 1,
            };
            var result = await _client.UpdateCareOpsManager(careOpsManager);
            Assert.That(result, Is.True, "The returned result should be true");
        }

        [Test]
        public async Task DeleteCareOpsManager_ShouldReturnBool()
        {
            var opsManager = await _client.GetCareOpsManager();
            var result = await _client.DeleteCareOpsManager(opsManager[0].HcTaskId, "Nikhil");
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
