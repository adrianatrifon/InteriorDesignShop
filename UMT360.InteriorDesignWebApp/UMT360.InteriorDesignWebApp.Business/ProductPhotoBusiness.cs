using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Business.Core;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.Business
{
    public class ProductPhotoBusiness
    {
        #region Methods
        public List<ProductPhoto> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.ProductPhotoRepository.ReadAll();
        }

        public void Insert(ProductPhoto productPhoto)
        {
            BusinessContext.Current.RepositoryContext.ProductPhotoRepository.Insert(productPhoto);
        }

        public void Delete(ProductPhoto productPhoto)
        {
            BusinessContext.Current.RepositoryContext.ProductPhotoRepository.Delete(productPhoto);
        }
        #endregion        
    }
}
