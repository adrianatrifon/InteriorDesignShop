using System;
using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.RepositoryAbstraction
{
    public interface ICityRepository
    {
        List<City> ReadAll();
        void Insert(City city);
        void Update(City city);
        void Delete(Guid cityId);
        City GetById(Guid cityId);
    }
}
