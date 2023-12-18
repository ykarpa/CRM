using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Presentation.Views
{
	/// <summary>
	/// Interaction logic for ProfileModalDialog.xaml
	/// </summary>
	public partial class ProfileModalDialog : UserControl
    {
        public ProfileModalDialog()
        {
            InitializeComponent();
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
        private void NavigateToProfile_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

	}
}
