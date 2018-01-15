using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using UMT360.InteriorDesignWebApp.Models;
using UMT360.InteriorDesignWebApp.Repository.Core;
using UMT360.InteriorDesignWebApp.RepositoryAbstraction;

namespace UMT360.InteriorDesignWebApp.Repository
{
    public class DesignerRepository:BaseRepository<Designer>,IDesignerRepository
    {
        #region Methods
        public List<Designer> ReadAll()
        {
            return ReadAll("dbo.Designers_ReadAll");
        }

        public void Insert(Designer designer)
        {           
            SqlParameter[] parameters = GetParametersFromModel(designer);
            ExecuteNonQuery("dbo.Designers_Create", parameters);
        }

        public void Update(Designer designer)
        {
            SqlParameter[] parameters = GetParametersFromModel(designer);
            ExecuteNonQuery("dbo.Designers_Update", parameters);
        }

        public void Delete(Guid designerId)
        {
            SqlParameter[] parameters = { new SqlParameter("@DesignerID", designerId) };
            ExecuteNonQuery("dbo.Designers_Delete", parameters);
        }

        public Designer GetById(Guid designerId)
        {
            SqlParameter[] parameters = { new SqlParameter("@DesignerID", designerId) };
            List<Designer> designers = new List<Designer>();
            designers = ReadAll("dbo.Designers_GetById", parameters);

            return designers.Single();
        }

        protected override Designer GetModelFromReader(SqlDataReader reader)
        {
            Designer designer = new Designer();
            designer.Id = reader.GetGuid(reader.GetOrdinal("DesignerID"));
            designer.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
            designer.LastName = reader.GetString(reader.GetOrdinal("LastName"));
            designer.Description = reader.GetString(reader.GetOrdinal("Description"));
            return designer;
        }

        internal SqlParameter[] GetParametersFromModel(Designer designer)
        {
            SqlParameter[] parameters ={ new SqlParameter("@DesignerID", designer.Id), new SqlParameter("@FirstName", designer.FirstName),
                                            new SqlParameter("@LastName", designer.LastName), new SqlParameter("@Description", designer.Description)};
            return parameters;
        }
        #endregion
    }
}
