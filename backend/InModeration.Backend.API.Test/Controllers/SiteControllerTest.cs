using AutoMapper;
using InModeration.Backend.API.Controllers;
using InModeration.Backend.API.Errors;
using InModeration.Backend.API.Models;
using InModeration.Backend.API.Resources;
using InModeration.Backend.API.Services;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace InModeration.Backend.API.Test.Controllers
{
    public class SiteControllerTest
    {
        private readonly Mock<IMapper> _mockMapper;

        private readonly Mock<ISiteService> _mockSiteService;

        private readonly SiteController _controller;

        public SiteControllerTest()
        {
            _mockMapper = new Mock<IMapper>();
            _mockSiteService = new Mock<ISiteService>();

            _controller = new SiteController(null, _mockMapper.Object, _mockSiteService.Object);
        }

        [Fact]
        public async void Post_InvalidModelState_ThrowsError()
        {
            _controller.ModelState.AddModelError("mock", "error");

            var site = new SaveSiteResource();

            Func<Task> act = async () => await _controller.Post(site);

            await Assert.ThrowsAsync<HttpException>(act);
        }

        [Fact]
        public async void Post_MapsSiteResource_ToSite()
        {
            var site = new SaveSiteResource();

            var mockMappedSite = new Site();

            _mockMapper.Setup(m => m.Map<SaveSiteResource, Site>(site)).Returns(mockMappedSite);

            await _controller.Post(site);

            _mockMapper.Verify(m => m.Map<SaveSiteResource, Site>(site), Times.Once);
        }

        [Fact]
        public async void Post_PersistsMappedSite_WithSiteService()
        {
            var site = new SaveSiteResource();

            var mockMappedSite = new Site();

            _mockMapper.Setup(m => m.Map<SaveSiteResource, Site>(site)).Returns(mockMappedSite);

            await _controller.Post(site);

            _mockSiteService.Verify(m => m.CreateSiteAsync(mockMappedSite), Times.Once);
        }

        [Fact]
        public async void Get_RetrievesUsers_FromSiteService()
        {
            var id = 1;
            var domain = "website.com";

            await _controller.Get(id, domain);

            _mockSiteService.Verify(m => m.ListSitesAsync(id, domain), Times.Once);
        }

    }
}
