using System;
using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Business.Core;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.Business
{
    public class StyleBusiness
    {
        #region Methods
        public List<Style> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.StyleRepository.ReadAll();
        }

        public void Insert(Style style)
        {
            BusinessContext.Current.RepositoryContext.StyleRepository.Insert(style);
        }

        public void Update(Style style)
        {
            BusinessContext.Current.RepositoryContext.StyleRepository.Update(style);
        }

        public void Delete(Guid styleId)
        {
            BusinessContext.Current.RepositoryContext.StyleRepository.Delete(styleId);
        }

        public Style GetById(Guid styleId)
        {
            return BusinessContext.Current.RepositoryContext.StyleRepository.GetById(styleId);
        }
        #endregion        
    }
}
