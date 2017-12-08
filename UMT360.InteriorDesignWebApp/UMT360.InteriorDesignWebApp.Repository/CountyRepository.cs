using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.Repository
{
    public class CountyRepository
    {
        #region Methods
        public List<County> ReadAll()
        {
            string connectionString = @"Server=ADRI-PC\SQLEXPRESS;Database=InteriorDesignShopDB;Trusted_Connection=True;";
            List<County> counties = new List<County>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Counties_ReadAll";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                County county = new County();
                                county.Id = reader.GetGuid(reader.GetOrdinal("CountyID"));
                                county.Name = reader.GetString(reader.GetOrdinal("Name"));
                                county.CountryId = reader.GetGuid(reader.GetOrdinal("CountryID"));

                                counties.Add(county);
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
            return counties;
        }

        public void Insert(County county)
        {
            string connectionString = @"Server=ADRI-PC\SQLEXPRESS;Database=InteriorDesignShopDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Counties_Create";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@CountyID", county.Id));
                        command.Parameters.Add(new SqlParameter("@CountyName", county.Name));
                        command.Parameters.Add(new SqlParameter("@CountryID", county.CountryId));

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
        public void Update(County county)
        {
            string connectionString = @"Server=ADRI-PC\SQLEXPRESS;Database=InteriorDesignShopDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Counties_Update";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@CountyID", county.Id));
                        command.Parameters.Add(new SqlParameter("@CountyName", county.Name));
                        command.Parameters.Add(new SqlParameter("@CountryID", county.CountryId));

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
        public void Delete(Guid countyId)
        {

            string connectionString = @"Server=ADRI-PC\SQLEXPRESS;Database=InteriorDesignShopDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Counties_Delete";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@CountyID", countyId));

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

        public County GetById(Guid countyId)
        {
            County county = new County();
            string connectionString = @"Server=ADRI-PC\SQLEXPRESS;Database=InteriorDesignShopDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Counties_GetById";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@CountyID", countyId));
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                county.Id = reader.GetGuid(reader.GetOrdinal("CountyID"));
                                county.Name = reader.GetString(reader.GetOrdinal("Name"));
                                county.CountryId = reader.GetGuid(reader.GetOrdinal("CountryID"));

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
            return county;
        }
        #endregion
    }
}
