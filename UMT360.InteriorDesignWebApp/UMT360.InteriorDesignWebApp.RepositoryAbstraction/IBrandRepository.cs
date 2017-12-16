using System;
using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.RepositoryAbstraction
{
    public interface IBrandRepository
    {
        List<Brand> ReadAll();
        void Insert(Brand brand);
        void Update(Brand brand);
        void Delete(Guid brandId);
        Brand GetById(Guid brandId);
    }
}