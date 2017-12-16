using System;
using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.RepositoryAbstraction
{
    public interface IPromotionRepository
    {
        List<Promotion> ReadAll();
        void Insert(Promotion promotion);
        void Update(Promotion promotion);
        void Delete(Guid promotionId);
        Promotion GetById(Guid promotionId);
    }
}
