using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DAL.Models;
using BLL.Services;
using System.Linq;

namespace Presentation.ViewModels
{
    public class OrdersViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ProductViewModel> _products;

        public ObservableCollection<ProductViewModel> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                OnPropertyChanged();
            }
        }


        private async Task LoadProducts()
        {
            var productService = new ProductService();
            var products = await productService.GetAll();

            var productViewModels = products.Select(product => new ProductViewModel
            {
                Title = product.Title,
                Description = product.Description,
                Price = product.Price,
                Model = product.Model,
                ItemsAvailable = product.ItemsAvailable
            }).ToList();

            Products = new ObservableCollection<ProductViewModel>(productViewModels);
        }


        public OrdersViewModel()
        {
            LoadProducts();
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
