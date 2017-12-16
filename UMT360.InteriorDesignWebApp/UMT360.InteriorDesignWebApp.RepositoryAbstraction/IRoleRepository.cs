using System;
using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.RepositoryAbstraction
{
    public interface IRoleRepository
    {
        List<Role> ReadAll();
        void Insert(Role role);
        void Update(Role role);
        void Delete(Guid roleId);
        Role GetById(Guid roleId);   
    }
}
