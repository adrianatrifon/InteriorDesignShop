using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.Repository
{
    public class CityRepository
    {
        #region Methods
        public List<City> ReadAll()
        {
            string connectionString = @"Server=ADRI-PC\SQLEXPRESS;Database=InteriorDesignShopDB;Trusted_Connection=True;";
            List<City> cities = new List<City>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Cities_ReadAll";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                City city = new City();
                                city.Id = reader.GetGuid(reader.GetOrdinal("CityID"));                                
                                city.Name = reader.GetString(reader.GetOrdinal("Name"));
                                city.CountyId = reader.GetGuid(reader.GetOrdinal("CountyID"));

                                cities.Add(city);
                            }
                        }
                    }

                }
                catch (SqlException sqlEx)
                {
                    Console.WriteLine("There was a SQL error: {0}", sqlEx.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("There was an error: {0}", ex.Message);
                }

            }
            return cities;
        }

        public void Insert(City city)
        {
            string connectionString = @"Server=ADRI-PC\SQLEXPRESS;Database=InteriorDesignShopDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Cities_Create";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@CityID", city.Id));
                        command.Parameters.Add(new SqlParameter("@CityName", city.Name));
                        command.Parameters.Add(new SqlParameter("@CountyID", city.CountyId));

                        connection.Open();
                        command.ExecuteNonQuery();
                    }

                }
                catch (SqlException sqlEx)
                {
                    Console.WriteLine("There was a SQL error: {0}", sqlEx.Message);
                }
                catch (Exception ex)
                {

                    Console.WriteLine("There was an error: {0}", ex.Message);
                }

            }

        }
        public void Update(City city, string newCityName, Guid newCountyId)
        {
            string connectionString = @"Server=ADRI-PC\SQLEXPRESS;Database=InteriorDesignShopDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Cities_Update";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@CityID", city.Id));
                        command.Parameters.Add(new SqlParameter("@CityName", newCityName));
                        command.Parameters.Add(new SqlParameter("@CountyID", newCountyId));

                        connection.Open();
                        command.ExecuteNonQuery();
                    }

                }
                catch (SqlException sqlEx)
                {
                    Console.WriteLine("There was a SQL error: {0}", sqlEx.Message);
                }
                catch (Exception ex)
                {

                    Console.WriteLine("There was an error: {0}", ex.Message);
                }

            }

        }
        public void Delete(Guid cityId)
        {

            string connectionString = @"Server=ADRI-PC\SQLEXPRESS;Database=InteriorDesignShopDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Cities_Delete";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@CityID", cityId));

                        connection.Open();
                        command.ExecuteNonQuery();
                    }

                }
                catch (SqlException sqlEx)
                {
                    Console.WriteLine("There was a SQL error: {0}", sqlEx.Message);
                }
                catch (Exception ex)
                {

                    Console.WriteLine("There was an error: {0}", ex.Message);
                }

            }

        }

        public City GetById(Guid cityId)
        {
            City city = new City();
            string connectionString = @"Server=ADRI-PC\SQLEXPRESS;Database=InteriorDesignShopDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Cities_GetById";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@CityID", cityId));
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                city.Id = reader.GetGuid(reader.GetOrdinal("CityID"));
                                city.Name = reader.GetString(reader.GetOrdinal("Name"));
                                city.CountyId = reader.GetGuid(reader.GetOrdinal("CountyID"));

                            }

                        }

                    }
                }
                catch (SqlException sqlEx)
                {
                    Console.WriteLine("There was a SQL error: {0}", sqlEx.Message);
                }
                catch (Exception ex)
                {

                    Console.WriteLine("There was an error: {0}", ex.Message);
                }


            }
            return city;
        }
        #endregion
    }
}
