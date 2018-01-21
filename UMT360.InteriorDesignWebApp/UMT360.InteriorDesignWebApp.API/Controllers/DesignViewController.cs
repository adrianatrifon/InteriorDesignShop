using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UMT360.InteriorDesignWebApp.Business.Core;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.API.Controllers
{
    [RoutePrefix("api/designs")]
    public class DesignViewController : ApiController
    {
        // GET api/<controller>/5
        [HttpGet]
        [Route("")]
        public IEnumerable<DesignView> ReadAll()
        {
            using (BusinessContext context = new BusinessContext())
            {
                return context.DesignViewBusiness.ReadAll();
            }
        }
        
    }
}