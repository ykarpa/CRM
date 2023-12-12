// <copyright file="MainViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Presentation.ViewModels
{
    using Presentation.Core;
    using Presentation.Services;
    using Presentation.Views;

    public class MainViewModel : ViewModel
    {
        private INavigationService _navigation;
        private ProfileModalDialog profileDialog;

        public MainViewModel(INavigationService navService, ProfileModalDialog _profileDialog)
        {
            this._navigation = navService;
            this.NavigateToCategories = new RelayCommand(o => true, o => { this.Navigation.NavigateTo<CategoriesViewModel>(); });
            this.ProfileDialog = _profileDialog;
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

        public ProfileModalDialog ProfileDialog
        {
            get => this.profileDialog;
            set
            {
                this.profileDialog = value;
                this.OnPropertyChange();
            }
        }

        public RelayCommand NavigateToCategories { get; set; }

        public RelayCommand NavigateToModalDialog { get; set; }
    }
}
