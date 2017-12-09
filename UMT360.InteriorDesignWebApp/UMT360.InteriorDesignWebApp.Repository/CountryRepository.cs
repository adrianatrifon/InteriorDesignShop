using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using UMT360.InteriorDesignWebApp.Models;
using UMT360.InteriorDesignWebApp.Repository.Core;

namespace UMT360.InteriorDesignWebApp.Repository
{
    public class CountryRepository:BaseRepository<Country>
    {
        #region Methods
        public List<Country> ReadAll()
        {
            return ReadAll("dbo.Countries_ReadAll");

        }

        public void Insert(Country country)
        {

            SqlParameter[] parameters = { new SqlParameter("@CountryID", country.Id), new SqlParameter("@CountryName", country.Name) };
            Operation("dbo.Countries_Create", parameters);

        }
        public void Update(Country country)
        {
            SqlParameter[] parameters = { new SqlParameter("@CountryID", country.Id), new SqlParameter("@CountryName", country.Name) };
            Operation("dbo.Countries_Update", parameters);

        }

        public void Delete(Guid countryId)
        {
            SqlParameter[] parameters = { new SqlParameter("@CountryID", countryId) };
            Operation("dbo.Countries_Delete", parameters);

        }

        public Country GetById(Guid countryId)
        {
            Country country = new Country();
            SqlParameter[] parameters = { new SqlParameter("@CountryID", countryId) };
            List<Country> countries = new List<Country>();
            countries = ReadAll("dbo.Countries_GetById", parameters);

            return countries.ElementAt(0);
        }

        public override Country GetModelFromReader(SqlDataReader reader)
        {
            Country country = new Country();
            country.Id = reader.GetGuid(reader.GetOrdinal("CountryID"));
            country.Name = reader.GetString(reader.GetOrdinal("Name"));
            return country;
        }
        #endregion
    }
}
