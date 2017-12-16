using System;
using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Business.Core;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.Business
{
    #region Methods
    public class CategoryBusiness
    {
        public List<Category> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.CategoryRepository.ReadAll();
        }

        public void Insert(Category category)
        {
            BusinessContext.Current.RepositoryContext.CategoryRepository.Insert(category);
        }

        public void Update(Category category)
        {
            BusinessContext.Current.RepositoryContext.CategoryRepository.Update(category);
        }

        public void Delete(Guid categoryId)
        {
            BusinessContext.Current.RepositoryContext.CategoryRepository.Delete(categoryId);
        }

        public Category GetById(Guid categoryId)
        {
            return BusinessContext.Current.RepositoryContext.CategoryRepository.GetById(categoryId);

        }
        #endregion
    }
}
