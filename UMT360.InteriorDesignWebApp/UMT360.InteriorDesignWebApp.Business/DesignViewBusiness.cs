using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Business.Core;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.Business
{
    public class DesignViewBusiness
    {
        public List<DesignView> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.DesignViewRepository.ReadAll();
        }
    }
}
