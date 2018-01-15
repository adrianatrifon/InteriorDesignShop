using System.Collections.Generic;
using System.Data.SqlClient;
using UMT360.InteriorDesignWebApp.Models;
using UMT360.InteriorDesignWebApp.Repository.Core;
using UMT360.InteriorDesignWebApp.RepositoryAbstraction;

namespace UMT360.InteriorDesignWebApp.Repository
{
    public class DesignerDesignRepository:BaseRepository<DesignerDesign>,IDesignerDesignRepository
    {
        #region Methods
        public List<DesignerDesign> ReadAll()
        {
            return ReadAll("dbo.DesignersDesigns_ReadAll");
        }

        public void Insert(DesignerDesign designerDesign)
        {
            SqlParameter[] parameters = GetParametersFromModel(designerDesign);
            ExecuteNonQuery("dbo.DesignersDesigns_Create", parameters);
        }
        public void Delete(DesignerDesign designerDesign)
        {
            SqlParameter[] parameters = GetParametersFromModel(designerDesign);
            ExecuteNonQuery("dbo.DesignersDesigns_Delete", parameters);
        }        

        protected override DesignerDesign GetModelFromReader(SqlDataReader reader)
        {
            DesignerDesign designerDesign = new DesignerDesign();
            designerDesign.DesignerId = reader.GetGuid(reader.GetOrdinal("DesignerID"));
            designerDesign.DesignId = reader.GetGuid(reader.GetOrdinal("DesignID"));
            return designerDesign;
        }
        internal SqlParameter[] GetParametersFromModel(DesignerDesign designerDesign)
        {
            SqlParameter[] parameters = { new SqlParameter("@DesignerID", designerDesign.DesignerId),
                                          new SqlParameter("@DesignID", designerDesign.DesignId)};
            return parameters;
        }
        #endregion        
    }
}
