using System;
using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Business.Core;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.Business
{
    public class OrderBusiness
    {
        #region Methods
        public List<Order> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.OrderRepository.ReadAll();
        }

        public void Insert(Order order)
        {
            BusinessContext.Current.RepositoryContext.OrderRepository.Insert(order);
        }
        public void Update(Order order)
        {
            BusinessContext.Current.RepositoryContext.OrderRepository.Update(order);
        }

        public void Delete(Guid orderId)
        {
            BusinessContext.Current.RepositoryContext.OrderRepository.Delete(orderId);
        }

        public Order GetById(Guid orderId)
        {
            return BusinessContext.Current.RepositoryContext.OrderRepository.GetById(orderId);
        }
        #endregion        
    }
}
