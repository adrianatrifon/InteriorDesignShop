using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.Repository
{
    public class BrandRepository
    {
        #region Methods
        public List<Brand> ReadAll()
        {
            string connectionString = @"Server=ADRI-PC\SQLEXPRESS;Database=InteriorDesignShopDB;Trusted_Connection=True;";
            List<Brand> brands = new List<Brand>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Brands_ReadAll";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                Brand brand = new Brand();
                                brand.Id = reader.GetGuid(reader.GetOrdinal("BrandID"));
                                brand.Name = reader.GetString(reader.GetOrdinal("Name"));

                                brands.Add(brand);
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
            return brands;
        }

        public void Insert(Brand brand)
        {
            string connectionString = @"Server=ADRI-PC\SQLEXPRESS;Database=InteriorDesignShopDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Brands_Create";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@BrandID", brand.Id));
                        command.Parameters.Add(new SqlParameter("@BrandName", brand.Name));

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
        public void Update(Brand brand)
        {
            string connectionString = @"Server=ADRI-PC\SQLEXPRESS;Database=InteriorDesignShopDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Brands_Update";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@BrandID", brand.Id));
                        command.Parameters.Add(new SqlParameter("@BrandName", brand.Name));

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
        public void Delete(Guid brandId)
        {

            string connectionString = @"Server=ADRI-PC\SQLEXPRESS;Database=InteriorDesignShopDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Brands_Delete";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@BrandID", brandId));

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

        public Brand GetById(Guid brandId)
        {
            Brand brand = new Brand();
            string connectionString = @"Server=ADRI-PC\SQLEXPRESS;Database=InteriorDesignShopDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Brands_GetById";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@BrandID", brandId));
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                brand.Id = reader.GetGuid(reader.GetOrdinal("BrandID"));
                                brand.Name = reader.GetString(reader.GetOrdinal("Name"));
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

            return brand;
        }
        #endregion
    }
}
