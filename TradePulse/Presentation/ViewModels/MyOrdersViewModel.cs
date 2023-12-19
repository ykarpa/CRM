using BLL.DTOs;
using BLL.Services;
using DAL.Models;
using Presentation.Core;
using System.Threading.Tasks;

namespace Presentation.ViewModels
{
    public class MyOrdersViewModel : ViewModel
    {
        private OrderDetailsDTO _order;
        public OrderDetailsDTO Order
        {
            get => _order;
            set
            {
                _order = value;
                OnPropertyChange();
            }
        }
    }
}
