using System.Collections.Generic;
using System.Data.SqlClient;
using UMT360.InteriorDesignWebApp.Models;
using UMT360.InteriorDesignWebApp.Repository.Core;
using UMT360.InteriorDesignWebApp.RepositoryAbstraction;

namespace UMT360.InteriorDesignWebApp.Repository
{
    public class ProductPhotoRepository : BaseRepository<ProductPhoto>,IProductPhotoRepository
    {
        #region Methods
        public List<ProductPhoto> ReadAll()
        {
            return ReadAll("dbo.ProductsPhotos_ReadAll");
        }

        public void Insert(ProductPhoto productPhoto)
        {
            SqlParameter[] parameters = GetParametersFromModel(productPhoto);
            ExecuteNonQuery("dbo.ProductsPhotos_Create", parameters);
        }

        public void Delete(ProductPhoto productPhoto)
        {
            SqlParameter[] parameters = GetParametersFromModel(productPhoto);
            ExecuteNonQuery("dbo.ProductsPhotos_Delete", parameters);
        }

        protected override ProductPhoto GetModelFromReader(SqlDataReader reader)
        {
            ProductPhoto productPhoto = new ProductPhoto();
            productPhoto.PhotoId = reader.GetGuid(reader.GetOrdinal("PhotoID"));
            productPhoto.ProductId = reader.GetGuid(reader.GetOrdinal("ProductID"));
            return productPhoto;
        }
        internal SqlParameter[] GetParametersFromModel(ProductPhoto productPhoto)
        {
            SqlParameter[] parameters = { new SqlParameter("@PhotoID", productPhoto.PhotoId),
                                          new SqlParameter("@ProductID", productPhoto.ProductId)};
            return parameters;
        }
        #endregion        
    }
}
