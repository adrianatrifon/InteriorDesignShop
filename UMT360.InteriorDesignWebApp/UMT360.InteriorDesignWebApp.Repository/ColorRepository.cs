using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using UMT360.InteriorDesignWebApp.Models;
using UMT360.InteriorDesignWebApp.Repository.Core;
using UMT360.InteriorDesignWebApp.RepositoryAbstraction;

namespace UMT360.InteriorDesignWebApp.Repository
{
    public class ColorRepository:BaseRepository<Color>,IColorRepository
    {
        #region Methods
        public List<Color> ReadAll()
        {
            return  ReadAll("dbo.Colors_ReadAll");
        }       
        
        public void Insert(Color color)
        {
            SqlParameter[] parameters = GetParametersFromModel(color);
            ExecuteNonQuery("dbo.Colors_Create",parameters);
        }
        public void Update(Color color)
        {
            SqlParameter[] parameters = GetParametersFromModel(color);
            ExecuteNonQuery("dbo.Colors_Update", parameters);
        }

        public void Delete(Guid colorId)
        {
            SqlParameter[] parameters = { new SqlParameter("@ColorID", colorId) };
            ExecuteNonQuery("dbo.Colors_Delete", parameters);
        }
        
        public Color GetById(Guid colorId)
        {
            SqlParameter[] parameters ={ new SqlParameter("@ColorID", colorId) };
            List<Color> colors = new List<Color>();           
            colors= ReadAll("dbo.Colors_GetById", parameters);
            
            return colors.Single();        
        }

        protected override Color GetModelFromReader(SqlDataReader reader)
        {
            Color color = new Color();
            color.Id = reader.GetGuid(reader.GetOrdinal("ColorID"));
            color.Name = reader.GetString(reader.GetOrdinal("Name"));
            return color;
        }
        internal SqlParameter[] GetParametersFromModel(Color color)
        {
            SqlParameter[] parameters = { new SqlParameter("@ColorID", color.Id), new SqlParameter("@ColorName", color.Name) };
            return parameters;
        }
        #endregion
    }
}
