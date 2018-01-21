using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.RepositoryAbstraction
{
    public interface IDesignViewRepository
    {
        List<DesignView> ReadAll();
    }
}
