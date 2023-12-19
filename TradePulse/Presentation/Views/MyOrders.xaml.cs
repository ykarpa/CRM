using DAL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Presentation.Views
{
    /// <summary>
    /// Interaction logic for MyOrders.xaml
    /// </summary>
    public partial class MyOrders : UserControl
    {
        public ObservableCollection<Order> Orders { get; set; }

        public MyOrders()
        {
            InitializeComponent();
            DataContext = this;

            Orders = new ObservableCollection<Order>
            {
                new Order
                {
                    OrderId = 1,
                    CreatedAt = DateTime.Parse("19.12.2023"),
                    OrderPrice = 749.97m,
                    DropPrice = 20450621322693,
                    DeliveryType = "Нова пошта",
                    PaymentType = "Післяплата",
                    Receiver = new User { FirstName = "Остап" }
                },
                //new Order
                //{
                //    OrderId = 1,
                //    CreatedAt = DateTime.Parse("10.12.2023"),
                //    OrderPrice = 249.99m,
                //    DropPrice = 5503667997307,
                //    DeliveryType = "Укрпошта",
                //    PaymentType = "Оплата карткою",
                //    Receiver = new User { FirstName = "Остап" }
                //} 
            };
        }
    }
}
