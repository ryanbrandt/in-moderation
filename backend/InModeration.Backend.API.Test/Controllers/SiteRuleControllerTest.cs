using AutoMapper;
using InModeration.Backend.API.Controllers;
using InModeration.Backend.API.Models;
using InModeration.Backend.API.Services;
using Moq;
using Xunit;
using System;
using System.Threading.Tasks;
using InModeration.Backend.API.Errors;
using System.Net;

namespace InModeration.Backend.API.Test.Controllers
{
    public class SiteRuleControllerTest
    {
        private readonly Mock<IMapper> _mockMapper;

        private readonly Mock<ISiteRuleService> _mockSiteRuleService;

        private readonly Mock<ISiteService> _mockSiteService;

        private readonly SiteRuleController _controller;

        public SiteRuleControllerTest()
        {
            _mockMapper = new Mock<IMapper>();
            _mockSiteRuleService = new Mock<ISiteRuleService>();
            _mockSiteService = new Mock<ISiteService>();

            _controller = new SiteRuleController(null, _mockMapper.Object, _mockSiteRuleService.Object, _mockSiteService.Object);
        }

        [Fact]
        public async void Post_InvalidModelState_ThrowsError()
        {
            _controller.ModelState.AddModelError("mock", "error");

            var rule = new SiteRule();

            Func<Task> act = () => _controller.Post(rule);

            await Assert.ThrowsAsync<HttpException>(act);
        }

        [Fact]
        public async void Post_PersistsRule_WithSiteRuleService()
        {
            var rule = new SiteRule();

            await _controller.Post(rule);

            _mockSiteRuleService.Verify(m => m.CreateSiteRuleAsync(rule), Times.Once);
        }

        [Fact]
        public async void Post_AssignsAssociatedSite()
        {
            var site = new Site()
            {
                Id = 1,
                Domain = "foo.com"
            };

            var rule = new SiteRule()
            {
                SiteId = site.Id
            };

            _mockSiteService.Setup(m => m.FindSiteAsync(rule.SiteId)).ReturnsAsync(site);

            await _controller.Post(rule);

            _mockSiteService.Verify(m => m.FindSiteAsync(rule.SiteId), Times.Once);

            Assert.Equal(rule.Site, site);
        }

        [Fact]
        public async void Get_RetrievesUserRulesWithSite_WithSiteRuleService()
        {
            var userId = 1;

            await _controller.Get(userId, null);

            _mockSiteRuleService.Verify(m => m.ListSiteRulesAsync(userId, null, true), Times.Once);
        }

        [Fact]
        public async void Put_SiteRuleDoesNotExist_ThrowsError()
        {
            var userId = 1;
            var siteId = 1;

            _mockSiteRuleService.Setup(m => m.FindSiteRuleAsync(userId, siteId)).Returns(Task.FromResult<SiteRule>(null));

            Func<Task> act = () => _controller.Put(userId, siteId, new SiteRule());

            await Assert.ThrowsAsync<HttpException>(act);
        }

        [Fact]
        public async void Put_UpdatesSiteRule_WithSiteRuleService()
        {
            var userId = 1;
            var siteId = 1;

            var existingRule = new SiteRule();
            var updatedRule = new SiteRule();

            _mockSiteRuleService.Setup(m => m.FindSiteRuleAsync(userId, siteId)).ReturnsAsync(existingRule);

            await _controller.Put(userId, siteId, updatedRule);

            _mockSiteRuleService.Verify(m => m.UpdateSiteRuleAsync(existingRule, updatedRule), Times.Once);
        }

        [Fact]
        public async void Delete_SiteRuleDoesNotExist_ThrowsError()
        {
            var userId = 1;
            var siteId = 1;

            _mockSiteRuleService.Setup(m => m.FindSiteRuleAsync(userId, siteId)).Returns(Task.FromResult<SiteRule>(null));

            Func<Task> act = () => _controller.Delete(userId, siteId);

            await Assert.ThrowsAsync<HttpException>(act);
        }

        [Fact]
        public async void Delete_DeletesSiteRule_WithSiteRuleService()
        {
            var userId = 1;
            var siteId = 1;

            var existingSiteRule = new SiteRule();

            _mockSiteRuleService.Setup(m => m.FindSiteRuleAsync(userId, siteId)).ReturnsAsync(existingSiteRule);

            await _controller.Delete(userId, siteId);

            _mockSiteRuleService.Verify(m => m.DeleteSiteRuleAsync(existingSiteRule), Times.Once);
        }
    }
}
