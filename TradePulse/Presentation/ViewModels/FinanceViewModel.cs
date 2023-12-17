using BLL.Services;
using Presentation.Core;
using System.Threading.Tasks;

namespace Presentation.ViewModels
{
    public class FinanceViewModel : ViewModel
    {
        private decimal _earnedMoney;
        public decimal EarnedMoney
        {
            get => _earnedMoney;
            set
            {
                _earnedMoney = value;
                OnPropertyChange(nameof(EarnedMoney));
            }
        }
    }
}
