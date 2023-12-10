using System.ComponentModel;
using System.Runtime.CompilerServices;
using DAL.Models;

namespace Presentation.ViewModels
{
    public class CardInfoViewModel : INotifyPropertyChanged
    {
        private ProductViewModel _productViewModel;

        public ProductViewModel ProductViewModel
        {
            get { return _productViewModel; }
            set
            {
                _productViewModel = value;
                OnPropertyChanged();
            }
        }

        public CardInfoViewModel(ProductViewModel productViewModel)
        {
            _productViewModel = productViewModel;
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
