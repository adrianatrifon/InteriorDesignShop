using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using UMT360.InteriorDesignWebApp.Models;
using UMT360.InteriorDesignWebApp.Repository.Core;
using UMT360.InteriorDesignWebApp.RepositoryAbstraction;

namespace UMT360.InteriorDesignWebApp.Repository
{
    public class DesignRepository:BaseRepository<Design>,IDesignRepository
    {
        #region Methods
        public List<Design> ReadAll()
        {
            return  ReadAll("dbo.Designs_ReadAll");
        }       
        
        public void Insert(Design design)
        {
            SqlParameter[] parameters = GetParametersFromModel(design);
            ExecuteNonQuery("dbo.Designs_Create",parameters);
        }
        public void Update(Design design)
        {
            SqlParameter[] parameters = GetParametersFromModel(design);
            ExecuteNonQuery("dbo.Designs_Update", parameters);
        }

        public void Delete(Guid designId)
        {
            SqlParameter[] parameters = { new SqlParameter("@DesignID", designId) };
            ExecuteNonQuery("dbo.Designs_Delete", parameters);
        }
        
        public Design GetById(Guid designId)
        {
            SqlParameter[] parameters ={ new SqlParameter("@DesignID", designId) };
            List<Design> designs = new List<Design>();           
            designs= ReadAll("dbo.Designs_GetById", parameters);
            
            return designs.Single();        
        }

        protected override Design GetModelFromReader(SqlDataReader reader)
        {
            Design design = new Design();
            design.Id = reader.GetGuid(reader.GetOrdinal("DesignID"));
            design.Name = reader.GetString(reader.GetOrdinal("Name"));
            design.Description = reader.GetString(reader.GetOrdinal("Description"));
            design.CategoryId = reader.GetGuid(reader.GetOrdinal("CategoryID"));
            design.StyleId = reader.GetGuid(reader.GetOrdinal("StyleID"));
            return design;
        }
        internal SqlParameter[] GetParametersFromModel(Design design)
        {
            SqlParameter[] parameters = { new SqlParameter("@DesignID", design.Id), new SqlParameter("@DesignName", design.Name),
                                           new SqlParameter("@DesignDescription", design.Description),
                                            new SqlParameter("@CategoryID", design.CategoryId),
                                             new SqlParameter("@StyleID", design.StyleId)};
            return parameters;
        }
        #endregion
    }
}
