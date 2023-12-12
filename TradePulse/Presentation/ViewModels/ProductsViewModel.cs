// <copyright file="ProductsViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Presentation.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using BLL.Services;
    using Presentation.Core;
    using Presentation.Services;

    public class ProductsViewModel : ViewModel
    {
        private ObservableCollection<ProductViewModel>? _products;
        private string? _category;

        public ProductsViewModel(ProductService productService, INavigationService navigation)
        {
            this.ProductService = productService;
            this.InitNavCommand = (id) => new RelayCommand(o => true, o =>
            {
                navigation.NavigateTo<ProductDetailsViewModel>();
                navigation.InitParam<ProductDetailsViewModel>(p => p.ProductId = id);
            });
        }

        public ObservableCollection<ProductViewModel> Products
        {
            get => this._products!;
            set
            {
                this._products = value;
                this.OnPropertyChange();
            }
        }

        public string Category
        {
            get => this._category!;
            set
            {
                this._category = value;
                Task.Run(async () => await this.LoadProducts(this._category));
                this.OnPropertyChange();
            }
        }

        public Func<int, RelayCommand> InitNavCommand { get; private set; }

        public ProductService ProductService { get; set; }

        private async Task LoadProducts(string category = "")
        {
            var products = await this.ProductService.GetProductsList();

            var productViewModels = products.Where(p => p.Category == category).Select(product => new ProductViewModel()
            {
                Title = product.Title,
                Description = product.Description,
                Price = product.Price,
                Model = product.Model!,
                ItemsAvailable = product.ItemsAvailable,
                NavigateToDetails = this.InitNavCommand(product.ProductId),
            });
            this.Products = new ObservableCollection<ProductViewModel>(productViewModels);
        }
    }
}