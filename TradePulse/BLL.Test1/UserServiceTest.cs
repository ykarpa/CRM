using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Services;
using DAL.Models;
using Moq;
using Xunit;
using FluentAssertions;
using DAL.GenerickRepository;

namespace BLL.Test
{
    public class UserServiceTest
    {
        [Fact]
        public async Task GetAll_ReturnsAllUsers()
        {
            // Arrange
            var users = new List<User>
            {
                new User { UserId = 1, /* other properties */ },
                new User { UserId = 2, /* other properties */ },
            };

            var repositoryMock = new Mock<IGenericRepository<User>>();
            repositoryMock.Setup(repo => repo.GetAll())
                .ReturnsAsync(users);

            var userService = new UserService(repositoryMock.Object);

            // Act
            var result = await userService.GetAll();

            // Assert
            result.Should().BeEquivalentTo(users);
        }

        [Fact]
        public async Task GetById_ReturnsCorrectUser()
        {
            // Arrange
            int userId = 1;
            var user = new User { UserId = userId, /* other properties */ };

            var repositoryMock = new Mock<IGenericRepository<User>>();
            repositoryMock.Setup(repo => repo.GetById(userId))
                .ReturnsAsync(user);

            var userService = new UserService(repositoryMock.Object);

            // Act
            var result = await userService.GetById(userId);

            // Assert
            result.Should().BeEquivalentTo(user);
        }

        [Fact]
        public void Create_SavesUser()
        {
            // Arrange
            var user = new User { UserId = 1, /* other properties */ };

            var repositoryMock = new Mock<IGenericRepository<User>>();
            var userService = new UserService(repositoryMock.Object);
            // Act
            userService.Create(user);

            // Assert
            repositoryMock.Verify(repo => repo.Create(user), Times.Once);
            repositoryMock.Verify(repo => repo.Save(), Times.Once);
        }

        [Fact]
        public void Update_SavesUser()
        {
            // Arrange
            var user = new User { UserId = 1, /* other properties */ };

            var repositoryMock = new Mock<IGenericRepository<User>>();
            var userService = new UserService(repositoryMock.Object);
            // Act
            userService.Update(user);

            // Assert
            repositoryMock.Verify(repo => repo.Update(user), Times.Once);
            repositoryMock.Verify(repo => repo.Save(), Times.Once);
        }

        [Fact]
        public void Delete_SavesUser()
        {
            // Arrange
            var user = new User { UserId = 1, /* other properties */ };

            var repositoryMock = new Mock<IGenericRepository<User>>();
            var userService = new UserService(repositoryMock.Object);

            // Act
            userService.Delete(user);

            // Assert
            repositoryMock.Verify(repo => repo.Delete(user), Times.Once);
            repositoryMock.Verify(repo => repo.Save(), Times.Once);
        }
    }
}
