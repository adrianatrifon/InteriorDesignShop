using System;

namespace UMT360.InteriorDesignWebApp.RepositoryAbstraction.Core
{
    public interface IRepositoryContext : IDisposable
    {
        IDesignRepository DesignRepository { get; }
        IDesignerRepository DesignerRepository { get; }
        IAccountRepository AccountRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IStyleRepository StyleRepository { get; }
        IPhotoRepository PhotoRepository { get; }
        IDesignPhotoRepository DesignPhotoRepository { get; }
        IDesignerPhotoRepository DesignerPhotoRepository { get; }
        IDesignerDesignRepository DesignerDesignRepository { get; }
        IRoleRepository RoleRepository { get; }
        IDesignViewRepository DesignViewRepository { get; }
    }
}
