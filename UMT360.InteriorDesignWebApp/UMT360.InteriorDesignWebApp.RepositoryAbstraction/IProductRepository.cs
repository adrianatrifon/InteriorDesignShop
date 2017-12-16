using System;
using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.RepositoryAbstraction
{
    public interface IProductRepository
    {
        List<Product> ReadAll();
        void Insert(Product product);
        void Update(Product product);
        void Delete(Guid productId);
        Product GetById(Guid productId);
    }
}
