using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMT360.InteriorDesignWebApp.Models
{
    public class Person
    {
        #region Properties
        public Guid Id { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Street { set; get; }
        public string Number { set; get; }
        public DateTime BirthDay { set; get; }
        public string PhoneNumber { set; get; }
        public Guid CityID { set; get; }
        public Guid AccountId { set; get; }
        #endregion
    }
}
