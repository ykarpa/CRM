using System.Windows;
using System.Windows.Controls;

namespace Presentation.Components
{
	/// <summary>
	/// Interaction logic for Navbar.xaml
	/// </summary>
	public partial class Navbar : UserControl
	{
		public Navbar()
		{
			InitializeComponent();
		}

		private void CategoryButton_Click(object sender, RoutedEventArgs e)
		{
			new MainWindow().Show();
		}
	}
}
