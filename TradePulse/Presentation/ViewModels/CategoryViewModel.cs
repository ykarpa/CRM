// <copyright file="CategoryViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Presentation.ViewModels
{
    using Presentation.Core;

    public class CategoryViewModel : ViewModel
    {
        private string? _categoryTitle;

        public string CategoryTitle
        {
            get
            {
                return this._categoryTitle!;
            }

            set
            {
                if (this._categoryTitle != value)
                {
                    this._categoryTitle = value;
                    this.OnPropertyChange();
                }
            }
        }

        public RelayCommand? NavigateToProducts { get; set; }
    }
}