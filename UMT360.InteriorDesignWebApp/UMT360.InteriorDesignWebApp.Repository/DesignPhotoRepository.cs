using System.Collections.Generic;
using System.Data.SqlClient;
using UMT360.InteriorDesignWebApp.Models;
using UMT360.InteriorDesignWebApp.Repository.Core;
using UMT360.InteriorDesignWebApp.RepositoryAbstraction;

namespace UMT360.InteriorDesignWebApp.Repository
{
    public class DesignPhotoRepository : BaseRepository<DesignPhoto>,IDesignPhotoRepository
    {
        #region Methods
        public List<DesignPhoto> ReadAll()
        {
            return ReadAll("dbo.DesignsPhotos_ReadAll");
        }

        public void Insert(DesignPhoto designPhoto)
        {
            SqlParameter[] parameters = GetParametersFromModel(designPhoto);
            ExecuteNonQuery("dbo.DesignsPhotos_Create", parameters);
        }
        public void Delete(DesignPhoto designPhoto)
        {
            SqlParameter[] parameters = GetParametersFromModel(designPhoto);
            ExecuteNonQuery("dbo.DesignsPhotos_Delete", parameters);
        }
        protected override DesignPhoto GetModelFromReader(SqlDataReader reader)
        {
            DesignPhoto designPhoto = new DesignPhoto();
            designPhoto.DesignId = reader.GetGuid(reader.GetOrdinal("DesignID"));
            designPhoto.PhotoId = reader.GetGuid(reader.GetOrdinal("PhotoID"));
            return designPhoto;
        }
        internal SqlParameter[] GetParametersFromModel(DesignPhoto designPhoto)
        {
            SqlParameter[] parameters = { new SqlParameter("@DesignID", designPhoto.DesignId),
                                          new SqlParameter("@PhotoID", designPhoto.PhotoId)};
            return parameters;
        }
        #endregion        
    }
}
