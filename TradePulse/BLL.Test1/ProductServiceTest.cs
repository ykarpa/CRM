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
    public class ProductServiceTest
    {
        [Fact]
        public async Task GetAll_ReturnsAllProducts()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { ProductId = 1, /* other properties */ },
                new Product { ProductId = 2, /* other properties */ },
            };

            var repositoryMock = new Mock<IGenericRepository<Product>>();
            repositoryMock.Setup(repo => repo.GetAll())
                .ReturnsAsync(products);

            var productService = new ProductService(repositoryMock.Object );

            // Act
            var result = await productService.GetAll();

            // Assert
            result.Should().BeEquivalentTo(products);
        }

        [Fact]
        public async Task GetById_ReturnsCorrectProduct()
        {
            // Arrange
            int productId = 1;
            var product = new Product { ProductId = productId, /* other properties */ };

            var repositoryMock = new Mock<IGenericRepository<Product>>();
            repositoryMock.Setup(repo => repo.GetById(productId))
                .ReturnsAsync(product);

            var productService = new ProductService(repositoryMock.Object);

            // Act
            var result = await productService.GetById(productId);

            // Assert
            result.Should().BeEquivalentTo(product);
        }

        [Fact]
        public void Create_SavesProduct()
        {
            // Arrange
            var product = new Product { ProductId = 1, /* other properties */ };

            var repositoryMock = new Mock<IGenericRepository<Product>>();
            var productService = new ProductService (repositoryMock.Object );

            // Act
            productService.Create(product);

            // Assert
            repositoryMock.Verify(repo => repo.Create(product), Times.Once);
            repositoryMock.Verify(repo => repo.Save(), Times.Once);
        }

        [Fact]
        public void Update_SavesProduct()
        {
            // Arrange
            var product = new Product { ProductId = 1, /* other properties */ };

            var repositoryMock = new Mock<IGenericRepository<Product>>();
            var productService = new ProductService(repositoryMock.Object);

            // Act
            productService.Update(product);

            // Assert
            repositoryMock.Verify(repo => repo.Update(product), Times.Once);
            repositoryMock.Verify(repo => repo.Save(), Times.Once);
        }

        [Fact]
        public void Delete_SavesProduct()
        {
            // Arrange
            var product = new Product { ProductId = 1, /* other properties */ };

            var repositoryMock = new Mock<IGenericRepository<Product>>();
            var productService = new ProductService(repositoryMock.Object);

            // Act
            productService.Delete(product);

            // Assert
            repositoryMock.Verify(repo => repo.Delete(product), Times.Once);
            repositoryMock.Verify(repo => repo.Save(), Times.Once);
        }
    }
}
