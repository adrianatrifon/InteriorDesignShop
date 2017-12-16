using System;
using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Business.Core;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.Business
{
    public class CurrencyBusiness
    {
        #region Methods
        public List<Currency> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.CurrencyRepository.ReadAll();
        }

        public void Insert(Currency currency)
        {
            BusinessContext.Current.RepositoryContext.CurrencyRepository.Insert(currency);
        }
        public void Update(Currency currency)
        {
            BusinessContext.Current.RepositoryContext.CurrencyRepository.Update(currency);
        }

        public void Delete(Guid currencyId)
        {
            BusinessContext.Current.RepositoryContext.CurrencyRepository.Delete(currencyId);
        }

        public Currency GetById(Guid currencyId)
        {
            return BusinessContext.Current.RepositoryContext.CurrencyRepository.GetById(currencyId);

        }
        #endregion        
    }
}
