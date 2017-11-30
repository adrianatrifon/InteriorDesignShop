using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMT360.InteriorDesignWebApp.Models
{
    public class ProductPromotion
    {
        #region Properties
        public Guid ProductId { set; get; }
        public Guid PromotionId { set; get; }
        #endregion
    }
}
