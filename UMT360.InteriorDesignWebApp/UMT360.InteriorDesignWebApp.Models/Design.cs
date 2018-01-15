using System;

namespace UMT360.InteriorDesignWebApp.Models
{
    public class Design
    {
        #region Properties
        public Guid Id { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public Guid CategoryId { set; get; }
        public Guid StyleId { set; get; }
        #endregion
    }
}
