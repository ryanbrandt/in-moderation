using AutoMapper;
using InModeration.Backend.API.Controllers;
using InModeration.Backend.API.Services;
using Moq;

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

            _controller = new SiteRuleController(null, _mockMapper.Object, _mockSiteRuleService.Object, _mockSiteService.Object);
        }
    }
}
