using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.Repository
{
    public class OrderRepository
    {
        #region Methods
        public List<Order> ReadAll()
        {
            string connectionString = @"Server=ADRI-PC\SQLEXPRESS;Database=InteriorDesignShopDB;Trusted_Connection=True;";
            List<Order> orders = new List<Order>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Orders_ReadAll";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                Order order = new Order();
                                order.Id = reader.GetGuid(reader.GetOrdinal("OrderID"));
                                order.Date = reader.GetDateTime(reader.GetOrdinal("Date"));
                                order.DeliveryAddress = reader.GetString(reader.GetOrdinal("DeliveryAddress"));
                                order.PersonId = reader.GetGuid(reader.GetOrdinal("PersonID"));
                                order.PaymentOptionId = reader.GetGuid(reader.GetOrdinal("PaymentOptionID"));

                                orders.Add(order);
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
            return orders;
        }

        public void Insert(Order order)
        {
            string connectionString = @"Server=ADRI-PC\SQLEXPRESS;Database=InteriorDesignShopDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Orders_Create";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@OrderID", order.Id));
                        command.Parameters.Add(new SqlParameter("@Date", order.Date));
                        command.Parameters.Add(new SqlParameter("@DeliveryAddress", order.DeliveryAddress));
                        command.Parameters.Add(new SqlParameter("@PersonID", order.PersonId));
                        command.Parameters.Add(new SqlParameter("@PaymentOptionID", order.PaymentOptionId));

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
        public void Update(Order order, DateTime newOrderDate, string newDeliveryAddress, Guid newPersonId, Guid newPaymentOptionId)
        {
            string connectionString = @"Server=ADRI-PC\SQLEXPRESS;Database=InteriorDesignShopDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Orders_Update";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@OrderID", order.Id));
                        command.Parameters.Add(new SqlParameter("@Date", newOrderDate));
                        command.Parameters.Add(new SqlParameter("@DeliveryAddress", newDeliveryAddress));
                        command.Parameters.Add(new SqlParameter("@PersonID", newPersonId));
                        command.Parameters.Add(new SqlParameter("@PaymentOptionID", newPaymentOptionId));

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
        public void Delete(Guid orderId)
        {

            string connectionString = @"Server=ADRI-PC\SQLEXPRESS;Database=InteriorDesignShopDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Orders_Delete";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@OrderID", orderId));

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

        public Order GetById(Guid orderId)
        {
            Order order = new Order();
            string connectionString = @"Server=ADRI-PC\SQLEXPRESS;Database=InteriorDesignShopDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Orders_GetById";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@OrderID", orderId));
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                order.Id = reader.GetGuid(reader.GetOrdinal("OrderID"));
                                order.Date = reader.GetDateTime(reader.GetOrdinal("Date"));
                                order.DeliveryAddress = reader.GetString(reader.GetOrdinal("DeliveryAddress"));
                                order.PersonId = reader.GetGuid(reader.GetOrdinal("PersonID"));
                                order.PaymentOptionId = reader.GetGuid(reader.GetOrdinal("PaymentOptionID"));
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

            return order;
        }
        #endregion
    }
}
