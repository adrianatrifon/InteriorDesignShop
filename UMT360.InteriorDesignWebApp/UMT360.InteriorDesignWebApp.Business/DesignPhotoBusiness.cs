using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Business.Core;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.Business
{
    public class DesignPhotoBusiness
    {
        #region Methods
        public List<DesignPhoto> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.DesignPhotoRepository.ReadAll();
        }

        public void Insert(DesignPhoto designPhoto)
        {
            BusinessContext.Current.RepositoryContext.DesignPhotoRepository.Insert(designPhoto);
        }
        public void Delete(DesignPhoto designPhoto)
        {
            BusinessContext.Current.RepositoryContext.DesignPhotoRepository.Delete(designPhoto);
        }
        #endregion        
    }
}
