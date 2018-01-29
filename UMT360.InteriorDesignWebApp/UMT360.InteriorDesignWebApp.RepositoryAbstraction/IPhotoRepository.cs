using System;
using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.RepositoryAbstraction
{
    public interface IPhotoRepository
    {
        List<Photo> ReadAll();
        void Insert(Photo photo);
        void Update(Photo photo);
        void Delete(Guid photoId);
        Photo GetById(Guid photoId);
       // List<Photo> ReadDesignPhotos(Guid designId);
    }
}
