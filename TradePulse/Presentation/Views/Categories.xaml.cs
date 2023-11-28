using Presentation.Core;
using Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Presentation.Views
{
	/// <summary>
	/// Interaction logic for Categories.xaml
	/// </summary>
	public partial class Categories : UserControl
	{
        private CategoriesViewModel viewModel;
        public Categories()
		{
			InitializeComponent();

			viewModel = new CategoriesViewModel();
            viewModel.CategoriesLoaded += ViewModel_CategoriesLoaded;
        }

        private void ViewModel_CategoriesLoaded(object sender, List<string> categories)
        {
            WrapPanel categoriesWrapPanel = CategoriesWrapPanel;

            foreach (var category in categories)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Button button = new Button
                    {
                        Background = new SolidColorBrush(Color.FromArgb(0xB0, 0xC2, 0xE6, 0xFF)),
                        Width = 250,
                        Height = 150,
                        Margin = new Thickness(20, 0, 60, 10),
                        Content = new TextBlock
                        {
                            Text = category,
                            VerticalAlignment = VerticalAlignment.Center,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            FontSize = 18,
                            Foreground = Brushes.Black
                        }
                    };

                    categoriesWrapPanel.Children.Add(button);
                });
            }
        }

        private void YourWindow_Loaded(object sender, RoutedEventArgs e)
        {
            viewModel.LoadCategories();
        }
    }
}
