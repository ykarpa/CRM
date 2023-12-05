using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Services;
using Moq;
using Xunit;
using FluentAssertions;
using DAL.Models;

namespace BLL.Test
{
    public class IServiceTest
    {
        [Fact]
        public async Task GetAll_ReturnsAllInstances()
        {
            // Arrange
            var instances = new List<Order>
            {
                new Order { OrderId = 1, /* other properties */ },
                new Order { OrderId = 2, /* other properties */ },
            };

            var serviceMock = new Mock<IService<Order>>();
            serviceMock.Setup(service => service.GetAll())
                .ReturnsAsync(instances);

            // Act
            var result = await serviceMock.Object.GetAll();

            // Assert
            result.Should().BeEquivalentTo(instances);
        }

        [Fact]
        public async Task GetById_ReturnsCorrectInstance()
        {
            // Arrange
            int id = 1;
            var instance = new Order { OrderId = id, /* other properties */ };

            var serviceMock = new Mock<IService<Order>>();
            serviceMock.Setup(service => service.GetById(id))
                .ReturnsAsync(instance);

            // Act
            var result = await serviceMock.Object.GetById(id);

            // Assert
            result.Should().BeEquivalentTo(instance);
        }

        [Fact]
        public void Create_CallsCreateMethod()
        {
            // Arrange
            var instance = new Order { OrderId = 1, /* other properties */ };

            var serviceMock = new Mock<IService<Order>>();
            serviceMock.Setup(service => service.Create(instance));

            // Act
            serviceMock.Object.Create(instance);

            // Assert
            serviceMock.Verify(service => service.Create(instance), Times.Once);
        }

        [Fact]
        public void Update_CallsUpdateMethod()
        {
            // Arrange
            var instance = new Order { OrderId = 1, /* other properties */ };

            var serviceMock = new Mock<IService<Order>>();
            serviceMock.Setup(service => service.Update(instance));

            // Act
            serviceMock.Object.Update(instance);

            // Assert
            serviceMock.Verify(service => service.Update(instance), Times.Once);
        }

        [Fact]
        public void Delete_CallsDeleteMethod()
        {
            // Arrange
            var instance = new Order { OrderId = 1, /* other properties */ };

            var serviceMock = new Mock<IService<Order>>();
            serviceMock.Setup(service => service.Delete(instance));

            // Act
            serviceMock.Object.Delete(instance);

            // Assert
            serviceMock.Verify(service => service.Delete(instance), Times.Once);
        }
    }
}
