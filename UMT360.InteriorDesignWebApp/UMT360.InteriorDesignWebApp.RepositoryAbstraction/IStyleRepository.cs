using System;
using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.RepositoryAbstraction
{
    public interface IStyleRepository
    {
        List<Style> ReadAll();
        void Insert(Style style);
        void Update(Style style);
        void Delete(Guid styleId);
        Style GetById(Guid styleId);
    }
}