using Presentation.Core;
using Presentation.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Presentation.ViewModels
{
	public class CategoriesViewModel : ViewModel
    {
        private ObservableCollection<CategoryViewModel> _categories;

        public ObservableCollection<CategoryViewModel> Categories
        {
            get => _categories;
            set
            {
                _categories = value;
                OnPropertyChange();
            }
        }
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

        public RelayCommand NavigateToProducts { get; set; }
        public Func<string, RelayCommand> InitNavCommand { get; private set; }
        private void InitCategories()
        {
            var categoryViewModels = this._categoriesData.Select(c => new CategoryViewModel()
            {
                CategoryTitle = c,
                NavigateToProducts = InitNavCommand(c)
            });
            Categories = new ObservableCollection<CategoryViewModel>(categoryViewModels);
        }

        private readonly string[] _categoriesData;
        public CategoriesViewModel(INavigationService navService)
        {
            _navigation = navService;
            this.InitNavCommand = (name) => new RelayCommand(o => true, o =>
            {
                Navigation.NavigateTo<ProductsViewModel>();
                Navigation.InitParam<ProductsViewModel>(v => v.Category = name);
            });
            this._categoriesData = new string[]
            {
                "Електроніка та Гаджети", "Одяг та Взуття", "Побутова Техніка", "Спорт",
                "Іграшки", "Кухонні Товари", "Меблі та Декор", "Книги", "Автомобільні Товари",
                "Садові та Зовнішні Товари", "Мистецтво та Рукоділля", "Аксесуари"
            };
            InitCategories();
        }
    }
}