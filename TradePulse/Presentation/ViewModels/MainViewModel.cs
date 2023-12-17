using Presentation.Services;
using Presentation.Core;
using Presentation.Views;
using System.Windows;

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
		private Visibility _visibility = Visibility.Hidden;

		public Visibility NavButtonsVisibility
		{
			get => _visibility;
			set
			{
				_visibility = value;
				OnPropertyChange();
			}
		}
		public void ShowNavBarButtons() 
		{
			NavButtonsVisibility = Visibility.Visible;
		}
		public void HideNavBarButtons()
		{
			NavButtonsVisibility = Visibility.Hidden;
		}
		public RelayCommand NavigateToCategories { get; set; }
		public RelayCommand NavigateToProfile { get; private set; }
        public RelayCommand NavigateToFinance { get; set; }


        public MainViewModel(INavigationService navService, ProfileModalDialog _profileDialog)
		{
			_navigation = navService;
			this.NavigateToCategories = new RelayCommand(o => true, o => { Navigation.NavigateTo<CategoriesViewModel>(); });
            this.NavigateToProfile = new RelayCommand(o => true, o =>
            {
                Navigation.NavigateTo<ProfileViewModel>();
                Navigation.InitParam<ProfileViewModel>(p => p.User = AuthService.CurrentUser);
            });
        }
	}
}
