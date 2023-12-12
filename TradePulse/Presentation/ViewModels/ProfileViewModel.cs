using BLL.DTOs;
using BLL.Services;
using DAL.Models;
using Presentation.Core;
using System.Threading.Tasks;

namespace Presentation.ViewModels
{
    public class ProfileViewModel : ViewModel
    {
        private UserDetailsDTO _user;
        public UserDetailsDTO User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChange(nameof(User));
            }
        }
    }
}
