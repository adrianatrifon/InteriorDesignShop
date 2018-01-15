using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using UMT360.InteriorDesignWebApp.Models;
using UMT360.InteriorDesignWebApp.Repository.Core;
using UMT360.InteriorDesignWebApp.RepositoryAbstraction;

namespace UMT360.InteriorDesignWebApp.Repository
{
    public class StyleRepository:BaseRepository<Style>,IStyleRepository
    {
        #region Methods
        public List<Style> ReadAll()
        {
            return ReadAll("dbo.Styles_ReadAll");
        }

        public void Insert(Style style)
        {
            SqlParameter[] parameters = GetParametersFromModel(style);
            ExecuteNonQuery("dbo.Styles_Create", parameters);
        }

        public void Update(Style style)
        {
            SqlParameter[] parameters = GetParametersFromModel(style);
            ExecuteNonQuery("dbo.Styles_Update", parameters);
        }

        public void Delete(Guid styleId)
        {
            SqlParameter[] parameters = { new SqlParameter("@StyleID", styleId) };
            ExecuteNonQuery("dbo.Styles_Delete", parameters);
        }

        public Style GetById(Guid styleId)
        {
            SqlParameter[] parameters = { new SqlParameter("@StyleID", styleId) };
            List<Style> styles = new List<Style>();
            styles = ReadAll("dbo.Styles_GetById", parameters);

            return styles.Single();
        }

        protected override Style GetModelFromReader(SqlDataReader reader)
        {
            Style style = new Style();
            style.Id = reader.GetGuid(reader.GetOrdinal("stylesID"));
            style.Name = reader.GetString(reader.GetOrdinal("Name"));
            return style;
        }
        internal SqlParameter[] GetParametersFromModel(Style style)
        {
            SqlParameter[] parameters = { new SqlParameter("@StyleID", style.Id), new SqlParameter("@StyleName", style.Name)};
            return parameters;
        }
        #endregion        
    }
}
