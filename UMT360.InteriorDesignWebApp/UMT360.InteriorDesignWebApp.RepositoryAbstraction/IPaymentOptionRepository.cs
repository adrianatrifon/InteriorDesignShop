using System;
using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.RepositoryAbstraction
{
    public interface IPaymentOptionRepository
    {
        List<PaymentOption> ReadAll();
        void Insert(PaymentOption paymentOption);
        void Update(PaymentOption paymentOption);
        void Delete(Guid paymentOptionId);
        PaymentOption GetById(Guid paymentOptionId);
    }
}
