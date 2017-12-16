using System;
using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.RepositoryAbstraction
{
    public interface ICountyRepository
    {
        List<County> ReadAll();
        void Insert(County county);
        void Update(County county);
        void Delete(Guid countyId);
        County GetById(Guid countyId);
    }
}
