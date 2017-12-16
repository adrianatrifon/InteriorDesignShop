using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Business.Core;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.Business
{
    public class ProductMaterialBusiness
    {
        #region Methods
        public List<ProductMaterial> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.ProductMaterialRepository.ReadAll();
        }

        public void Insert(ProductMaterial productMaterial)
        {
            BusinessContext.Current.RepositoryContext.ProductMaterialRepository.Insert(productMaterial);
        }
        public void Delete(ProductMaterial productMaterial)
        {
            BusinessContext.Current.RepositoryContext.ProductMaterialRepository.Delete(productMaterial);
        }
        #endregion        
    }
}
