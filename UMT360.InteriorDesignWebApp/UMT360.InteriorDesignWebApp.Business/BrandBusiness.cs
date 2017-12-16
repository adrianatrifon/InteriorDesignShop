using System;
using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Business.Core;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.Business
{
    public class BrandBusiness
    {
        #region Methods
        public List<Brand> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.BrandRepository.ReadAll();
        }

        public void Insert(Brand brand)
        {
            BusinessContext.Current.RepositoryContext.BrandRepository.Insert(brand);
        }

        public void Update(Brand brand)
        {
            BusinessContext.Current.RepositoryContext.BrandRepository.Update(brand);
        }

        public void Delete(Guid brandId)
        {
            BusinessContext.Current.RepositoryContext.BrandRepository.Delete(brandId);
        }

        public Brand GetById(Guid brandId)
        {
            return BusinessContext.Current.RepositoryContext.BrandRepository.GetById(brandId);
        }
        #endregion
    }
}
