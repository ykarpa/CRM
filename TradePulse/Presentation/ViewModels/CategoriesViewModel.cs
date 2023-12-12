// <copyright file="CategoriesViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Presentation.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Presentation.Core;
    using Presentation.Services;

    public class CategoriesViewModel : ViewModel
    {
        private ObservableCollection<CategoryViewModel> _categories;

        public ObservableCollection<CategoryViewModel> Categories
        {
            get => this._categories;
            set
            {
                this._categories = value;
                this.OnPropertyChange();
            }
        }

        private INavigationService _navigation;

        public INavigationService Navigation
        {
            get => this._navigation;
            set
            {
                this._navigation = value;
                this.OnPropertyChange();
            }
        }

        public RelayCommand NavigateToProducts { get; set; }

        public Func<string, RelayCommand> InitNavCommand { get; private set; }

        private void InitCategories()
        {
            var categoryViewModels = this.categoriesData.Select(c => new CategoryViewModel()
            {
                CategoryTitle = c,
                NavigateToProducts = this.InitNavCommand(c),
            });
            this.Categories = new ObservableCollection<CategoryViewModel>(categoryViewModels);
        }

        private string[] categoriesData;

        public CategoriesViewModel(INavigationService navService)
        {
            this._navigation = navService;
            this.InitNavCommand = (name) => new RelayCommand(o => true, o =>
            {
                this.Navigation.NavigateTo<ProductsViewModel>();
                this.Navigation.InitParam<ProductsViewModel>(v => v.Category = name);
            });
            this.categoriesData = new string[]
            {
                "Електроніка та Гаджети", "Одяг та Взуття", "Побутова Техніка", "Спорт",
                "Іграшки", "Кухонні Товари", "Меблі та Декор", "Книги", "Автомобільні Товари",
                "Садові та Зовнішні Товари", "Мистецтво та Рукоділля", "Аксесуари",
            };
            this.InitCategories();
        }
    }
}