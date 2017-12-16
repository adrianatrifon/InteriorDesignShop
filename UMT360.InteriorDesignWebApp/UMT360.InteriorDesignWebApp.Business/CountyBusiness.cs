using System;
using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Business.Core;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.Business
{
    public class CountyBusiness
    {
        #region Methods
        public List<County> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.CountyRepository.ReadAll();
        }

        public void Insert(County county)
        {
            BusinessContext.Current.RepositoryContext.CountyRepository.Insert(county);
        }
        public void Update(County county)
        {
            BusinessContext.Current.RepositoryContext.CountyRepository.Update(county);
        }

        public void Delete(Guid countyId)
        {
            BusinessContext.Current.RepositoryContext.CountyRepository.Delete(countyId);
        }

        public County GetById(Guid countyId)
        {
            return BusinessContext.Current.RepositoryContext.CountyRepository.GetById(countyId);
        }
        #endregion
    }
}
