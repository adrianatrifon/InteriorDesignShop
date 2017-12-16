using System;
using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.RepositoryAbstraction
{
    public interface IOrderRepository
    {
        List<Order> ReadAll();
        void Insert(Order order);
        void Update(Order order);
        void Delete(Guid orderId);
        Order GetById(Guid orderId);
    }
}
