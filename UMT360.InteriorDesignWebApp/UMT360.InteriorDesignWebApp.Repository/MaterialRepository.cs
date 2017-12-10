using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using UMT360.InteriorDesignWebApp.Models;
using UMT360.InteriorDesignWebApp.Repository.Core;

namespace UMT360.InteriorDesignWebApp.Repository
{
    public class MaterialRepository:BaseRepository<Material>
    {
        #region Methods
        public List<Material> ReadAll()
        {
            ColorRepository colorRepository = RepositoryContext.ColorRepository;
            return ReadAll("dbo.Materials_ReadAll");

        }

        public void Insert(Material material)
        {

            SqlParameter[] parameters = { new SqlParameter("@MaterialID", material.Id), new SqlParameter("@MaterialName", material.Name) };
            Operation("dbo.Materials_Create", parameters);

        }
        public void Update(Material material)
        {
            SqlParameter[] parameters = { new SqlParameter("@MaterialID", material.Id), new SqlParameter("@MaterialName", material.Name) };
            Operation("dbo.Materials_Update", parameters);

        }

        public void Delete(Guid materialId)
        {
            SqlParameter[] parameters = { new SqlParameter("@MaterialID", materialId) };
            Operation("dbo.Materials_Delete", parameters);

        }

        public Material GetById(Guid materialId)
        {
            Material material = new Material();
            SqlParameter[] parameters = { new SqlParameter("@MaterialID", materialId) };
            List<Material> materials = new List<Material>();
            materials = ReadAll("dbo.Materials_GetById", parameters);

            return materials.ElementAt(0);
        }

        public override Material GetModelFromReader(SqlDataReader reader)
        {
            Material material = new Material();
            material.Id = reader.GetGuid(reader.GetOrdinal("MaterialID"));
            material.Name = reader.GetString(reader.GetOrdinal("Name"));
            return material;
        }
        #endregion

    }
}
