using BLL.DTOs;
using BLL.Services;
using Presentation.Core;
using Presentation.Services;
using Presentation.Views;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Presentation.ViewModels
{
	public class LoginViewModel : ViewModel
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
		private UserService _userService;

		public UserService UserService
		{
			get => _userService;
			private set
			{
				_userService = value;
				OnPropertyChange();
			}
		}

		public RelayCommand NavigateToRegistration { get; set; }
		public RelayCommand LoginCommand { get; set; }

		private string _email = "";

		public string Email
		{
			get => _email;
			set
			{
				_email = value;
				OnPropertyChange(nameof(Email));
			}
		}

		private string _passsword = "";

		public string Password
		{
			get => _passsword;
			set
			{
				_passsword = value;
				OnPropertyChange(nameof(Password));
			}
		}

		public async Task Login(string email, string password)
		{
			UserDetailsDTO user = await UserService.GetUserDetailsByEmail(email)!;
			if(user == null)
			{
				MessageBox.Show($"Користувача з поштою {Email} не існує", "User not found", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}
			bool passwordsMatch = PasswordService.Verify(Password, user.Password);
			if(!passwordsMatch)
			{
				MessageBox.Show($"Ви ввели неправильний пароль", "Incorrect password", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}
			AuthService.CurrentUserId = user.UserId;
			_mainViewModel.ShowNavBarButtons();
			Navigation.NavigateTo<CategoriesViewModel>();
		}
		private MainViewModel _mainViewModel;
		public LoginViewModel(INavigationService _navService, UserService userService, MainViewModel mw)
		{
			this._navigation = _navService;
			this._userService = userService;
			_mainViewModel = mw;
			this.NavigateToRegistration = new RelayCommand(o => true, o =>
			{
				Navigation.NavigateTo<RegistrationViewModel>();
			});
			
			this.LoginCommand = new RelayCommand(o => true, o =>
			{
				Password = (o as PasswordBox)!.Password;
				Task.Run(async () => await Login(Email, Password));
			});
		}
	}
}
