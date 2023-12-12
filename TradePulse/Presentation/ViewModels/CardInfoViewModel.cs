// <copyright file="CardInfoViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Presentation.ViewModels
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public class CardInfoViewModel : INotifyPropertyChanged
    {
        private ProductViewModel _productViewModel;

        public ProductViewModel ProductViewModel
        {
            get
            {
                return this._productViewModel;
            }

            set
            {
                this._productViewModel = value;
                this.OnPropertyChanged();
            }
        }

        public CardInfoViewModel(ProductViewModel productViewModel)
        {
            this._productViewModel = productViewModel;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
