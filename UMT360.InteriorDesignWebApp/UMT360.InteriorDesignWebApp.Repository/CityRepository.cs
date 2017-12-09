using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using UMT360.InteriorDesignWebApp.Models;
using UMT360.InteriorDesignWebApp.Repository.Core;

namespace UMT360.InteriorDesignWebApp.Repository
{
    public class CityRepository:BaseRepository<City>
    {
        #region Methods
        public List<City> ReadAll()
        {
            return ReadAll("dbo.Cities_ReadAll");

        }

        public void Insert(City city)
        {

            SqlParameter[] parameters = { new SqlParameter("@CityID", city.Id), new SqlParameter("@CityName", city.Name),
                                          new SqlParameter("@CountyID", city.CountyId) };
            Operation("dbo.Cities_Create", parameters);

        }
        public void Update(City city)
        {
            SqlParameter[] parameters = { new SqlParameter("@CityID", city.Id), new SqlParameter("@CityName", city.Name),
                                          new SqlParameter("@CountyID", city.CountyId) };
            Operation("dbo.Cities_Update", parameters);

        }

        public void Delete(Guid cityId)
        {
            SqlParameter[] parameters = { new SqlParameter("@CityID", cityId) };
            Operation("dbo.Cities_Delete", parameters);

        }

        public City GetById(Guid cityId)
        {
            City city = new City();
            SqlParameter[] parameters = { new SqlParameter("@CityID", cityId) };
            List<City> cities = new List<City>();
            cities = ReadAll("dbo.Cities_GetById", parameters);

            return cities.ElementAt(0);
        }

        public override City GetModelFromReader(SqlDataReader reader)
        {
            City city = new City();
            city.Id = reader.GetGuid(reader.GetOrdinal("CityID"));
            city.Name = reader.GetString(reader.GetOrdinal("Name"));
            city.CountyId = reader.GetGuid(reader.GetOrdinal("CountyID"));
            return city;
        }
        #endregion
        
    }
}
