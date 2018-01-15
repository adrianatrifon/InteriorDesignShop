using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.RepositoryAbstraction
{
    public interface IDesignerPhotoRepository
    {
        List<DesignerPhoto> ReadAll();
        void Insert(DesignerPhoto designerPhoto);
        void Delete(DesignerPhoto designerPhoto);
    }
}
