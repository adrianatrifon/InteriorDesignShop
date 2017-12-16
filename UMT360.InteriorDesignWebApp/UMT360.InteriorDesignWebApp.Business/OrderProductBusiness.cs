using System;
using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Business.Core;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.Business
{
    public class OrderProductBusiness
    {
        #region Methods
        public List<OrderProduct> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.OrderProductRepository.ReadAll();
        }

        public void Insert(OrderProduct orderProduct)
        {
            BusinessContext.Current.RepositoryContext.OrderProductRepository.Insert(orderProduct);
        }
        public void Update(OrderProduct orderProduct)
        {
            BusinessContext.Current.RepositoryContext.OrderProductRepository.Update(orderProduct);
        }

        public void Delete(Guid orderId, Guid productId)
        {
            BusinessContext.Current.RepositoryContext.OrderProductRepository.Delete(orderId,productId);
        }

        public OrderProduct GetById(Guid orderId, Guid productId)
        {
            return BusinessContext.Current.RepositoryContext.OrderProductRepository.GetById(orderId, productId);
        }
        #endregion        
    }
}
