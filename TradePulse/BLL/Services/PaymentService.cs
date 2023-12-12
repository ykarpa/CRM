// <copyright file="PaymentService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BLL.Services
{
    using BLL.DTOs;
    using DAL.GenerickRepository;
    using DAL.Models;

    public class PaymentService : IService<Payment>
    {
        private IGenericRepository<Payment> paymentRepository;

        public PaymentService()
        {
            this.paymentRepository = new TradePulseRepository<Payment>();
        }

        public PaymentService(IGenericRepository<Payment> paymentService)
        {
            this.paymentRepository = paymentService;
        }

        public Task<List<Payment>> GetAll()
        {
            return this.paymentRepository.GetAll();
        }

        public Task<Payment> GetById(int id)
        {
            return this.paymentRepository.GetById(id);
        }

        public IQueryable<Payment> GetQuaryable()
        {
            return this.paymentRepository.GetQuaryable();
        }

        public void Create(Payment payment)
        {
            this.paymentRepository.Create(payment);
            this.paymentRepository.Save();
        }

        public void Update(Payment payment)
        {
            this.paymentRepository.Update(payment);
            this.paymentRepository.Save();
        }

        public void Delete(Payment payment)
        {
            this.paymentRepository.Delete(payment);
            this.paymentRepository.Save();
        }

        public async Task<List<PaymentListDTO>> GetPaymentsList()
        {
            return (await this.GetAll()).Select(p => new PaymentListDTO()
            {
                PaymentId = p.PaymentId,
                From = p.From,
                To = p.To,
                Amount = p.Amount,
                Purpose = p.Purpose,
            }).ToList();
        }

        // public async Task<PaymentListDTO> GetPaymentDetails(int id)
        // {
        //    var payment = await this.GetById(id);
        //    return new PaymentListDTO()
        //    {
        //        PaymentId = payment.PaymentId,
        //        From = payment.From,
        //        To = payment.To,
        //        Amount = payment.Amount,
        //        Purpose = payment.Purpose
        //    };
        // }
    }
}
