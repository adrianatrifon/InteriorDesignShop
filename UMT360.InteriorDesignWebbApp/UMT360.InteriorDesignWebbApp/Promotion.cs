using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMT360.InteriorDesignShop.Models
{
    public class Promotion
    {
        #region Properties
        public Guid Id { set; get; }
        public string Name { set; get; }
        public string Valability { set; get; }
        public string Description { set; get; }
        #endregion
    }
}
