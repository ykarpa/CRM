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
    public class SubscriptionServiceTest
    {
        [Fact]
        public async Task GetAll_ReturnsAllSubscriptions()
        {
            // Arrange
            var subscriptions = new List<Subscription>
            {
                new Subscription { SubscriptionId = 1, /* other properties */ },
                new Subscription { SubscriptionId = 2, /* other properties */ },
            };

            var repositoryMock = new Mock<IGenericRepository<Subscription>>();
            repositoryMock.Setup(repo => repo.GetAll())
                .ReturnsAsync(subscriptions);

            var subscriptionService = new SubscriptionService(repositoryMock.Object);

            // Act
            var result = await subscriptionService.GetAll();

            // Assert
            result.Should().BeEquivalentTo(subscriptions);
        }

        [Fact]
        public async Task GetById_ReturnsCorrectSubscription()
        {
            // Arrange
            int subscriptionId = 1;
            var subscription = new Subscription { SubscriptionId = subscriptionId, /* other properties */ };

            var repositoryMock = new Mock<IGenericRepository<Subscription>>();
            repositoryMock.Setup(repo => repo.GetById(subscriptionId))
                .ReturnsAsync(subscription);

            var subscriptionService = new SubscriptionService(repositoryMock.Object);

            // Act
            var result = await subscriptionService.GetById(subscriptionId);

            // Assert
            result.Should().BeEquivalentTo(subscription);
        }

        [Fact]
        public void Create_SavesSubscription()
        {
            // Arrange
            var subscription = new Subscription { SubscriptionId = 1, /* other properties */ };

            var repositoryMock = new Mock<IGenericRepository<Subscription>>();
            var subscriptionService = new SubscriptionService(repositoryMock.Object);

            // Act
            subscriptionService.Create(subscription);

            // Assert
            repositoryMock.Verify(repo => repo.Create(subscription), Times.Once);
            repositoryMock.Verify(repo => repo.Save(), Times.Once);
        }

        [Fact]
        public void Update_SavesSubscription()
        {
            // Arrange
            var subscription = new Subscription { SubscriptionId = 1, /* other properties */ };

            var repositoryMock = new Mock<IGenericRepository<Subscription>>();
            var subscriptionService = new SubscriptionService(repositoryMock.Object);

            // Act
            subscriptionService.Update(subscription);

            // Assert
            repositoryMock.Verify(repo => repo.Update(subscription), Times.Once);
            repositoryMock.Verify(repo => repo.Save(), Times.Once);
        }

        [Fact]
        public void Delete_SavesSubscription()
        {
            // Arrange
            var subscription = new Subscription { SubscriptionId = 1, /* other properties */ };

            var repositoryMock = new Mock<IGenericRepository<Subscription>>();
            var subscriptionService = new SubscriptionService(repositoryMock.Object);

            // Act
            subscriptionService.Delete(subscription);

            // Assert
            repositoryMock.Verify(repo => repo.Delete(subscription), Times.Once);
            repositoryMock.Verify(repo => repo.Save(), Times.Once);
        }
    }
}
