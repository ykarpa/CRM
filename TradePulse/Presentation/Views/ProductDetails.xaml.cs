using System.Windows.Controls;
using System.Windows;

namespace Presentation.Views
{
	/// <summary>
	/// Interaction logic for CardInfo.xaml
	/// </summary>
	public partial class ProductDetails : UserControl
    {
        public ProductDetails()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBox.Show("Товар додано до кошика!");
        }
    }
}
