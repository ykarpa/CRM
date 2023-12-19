using BLL.DTOs;
using BLL.Services;
using Presentation.Core;
using Presentation.Services;
using System.Data;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Presentation.ViewModels
{
    public class CreationAdvertisementViewModel : ViewModel
    {
        private INavigationService _navService { get; set; }
        private ProductService _productService = new ProductService();

        private string? _title;

        public string? Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChange();
            }
        }

        private string? _description;

        public string? Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChange();
            }
        }

        private string? _model;

        public string? Model
        {
            get => _model;
            set
            {
                _model = value;
                OnPropertyChange();
            }
        }

        private decimal _price;

        public decimal Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChange();
            }
        }

        private ComboBoxItem? _category;

        public ComboBoxItem? Category
        {
            get => _category;
            set
            {
                _category = value;
                _categoryString = _category.Content as string;
                OnPropertyChange();
            }
        }

        private string _categoryString;
        public RelayCommand CreateAdvertisementCommand { get; set; }

        public async Task<bool> CreateAdvertisement()
        {
            bool isDataValid = ValidateData();
            if (!isDataValid)
            {
                return false;
            }
            ProductDetailsDTO product = new ProductDetailsDTO()
            {
                Title = this.Title!,
                Description = this.Description!,
                Model = this.Model!,
                Price = this.Price!,
                Category = _categoryString,
                ItemsAvailable = 1,
                VendorId = 1,
            };
            try
            {
                await _productService.Create(product);
            }
            catch 
            { 
                return false;
            }

            return true;
        }

        private bool ValidateData()
        {
            if (Title == string.Empty)
            {
                MessageBox.Show($"Введіть назву", "Text field is empty", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (Description == string.Empty)
            {
                MessageBox.Show($"Введіть опис", "Text field is empty", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (Model == string.Empty)
            {
                MessageBox.Show($"Введіть модель", "Text field is empty", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (Category is null)
            {
                MessageBox.Show($"Виберіть категорію", "Text field is empty", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (Price <= 0)
            {
                MessageBox.Show($"Введіть дійсну ціну", "Passwords don't match", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        public CreationAdvertisementViewModel(INavigationService navService)
        {
            _navService = navService;
            this.CreateAdvertisementCommand = new RelayCommand(_ => true, _ =>
            {
                Task.Run(async () =>
                {
                    var isRegistered = await this.CreateAdvertisement();
                    if (!isRegistered) return;
                    navService.NavigateTo<CategoriesViewModel>();
                });
            });
        }
    }
}
