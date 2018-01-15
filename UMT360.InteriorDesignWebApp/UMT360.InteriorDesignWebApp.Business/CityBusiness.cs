using System;
using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Business.Core;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.Business
{
    public class CityBusiness
    {
        #region Methods
        public List<Style> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.CityRepository.ReadAll();
        }

        public void Insert(Style city)
        {
            BusinessContext.Current.RepositoryContext.CityRepository.Insert(city);
        }

        public void Update(Style city)
        {
            BusinessContext.Current.RepositoryContext.CityRepository.Update(city);
        }

        public void Delete(Guid cityId)
        {
            BusinessContext.Current.RepositoryContext.CityRepository.Delete(cityId);
        }

        public Style GetById(Guid cityId)
        {
            return BusinessContext.Current.RepositoryContext.CityRepository.GetById(cityId);
        }
        #endregion        
    }
}
