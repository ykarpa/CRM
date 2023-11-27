using Presentation.Core;
using Presentation.Services;

namespace Presentation.ViewModels
{
	public class CategoriesViewModel: ViewModel
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

		public CategoriesViewModel(INavigationService navService)
		{
			_navigation = navService;
			this.NavigateToAccessories = new RelayCommand(o => true, o => { Navigation.NavigateTo<ProductsViewModel>(); });
		}
    }
}
