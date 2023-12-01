using Presentation.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ViewModels
{
    public class CategoryViewModel : ViewModel
    {
        private string? _categoryTitle;

        public string CategoryTitle
        {
            get { return _categoryTitle!; }
            set
            {
                if (_categoryTitle != value)
                {
                    _categoryTitle = value;
                    OnPropertyChange();
                }
            }
        }

        public RelayCommand NavigateToProducts { get; set; }
    }
}