using BLL.DTOs;
using BLL.Services;
using Presentation.Core;
using Presentation.Services;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using DAL.Models;

namespace Presentation.ViewModels
{
    public class CreationOrderViewModel : ViewModel
    {
        private INavigationService _navService { get; set; }
        private OrderService _orderService = new OrderService();
        private string? _firstName;

        public string? FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChange();
            }
        }
        private string? _lastName;

        public string? LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChange();
            }
        }

        private string? _email;

        public string? Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChange();
            }
        }

        private ComboBoxItem? _deliveryType;

        public ComboBoxItem? DeliveryType
        {
            get => _deliveryType;
            set
            {
                _deliveryType = value;
                _deliveryTypeString = _deliveryType.Content as string;
                OnPropertyChange();
            }
        }

        private string _deliveryTypeString;

        private ComboBoxItem? _paymentType;

        public ComboBoxItem? PaymentType
        {
            get => _paymentType;
            set
            {
                _paymentType = value;
                _paymentTypeString = _paymentType.Content as string;
                OnPropertyChange();
            }
        }

        private string _paymentTypeString;
        public RelayCommand CreateOrderCommand { get; set; }

        public async Task<bool> CreateOrder()
        {
            bool isDataValid = ValidateData();
            if (!isDataValid)
            {
                return false;
            }
            UserDetailsDTO user = new UserDetailsDTO()
            {
                FirstName = this.FirstName!,
                LastName = this.LastName!,
                Email = this.Email!,
            };
            OrderDetailsDTO order = new OrderDetailsDTO()
            {
                PaymentType = _paymentTypeString,
                DeliveryType = _deliveryTypeString,
                ReceiverId = user.UserId,
            };
            try
            {
                await _orderService.Create(order);
            }
            catch
            {
                return false;
            }

            return true;
        }

        private bool ValidateData()
        {
            if (FirstName == string.Empty)
            {
                MessageBox.Show($"Введіть прізвище", "Text field is empty", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (LastName == string.Empty)
            {
                MessageBox.Show($"Введіть ім'я", "Text field is empty", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (Email == string.Empty)
            {
                MessageBox.Show($"Введіть електронну адресу", "Text field is empty", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (DeliveryType is null)
            {
                MessageBox.Show($"Виберіть спосіб доставки", "Text field is empty", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (PaymentType is null)
            {
                MessageBox.Show($"Виберіть спосіб оплати", "Text field is empty", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        public CreationOrderViewModel(INavigationService navService)
        {
            _navService = navService;
            this.CreateOrderCommand = new RelayCommand(_ => true, _ =>
            {
                Task.Run(async () =>
                {
                    var isRegistered = await this.CreateOrder();
                    if (!isRegistered) return;
                    _navService.NavigateTo<CategoriesViewModel>();
                });                
            });
        }
    }
}
