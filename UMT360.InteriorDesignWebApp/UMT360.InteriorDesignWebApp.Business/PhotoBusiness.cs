using System;
using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Business.Core;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.Business
{
    public class PhotoBusiness
    {
        #region Methods
        public List<Photo> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.PhotoRepository.ReadAll();
        }

        public void Insert(Photo photo)
        {
            BusinessContext.Current.RepositoryContext.PhotoRepository.Insert(photo);
        }
        public void Update(Photo photo)
        {
            BusinessContext.Current.RepositoryContext.PhotoRepository.Update(photo);
        }

        public void Delete(Guid photoId)
        {
            BusinessContext.Current.RepositoryContext.PhotoRepository.Delete(photoId);
        }

        public Photo GetById(Guid photoId)
        {
            return BusinessContext.Current.RepositoryContext.PhotoRepository.GetById(photoId);
        }
        /*
        public List<Photo> ReadDesignPhotos(Guid designId)
        {
            return BusinessContext.Current.RepositoryContext.PhotoRepository.ReadDesignPhotos(designId);
        }
        */
        #endregion 
    }
}
