using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.RepositoryAbstraction
{
    public interface IProductPhotoRepository
    {
        List<ProductPhoto> ReadAll();
        void Insert(ProductPhoto productPhoto);
        void Delete(ProductPhoto productPhoto);
    }
}
