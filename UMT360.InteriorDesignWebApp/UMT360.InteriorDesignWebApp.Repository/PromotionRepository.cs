using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using UMT360.InteriorDesignWebApp.Models;
using UMT360.InteriorDesignWebApp.Repository.Core;

namespace UMT360.InteriorDesignWebApp.Repository
{
    public class PromotionRepository : BaseRepository<Promotion>
    {
        #region Methods
        public List<Promotion> ReadAll()
        {
            return ReadAll("dbo.Promotions_ReadAll");

        }

        public void Insert(Promotion promotion)
        {

            SqlParameter[] parameters = { new SqlParameter("@PromotionID", promotion.Id),
                                          new SqlParameter("@PromotionName", promotion.Name),
                                          new SqlParameter("@StartDate", promotion.StartDate),
                                          new SqlParameter("@EndDate", promotion.EndDate),
                                          new SqlParameter("@Description", promotion.Description)
                                        };

            Operation("dbo.Promotions_Create", parameters);

        }
        public void Update(Promotion promotion)
        {
            SqlParameter[] parameters = { new SqlParameter("@PromotionID", promotion.Id),
                                          new SqlParameter("@PromotionName", promotion.Name),
                                          new SqlParameter("@StartDate", promotion.StartDate),
                                          new SqlParameter("@EndDate", promotion.EndDate),
                                          new SqlParameter("@Description", promotion.Description)
                                        };
            Operation("dbo.Promotions_Update", parameters);

        }

        public void Delete(Guid promotionId)
        {
            SqlParameter[] parameters = { new SqlParameter("@PromotionID", promotionId) };
            Operation("dbo.Promotions_Delete", parameters);

        }

        public Promotion GetById(Guid promotionId)
        {
            Promotion promotion = new Promotion();
            SqlParameter[] parameters = { new SqlParameter("@PromotionID", promotionId) };
            List<Promotion> promotions = new List<Promotion>();
            promotions = ReadAll("dbo.Promotions_GetById", parameters);

            return promotions.ElementAt(0);
        }

        public override Promotion GetModelFromReader(SqlDataReader reader)
        {
            Promotion promotion = new Promotion();
            promotion.Id = reader.GetGuid(reader.GetOrdinal("PromotionID"));
            promotion.Name = reader.GetString(reader.GetOrdinal("Name"));
            promotion.StartDate = reader.GetDateTime(reader.GetOrdinal("StartDate"));
            promotion.EndDate = reader.GetDateTime(reader.GetOrdinal("EndDate"));
            promotion.Description = reader.GetString(reader.GetOrdinal("Description"));

            return promotion;
        }
        #endregion        
    }
}
