using Presentation.ViewModels;
using System;
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
			MainGrid.Children.Add(new ProfileModalDialog());
        }
    }
}
