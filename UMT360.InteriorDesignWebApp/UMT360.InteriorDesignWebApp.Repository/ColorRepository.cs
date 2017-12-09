using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using UMT360.InteriorDesignWebApp.Models;
using UMT360.InteriorDesignWebApp.Repository.Core;

namespace UMT360.InteriorDesignWebApp.Repository
{
    public class ColorRepository:BaseRepository<Color>
    {
        #region Methods
        public List<Color> ReadAll()
        {
            return  ReadAll("dbo.Colors_ReadAll");

        }       
        
        public void Insert(Color color)
        {

            SqlParameter[] parameters = { new SqlParameter("@ColorID", color.Id), new SqlParameter("@ColorName",color.Name)};
            Operation("dbo.Colors_Create",parameters);

        }
        public void Update(Color color)
        {
            SqlParameter[] parameters = { new SqlParameter("@ColorID", color.Id), new SqlParameter("@ColorName", color.Name) };
            Operation("dbo.Colors_Update", parameters);           

        }

        public void Delete(Guid colorId)
        {
            SqlParameter[] parameters = { new SqlParameter("@ColorID", colorId) };
            Operation("dbo.Colors_Delete", parameters);          

        }
        
        public Color GetById(Guid colorId)
        {
            Color color = new Color();
            SqlParameter[] parameters ={ new SqlParameter("@ColorID", colorId) };
            List<Color> colors = new List<Color>();           
            colors= ReadAll("dbo.Colors_GetById", parameters);
            
            return colors.ElementAt(0);        
        }

        public override Color GetModelFromReader(SqlDataReader reader)
        {
            Color color = new Color();
            color.Id = reader.GetGuid(reader.GetOrdinal("ColorID"));
            color.Name = reader.GetString(reader.GetOrdinal("Name"));
            return color;
        }
        #endregion
    }
}
