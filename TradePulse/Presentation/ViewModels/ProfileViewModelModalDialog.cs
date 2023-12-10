using BLL.Services;
using DAL.Models;
using Presentation.Core;
using Presentation.Services;
using System;

namespace Presentation.ViewModels
{
    public class ProfileViewModelModalDialog : ViewModel
    {
        private string _username;

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChange();
            }
        }

        public RelayCommand NavigateToProfileCommand { get; private set; }
        public IService<User> UserService { get; set; }

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

        public ProfileViewModelModalDialog(IService<User> userService, INavigationService navigation)
        {
            UserService = userService;
            _navigation = navigation;
            NavigateToProfileCommand = new RelayCommand(o => true, o => NavigateToProfile());
        }

        private void NavigateToProfile()
        {
            int userId = 1; // отримайте ідентифікатор користувача, можливо, з параметрів чи з іншого джерела;

            // Викликати команду для навігації до ProfileViewModel
            Navigation.NavigateTo<ProfileViewModel>();
            Navigation.InitParam<ProfileViewModel>(p => p.UserId = userId);
        }
    }
}
