using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using UMT360.InteriorDesignWebApp.Models;
using UMT360.InteriorDesignWebApp.Repository.Core;

namespace UMT360.InteriorDesignWebApp.Repository
{
    public class ProductPromotionRepository : BaseRepository<ProductPromotion>
    {
        #region Methods
        public List<ProductPromotion> ReadAll()
        {
            return ReadAll("dbo.ProductsPromotions_ReadAll");

        }

        public void Insert(ProductPromotion productPromotion)
        {

            SqlParameter[] parameters = { new SqlParameter("@PromotionID", productPromotion.PromotionId),
                                          new SqlParameter("@ProductID", productPromotion.ProductId)};

            Operation("dbo.ProductsPromotions_Create", parameters);

        }


        public void Delete(ProductPromotion productPromotion)
        {
            SqlParameter[] parameters = { new SqlParameter("@PromotionID", productPromotion.PromotionId),
                                          new SqlParameter("@ProductID", productPromotion.ProductId)};

            Operation("dbo.ProductsPromotions_Delete", parameters);

        }

        public override ProductPromotion GetModelFromReader(SqlDataReader reader)
        {
            ProductPromotion productPromotion = new ProductPromotion();
            productPromotion.PromotionId = reader.GetGuid(reader.GetOrdinal("PromotionID"));
            productPromotion.ProductId = reader.GetGuid(reader.GetOrdinal("ProductID"));
            return productPromotion;
        }
        #endregion
        
    }
}
