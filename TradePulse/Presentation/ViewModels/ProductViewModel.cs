using System.ComponentModel;
using System.Runtime.CompilerServices;
using DAL.Models;

namespace Presentation.ViewModels
{
    public class ProductViewModel : INotifyPropertyChanged
    {
        private string _title;
        private string _description;
        private decimal _price;
        private string _model;
        private uint _itemsAvailable;

        public string Title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged();
                }
            }
        }

        public decimal Price
        {
            get { return _price; }
            set
            {
                if (_price != value)
                {
                    _price = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Model
        {
            get { return _model ?? ""; }
            set
            {
                if (_model != value)
                {
                    _model = value;
                    OnPropertyChanged();
                }
            }
        }

        public uint ItemsAvailable
        {
            get { return _itemsAvailable; }
            set
            {
                if (_itemsAvailable != value)
                {
                    _itemsAvailable = value;
                    OnPropertyChanged();
                }
            }
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
