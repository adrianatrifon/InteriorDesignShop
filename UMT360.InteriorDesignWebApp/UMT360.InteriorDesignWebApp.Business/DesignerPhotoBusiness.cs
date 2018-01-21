using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Business.Core;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.Business
{
    public class DesignerPhotoBusiness
    {
        #region Methods
        public List<DesignerPhoto> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.DesignerPhotoRepository.ReadAll();
        }

        public void Insert(DesignerPhoto designerPhoto)
        {
            BusinessContext.Current.RepositoryContext.DesignerPhotoRepository.Insert(designerPhoto);
        }

        public void Delete(DesignerPhoto designerPhoto)
        {
            BusinessContext.Current.RepositoryContext.DesignerPhotoRepository.Delete(designerPhoto);
        }
        #endregion        
    }
}
