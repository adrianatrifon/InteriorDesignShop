using System.Collections.Generic;
using System.Data.SqlClient;
using UMT360.InteriorDesignWebApp.Models;
using UMT360.InteriorDesignWebApp.Repository.Core;
using UMT360.InteriorDesignWebApp.RepositoryAbstraction;

namespace UMT360.InteriorDesignWebApp.Repository
{
    public class ProductColorRepository:BaseRepository<ProductColor>,IProductColorRepository
    {
        #region Methods
        public List<ProductColor> ReadAll()
        {
            return ReadAll("dbo.ProductsColors_ReadAll");
        }

        public void Insert(ProductColor productColor)
        {
            SqlParameter[] parameters = GetParametersFromModel(productColor);
            ExecuteNonQuery("dbo.ProductsColors_Create", parameters);
        }        

        public void Delete(ProductColor productColor)
        {
            SqlParameter[] parameters = GetParametersFromModel(productColor);
            ExecuteNonQuery("dbo.ProductsColors_Delete", parameters);
        }

        protected override ProductColor GetModelFromReader(SqlDataReader reader)
        {
            ProductColor productColor = new ProductColor();
            productColor.ColorId = reader.GetGuid(reader.GetOrdinal("ColorID"));
            productColor.ProductId = reader.GetGuid(reader.GetOrdinal("ProductID"));
            return productColor;
        }
        internal SqlParameter[] GetParametersFromModel(ProductColor productColor)
        {
            SqlParameter[] parameters = { new SqlParameter("@ColorID", productColor.ColorId),
                                          new SqlParameter("@ProductID", productColor.ProductId)};
            return parameters;
        }
        #endregion        
    }
}
