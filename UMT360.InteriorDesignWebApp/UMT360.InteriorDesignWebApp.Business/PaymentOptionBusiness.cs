using System;
using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Business.Core;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.Business
{
    public class PaymentOptionBusiness
    {
        #region Methods
        public List<PaymentOption> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.PaymentOptionRepository.ReadAll();
        }

        public void Insert(PaymentOption paymentOption)
        {
            BusinessContext.Current.RepositoryContext.PaymentOptionRepository.Insert(paymentOption);
        }
        public void Update(PaymentOption paymentOption)
        {
            BusinessContext.Current.RepositoryContext.PaymentOptionRepository.Update(paymentOption);
        }

        public void Delete(Guid paymentOptionId)
        {
            BusinessContext.Current.RepositoryContext.PaymentOptionRepository.Delete(paymentOptionId);
        }

        public PaymentOption GetById(Guid paymentOptionId)
        {
            return BusinessContext.Current.RepositoryContext.PaymentOptionRepository.GetById(paymentOptionId);
        }
        #endregion        
    }
}
