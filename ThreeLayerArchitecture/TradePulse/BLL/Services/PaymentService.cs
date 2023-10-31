using DAL.GenerickRepository;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PaymentService
    {
        private IGenericRepository<Payment> paymentRepository;

        public PaymentService(IGenericRepository<Payment> repository)
        {
            paymentRepository = repository;
        }

        public Task<List<Payment>> GetAll()
        {
            return paymentRepository.GetAll();
        }

        public Task<Payment> GetPaymentById(int id)
        {
            return paymentRepository.GetById(id);
        }

        public IQueryable<Payment> GetQuaryable()
        {
            return paymentRepository.GetQuaryable();
        }

        public void CreatePayment(Payment payment)
        {
            paymentRepository.Create(payment);
            paymentRepository.Save();
        }

        public void UpdatePayment(Payment payment)
        {
            paymentRepository.Update(payment);
            paymentRepository.Save();
        }

        public void DeletePayment(Payment payment)
        {
            paymentRepository.Delete(payment);
            paymentRepository.Save();
        }
    }
}
