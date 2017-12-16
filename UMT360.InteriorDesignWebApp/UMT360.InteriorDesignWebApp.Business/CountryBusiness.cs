using System;
using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Business.Core;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.Business
{
    public class CountryBusiness
    {
        #region Methods
        public List<Country> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.CountryRepository.ReadAll();
        }

        public void Insert(Country country)
        {
            BusinessContext.Current.RepositoryContext.CountryRepository.Insert(country);
        }
        public void Update(Country country)
        {
            BusinessContext.Current.RepositoryContext.CountryRepository.Update(country);
        }

        public void Delete(Guid countryId)
        {
            BusinessContext.Current.RepositoryContext.CountryRepository.Delete(countryId);
        }

        public Country GetById(Guid countryId)
        {
            return BusinessContext.Current.RepositoryContext.CountryRepository.GetById(countryId);
        }
        #endregion
    }
}
