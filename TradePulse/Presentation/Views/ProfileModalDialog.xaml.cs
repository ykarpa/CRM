// <copyright file="ProfileModalDialog.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Presentation.Views
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
    /// Interaction logic for ProfileModalDialog.xaml.
    /// </summary>
    public partial class ProfileModalDialog : UserControl
    {
        public ProfileModalDialog()
        {
            this.InitializeComponent();
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}
