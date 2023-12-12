// <copyright file="ProductService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BLL.Services
{
    using BLL.DTOs;
    using DAL.GenerickRepository;
    using DAL.Models;

    public class ProductService : IService<Product>
    {
        private readonly IGenericRepository<Product> productRepository;

        public ProductService()
        {
            this.productRepository = new TradePulseRepository<Product>();
        }

        public ProductService(IGenericRepository<Product> productService)
        {
            this.productRepository = productService;
        }

        public Task<List<Product>> GetAll()
        {
            return this.productRepository.GetAll();
        }

        public Task<Product> GetById(int id)
        {
            return this.productRepository.GetById(id);
        }

        public IQueryable<Product> GetQuaryable()
        {
            return this.productRepository.GetQuaryable();
        }

        public void Create(Product product)
        {
            this.productRepository.Create(product);
            this.productRepository.Save();
        }

        public void Update(Product product)
        {
            this.productRepository.Update(product);
            this.productRepository.Save();
        }

        public void Delete(Product product)
        {
            this.productRepository.Delete(product);
            this.productRepository.Save();
        }

        public async Task<List<ProductListDTO>> GetProductsList()
        {
            return (await this.GetAll()).Select(p => new ProductListDTO()
            {
                Title = p.Title,
                Price = p.Price,
                Description = p.Description,
                ItemsAvailable = p.ItemsAvailable,
                Model = p.Model,
                ProductId = p.ProductId,
                Category = p.Category,
            }).ToList();
        }

        public async Task<ProductDetailsDTO> GetProductDetails(int id)
        {
            var product = await this.GetById(id);
            return new ProductDetailsDTO()
            {
                CreatedAt = product.CreatedAt,
                Description = product.Description,
                ItemsAvailable = product.ItemsAvailable,
                Model = product.Model,
                ProductId = product.ProductId,
                Price = product.Price,
                Title = product.Title,
                VendorId = product.VendorId,
                Category = product.Category,
            };
        }
    }
}
