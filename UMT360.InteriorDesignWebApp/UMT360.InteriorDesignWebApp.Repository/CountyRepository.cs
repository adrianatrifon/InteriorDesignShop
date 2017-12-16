using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using UMT360.InteriorDesignWebApp.Models;
using UMT360.InteriorDesignWebApp.Repository.Core;
using UMT360.InteriorDesignWebApp.RepositoryAbstraction;

namespace UMT360.InteriorDesignWebApp.Repository
{
    public class CountyRepository:BaseRepository<County>,ICountyRepository
    {
        #region Methods
        public List<County> ReadAll()
        {
            return ReadAll("dbo.Counties_ReadAll");
        }

        public void Insert(County county)
        {
            SqlParameter[] parameters = GetParametersFromModel(county);
            ExecuteNonQuery("dbo.Counties_Create", parameters);
        }
        public void Update(County county)
        {
            SqlParameter[] parameters = GetParametersFromModel(county);
            ExecuteNonQuery("dbo.Counties_Update", parameters);
        }

        public void Delete(Guid countyId)
        {
            SqlParameter[] parameters = { new SqlParameter("@CountyID", countyId) };
            ExecuteNonQuery("dbo.Counties_Delete", parameters);
        }

        public County GetById(Guid countyId)
        {
            SqlParameter[] parameters = { new SqlParameter("@CountyID", countyId) };
            List<County> counties = new List<County>();
            counties = ReadAll("dbo.Counties_GetById", parameters);
            return counties.Single();
        }

        protected override County GetModelFromReader(SqlDataReader reader)
        {
            County county = new County();
            county.Id = reader.GetGuid(reader.GetOrdinal("CountyID"));
            county.Name = reader.GetString(reader.GetOrdinal("Name"));
            county.CountryId = reader.GetGuid(reader.GetOrdinal("CountryID"));
            return county;
        }
        internal SqlParameter[] GetParametersFromModel(County county)
        {
            SqlParameter[] parameters = { new SqlParameter("@CountyID", county.Id),
                                          new SqlParameter("@CountyName", county.Name),
                                          new SqlParameter("@CountryID", county.CountryId)
                                        };
            return parameters;
        }
        #endregion        
    }
}
