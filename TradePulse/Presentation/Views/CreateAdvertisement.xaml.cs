using Microsoft.Win32;
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
    /// Interaction logic for CreateAdvertisement.xaml
    /// </summary>
    public partial class CreateAdvertisement : UserControl
    {
        public CreateAdvertisement()
        {
            InitializeComponent();
        }

        private void btnAddFile1_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image files (*.jpeg, *.jpg, *.png)|*.jpeg;*.jpg;*.png";
            fileDialog.Title = "Оберіть файл";

            bool? success = fileDialog.ShowDialog();
            if (success == true)
            {
                string path = fileDialog.FileName;
                string fileName = fileDialog.SafeFileName;
                btnAddFile1.Content = fileName;
            }
            else
            { }
        }

        private void btnAddFile2_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image files (*.jpeg, *.jpg, *.png)|*.jpeg;*.jpg;*.png";
            fileDialog.Title = "Оберіть файл";

            bool? success = fileDialog.ShowDialog();
            if (success == true)
            {
                string path = fileDialog.FileName;
                string fileName = fileDialog.SafeFileName;
                btnAddFile2.Content = fileName;
            }
            else
            { }
        }

        private void btnAddFile3_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image files (*.jpeg, *.jpg, *.png)|*.jpeg;*.jpg;*.png";
            fileDialog.Title = "Оберіть файл";

            bool? success = fileDialog.ShowDialog();
            if (success == true)
            {
                string path = fileDialog.FileName;
                string fileName = fileDialog.SafeFileName;
                btnAddFile3.Content = fileName;
            }
            else
            { }
        }

        private void btnAddFile4_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image files (*.jpeg, *.jpg, *.png)|*.jpeg;*.jpg;*.png";
            fileDialog.Title = "Оберіть файл";

            bool? success = fileDialog.ShowDialog();
            if (success == true)
            {
                string path = fileDialog.FileName;
                string fileName = fileDialog.SafeFileName;
                btnAddFile4.Content = fileName;
            }
            else
            { }
        }

        private void btnAddFile5_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image files (*.jpeg, *.jpg, *.png)|*.jpeg;*.jpg;*.png";
            fileDialog.Title = "Оберіть файл";

            bool? success = fileDialog.ShowDialog();
            if (success == true)
            {
                string path = fileDialog.FileName;
                string fileName = fileDialog.SafeFileName;
                btnAddFile5.Content = fileName;
            }
            else
            { }
        }
    }
}
