using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;



namespace Presentation.Views
{
    /// <summary>
    /// Interaction logic for CreateOrder.xaml
    /// </summary>
    public partial class CreateOrder : UserControl
    {
        public CreateOrder()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            MessageBox.Show("Товар оформлено!");

        }
    }
}
