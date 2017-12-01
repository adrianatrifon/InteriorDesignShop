using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.Repository
{
    public class ProductRepository
    {
        #region Methods
        public List<Product> ReadAll()
        {
            string connectionString = @"Server=ADRI-PC\SQLEXPRESS;Database=InteriorDesignShopDB;Trusted_Connection=True;";
            List<Product> products = new List<Product>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Products_ReadAll";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                Product product = new Product();
                                product.Id = reader.GetGuid(reader.GetOrdinal("ProductID"));
                                product.Name = reader.GetString(reader.GetOrdinal("Name"));
                                product.Price = reader.GetDecimal(reader.GetOrdinal("Price"));
                                product.CurrencyId= reader.GetGuid(reader.GetOrdinal("CurrencyID"));
                                product.Stock = reader.GetInt32(reader.GetOrdinal("Stock"));
                                product.Dimensions = reader.GetString(reader.GetOrdinal("Dimensions"));
                                product.Weight = reader.GetString(reader.GetOrdinal("Weight"));
                                product.Guarantee = reader.GetString(reader.GetOrdinal("Guarantee"));
                                product.Description = reader.GetString(reader.GetOrdinal("Description"));
                                product.BrandId = reader.GetGuid(reader.GetOrdinal("BrandID"));
                                product.CategoryId = reader.GetGuid(reader.GetOrdinal("CategoryID"));

                                products.Add(product);
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
            return products;
        }

        public void Insert(Product product)
        {
            string connectionString = @"Server=ADRI-PC\SQLEXPRESS;Database=InteriorDesignShopDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Products_Create";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@ProductID", product.Id));
                        command.Parameters.Add(new SqlParameter("@ProductName", product.Name));
                        command.Parameters.Add(new SqlParameter("@Price", product.Price));
                        command.Parameters.Add(new SqlParameter("@CurrencyID", product.CurrencyId));
                        command.Parameters.Add(new SqlParameter("@Stock", product.Stock));
                        command.Parameters.Add(new SqlParameter("@Dimensions", product.Dimensions));
                        command.Parameters.Add(new SqlParameter("@Weight", product.Weight));
                        command.Parameters.Add(new SqlParameter("@Guarantee", product.Guarantee));
                        command.Parameters.Add(new SqlParameter("@Description", product.Description));
                        command.Parameters.Add(new SqlParameter("@BrandID", product.BrandId));
                        command.Parameters.Add(new SqlParameter("@CategoryID", product.CategoryId));


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
        public void Update(Product product, string newProductName, decimal newProductPrice, Guid newCurrencyId, int newProductStock, string newProductDimensions,
                            string newProductWeight, string newProductGuarantee, string newProductDescription, Guid newBrandId, Guid newCategoryId)
        {
            string connectionString = @"Server=ADRI-PC\SQLEXPRESS;Database=InteriorDesignShopDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Products_Update";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@ProductID", product.Id));
                        command.Parameters.Add(new SqlParameter("@ProductName", newProductName));
                        command.Parameters.Add(new SqlParameter("@Price", newProductPrice));
                        command.Parameters.Add(new SqlParameter("@CurrencyID", newCurrencyId));
                        command.Parameters.Add(new SqlParameter("@Stock", newProductStock));
                        command.Parameters.Add(new SqlParameter("@Dimensions", newProductDimensions));
                        command.Parameters.Add(new SqlParameter("@Weight", newProductWeight));
                        command.Parameters.Add(new SqlParameter("@Guarantee", newProductGuarantee));
                        command.Parameters.Add(new SqlParameter("@Description", newProductDescription));
                        command.Parameters.Add(new SqlParameter("@BrandID", newBrandId));
                        command.Parameters.Add(new SqlParameter("@CategoryID", newCategoryId));

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
        public void Delete(Guid productId)
        {

            string connectionString = @"Server=ADRI-PC\SQLEXPRESS;Database=InteriorDesignShopDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Products_Delete";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@ProductID", productId));

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

        public Product GetById(Guid productId)
        {
            Product product = new Product();
            string connectionString = @"Server=ADRI-PC\SQLEXPRESS;Database=InteriorDesignShopDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Products_GetById";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@ProductID", productId));
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
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

            return product;
        }
        #endregion
    }
}
