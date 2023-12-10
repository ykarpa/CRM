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
    public class PaymentServiceTest
    {
        [Fact]
        public async Task GetAll_ReturnsAllPayments()
        {
            // Arrange
            var payments = new List<Payment>
            {
                new Payment { PaymentId = 1, /* other properties */ },
                new Payment { PaymentId = 2, /* other properties */ },
            };

            var repositoryMock = new Mock<IGenericRepository<Payment>>();
            repositoryMock.Setup(repo => repo.GetAll())
                .ReturnsAsync(payments);

            var paymentService = new PaymentService(repositoryMock.Object);

            // Act
            var result = await paymentService.GetAll();

            // Assert
            result.Should().BeEquivalentTo(payments);
        }

        [Fact]
        public async Task GetById_ReturnsCorrectPayment()
        {
            // Arrange
            int paymentId = 1;
            var payment = new Payment { PaymentId = paymentId, /* other properties */ };

            var repositoryMock = new Mock<IGenericRepository<Payment>>();
            repositoryMock.Setup(repo => repo.GetById(paymentId))
                .ReturnsAsync(payment);

            var paymentService = new PaymentService(repositoryMock.Object);

            // Act
            var result = await paymentService.GetById(paymentId);

            // Assert
            result.Should().BeEquivalentTo(payment);
        }

        [Fact]
        public void Create_SavesPayment()
        {
            // Arrange
            var payment = new Payment { PaymentId = 1, /* other properties */ };

            var repositoryMock = new Mock<IGenericRepository<Payment>>();
            var paymentService = new PaymentService(repositoryMock.Object);

            // Act
            paymentService.Create(payment);

            // Assert
            repositoryMock.Verify(repo => repo.Create(payment), Times.Once);
            repositoryMock.Verify(repo => repo.Save(), Times.Once);
        }

        [Fact]
        public void Update_SavesPayment()
        {
            // Arrange
            var payment = new Payment { PaymentId = 1, /* other properties */ };

            var repositoryMock = new Mock<IGenericRepository<Payment>>();
            var paymentService = new PaymentService(repositoryMock.Object);

            // Act
            paymentService.Update(payment);

            // Assert
            repositoryMock.Verify(repo => repo.Update(payment), Times.Once);
            repositoryMock.Verify(repo => repo.Save(), Times.Once);
        }

        [Fact]
        public void Delete_SavesPayment()
        {
            // Arrange
            var payment = new Payment { PaymentId = 1, /* other properties */ };

            var repositoryMock = new Mock<IGenericRepository<Payment>>();
            var paymentService = new PaymentService(repositoryMock.Object);
            // Act
            paymentService.Delete(payment);

            // Assert
            repositoryMock.Verify(repo => repo.Delete(payment), Times.Once);
            repositoryMock.Verify(repo => repo.Save(), Times.Once);
        }
    }
}
