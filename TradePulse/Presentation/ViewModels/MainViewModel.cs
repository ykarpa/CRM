using Presentation.Services;
using Presentation.Core;
using Presentation.Views;

namespace Presentation.ViewModels
{
	public class MainViewModel : ViewModel
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

		private ProfileModalDialog profileDialog;

		public ProfileModalDialog ProfileDialog
		{
			get => profileDialog;
			set
			{
				profileDialog = value;
				OnPropertyChange();
			}
		}


		public RelayCommand NavigateToCategories { get; set; }
		public RelayCommand NavigateToModalDialog { get; set; }

		public MainViewModel(INavigationService navService, ProfileModalDialog _profileDialog)
		{
			_navigation = navService;
			this.NavigateToCategories = new RelayCommand(o => true, o => { Navigation.NavigateTo<CategoriesViewModel>(); });
			ProfileDialog = _profileDialog;
		}
	}
}
