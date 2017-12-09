using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using UMT360.InteriorDesignWebApp.Models;
using UMT360.InteriorDesignWebApp.Repository.Core;

namespace UMT360.InteriorDesignWebApp.Repository
{
    public class PhotoRepository:BaseRepository<Photo>
    {
        #region Methods
        public List<Photo> ReadAll()
        {
            return ReadAll("dbo.Photos_ReadAll");

        }

        public void Insert(Photo photo)
        {

            SqlParameter[] parameters = { new SqlParameter("@PhotoID", photo.Id), new SqlParameter("@PhotoName", photo.Image)};
            Operation("dbo.Photos_Create", parameters);

        }
        public void Update(Photo photo)
        {
            SqlParameter[] parameters = { new SqlParameter("@PhotoID", photo.Id), new SqlParameter("@PhotoName", photo.Image) };
            Operation("dbo.Photos_Update", parameters);

        }

        public void Delete(Guid photoId)
        {
            SqlParameter[] parameters = { new SqlParameter("@PhotoID", photoId) };
            Operation("dbo.Photos_Delete", parameters);

        }

        public Photo GetById(Guid photoId)
        {
            Photo photo = new Photo();
            SqlParameter[] parameters = { new SqlParameter("@PhotoID", photoId) };
            List<Photo> photos = new List<Photo>();
            photos = ReadAll("dbo.Photos_GetById", parameters);

            return photos.ElementAt(0);
        }

        public override Photo GetModelFromReader(SqlDataReader reader)
        {
            Photo photo = new Photo();
            photo.Id = reader.GetGuid(reader.GetOrdinal("PhotoID"));
            photo.Image = (byte[])reader["Image"];

            return photo;
        }
        #endregion        
        
    }
}
