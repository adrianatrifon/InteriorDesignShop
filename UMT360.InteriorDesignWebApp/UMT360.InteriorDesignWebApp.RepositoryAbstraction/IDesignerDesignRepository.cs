using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.RepositoryAbstraction
{
    public interface IDesignerDesignRepository
    {
        List<DesignerDesign> ReadAll();
        void Insert(DesignerDesign designerDesign);
        void Delete(DesignerDesign designerDesign);
    }
}
