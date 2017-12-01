using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.Repository
{
    public class PromotionRepository
    {
        #region Methods
        public List<Promotion> ReadAll()
        {
            string connectionString = @"Server=ADRI-PC\SQLEXPRESS;Database=InteriorDesignShopDB;Trusted_Connection=True;";
            List<Promotion> promotions = new List<Promotion>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Promotions_ReadAll";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                Promotion promotion = new Promotion();
                                promotion.Id = reader.GetGuid(reader.GetOrdinal("PromotionID"));
                                promotion.Name = reader.GetString(reader.GetOrdinal("Name"));
                                promotion.StartDate = reader.GetDateTime(reader.GetOrdinal("StartDate"));
                                promotion.EndDate = reader.GetDateTime(reader.GetOrdinal("EndDate"));
                                promotion.Description = reader.GetString(reader.GetOrdinal("Description"));

                                promotions.Add(promotion);
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
            return promotions;
        }

        public void Insert(Promotion promotion)
        {
            string connectionString = @"Server=ADRI-PC\SQLEXPRESS;Database=InteriorDesignShopDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Promotions_Create";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@PromotionID", promotion.Id));
                        command.Parameters.Add(new SqlParameter("@PromotionName", promotion.Name));
                        command.Parameters.Add(new SqlParameter("@StartDate", promotion.StartDate));
                        command.Parameters.Add(new SqlParameter("@EndDate", promotion.EndDate));
                        command.Parameters.Add(new SqlParameter("@Description", promotion.Description));

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
        public void Update(Promotion promotion, string newPromotionName, DateTime newStartDate, DateTime newEndDate, string newDescription)
        {
            string connectionString = @"Server=ADRI-PC\SQLEXPRESS;Database=InteriorDesignShopDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Promotions_Update";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@PromotionID", promotion.Id));
                        command.Parameters.Add(new SqlParameter("@PromotionName", newPromotionName));
                        command.Parameters.Add(new SqlParameter("@StartDate", newStartDate));
                        command.Parameters.Add(new SqlParameter("@EndDate", newEndDate));
                        command.Parameters.Add(new SqlParameter("@Description", newDescription));

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
        public void Delete(Guid promotionId)
        {

            string connectionString = @"Server=ADRI-PC\SQLEXPRESS;Database=InteriorDesignShopDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Promotions_Delete";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@PromotionID", promotionId));

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

        public Promotion GetById(Guid promotionId)
        {
            Promotion promotion = new Promotion();
            string connectionString = @"Server=ADRI-PC\SQLEXPRESS;Database=InteriorDesignShopDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Promotions_GetById";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@PromotionID", promotionId));
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                promotion.Id = reader.GetGuid(reader.GetOrdinal("PromotionID"));
                                promotion.Name = reader.GetString(reader.GetOrdinal("Name"));
                                promotion.StartDate = reader.GetDateTime(reader.GetOrdinal("StartDate"));
                                promotion.EndDate = reader.GetDateTime(reader.GetOrdinal("EndDate"));
                                promotion.Description = reader.GetString(reader.GetOrdinal("Description"));
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

            return promotion;
        }
        #endregion
    }
}
