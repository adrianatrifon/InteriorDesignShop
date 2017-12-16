using System;
using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Business.Core;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.Business
{
    public class CityBusiness
    {
        #region Methods
        public List<City> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.CityRepository.ReadAll();
        }

        public void Insert(City city)
        {
            BusinessContext.Current.RepositoryContext.CityRepository.Insert(city);
        }

        public void Update(City city)
        {
            BusinessContext.Current.RepositoryContext.CityRepository.Update(city);
        }

        public void Delete(Guid cityId)
        {
            BusinessContext.Current.RepositoryContext.CityRepository.Delete(cityId);
        }

        public City GetById(Guid cityId)
        {
            return BusinessContext.Current.RepositoryContext.CityRepository.GetById(cityId);
        }
        #endregion        
    }
}
