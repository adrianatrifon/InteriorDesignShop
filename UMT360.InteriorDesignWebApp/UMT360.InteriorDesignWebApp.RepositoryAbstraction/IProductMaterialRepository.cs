using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.RepositoryAbstraction
{
    public interface IProductMaterialRepository
    {
        List<ProductMaterial> ReadAll();
        void Insert(ProductMaterial productMaterial);
        void Delete(ProductMaterial productMaterial);
    }
}
