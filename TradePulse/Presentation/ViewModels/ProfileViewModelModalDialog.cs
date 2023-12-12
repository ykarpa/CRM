// <copyright file="ProfileViewModelModalDialog.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Presentation.ViewModels
{
    using Presentation.Core;
    using Presentation.Services;

    public class ProfileViewModelModalDialog : ViewModel
    {
        private INavigationService _navigation;

        public ProfileViewModelModalDialog(INavigationService navService)
        {
            this._navigation = navService;
            this.NavigateToProfile = new RelayCommand(o => true, o =>
            {
                this.Navigation.NavigateTo<ProfileViewModel>();

                // TODO: replace after auth implmentation
                this.Navigation.InitParam<ProfileViewModel>(p => p.UserId = 1);
            });
        }

        public INavigationService Navigation
        {
            get => this._navigation;
            set
            {
                this._navigation = value;
                this.OnPropertyChange();
            }
        }

        public RelayCommand NavigateToProfile { get; set; }
    }
}
