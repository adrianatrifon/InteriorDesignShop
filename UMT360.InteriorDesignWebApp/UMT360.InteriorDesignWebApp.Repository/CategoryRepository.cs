using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using UMT360.InteriorDesignWebApp.Models;
using UMT360.InteriorDesignWebApp.Repository.Core;
using UMT360.InteriorDesignWebApp.RepositoryAbstraction;

namespace UMT360.InteriorDesignWebApp.Repository
{
    public class CategoryRepository:BaseRepository<Category>,ICategoryRepository
    {
        #region Methods
        public List<Category> ReadAll()
        {
            return ReadAll("dbo.Categories_ReadAll");
        }

        public void Insert(Category category)
        {
            SqlParameter[] parameters = GetParametersFromModel(category);
            ExecuteNonQuery("dbo.Categories_Create", parameters);
        }

        public void Update(Category category)
        {
            SqlParameter[] parameters = GetParametersFromModel(category);
            ExecuteNonQuery("dbo.Categories_Update", parameters);
        }

        public void Delete(Guid categoryId)
        {
            SqlParameter[] parameters = { new SqlParameter("@CategoryID", categoryId) };
            ExecuteNonQuery("dbo.Categories_Delete", parameters);
        }

        public Category GetById(Guid categoryId)
        {
            SqlParameter[] parameters = { new SqlParameter("@CategoryID", categoryId) };
            List<Category> categories = new List<Category>();
            categories = ReadAll("dbo.Categories_GetById", parameters);

            return categories.Single();
        }

        protected override Category GetModelFromReader(SqlDataReader reader)
        {
            Category category = new Category();
            category.Id = reader.GetGuid(reader.GetOrdinal("CategoryID"));
            category.ParentCategoryId = reader.GetGuid(reader.GetOrdinal("ParentCategoryID"));
            category.Name = reader.GetString(reader.GetOrdinal("Name"));
            return category;
        }
        internal SqlParameter[] GetParametersFromModel(Category category)
        {
            SqlParameter[] parameters = { new SqlParameter("@CategoryID", category.Id),
                                          new SqlParameter("@ParentCategory", category.ParentCategoryId),
                                          new SqlParameter("@CategoryName", category.Name)
                                        };
            return parameters;
        }
        #endregion        
    }
}
