using System.Globalization;

namespace CronCraftService.NunitTest
{
    public class CronCraftControllerTest
    {
        private const string _baseApiUrl = "http://localhost:5065";
        private CronCraftClient _client;
        readonly List<string> _passedTests = new();
        readonly List<string> _failedTests = new();

        [SetUp]
        public void Setup()
        {
            _client = new CronCraftClient(_baseApiUrl);
        }

        [Test]
        public async Task GetCronCraft_ShouldReturnCronCraft()
        {
            var cronCraft = await _client.GetCronCraft();
            Assert.That(cronCraft, Is.Not.Null, "The returned list of cronCraft should not be null");
            Assert.That(cronCraft, Is.Not.Empty, "The returned list of cronCraft should have at least one cronCraft");

            foreach (var cron in cronCraft)
            {
                Assert.Multiple(() =>
                {
                    TrackAssertionResult(() =>
                    {
                        Assert.That(cron.HcSchId, Is.GreaterThanOrEqualTo(0), $"HcSchId should be greater than or equal to 0 for cronCraft {cron.HcSchId}");
                    }, "HcSchId", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(cron.SchedulerName, Is.Not.Null, $"SchedulerName should not be null for cronCraft {cron.SchedulerName}");
                    }, "SchedulerName", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(cron.SchedulerDesc, Is.Not.Null, $"SchedulerDesc should not be null for cronCraft {cron.SchedulerDesc}");
                    }, "SchedulerDesc", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(cron.IsActive, Is.TypeOf<bool>(), $"IsActive should be of type bool for cronCraft {cron.IsActive}");
                    }, "IsActive", _passedTests, _failedTests);
                });
            }

            // Display results
            TestContext.WriteLine("Test results:");
            TestContext.WriteLine($"Passed tests: {string.Join(", ", _passedTests)}");
            TestContext.WriteLine($"Failed tests: {string.Join(", ", _failedTests)}");
            Assert.That(_failedTests, Is.Empty, "One or more tests failed.");
        }

        [Test]
        public async Task GetCronCraftById_ShouldReturnCronCraft()
        {
            var craftCron = await _client.GetCronCraft();
            var cronCraft = await _client.GetCronCraftById(craftCron[0].HcSchId);
            Assert.That(cronCraft, Is.Not.Null, "The returned list of cronCraft should not be null");
            Assert.That(cronCraft, Is.Not.Empty, "The returned list of cronCraft should have at least one cronCraft");

            foreach (var cron in cronCraft)
            {
                Assert.Multiple(() =>
                {
                    TrackAssertionResult(() =>
                    {
                        Assert.That(cron.HcSchId, Is.GreaterThanOrEqualTo(0), $"HcSchId should be greater than or equal to 0 for cronCraft {cron.HcSchId}");
                    }, "HcSchId", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(cron.SchedulerName, Is.Not.Null, $"SchedulerName should not be null for cronCraft {cron.SchedulerName}");
                    }, "SchedulerName", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(cron.SchedulerDesc, Is.Not.Null, $"SchedulerDesc should not be null for cronCraft {cron.SchedulerDesc}");
                    }, "SchedulerDesc", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(cron.IsActive, Is.TypeOf<bool>(), $"IsActive should be of type bool for cronCraft {cron.IsActive}");
                    }, "IsActive", _passedTests, _failedTests);
                });
            }

            // Display results
            TestContext.WriteLine("Test results:");
            TestContext.WriteLine($"Passed tests: {string.Join(", ", _passedTests)}");
            TestContext.WriteLine($"Failed tests: {string.Join(", ", _failedTests)}");
            Assert.That(_failedTests, Is.Empty, "One or more tests failed.");
        }

        [Test]
        public async Task AddCronCraft_ShouldReturnBool()
        {
            var schedule = new HyperCareScheduler
            {
                SchedulerName = "Test",
                SchedulerDesc = "Test",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.ParseExact("9999-12-31 00:00:00.000", "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture),
                ScheduleTime = DateTime.ParseExact("1900-01-01 00:00:00.000", "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture),
                CreatedDate = DateTime.UtcNow,
                CreatedUser = "UnitTest",
                UpdatedDate = DateTime.UtcNow,
                UpdatedUser = "UnitTest",
                IsActive = true,
                FrequencyStartDay = 0,
                FrequencyEndDay = 0,
                IsOneOff = false
            };
            var result = await _client.AddCronCraft(schedule);
            Assert.That(result, Is.True, "The returned result should be true");
        }

        [Test]
        public async Task UpdateCronCraft_ShouldReturnBool()
        {
            var craftCron = await _client.GetCronCraft();
            var schedule = new HyperCareScheduler
            {
                HcSchId = craftCron[0].HcSchId,
                SchedulerName = "Test-1",
                SchedulerDesc = "Test-1",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.ParseExact("9999-12-31 00:00:00.000", "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture),
                ScheduleTime = DateTime.ParseExact("1900-01-01 00:00:00.000", "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture),
                CreatedDate = DateTime.UtcNow,
                CreatedUser = "UnitTest",
                UpdatedDate = DateTime.UtcNow,
                UpdatedUser = "UnitTest",
                IsActive = true,
                FrequencyStartDay = 0,
                FrequencyEndDay = 0,
                IsOneOff = false
            };
            var result = await _client.UpdateCronCraft(schedule);
            Assert.That(result, Is.True, "The returned result should be true");
        }

        [Test]
        public async Task DeleteCronCraft_ShouldReturnBool()
        {
            var craftCron = await _client.GetCronCraft();
            var result = await _client.DeleteCronCraft(craftCron[0].HcSchId, "Nikhil");
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
