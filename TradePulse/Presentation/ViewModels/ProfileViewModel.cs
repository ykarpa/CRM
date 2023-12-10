using BLL.Services;
using DAL.Models;
using Presentation.Core;
using System.Threading.Tasks;

namespace Presentation.ViewModels
{
    public class ProfileViewModel : ViewModel
    {
        private int _userId = 1;
        public int UserId
        {
            get => _userId;
            set
            {
                _userId = value;
                LoadUserDataAsync();
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
            LoadUserDataAsync();
        }

        private async void LoadUserDataAsync()
        {
            // Змініть ім'я методу на той, який вам доступний для отримання користувача.
            // Наприклад, якщо у вас є метод GetById, змініть на GetByIdAsync.
            User = await UserService.GetById(_userId);
        }
    }
}
