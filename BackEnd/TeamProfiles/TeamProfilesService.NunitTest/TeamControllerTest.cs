﻿namespace TeamProfilesService.NunitTest
{
    [TestFixture]
    public class TeamControllerTest
    {
        private const string _baseApiUrl = "http://localhost:5139";
        private TeamProfileClient _client;

        [SetUp]
        public void Setup()
        {
            _client = new TeamProfileClient(_baseApiUrl);
        }

        [Test]
        public async Task GetAllResponsibleTeam_ShouldReturnTeams()
        {
            var teams = await _client.GetAllResponsibleTeam();
            Assert.That(teams, Is.Not.Null, "The returned list of teams should not be null");
            Assert.That(teams, Is.Not.Empty, "The returned list of teams should have at least one team");
            foreach (var team in teams)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(team.SNo, Is.GreaterThanOrEqualTo(0), $"SNo should be greater than or equal to 0 for team {team.ResponsibleTeam}");
                    Assert.That(team.Module, Is.Not.Null.Or.Empty, "Module should not be null or empty");
                    Assert.That(team.ResponsibleTeam, Is.Not.Null.Or.Empty, "ResponsibleTeam should not be null or empty");
                    Assert.That(team.ActionType, Is.Not.Null.Or.Empty, "ActionType should not be null or empty");
                    Assert.That(team.NumberOfTasks, Is.GreaterThanOrEqualTo(0), $"NumberOfTasks should be greater than or equal to 0 for team {team.ResponsibleTeam}");
                    Assert.That(team.OnsiteTeam, Is.Not.Null.Or.Empty.Or.EqualTo(team.PrimaryResource).Or.Null.Or.EqualTo(team.SecondaryResource).Or.Null, $"At least one of OnsiteTeam, PrimaryResource, or SecondaryResource should be present for team {team.ResponsibleTeam}");

                });
            }
        }

        [Test]
        public async Task GetResourceByModuleName_ShouldReturnTeams()
        {
            var teams = await _client.GetResourceByModuleName("Account Management");
            Assert.That(teams, Is.Not.Null, "The returned list of teams should not be null");
            Assert.That(teams, Is.Not.Empty, "The returned list of teams should have at least one team");
            foreach (var team in teams)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(team.NumberOfTasks, Is.GreaterThanOrEqualTo(0), $"NumberOfTasks should be greater than or equal to 0 for team {team.ResponsibleTeam}");
                    Assert.That(team.OnsiteTeam, Is.Not.Null.Or.Empty.Or.EqualTo(team.PrimaryResource).Or.Null.Or.EqualTo(team.SecondaryResource).Or.Null, $"At least one of OnsiteTeam, PrimaryResource, or SecondaryResource should be present for team {team.ResponsibleTeam}");

                });
            }
        }

        [Test]
        public async Task GetModuleDataByResourceName_ShouldReturnTeams()
        {
            var teams = await _client.GetModuleDataByResourceName("Prabhanjan");
            Assert.That(teams, Is.Not.Null, "The returned list of teams should not be null");
            Assert.That(teams, Is.Not.Empty, "The returned list of teams should have at least one team");
            foreach (var team in teams)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(team.SNo, Is.GreaterThanOrEqualTo(0), $"SNo should be greater than or equal to 0 for team {team.ResponsibleTeam}");
                    Assert.That(team.Module, Is.Not.Null.Or.Empty, "Module should not be null or empty");
                    Assert.That(team.ResponsibleTeam, Is.Not.Null.Or.Empty, "ResponsibleTeam should not be null or empty");
                    Assert.That(team.ActionType, Is.Not.Null.Or.Empty, "ActionType should not be null or empty");
                    Assert.That(team.NumberOfTasks, Is.GreaterThanOrEqualTo(0), $"NumberOfTasks should be greater than or equal to 0 for team {team.ResponsibleTeam}");
                    Assert.That(team.OnsiteTeam, Is.Not.Null.Or.Empty.Or.EqualTo(team.PrimaryResource).Or.Null.Or.EqualTo(team.SecondaryResource).Or.Null, $"At least one of OnsiteTeam, PrimaryResource, or SecondaryResource should be present for team {team.ResponsibleTeam}");

                });
            }
        }

        [Test]
        public async Task AddResponsibleTeam_ShouldReturnBool()
        {
            var team = new HypercareResponsibleTeam
            {
                Module = "Account Management",
                ResponsibleTeam = "Account Management",
                ActionType = "Account Management",
                NumberOfTasks = 0,
                OnsiteTeam = "Account Management",
                PrimaryResource = "Account Management",
                SecondaryResource = "Account Management"
            };
            var result = await _client.AddResponsibleTeam(team);
            Assert.That(result, Is.True, "The returned result should be true");
        }

        [Test]
        public async Task UpdateResponsibleTeam_ShouldReturnBool()
        {
            var team = new HypercareResponsibleTeam
            {
                SNo = 1002,
                Module = "Account Management",
                ResponsibleTeam = "Account Management",
                ActionType = "Account Management",
                NumberOfTasks = 0,
                OnsiteTeam = "Account Management",
                PrimaryResource = "Account Management",
                SecondaryResource = "Account Management"
            };
            var result = await _client.UpdateResponsibleTeam(team);
            Assert.That(result, Is.True, "The returned result should be true");
        }
    }
}