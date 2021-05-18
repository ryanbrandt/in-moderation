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

namespace InModeration.Backend.API.Test
{
    public class UserControllerTest
    {
        private readonly Mock<IMapper> _mockMapper;

        private readonly Mock<IUserService> _mockUserService;

        private readonly UserController _controller;

        public UserControllerTest()
        {
            _mockMapper = new Mock<IMapper>();
            _mockUserService = new Mock<IUserService>();

            _controller = new UserController(null, _mockUserService.Object, _mockMapper.Object);
        }

        [Fact]
        public async void Post_InvalidModelState_ThrowsError()
        {
            _controller.ModelState.AddModelError("mock", "error");

            var user = new SaveUserResource();

            Func<Task> act = async () => await _controller.Post(user);

            await Assert.ThrowsAsync<HttpException>(act);

            _controller.ModelState.ClearValidationState("mock");
        }

        [Fact]
        public async void Post_MapsSaveUserResource_ToUser()
        {
            var user = new SaveUserResource();

            await _controller.Post(user);

            _mockMapper.Verify(m => m.Map<SaveUserResource, User>(user), Times.Once());
        }

        [Fact]
        public async void Post_PersistsMappedUser_WithUserService()
        {
            var user = new SaveUserResource();

            var mockMappedUser = new User();

            _mockMapper.Setup(m => m.Map<SaveUserResource, User>(user)).Returns(mockMappedUser);

            await _controller.Post(user);

            _mockUserService.Verify(m => m.CreateUserAsync(mockMappedUser), Times.Once);
        }
    }
}
