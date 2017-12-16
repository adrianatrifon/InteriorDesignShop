using System;
using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Business.Core;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.Business
{
    public class MaterialBusiness
    {
        #region Methods
        public List<Material> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.MaterialRepository.ReadAll();
        }

        public void Insert(Material material)
        {
            BusinessContext.Current.RepositoryContext.MaterialRepository.Insert(material);
        }
        public void Update(Material material)
        {
            BusinessContext.Current.RepositoryContext.MaterialRepository.Update(material);
        }

        public void Delete(Guid materialId)
        {
            BusinessContext.Current.RepositoryContext.MaterialRepository.Delete(materialId);
        }

        public Material GetById(Guid materialId)
        {
            return BusinessContext.Current.RepositoryContext.MaterialRepository.GetById(materialId);
        }
        #endregion
    }
}
