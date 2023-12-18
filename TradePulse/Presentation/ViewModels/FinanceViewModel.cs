using Presentation.Core;

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
                OnPropertyChange();
            }
        }
    }
}
