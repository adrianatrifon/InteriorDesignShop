using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Business.Core;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.Business
{
    public class ProductColorBusiness
    {
        #region Methods
        public List<ProductColor> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.ProductColorRepository.ReadAll();
        }

        public void Insert(ProductColor productColor)
        {
            BusinessContext.Current.RepositoryContext.ProductColorRepository.Insert(productColor);
        }

        public void Delete(ProductColor productColor)
        {
            BusinessContext.Current.RepositoryContext.ProductColorRepository.Delete(productColor);
        }
        #endregion        
    }
}
