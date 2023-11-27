using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Presentation.Core;

namespace Presentation.Services
{
	public interface INavigationService
	{
		ViewModel CurrentView { get; }
		void NavigateTo<T>() where T : ViewModel;
	}
	public class NavigationServices : INotifyPropertyChanged, INavigationService
	{
		private ViewModel _currentView;

		public ViewModel CurrentView
		{
			get => _currentView;
			private set
			{
				_currentView = value;
				OnPropertyChange();
			}
		}

		public Func<Type, ViewModel> _viewModelFactory { get; }

		public NavigationServices(Func<Type, ViewModel> viewModelFactory)
        {
			_viewModelFactory = viewModelFactory;
		}

        public event PropertyChangedEventHandler? PropertyChanged;

		public void NavigateTo<TViewModel>() where TViewModel : ViewModel
		{
			ViewModel viewModel = _viewModelFactory.Invoke(typeof(TViewModel));
			CurrentView = viewModel;
		}

		protected void OnPropertyChange([CallerMemberName] string? propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
