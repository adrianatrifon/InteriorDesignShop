using System;
using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.RepositoryAbstraction
{
   public interface ICountryRepository
    {
        List<Country> ReadAll();
        void Insert(Country country);
        void Update(Country country);
        void Delete(Guid countryId);
        Country GetById(Guid countryId);
    }
}
