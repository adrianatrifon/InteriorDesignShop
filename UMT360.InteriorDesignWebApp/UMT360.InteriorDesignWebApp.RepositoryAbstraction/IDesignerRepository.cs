using System;
using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.RepositoryAbstraction
{
    public interface IDesignerRepository
    {
        List<Designer> ReadAll();
        void Insert(Designer designer);
        void Update(Designer designer);
        void Delete(Guid designerId);
        Designer GetById(Guid designerId);
    }
}