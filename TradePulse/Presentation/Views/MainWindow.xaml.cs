using Presentation.ViewModels;
using System.Windows;

namespace Presentation.Views
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </.`>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void ProfileButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
                profileDialog.Visibility = (profileDialog.Visibility == Visibility.Visible) ? Visibility.Hidden : Visibility.Visible;
            }
			catch
			{
				return;
			}
		}
	}
}
