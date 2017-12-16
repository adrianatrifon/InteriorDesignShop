using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Business.Core;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.Business
{
    public class ProductPromotionBusiness
    {
        #region Methods
        public List<ProductPromotion> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.ProductPromotionRepository.ReadAll();
        }

        public void Insert(ProductPromotion productPromotion)
        {
            BusinessContext.Current.RepositoryContext.ProductPromotionRepository.Insert(productPromotion);
        }

        public void Delete(ProductPromotion productPromotion)
        {
            BusinessContext.Current.RepositoryContext.ProductPromotionRepository.Delete(productPromotion);
        }
        #endregion        
    }
}
