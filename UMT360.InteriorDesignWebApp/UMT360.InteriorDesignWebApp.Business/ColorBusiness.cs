using System;
using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Business.Core;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.Business
{
    public class ColorBusiness
    {
        #region Methods
        public List<Color> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.ColorRepository.ReadAll();
        }

        public void Insert(Color color)
        {
            BusinessContext.Current.RepositoryContext.ColorRepository.Insert(color);
        }
        public void Update(Color color)
        {
            BusinessContext.Current.RepositoryContext.ColorRepository.Update(color);
        }

        public void Delete(Guid colorId)
        {
            BusinessContext.Current.RepositoryContext.ColorRepository.Delete(colorId);
        }

        public Color GetById(Guid colorId)
        {
            return BusinessContext.Current.RepositoryContext.ColorRepository.GetById(colorId);
        }
        #endregion
    }
}
