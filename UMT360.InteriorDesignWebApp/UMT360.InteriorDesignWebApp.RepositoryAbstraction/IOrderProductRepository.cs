using System;
using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.RepositoryAbstraction
{
    public interface IOrderProductRepository
    {
        List<OrderProduct> ReadAll();
        void Insert(OrderProduct orderProduct);
        void Update(OrderProduct orderProduct);
        void Delete(Guid orderId, Guid productId);
        OrderProduct GetById(Guid orderId, Guid productId);
    }
}
