using BLL.Services;
using DAL.Models;
using Presentation.Core;
using System.Threading.Tasks;

namespace Presentation.ViewModels
{
    public class ProfileViewModel : ViewModel
    {
        private int _userId;
        public int UserId
        {
            get => _userId;
            set
            {
                _userId = value;
                Task.Run(LoadUserDataAsync);
            }
        }

        private readonly IService<User> UserService;

        private User _user;
        public User User
        {
            get => _user;
            private set
            {
                _user = value;
                OnPropertyChange(nameof(User));
            }
        }

        public ProfileViewModel(IService<User> userService)
        {
            UserService = userService;
        }

        private async Task LoadUserDataAsync()
        {
            User = await UserService.GetById(_userId);
        }
    }
}
