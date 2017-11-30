using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMT360.InteriorDesignWebApp.Models
{
    public class Category
    {
        #region Properties
        public Guid Id { set; get; }
        public Guid ParentCategoryId { set; get; }
        public string Name { set; get; }
        #endregion
    }
}
