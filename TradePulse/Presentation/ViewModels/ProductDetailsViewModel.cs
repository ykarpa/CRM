// <copyright file="ProductDetailsViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Presentation.ViewModels
{
    using System.Threading.Tasks;
    using BLL.DTOs;
    using BLL.Services;
    using Presentation.Core;

    public class ProductDetailsViewModel : ViewModel
    {
        private int _productId;
        private ProductService productService;
        private ProductDetailsDTO? _product;

        public ProductDetailsViewModel(ProductService productService)
        {
            this.productService = productService;
        }

        public int ProductId
        {
            get => this._productId;
            set
            {
                this._productId = value;
                this.Product = Task.Run(async () => await this.productService.GetProductDetails(this._productId)).Result;
            }
        }

        public ProductDetailsDTO Product
        {
            get => this._product!;
            private set
            {
                this._product = value;
                this.OnPropertyChange(nameof(this.Product));
            }
        }
    }
}
