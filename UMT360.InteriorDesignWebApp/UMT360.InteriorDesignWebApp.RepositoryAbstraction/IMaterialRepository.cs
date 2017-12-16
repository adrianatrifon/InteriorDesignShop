using System;
using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.RepositoryAbstraction
{
    public interface IMaterialRepository
    {
        List<Material> ReadAll();
        void Insert(Material material);
        void Update(Material material);
        void Delete(Guid materialId);
        Material GetById(Guid materialId);
    }
}
