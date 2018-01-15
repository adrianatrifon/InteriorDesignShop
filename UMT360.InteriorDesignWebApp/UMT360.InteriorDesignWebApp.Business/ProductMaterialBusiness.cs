using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Business.Core;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.Business
{
    public class ProductMaterialBusiness
    {
        #region Methods
        public List<DesignPhoto> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.ProductMaterialRepository.ReadAll();
        }

        public void Insert(DesignPhoto productMaterial)
        {
            BusinessContext.Current.RepositoryContext.ProductMaterialRepository.Insert(productMaterial);
        }
        public void Delete(DesignPhoto productMaterial)
        {
            BusinessContext.Current.RepositoryContext.ProductMaterialRepository.Delete(productMaterial);
        }
        #endregion        
    }
}
