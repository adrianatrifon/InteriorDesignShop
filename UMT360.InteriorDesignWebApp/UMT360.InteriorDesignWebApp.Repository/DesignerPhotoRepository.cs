using System.Collections.Generic;
using System.Data.SqlClient;
using UMT360.InteriorDesignWebApp.Models;
using UMT360.InteriorDesignWebApp.Repository.Core;
using UMT360.InteriorDesignWebApp.RepositoryAbstraction;

namespace UMT360.InteriorDesignWebApp.Repository
{
    public class DesignerPhotoRepository:BaseRepository<DesignerPhoto>,IDesignerPhotoRepository
    {
        #region Methods
        public List<DesignerPhoto> ReadAll()
        {
            return ReadAll("dbo.DesignersPhotos_ReadAll");
        }

        public void Insert(DesignerPhoto designerPhoto)
        {
            SqlParameter[] parameters = GetParametersFromModel(designerPhoto);
            ExecuteNonQuery("dbo.DesignersPhotos_Create", parameters);
        }        

        public void Delete(DesignerPhoto designerPhoto)
        {
            SqlParameter[] parameters = GetParametersFromModel(designerPhoto);
            ExecuteNonQuery("dbo.DesignersPhotos_Delete", parameters);
        }

        protected override DesignerPhoto GetModelFromReader(SqlDataReader reader)
        {
            DesignerPhoto designerPhoto = new DesignerPhoto();
            designerPhoto.DesignerId = reader.GetGuid(reader.GetOrdinal("DesignerID"));
            designerPhoto.PhotoId = reader.GetGuid(reader.GetOrdinal("PhotoID"));
            return designerPhoto;
        }
        internal SqlParameter[] GetParametersFromModel(DesignerPhoto designerPhoto)
        {
            SqlParameter[] parameters = { new SqlParameter("@DesignerID", designerPhoto.DesignerId),
                                          new SqlParameter("@PhotoID", designerPhoto.PhotoId)};
            return parameters;
        }
        #endregion        
    }
}
