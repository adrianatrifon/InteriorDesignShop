using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMT360.InteriorDesignShop.Models
{
    public class Product
    {
        #region Properties
        public Guid Id { set; get; }
        public string Name { set; get; }
        public decimal Price { set; get; }
        public string Dimensions { set; get; }
        public string Weight { set; get; }
        public string Guarantee { set; get; }
        public string Description { set; get; }
        public Guid CurrencyId { set; get; }
        public Guid BrandId { set; get; }
        public Guid CategoryId { set; get; }
        #endregion
    }
}
