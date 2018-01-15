using System;
using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Business.Core;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.Business
{
    public class BrandBusiness
    {
        #region Methods
        public List<Designer> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.BrandRepository.ReadAll();
        }

        public void Insert(Designer brand)
        {
            BusinessContext.Current.RepositoryContext.BrandRepository.Insert(brand);
        }

        public void Update(Designer brand)
        {
            BusinessContext.Current.RepositoryContext.BrandRepository.Update(brand);
        }

        public void Delete(Guid brandId)
        {
            BusinessContext.Current.RepositoryContext.BrandRepository.Delete(brandId);
        }

        public Designer GetById(Guid brandId)
        {
            return BusinessContext.Current.RepositoryContext.BrandRepository.GetById(brandId);
        }
        #endregion
    }
}
