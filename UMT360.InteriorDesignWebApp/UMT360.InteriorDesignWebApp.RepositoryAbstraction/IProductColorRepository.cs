using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.RepositoryAbstraction
{
    public interface IProductColorRepository
    {
        List<ProductColor> ReadAll();
        void Insert(ProductColor productColor);
        void Delete(ProductColor productColor);
    }
}
