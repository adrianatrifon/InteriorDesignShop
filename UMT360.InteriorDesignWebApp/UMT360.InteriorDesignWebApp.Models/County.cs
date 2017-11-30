using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMT360.InteriorDesignWebApp.Models
{
    public class County
    {
        #region Properties
        public Guid Id { set; get; }
        public string Name { set; get; }
        public Guid CountryId { set; get; }
        #endregion
    }
}
