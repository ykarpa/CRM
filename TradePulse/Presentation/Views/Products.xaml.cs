using Presentation.ViewModels;
using System.Windows.Controls;
using System.Windows.Input;

namespace Presentation.Views
{
	/// <summary>
	/// Interaction logic for Products.xaml
	/// </summary>
	public partial class Products : UserControl
    {
        public Products()
        {
            InitializeComponent();
        }

		private void Border_MouseDown(object sender, MouseButtonEventArgs e)
		{
            if(e.ClickCount == 2)
            {
            }
        }
    }
}
