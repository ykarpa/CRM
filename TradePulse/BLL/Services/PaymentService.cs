using DAL.GenerickRepository;
using DAL.Models;

namespace BLL.Services
{
	public class PaymentService : IService<Payment>
	{
		private IGenericRepository<Payment> paymentRepository;

		public PaymentService()
		{
			paymentRepository = new TradePulseRepository<Payment>();
		}
        public PaymentService(IGenericRepository<Payment>paymentService)
        {
			paymentRepository = paymentService;
        }

        public Task<List<Payment>> GetAll()
		{
			return paymentRepository.GetAll();
		}

		public Task<Payment> GetById(int id)
		{
			return paymentRepository.GetById(id);
		}

		public IQueryable<Payment> GetQuaryable()
		{
			return paymentRepository.GetQuaryable();
		}

		public void Create(Payment payment)
		{
			paymentRepository.Create(payment);
			paymentRepository.Save();
		}

		public void Update(Payment payment)
		{
			paymentRepository.Update(payment);
			paymentRepository.Save();
		}

		public void Delete(Payment payment)
		{
			paymentRepository.Delete(payment);
			paymentRepository.Save();
		}
	}
}
