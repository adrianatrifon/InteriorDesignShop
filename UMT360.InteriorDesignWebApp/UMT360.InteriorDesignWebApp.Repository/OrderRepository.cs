using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using UMT360.InteriorDesignWebApp.Models;
using UMT360.InteriorDesignWebApp.Repository.Core;

namespace UMT360.InteriorDesignWebApp.Repository
{
    public class OrderRepository:BaseRepository<Order>
    {
        #region Methods
        public List<Order> ReadAll()
        {
            return ReadAll("dbo.Orders_ReadAll");
        }

        public void Insert(Order order)
        {
            SqlParameter[] parameters = GetParametersFromModel(order);
            ExecuteNonQuery("dbo.Orders_Create", parameters);
        }
        public void Update(Order order)
        {
            SqlParameter[] parameters = GetParametersFromModel(order);
            ExecuteNonQuery("dbo.Orders_Update", parameters);
        }

        public void Delete(Guid orderId)
        {
            SqlParameter[] parameters = { new SqlParameter("@OrderID", orderId) };
            ExecuteNonQuery("dbo.Orders_Delete", parameters);
        }

        public Order GetById(Guid orderId)
        {
            SqlParameter[] parameters = { new SqlParameter("@OrderID", orderId) };
            List<Order> orders = new List<Order>();
            orders = ReadAll("dbo.Orders_GetById", parameters);
            return orders.Single();
        }

        public override Order GetModelFromReader(SqlDataReader reader)
        {
            Order order = new Order();
            order.Id = reader.GetGuid(reader.GetOrdinal("OrderID"));
            order.Date = reader.GetDateTime(reader.GetOrdinal("Date"));
            order.DeliveryAddress = reader.GetString(reader.GetOrdinal("DeliveryAddress"));
            order.PersonId = reader.GetGuid(reader.GetOrdinal("PersonID"));
            order.PaymentOptionId = reader.GetGuid(reader.GetOrdinal("PaymentOptionID"));
            return order;
        }
        public SqlParameter[] GetParametersFromModel(Order order)
        {
            SqlParameter[] parameters = { new SqlParameter("@OrderID", order.Id),
                                          new SqlParameter("@Date", order.Date),
                                          new SqlParameter("@DeliveryAddress", order.DeliveryAddress),
                                          new SqlParameter("@PersonID", order.PersonId),
                                          new SqlParameter("@PaymentOptionID", order.PaymentOptionId)
                                        };
            return parameters;
        }
        #endregion        
    }
}
