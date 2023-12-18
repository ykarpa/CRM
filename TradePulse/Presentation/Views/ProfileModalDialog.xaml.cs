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
		private void CollapseModal(object sender, RoutedEventArgs e)
		{
			this.Visibility = Visibility.Collapsed;
		}

	}
}
