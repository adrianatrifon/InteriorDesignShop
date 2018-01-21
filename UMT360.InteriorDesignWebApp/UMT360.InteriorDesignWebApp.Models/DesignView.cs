using System;

namespace UMT360.InteriorDesignWebApp.Models
{
    public class DesignView
    {
        #region Properties
        public Guid Id { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string Category { set; get; }
        public string Style { set; get; }
        public byte[] Photos { set; get; }
        #endregion
    }
}
