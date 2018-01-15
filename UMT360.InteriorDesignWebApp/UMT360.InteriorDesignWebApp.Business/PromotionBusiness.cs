using System;
using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Business.Core;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.Business
{
    public class PromotionBusiness
    {
        #region Methods
        public List<Design> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.PromotionRepository.ReadAll();
        }

        public void Insert(Design promotion)
        {
            BusinessContext.Current.RepositoryContext.PromotionRepository.Insert(promotion);
        }
        public void Update(Design promotion)
        {
            BusinessContext.Current.RepositoryContext.PromotionRepository.Update(promotion);
        }

        public void Delete(Guid promotionId)
        {
            BusinessContext.Current.RepositoryContext.PromotionRepository.Delete(promotionId);
        }

        public Design GetById(Guid promotionId)
        {
            return BusinessContext.Current.RepositoryContext.PromotionRepository.GetById(promotionId);
        }
        #endregion        
    }
}
