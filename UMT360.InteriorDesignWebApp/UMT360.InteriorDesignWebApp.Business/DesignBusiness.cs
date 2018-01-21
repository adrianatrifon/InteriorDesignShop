using System;
using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Business.Core;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.Business
{
    public class DesignBusiness
    {
        #region Methods
        public List<Design> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.DesignRepository.ReadAll();
        }

        public void Insert(Design design)
        {
            BusinessContext.Current.RepositoryContext.DesignRepository.Insert(design);
        }
        public void Update(Design design)
        {
            BusinessContext.Current.RepositoryContext.DesignRepository.Update(design);
        }

        public void Delete(Guid designId)
        {
            BusinessContext.Current.RepositoryContext.DesignRepository.Delete(designId);
        }

        public Design GetById(Guid designId)
        {
            return BusinessContext.Current.RepositoryContext.DesignRepository.GetById(designId);
        }
        #endregion        
    }
}
