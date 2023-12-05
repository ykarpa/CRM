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
    public class UsersSubscriptionsServiceTest
    {
        [Fact]
        public async Task GetAll_ReturnsAllUsersSubscriptions()
        {
            // Arrange
            var usersSubscriptions = new List<UsersSubscriptions>
            {
                new UsersSubscriptions { /* properties */ },
                new UsersSubscriptions { /* properties */ },
            };

            var repositoryMock = new Mock<IGenericRepository<UsersSubscriptions>>();
            repositoryMock.Setup(repo => repo.GetAll())
                .ReturnsAsync(usersSubscriptions);

            var usersSubscriptionsService = new UsersSubscriptionsService(repositoryMock.Object);

            // Act
            var result = await usersSubscriptionsService.GetAll();

            // Assert
            result.Should().BeEquivalentTo(usersSubscriptions);
        }

        [Fact]
        public void GetById_ThrowsInvalidOperationException()
        {
            // Arrange
            var usersSubscriptionsService = new UsersSubscriptionsService();

            // Act & Assert
            Assert.ThrowsAsync<InvalidOperationException>(async () => await usersSubscriptionsService.GetById(1));
        }

        [Fact]
        public void Create_SavesUsersSubscriptions()
        {
            // Arrange
            var usersSubscriptions = new UsersSubscriptions { /* properties */ };

            var repositoryMock = new Mock<IGenericRepository<UsersSubscriptions>>();
            var usersSubscriptionsService = new UsersSubscriptionsService(repositoryMock.Object);

            // Act
            usersSubscriptionsService.Create(usersSubscriptions);

            // Assert
            repositoryMock.Verify(repo => repo.Create(usersSubscriptions), Times.Once);
            repositoryMock.Verify(repo => repo.Save(), Times.Once);
        }

        [Fact]
        public void Update_SavesUsersSubscriptions()
        {
            // Arrange
            var usersSubscriptions = new UsersSubscriptions { /* properties */ };

            var repositoryMock = new Mock<IGenericRepository<UsersSubscriptions>>();
            var usersSubscriptionsService = new UsersSubscriptionsService(repositoryMock.Object);

            // Act
            usersSubscriptionsService.Update(usersSubscriptions);

            // Assert
            repositoryMock.Verify(repo => repo.Update(usersSubscriptions), Times.Once);
            repositoryMock.Verify(repo => repo.Save(), Times.Once);
        }

        [Fact]
        public void Delete_SavesUsersSubscriptions()
        {
            // Arrange
            var usersSubscriptions = new UsersSubscriptions { /* properties */ };

            var repositoryMock = new Mock<IGenericRepository<UsersSubscriptions>>();
            var usersSubscriptionsService = new UsersSubscriptionsService(repositoryMock.Object);

            // Act
            usersSubscriptionsService.Delete(usersSubscriptions);

            // Assert
            repositoryMock.Verify(repo => repo.Delete(usersSubscriptions), Times.Once);
            repositoryMock.Verify(repo => repo.Save(), Times.Once);
        }
    }
}
