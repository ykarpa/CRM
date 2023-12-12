// <copyright file="NavigationServices.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Presentation.Services
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using Presentation.Core;

    public class NavigationServices : INotifyPropertyChanged, INavigationService
    {
        private ViewModel _currentView;

        public ViewModel CurrentView
        {
            get => this._currentView;
            private set
            {
                this._currentView = value;
                this.OnPropertyChange();
            }
        }

        public Func<Type, ViewModel> _viewModelFactory { get; }

        public NavigationServices(Func<Type, ViewModel> viewModelFactory)
        {
            this._viewModelFactory = viewModelFactory;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void NavigateTo<TViewModel>()
            where TViewModel : ViewModel
        {
            ViewModel viewModel = this._viewModelFactory.Invoke(typeof(TViewModel));
            this.CurrentView = viewModel;
        }

        public void NavigateTo<TViewModel, TParam>(TParam[] props)
            where TViewModel : ViewModel
        {
            ViewModel viewModel = this._viewModelFactory.Invoke(typeof(TViewModel));
            this.CurrentView = viewModel;
        }

        public void InitParam<TView>(Action<TView> initFunc)
            where TView : ViewModel
        {
            try
            {
                if (this.CurrentView is null)
                {
                    return;
                }

                initFunc((TView)this.CurrentView);
            }
            catch
            {
                MessageBox.Show("Some Error Occured (", "Navigation error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        protected void OnPropertyChange([CallerMemberName] string? propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
