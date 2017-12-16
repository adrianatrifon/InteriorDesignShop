using System;
using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Business.Core;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.Business
{
    public class ProductBusiness
    {
        #region Methods
        public List<Product> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.ProductRepository.ReadAll();
        }

        public void Insert(Product product)
        {
            BusinessContext.Current.RepositoryContext.ProductRepository.Insert(product);
        }
        public void Update(Product product)
        {
           BusinessContext.Current.RepositoryContext.ProductRepository.Update(product);
        }

        public void Delete(Guid productId)
        {
            BusinessContext.Current.RepositoryContext.ProductRepository.Delete(productId);
        }

        public Product GetById(Guid productId)
        {
            return BusinessContext.Current.RepositoryContext.ProductRepository.GetById(productId);
        }
        #endregion        
    }
}
