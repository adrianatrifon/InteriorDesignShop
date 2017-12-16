using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using UMT360.InteriorDesignWebApp.Models;
using UMT360.InteriorDesignWebApp.Repository.Core;
using UMT360.InteriorDesignWebApp.RepositoryAbstraction;

namespace UMT360.InteriorDesignWebApp.Repository
{
    public class OrderProductRepository:BaseRepository<OrderProduct>,IOrderProductRepository
    {
        #region Methods
        public List<OrderProduct> ReadAll()
        {
            return ReadAll("dbo.OrdersProducts_ReadAll");
        }

        public void Insert(OrderProduct orderProduct)
        {
            SqlParameter[] parameters = GetParametersFromModel(orderProduct);
            ExecuteNonQuery("dbo.OrdersProducts_Create", parameters);
        }
        public void Update(OrderProduct orderProduct)
        {
            SqlParameter[] parameters = GetParametersFromModel(orderProduct);
            ExecuteNonQuery("dbo.OrdersProducts_Update", parameters);
        }

        public void Delete(Guid orderId, Guid productId)
        {
            SqlParameter[] parameters = {new SqlParameter("@OrderID", orderId),new SqlParameter("@ProductID", productId)};
            ExecuteNonQuery("dbo.OrdersProducts_Delete", parameters);
        }

        public OrderProduct GetById(Guid orderId, Guid productId )
        {
            SqlParameter[] parameters = { new SqlParameter("@OrderID", orderId), new SqlParameter("@ProductID", productId) };
            List<OrderProduct> ordersProducts = new List<OrderProduct>();
            ordersProducts = ReadAll("dbo.OrdersProducts_GetById", parameters);
            return ordersProducts.Single();
        }

        protected override OrderProduct GetModelFromReader(SqlDataReader reader)
        {
            OrderProduct orderProduct = new OrderProduct();
            orderProduct.OrderId = reader.GetGuid(reader.GetOrdinal("OrderID"));
            orderProduct.ProductId = reader.GetGuid(reader.GetOrdinal("ProductID"));
            orderProduct.Quantity = reader.GetInt32(reader.GetOrdinal("Quantity"));
            return orderProduct;
        }
        internal SqlParameter[] GetParametersFromModel(OrderProduct orderProduct)
        {
            SqlParameter[] parameters = { new SqlParameter("@OrderID", orderProduct.OrderId),
                                          new SqlParameter("@ProductID", orderProduct.ProductId),
                                          new SqlParameter("@Quantity", orderProduct.Quantity)
                                        };
            return parameters;
        }
        #endregion        
    }
}
