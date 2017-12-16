using System;
using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Business.Core;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.Business
{
    public class RoleBusiness
    {
        #region Methods
        public List<Role> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.RoleRepository.ReadAll();
        }

        public void Insert(Role role)
        {
            BusinessContext.Current.RepositoryContext.RoleRepository.Insert(role);
        }
        public void Update(Role role)
        {
            BusinessContext.Current.RepositoryContext.RoleRepository.Update(role);
        }

        public void Delete(Guid roleId)
        {
            BusinessContext.Current.RepositoryContext.RoleRepository.Delete(roleId);
        }

        public Role GetById(Guid roleId)
        {
            return BusinessContext.Current.RepositoryContext.RoleRepository.GetById(roleId);
        }
        #endregion        
    }
}
