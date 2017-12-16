using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using UMT360.InteriorDesignWebApp.Models;
using UMT360.InteriorDesignWebApp.Repository.Core;
using UMT360.InteriorDesignWebApp.RepositoryAbstraction;

namespace UMT360.InteriorDesignWebApp.Repository
{
    public class RoleRepository:BaseRepository<Role>, IRoleRepository
    {
        #region Methods
        public List<Role> ReadAll()
        {
            return ReadAll("dbo.Roles_ReadAll");
        }

        public void Insert(Role role)
        {
            SqlParameter[] parameters = GetParametersFromModel(role);
            ExecuteNonQuery("dbo.Roles_Create", parameters);
        }
        public void Update(Role role)
        {
            SqlParameter[] parameters = GetParametersFromModel(role);
        }

        public void Delete(Guid roleId)
        {
            SqlParameter[] parameters = { new SqlParameter("@RoleID", roleId) };
            ExecuteNonQuery("dbo.Roles_Delete", parameters);
        }

        public Role GetById(Guid roleId)
        {
            SqlParameter[] parameters = { new SqlParameter("@RoleID", roleId) };
            List<Role> roles = new List<Role>();
            roles = ReadAll("dbo.Roles_GetById", parameters);
            return roles.Single();
        }

        protected override Role GetModelFromReader(SqlDataReader reader)
        {
            Role role = new Role();
            role.Id = reader.GetGuid(reader.GetOrdinal("RoleID"));
            role.Description = reader.GetString(reader.GetOrdinal("Description"));
            return role;
        }
        internal SqlParameter[] GetParametersFromModel(Role role)
        {
            SqlParameter[] parameters = { new SqlParameter("@RoleID", role.Id), new SqlParameter("@RoleName", role.Description) };
            return parameters;
        }
        #endregion        
    }
}
