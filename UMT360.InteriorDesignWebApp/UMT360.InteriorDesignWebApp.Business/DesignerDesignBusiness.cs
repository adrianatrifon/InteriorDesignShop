using System;
using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Business.Core;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.Business
{
    public class DesignerDesignBusiness
    {
        #region Methods
        public List<DesignerDesign> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.DesignerDesignRepository.ReadAll();
        }

        public void Insert(DesignerDesign designerDesign)
        {
            BusinessContext.Current.RepositoryContext.DesignerDesignRepository.Insert(designerDesign);
        }
        public void Delete(DesignerDesign designerDesign)
        {
            BusinessContext.Current.RepositoryContext.DesignerDesignRepository.Delete(designerDesign);
        }        
        #endregion        
    }
}
