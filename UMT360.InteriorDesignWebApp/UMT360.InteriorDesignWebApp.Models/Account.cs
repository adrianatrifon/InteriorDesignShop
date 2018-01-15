using System;

namespace UMT360.InteriorDesignWebApp.Models
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
