using AutoMapper;
using JobCandidate.Domain.Entities;
using JobCandidate.Service.DTOs;
using JobCandidate.Service.Services;
using JobCandidate.Data.IRepository;
using Moq;
using Xunit;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using MockQueryable.Moq;
using MockQueryable;

namespace JobCandidate.Service.Tests
{
    public class UserServiceTest
    {
        private readonly IMapper _mapper;

        public UserServiceTest()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>().ReverseMap();
            });

            _mapper = config.CreateMapper();
        }

        [Fact]
        public async Task AddOrUpdateUserAsync_ShouldCreateNewUser_WhenEmailNotExists()
        {
            // Arrange
            var users = new List<User>().AsQueryable().BuildMock();

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(r => r.SelectAll()).Returns(users);
            userRepositoryMock.Setup(r => r.CreateAsync(It.IsAny<User>()))
                              .ReturnsAsync((User u) => u);

            var userService = new UserService(userRepositoryMock.Object, _mapper);

            var userDto = new UserDto
            {
                FirstName = "Ali",
                LastName = "Valiyev",
                Email = "ali@example.com",
                PhoneNumber = "998901234567",
                Comment = "Test"
            };

            // Act
            var result = await userService.AddOrUpdateUserAsync(userDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(userDto.Email, result.Email);
        }

        [Fact]
        public async Task AddOrUpdateUserAsync_ShouldUpdateUser_WhenEmailExists()
        {
            // Arrange
            var existingUser = new User
            {
                Id = 1,
                FirstName = "Old",
                LastName = "Name",
                Email = "ali@example.com",
                CreatedAt = DateTime.UtcNow.AddDays(-1)
            };

            var users = new List<User> { existingUser }.AsQueryable().BuildMock();

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(r => r.SelectAll()).Returns(users);
            userRepositoryMock.Setup(r => r.UpdateAsync(It.IsAny<User>()))
                              .ReturnsAsync((User u) => u);

            var userService = new UserService(userRepositoryMock.Object, _mapper);

            var userDto = new UserDto
            {
                FirstName = "Updated",
                LastName = "User",
                Email = "ali@example.com",
                Comment = "Updated Comment"
            };

            // Act
            var result = await userService.AddOrUpdateUserAsync(userDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Updated", result.FirstName);
        }
    }
}
