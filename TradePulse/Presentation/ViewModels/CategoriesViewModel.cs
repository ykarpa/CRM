using BLL.Services;
using DAL.Models;
using Presentation.Core;
using Presentation.Services;
using Presentation.Views;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Presentation.ViewModels
{
    public class CategoriesViewModel : ViewModel
    {
        private INavigationService _navigation;

        public INavigationService Navigation
        {
            get => _navigation;
            set
            {
                _navigation = value;
                OnPropertyChange();
            }
        }

        public RelayCommand NavigateToAccessories { get; set; }

        public event EventHandler<List<string>> CategoriesLoaded;

        public async void LoadCategories()
        {
            ProductService productService = new ProductService();
            var categories = productService.GetQuaryable()
                .Select(p => p.Category)
                .ToList();

            CategoriesLoaded?.Invoke(this, categories);
        }

        public CategoriesViewModel()
        {
            Task.Run(LoadCategories);
        }

        public CategoriesViewModel(INavigationService navService)
        {
            _navigation = navService;
            this.NavigateToAccessories = new RelayCommand(o => true, o => { Navigation.NavigateTo<ProductsViewModel>(); });

            Task.Run(LoadCategories);
        }
    }
}
