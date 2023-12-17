using Presentation.Core;

namespace Presentation.ViewModels
{
    public class CategoryViewModel : ViewModel
    {
        private string? _categoryTitle;

        public string CategoryTitle
        {
            get => _categoryTitle!;
            set
            {
	            if (_categoryTitle == value) return;
	            _categoryTitle = value;
	            OnPropertyChange();
            }
        }

        public RelayCommand NavigateToProducts { get; set; }
    }
}