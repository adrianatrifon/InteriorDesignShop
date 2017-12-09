using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMT360.InteriorDesignWebApp.Models;
using UMT360.InteriorDesignWebApp.Repository.Core;

namespace UMT360.InteriorDesignWebApp.Repository
{
    public class ProductMaterialRepository : BaseRepository<ProductMaterial>
    {
        #region Methods
        public List<ProductMaterial> ReadAll()
        {
            return ReadAll("dbo.ProductsMaterials_ReadAll");

        }

        public void Insert(ProductMaterial productMaterial)
        {

            SqlParameter[] parameters = { new SqlParameter("@MaterialID", productMaterial.MaterialId),
                                          new SqlParameter("@ProductID", productMaterial.ProductId)};

            Operation("dbo.ProductsMaterials_Create", parameters);

        }


        public void Delete(ProductMaterial productMaterial)
        {
            SqlParameter[] parameters = { new SqlParameter("@MaterialID", productMaterial.MaterialId),
                                          new SqlParameter("@ProductID", productMaterial.ProductId) };

            Operation("dbo.ProductsMaterials_Delete", parameters);

        }

        public override ProductMaterial GetModelFromReader(SqlDataReader reader)
        {
            ProductMaterial productMaterial = new ProductMaterial();
            productMaterial.MaterialId = reader.GetGuid(reader.GetOrdinal("MaterialID"));
            productMaterial.ProductId = reader.GetGuid(reader.GetOrdinal("ProductID"));
            return productMaterial;
        }
        #endregion
        
    }
}
