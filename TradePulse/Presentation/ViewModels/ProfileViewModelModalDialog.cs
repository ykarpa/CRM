using Presentation.Services;
using Presentation.Core;
using Presentation.Views;

namespace Presentation.ViewModels
{
    public class ProfileViewModelModalDialog : ViewModel
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

        public RelayCommand NavigateToProfile { get; set; }

        public ProfileViewModelModalDialog(INavigationService navService)
        {
            _navigation = navService;
            this.NavigateToProfile = new RelayCommand(o => true, o =>
            {
                Navigation.NavigateTo<ProfileViewModel>();
                Navigation.InitParam<ProfileViewModel>(p => p.UserId = 1);
            });
        }
    }

}
