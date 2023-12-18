using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using BLL.DTOs;
using Presentation.Core;
using Presentation.Services;

namespace Presentation.ViewModels
{
	public class RegistrationViewModel : ViewModel
	{
		private INavigationService _navService { get; set; }
		private string? _firstName;

		public string? FirstName
		{
			get => _firstName;
			set
			{
				_firstName = value;
				OnPropertyChange();
			}
		}
		private string? _lastName;

		public string? LastName
		{
			get => _lastName;
			set
			{
				_lastName = value;
				OnPropertyChange();
			}
		}

		private string? _email;

		public string? Email
		{
			get => _email;
			set
			{
				_email = value;
				OnPropertyChange();
			}
		}

		private DateTime _birthDate = DateTime.Today;

		public DateTime BirthDate
		{
			get => _birthDate;
			set
			{
				_birthDate = value;
				OnPropertyChange();
			}
		}

		private string? _password;

		public string? Password
		{
			get => _password;
			set
			{
				_password = value;
				OnPropertyChange();
			}
		}

		private string? _repeatedPassword;

		public string? RepeatedPassword
		{
			get => _repeatedPassword;
			set
			{
				_repeatedPassword = value;
				OnPropertyChange();
			}
		}

		private ComboBoxItem? _role;

		public ComboBoxItem? Role
		{
			get => _role;
			set
			{
				_role = value;
				_roleString = _role.Content as string;
				OnPropertyChange();
			}
		}

		private string _roleString;
		public RelayCommand RegisterCommand { get; private init; }

		public async Task<bool> Register()
		{
			bool isDataValid = ValidateData();
			if (!isDataValid)
			{
				return false;
			}
			string encodedPassword = PasswordService.EncodePassword(Password!);
			UserDetailsDTO user = new UserDetailsDTO()
			{
				BirthDate = this.BirthDate,
				Password = encodedPassword,
				FirstName = this.FirstName!,
				Email = this.Email!,
				LastName = this.LastName!,
				Role = _roleString
			};
			try
			{
				await AuthService.Register(user);
			}
			catch
			{
				return false;
			}

			return true;
		}

		private bool ValidateData()
		{
			if (FirstName == string.Empty)
			{
				MessageBox.Show($"Введіть ім'я", "Text field is empty", MessageBoxButton.OK, MessageBoxImage.Error);
				return false;
			}
			if (LastName == string.Empty)
			{
				MessageBox.Show($"Введіть прізвище", "Text field is empty", MessageBoxButton.OK, MessageBoxImage.Error);
				return false;
			}
			if (Email == string.Empty)
			{
				MessageBox.Show($"Введіть електронну пошту", "Text field is empty", MessageBoxButton.OK, MessageBoxImage.Error);
				return false;
			}
			if (Role is null)
			{
				MessageBox.Show($"Виберіть роль", "Text field is empty", MessageBoxButton.OK, MessageBoxImage.Error);
				return false;
			}
			if (Password is null)
			{
				MessageBox.Show($"Введіть пароль", "Passwords don't match", MessageBoxButton.OK, MessageBoxImage.Error);
				return false;
			}
			if (Password != RepeatedPassword)
			{
				MessageBox.Show($"Паролі не збігаються", "Passwords don't match", MessageBoxButton.OK, MessageBoxImage.Error);
				return false;
			}

			if (BirthDate.AddYears(18).CompareTo(DateTime.Now) > 0)
			{
				MessageBox.Show($"Реєстрація дозволена тільки з 18 років", "User's not old enough", MessageBoxButton.OK, MessageBoxImage.Error);
				return false;
			}

			return true;
		}
		public RegistrationViewModel(INavigationService navService)
		{
			_navService = navService;
			this.RegisterCommand = new RelayCommand(_ => true, _ =>
			{
				Task.Run(async () =>
				{
					var isRegistered = await this.Register();
					if (!isRegistered) return;
					navService.NavigateTo<LoginViewModel>();
					navService.InitParam<LoginViewModel>(v => v.Email = this.Email!);
				});
			});
		}
	}
}
