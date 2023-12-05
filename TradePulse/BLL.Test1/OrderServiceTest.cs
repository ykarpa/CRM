using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Services;
using DAL.GenerickRepository;
using DAL.Models;
using Moq;
using Xunit;
using FluentAssertions;

namespace BLL.Test
{
    public class OrderServiceTest
    {
        [Fact]
        public async Task GetAll_ReturnsAllOrders()
        {
            // Arrange
            var orders = new List<Order>
            {
                new Order { OrderId = 1, /* other properties */ },
                new Order { OrderId = 2, /* other properties */ },
            };

            var repositoryMock = new Mock<IGenericRepository<Order>>();
            repositoryMock.Setup(repo => repo.GetAll())
                .ReturnsAsync(orders);

            var orderService = new OrderService(repositoryMock.Object);

            // Act
            var result = await orderService.GetAll();

            // Assert
            result.Should().BeEquivalentTo(orders);
        }

        [Fact]
        public async Task GetById_ReturnsCorrectOrder()
        {
            // Arrange
            int orderId = 1;
            var order = new Order { OrderId = orderId, /* other properties */ };

            var repositoryMock = new Mock<IGenericRepository<Order>>();
            repositoryMock.Setup(repo => repo.GetById(orderId))
                .ReturnsAsync(order);

            var orderService = new OrderService(repositoryMock.Object);

            // Act
            var result = await orderService.GetById(orderId);

            // Assert
            result.Should().BeEquivalentTo(order);
        }

        [Fact]
        public void Create_SavesOrder()
        {
            // Arrange
            var order = new Order { OrderId = 1, /* other properties */ };

            var repositoryMock = new Mock<IGenericRepository<Order>>();
            var orderService = new OrderService(repositoryMock.Object);

            // Act
            orderService.Create(order);

            // Assert
            repositoryMock.Verify(repo => repo.Create(order), Times.Once);
            repositoryMock.Verify(repo => repo.Save(), Times.Once);
        }

        [Fact]
        public void Update_SavesOrder()
        {
            // Arrange
            var order = new Order { OrderId = 1, /* other properties */ };

            var repositoryMock = new Mock<IGenericRepository<Order>>();
            var orderService = new OrderService(repositoryMock.Object);

            // Act
            orderService.Update(order);

            // Assert
            repositoryMock.Verify(repo => repo.Update(order), Times.Once);
            repositoryMock.Verify(repo => repo.Save(), Times.Once);
        }

        [Fact]
        public void Delete_SavesOrder()
        {
            // Arrange
            var order = new Order { OrderId = 1, /* other properties */ };

            var repositoryMock = new Mock<IGenericRepository<Order>>();
            var orderService = new OrderService(repositoryMock.Object);
            // Act
            orderService.Delete(order);

            // Assert
            repositoryMock.Verify(repo => repo.Delete(order), Times.Once);
            repositoryMock.Verify(repo => repo.Save(), Times.Once);
        }
    }
}
