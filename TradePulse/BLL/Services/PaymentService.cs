using BLL.DTOs;
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

		public IQueryable<Payment> GetQueryable()
		{
			return paymentRepository.GetQueryable();
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

        public async Task<List<PaymentListDTO>> GetPaymentsList()
        {
            return (await this.GetAll()).Select(p => new PaymentListDTO()
            {
                PaymentId = p.PaymentId,
                From = p.From,
                To = p.To,
                Amount = p.Amount,
                Purpose = p.Purpose
            }).ToList();
        }

        //public async Task<PaymentListDTO> GetPaymentDetails(int id)
        //{
        //    var payment = await this.GetById(id);
        //    return new PaymentListDTO()
        //    {
        //        PaymentId = payment.PaymentId,
        //        From = payment.From,
        //        To = payment.To,
        //        Amount = payment.Amount,
        //        Purpose = payment.Purpose
        //    };
        //}
    }
}
