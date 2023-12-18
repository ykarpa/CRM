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

		private ProfileModalDialog _profileDialog;

		public ProfileModalDialog ProfileDialog
		{
			get => _profileDialog;
			set
			{
				_profileDialog = value;
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

		public RelayCommand Logout { get; private set; }

        public MainViewModel(INavigationService navService, ProfileModalDialog _profileDialog)
		{
			_navigation = navService;
			this.NavigateToCategories = new RelayCommand(o => true, o => { Navigation.NavigateTo<CategoriesViewModel>(); });
            this.NavigateToProfile = new RelayCommand(o => true, o =>
            {
                Navigation.NavigateTo<ProfileViewModel>();
                Navigation.InitParam<ProfileViewModel>(p => p.User = AuthService.CurrentUser);
            });
            this.Logout = new RelayCommand(_ => true, _ =>
            {
	            AuthService.Logout();
				this.HideNavBarButtons();
				Navigation.NavigateTo<LoginViewModel>();
            });
            this.NavigateToFinance = new RelayCommand(_ => true, _ =>
            {
				Navigation.NavigateTo<FinanceViewModel>();
				Navigation.InitParam<FinanceViewModel>(v => v.EarnedMoney = 100000);
            });
		}
	}
}
