using System;
using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.RepositoryAbstraction
{
    public interface IDesignRepository
    {
        List<Design> ReadAll();
        void Insert(Design design);
        void Update(Design design);
        void Delete(Guid designId);
        Design GetById(Guid designId);
    }
}
