using System;
using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.RepositoryAbstraction
{
    public interface ICurrencyRepository
    {
        List<Currency> ReadAll();
        void Insert(Currency currency);
        void Update(Currency currency);
        void Delete(Guid currencyId);
        Currency GetById(Guid currencyId);   
    }
}
