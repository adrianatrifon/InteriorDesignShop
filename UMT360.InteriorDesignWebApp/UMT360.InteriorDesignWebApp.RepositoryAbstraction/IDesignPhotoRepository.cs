using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.RepositoryAbstraction
{
    public interface IDesignPhotoRepository
    {
        List<DesignPhoto> ReadAll();
        void Insert(DesignPhoto designPhoto);
        void Delete(DesignPhoto designPhoto);
    }
}
