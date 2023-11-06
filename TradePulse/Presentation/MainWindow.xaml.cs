using System.Windows;

namespace Presentation
{
	public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
		}
        private void AccessoriesButton_Click(object sender, RoutedEventArgs e)
        {
            Orders ordersWindow = new Orders();
            ordersWindow.Show();
            Close();
        }
	}
}
