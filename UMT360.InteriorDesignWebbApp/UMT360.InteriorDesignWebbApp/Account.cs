using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMT360.InteriorDesignShop.Models
{
    public class Account
    {
        #region Properties
        public Guid Id { set; get; }
        public string EmailAddress { set; get; }
        public string Password { set; get; }
        public Guid RoleId { set; get; }
        public Guid PhotoId { set; get; }
        #endregion
    }
}
