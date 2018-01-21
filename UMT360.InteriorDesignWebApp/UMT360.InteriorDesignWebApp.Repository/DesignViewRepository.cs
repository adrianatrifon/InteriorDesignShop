using System.Collections.Generic;
using System.Data.SqlClient;
using UMT360.InteriorDesignWebApp.Models;
using UMT360.InteriorDesignWebApp.Repository.Core;
using UMT360.InteriorDesignWebApp.RepositoryAbstraction;

namespace UMT360.InteriorDesignWebApp.Repository
{
    public class DesignViewRepository:BaseRepository<DesignView>, IDesignViewRepository
    {
        #region Mathods
        public List<DesignView> ReadAll()
        {
            return ReadAll("dbo.DesignView_ReadAll");
        }
        protected override DesignView GetModelFromReader(SqlDataReader reader)
        {
            DesignView designView = new DesignView();
            designView.Id = reader.GetGuid(reader.GetOrdinal("DesignID"));
            designView.Name = reader.GetString(reader.GetOrdinal("Name"));
            designView.Description = reader.GetString(reader.GetOrdinal("Description"));
            designView.Category = reader.GetString(reader.GetOrdinal("Category"));
            designView.Style = reader.GetString(reader.GetOrdinal("Style"));
            designView.Photos= (byte[])reader["Photo"];
            return designView;
        }
        #endregion
    }
}
