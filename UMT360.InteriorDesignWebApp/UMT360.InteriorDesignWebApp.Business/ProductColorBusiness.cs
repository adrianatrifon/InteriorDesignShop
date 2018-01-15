using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Business.Core;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.Business
{
    public class ProductColorBusiness
    {
        #region Methods
        public List<DesignerPhoto> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.ProductColorRepository.ReadAll();
        }

        public void Insert(DesignerPhoto productColor)
        {
            BusinessContext.Current.RepositoryContext.ProductColorRepository.Insert(productColor);
        }

        public void Delete(DesignerPhoto productColor)
        {
            BusinessContext.Current.RepositoryContext.ProductColorRepository.Delete(productColor);
        }
        #endregion        
    }
}
