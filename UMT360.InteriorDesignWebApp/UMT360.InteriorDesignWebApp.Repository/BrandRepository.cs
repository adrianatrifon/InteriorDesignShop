using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using UMT360.InteriorDesignWebApp.Models;
using UMT360.InteriorDesignWebApp.Repository.Core;

namespace UMT360.InteriorDesignWebApp.Repository
{
    public class BrandRepository:BaseRepository<Brand>
    {
        #region Methods
        public List<Brand> ReadAll()
        {
            return ReadAll("dbo.Brands_ReadAll");

        }

        public void Insert(Brand brand)
        {

            SqlParameter[] parameters = { new SqlParameter("@BrandID", brand.Id), new SqlParameter("@BrandName", brand.Name) };
            Operation("dbo.Brands_Create", parameters);

        }
        public void Update(Brand brand)
        {
            SqlParameter[] parameters = { new SqlParameter("@BrandID", brand.Id), new SqlParameter("@BrandName", brand.Name) };
            Operation("dbo.Brands_Update", parameters);

        }

        public void Delete(Guid brandId)
        {
            SqlParameter[] parameters = { new SqlParameter("@BrandID", brandId) };
            Operation("dbo.Brands_Delete", parameters);

        }

        public Brand GetById(Guid brandId)
        {
            Brand brand = new Brand();
            SqlParameter[] parameters = { new SqlParameter("@BrandID", brandId) };
            List<Brand> brands = new List<Brand>();
            brands = ReadAll("dbo.Brands_GetById", parameters);

            return brands.ElementAt(0);
        }

        public override Brand GetModelFromReader(SqlDataReader reader)
        {
            Brand brand = new Brand();
            brand.Id = reader.GetGuid(reader.GetOrdinal("BrandID"));
            brand.Name = reader.GetString(reader.GetOrdinal("Name"));
            return brand;
        }
        #endregion
    }
}
