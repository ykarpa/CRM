using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;
using Presentation.Core;

namespace Presentation.Services
{
	public interface INavigationService
	{
		ViewModel CurrentView { get; }
		void NavigateTo<T>() where T : ViewModel;
		void InitParam<TView>(Action<TView> initFunc) where TView : ViewModel;
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
		public void NavigateTo<TViewModel, TParam>(TParam[] props) where TViewModel : ViewModel
		{
			ViewModel viewModel = _viewModelFactory.Invoke(typeof(TViewModel));
			CurrentView = viewModel;
		}
		protected void OnPropertyChange([CallerMemberName] string? propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public void InitParam<TView>(Action<TView> initFunc) where TView : ViewModel
		{
			try
			{
				if (CurrentView is null)
				{
					return;
				}

				initFunc((TView)CurrentView);
			}
			catch
			{
				MessageBox.Show("Some Error Occured (", "Navigation error", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		//public void InitParam<TView, TParam>(string propertyName, TParam value) where TView : ViewModel
		//{
		//	try
		//	{
		//		if (CurrentView is null)
		//		{
		//			return;
		//		}
		//		var prop = CurrentView.GetType().GetProperties().Where(p => p.Name.ToLower() == propertyName.ToLower()).FirstOrDefault();
		//		if (prop is null)
		//		{
		//			throw new InvalidOperationException("Property is not defined");
		//		}
		//		prop.SetValue(CurrentView, value, null);
		//	}
		//	catch 
		//	{
		//		MessageBox.Show("Some Error Occured (", "Navigation error", MessageBoxButton.OK, MessageBoxImage.Error);
		//	}
		//}
	}
}
