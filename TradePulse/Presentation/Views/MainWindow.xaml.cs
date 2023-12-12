// <copyright file="MainWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Presentation.Views
{
    using System.Windows;
    using Presentation.ViewModels;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </.`>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainViewModel ctx = (MainViewModel)this.DataContext!;
                ProfileModalDialog modal = ctx.ProfileDialog;
                this.MainGrid.Children.Add(modal);
            }
            catch
            {
                return;
            }
        }
    }
}
