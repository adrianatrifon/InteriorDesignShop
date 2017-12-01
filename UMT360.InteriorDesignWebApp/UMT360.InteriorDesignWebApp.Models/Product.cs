using System;


namespace UMT360.InteriorDesignWebApp.Models
{
    public class Product
    {
        #region Properties
        public Guid Id { set; get; }
        public string Name { set; get; }
        public decimal Price { set; get; }
        public int Stock { set; get; }
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
