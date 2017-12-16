using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.RepositoryAbstraction
{
    public interface IProductPromotionRepository
    {
        List<ProductPromotion> ReadAll();
        void Insert(ProductPromotion productPromotion);
        void Delete(ProductPromotion productPromotion);  
    }
}
