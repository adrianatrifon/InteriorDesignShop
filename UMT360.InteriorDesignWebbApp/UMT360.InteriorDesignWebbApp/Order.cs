using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMT360.InteriorDesignShop.Models
{
    public class Order
    {
        #region Properties
        public Guid Id { set; get; }
        public DateTime Date { set; get; }
        public string DeliveryAddress { set; get; }
        public Guid PersonId { set; get; }
        public Guid PaymentOptionId { set; get; }
        #endregion
    }
}
