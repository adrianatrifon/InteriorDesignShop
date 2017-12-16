using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using UMT360.InteriorDesignWebApp.Models;
using UMT360.InteriorDesignWebApp.Repository.Core;
using UMT360.InteriorDesignWebApp.RepositoryAbstraction;

namespace UMT360.InteriorDesignWebApp.Repository
{
    public class ProductRepository : BaseRepository<Product>,IProductRepository
    {
        #region Methods
        public List<Product> ReadAll()
        {
            return ReadAll("dbo.Products_ReadAll");
        }

        public void Insert(Product product)
        {
            SqlParameter[] parameters = GetParametersFromModel(product);
            ExecuteNonQuery("dbo.Products_Create", parameters);
        }
        public void Update(Product product)
        {
            SqlParameter[] parameters = GetParametersFromModel(product);
            ExecuteNonQuery("dbo.Products_Update", parameters);
        }

        public void Delete(Guid productId)
        {
            SqlParameter[] parameters = { new SqlParameter("@ProductID", productId) };
            ExecuteNonQuery("dbo.Products_Delete", parameters);
        }

        public Product GetById(Guid productId)
        {
            SqlParameter[] parameters = { new SqlParameter("@ProductID", productId) };
            List<Product> products = new List<Product>();
            products = ReadAll("dbo.Products_GetById", parameters);
            return products.Single();
        }

        protected override Product GetModelFromReader(SqlDataReader reader)
        {
            Product product = new Product();
            product.Id = reader.GetGuid(reader.GetOrdinal("ProductID"));
            product.Name = reader.GetString(reader.GetOrdinal("Name"));
            product.Price = reader.GetDecimal(reader.GetOrdinal("Price"));
            product.CurrencyId = reader.GetGuid(reader.GetOrdinal("CurrencyID"));
            product.Stock = reader.GetInt32(reader.GetOrdinal("Stock"));
            product.Dimensions = reader.GetString(reader.GetOrdinal("Dimensions"));
            product.Weight = reader.GetString(reader.GetOrdinal("Weight"));
            product.Guarantee = reader.GetString(reader.GetOrdinal("Guarantee"));
            product.Description = reader.GetString(reader.GetOrdinal("Description"));
            product.BrandId = reader.GetGuid(reader.GetOrdinal("BrandID"));
            product.CategoryId = reader.GetGuid(reader.GetOrdinal("CategoryID"));
            return product;
        }
        internal SqlParameter[] GetParametersFromModel(Product product)
        {
            SqlParameter[] parameters = { new SqlParameter("@ProductID", product.Id),
                                          new SqlParameter("@ProductName", product.Name),
                                          new SqlParameter("@Price", product.Price),
                                          new SqlParameter("@CurrencyID", product.CurrencyId),
                                          new SqlParameter("@Stock", product.Stock),
                                          new SqlParameter("@Dimensions", product.Dimensions),
                                          new SqlParameter("@Weight", product.Weight),
                                          new SqlParameter("@Guarantee", product.Guarantee),
                                          new SqlParameter("@Description", product.Description),
                                          new SqlParameter("@BrandID", product.BrandId),
                                          new SqlParameter("@CategoryID", product.CategoryId)
                                        };
            return parameters;
        }
        #endregion        
    }
}
