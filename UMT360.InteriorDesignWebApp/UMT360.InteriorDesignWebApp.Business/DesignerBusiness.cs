using System;
using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Business.Core;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.Business
{
    public class DesignerBusiness
    {
        #region Methods
        public List<Designer> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.DesignerRepository.ReadAll();
        }

        public void Insert(Designer designer)
        {
            BusinessContext.Current.RepositoryContext.DesignerRepository.Insert(designer);
        }

        public void Update(Designer designer)
        {
            BusinessContext.Current.RepositoryContext.DesignerRepository.Update(designer);
        }

        public void Delete(Guid designerId)
        {
            BusinessContext.Current.RepositoryContext.DesignerRepository.Delete(designerId);
        }

        public Designer GetById(Guid designerId)
        {
            return BusinessContext.Current.RepositoryContext.DesignerRepository.GetById(designerId);
        }
        #endregion
    }
}
