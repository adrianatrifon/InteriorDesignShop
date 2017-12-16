using System;
using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.RepositoryAbstraction
{
    public interface ICategoryRepository
    {
        List<Category> ReadAll();
        void Insert(Category category);
        void Update(Category category);
        void Delete(Guid categoryId);
        Category GetById(Guid categoryId);        
    }
}
