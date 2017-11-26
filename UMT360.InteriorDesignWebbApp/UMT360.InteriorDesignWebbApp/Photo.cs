using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMT360.InteriorDesignShop.Models
{
    public class Photo
    {
        #region Properties
        public Guid Id { set; get; }
        public byte[] Image { set; get; }
        #endregion
    }
}
