using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using UMT360.InteriorDesignWebApp.Models;
using UMT360.InteriorDesignWebApp.Repository.Core;
using UMT360.InteriorDesignWebApp.RepositoryAbstraction;

namespace UMT360.InteriorDesignWebApp.Repository
{
    public class PhotoRepository:BaseRepository<Photo>,IPhotoRepository
    {
        #region Methods
        public List<Photo> ReadAll()
        {
            return ReadAll("dbo.Photos_ReadAll");
        }

        public void Insert(Photo photo)
        {
            SqlParameter[] parameters = GetParametersFromModel(photo);
            ExecuteNonQuery("dbo.Photos_Create", parameters);
        }
        public void Update(Photo photo)
        {
            SqlParameter[] parameters = GetParametersFromModel(photo);
            ExecuteNonQuery("dbo.Photos_Update", parameters);
        }

        public void Delete(Guid photoId)
        {
            SqlParameter[] parameters = { new SqlParameter("@PhotoID", photoId) };
            ExecuteNonQuery("dbo.Photos_Delete", parameters);
        }

        public Photo GetById(Guid photoId)
        {
            SqlParameter[] parameters = { new SqlParameter("@PhotoID", photoId) };
            List<Photo> photos = new List<Photo>();
            photos = ReadAll("dbo.Photos_GetById", parameters);
            return photos.Single();
        }

        protected override Photo GetModelFromReader(SqlDataReader reader)
        {
            Photo photo = new Photo();
            photo.Id = reader.GetGuid(reader.GetOrdinal("PhotoID"));
            photo.Image = reader.GetString(reader.GetOrdinal("Image")); 
            return photo;
        }
        internal SqlParameter[] GetParametersFromModel(Photo photo)
        {
            SqlParameter[] parameters = { new SqlParameter("@PhotoID", photo.Id), new SqlParameter("@PhotoName", photo.Image) };
            return parameters;
        }
        #endregion 
    }
}
