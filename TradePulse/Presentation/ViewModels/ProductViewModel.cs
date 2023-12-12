// <copyright file="ProductViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Presentation.ViewModels
{
    using Presentation.Core;

    public class ProductViewModel : ViewModel
    {
        private string? _title;
        private string? _description;
        private decimal _price;
        private string? _model;
        private uint _itemsAvailable;
        private RelayCommand? _navigateToDetails;

        public string Title
        {
            get
            {
                return this._title!;
            }

            set
            {
                if (this._title != value)
                {
                    this._title = value;
                    this.OnPropertyChange();
                }
            }
        }

        public string Description
        {
            get
            {
                return this._description!;
            }

            set
            {
                if (this._description != value)
                {
                    this._description = value;
                    this.OnPropertyChange();
                }
            }
        }

        public decimal Price
        {
            get
            {
                return this._price;
            }

            set
            {
                if (this._price != value)
                {
                    this._price = value;
                    this.OnPropertyChange();
                }
            }
        }

        public string Model
        {
            get
            {
                return this._model ?? string.Empty;
            }

            set
            {
                if (this._model != value)
                {
                    this._model = value;
                    this.OnPropertyChange();
                }
            }
        }

        public uint ItemsAvailable
        {
            get
            {
                return this._itemsAvailable;
            }

            set
            {
                if (this._itemsAvailable != value)
                {
                    this._itemsAvailable = value;
                    this.OnPropertyChange();
                }
            }
        }

        public RelayCommand? NavigateToDetails
        {
            get => this._navigateToDetails;
            set
            {
                this._navigateToDetails = value;
                this.OnPropertyChange();
            }
        }
    }
}
