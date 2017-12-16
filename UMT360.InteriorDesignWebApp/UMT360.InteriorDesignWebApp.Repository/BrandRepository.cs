using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using UMT360.InteriorDesignWebApp.Models;
using UMT360.InteriorDesignWebApp.Repository.Core;
using UMT360.InteriorDesignWebApp.RepositoryAbstraction;

namespace UMT360.InteriorDesignWebApp.Repository
{
    public class BrandRepository:BaseRepository<Brand>,IBrandRepository
    {
        #region Methods
        public List<Brand> ReadAll()
        {
            return ReadAll("dbo.Brands_ReadAll");
        }

        public void Insert(Brand brand)
        {           
            SqlParameter[] parameters = GetParametersFromModel(brand);
            ExecuteNonQuery("dbo.Brands_Create", parameters);
        }

        public void Update(Brand brand)
        {
            SqlParameter[] parameters = GetParametersFromModel(brand);
            ExecuteNonQuery("dbo.Brands_Update", parameters);
        }

        public void Delete(Guid brandId)
        {
            SqlParameter[] parameters = { new SqlParameter("@BrandID", brandId) };
            ExecuteNonQuery("dbo.Brands_Delete", parameters);
        }

        public Brand GetById(Guid brandId)
        {
            SqlParameter[] parameters = { new SqlParameter("@BrandID", brandId) };
            List<Brand> brands = new List<Brand>();
            brands = ReadAll("dbo.Brands_GetById", parameters);

            return brands.Single();
        }

        protected override Brand GetModelFromReader(SqlDataReader reader)
        {
            Brand brand = new Brand();
            brand.Id = reader.GetGuid(reader.GetOrdinal("BrandID"));
            brand.Name = reader.GetString(reader.GetOrdinal("Name"));
            return brand;
        }

        internal SqlParameter[] GetParametersFromModel(Brand brand)
        {
            SqlParameter[] parameters ={ new SqlParameter("@BrandID", brand.Id), new SqlParameter("@BrandName", brand.Name) };
            return parameters;
        }
        #endregion
    }
}
