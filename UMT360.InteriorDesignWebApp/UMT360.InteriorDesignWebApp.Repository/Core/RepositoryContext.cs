using System;
using UMT360.InteriorDesignWebApp.RepositoryAbstraction;
using UMT360.InteriorDesignWebApp.RepositoryAbstraction.Core;

namespace UMT360.InteriorDesignWebApp.Repository.Core
{
    public class RepositoryContext :IRepositoryContext
    {
        #region Members
        private static IRepositoryContext _instance;
        private IAccountRepository _accountRepository;
        private ICategoryRepository _categoryRepository;
        private IDesignRepository _designRepository;
        private IDesignerRepository _designerRepository;
        private IDesignerDesignRepository _designerDesignRepository;
        private IDesignerPhotoRepository _designerPhotoRepository;
        private IDesignPhotoRepository _designPhotoRepository;
        private IPhotoRepository _photoRepository;
        private IRoleRepository _roleRepository;
        private IStyleRepository _styleRepository;
        private IDesignViewRepository _designViewRepository;
        #endregion

        #region Constructors
        public RepositoryContext()
        {
            _instance = this;
        }
        #endregion

        #region Properties
        internal static IRepositoryContext Current
        {
            get
            {
                if (_instance == null)
                {
                    throw new Exception("No RepositoryContext instance available!");
                }
                return _instance;
            }
        }
        public IDesignRepository DesignRepository
        {
            get
            {
                if (_designRepository == null)
                    _designRepository = new DesignRepository();
                return _designRepository;
            }
        }
        public IDesignViewRepository DesignViewRepository
        {
            get
            {
                if (_designViewRepository == null)
                    _designViewRepository = new DesignViewRepository();
                return _designViewRepository;
            }
        }
        public IDesignerRepository DesignerRepository
        {
            get
            {
                if (_designerRepository == null)
                    _designerRepository = new DesignerRepository();
                return _designerRepository;
            }
        }
        public IAccountRepository AccountRepository
        {
            get
            {
                if (_accountRepository == null)
                    _accountRepository = new AccountRepository();
                return _accountRepository;
            }
        }
        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                    _categoryRepository = new CategoryRepository();
                return _categoryRepository;
            }
        }
        public IStyleRepository StyleRepository
        {
            get
            {
                if (_styleRepository == null)
                    _styleRepository = new StyleRepository();
                return _styleRepository;
            }
        }
        public IPhotoRepository PhotoRepository
        {
            get
            {
                if (_photoRepository == null)
                    _photoRepository = new PhotoRepository();
                return _photoRepository;
            }
        }
        public IDesignerDesignRepository DesignerDesignRepository
        {
            get
            {
                if (_designerDesignRepository == null)
                    _designerDesignRepository = new DesignerDesignRepository();
                return _designerDesignRepository;
            }
        }
        public IDesignPhotoRepository DesignPhotoRepository
        {
            get
            {
                if (_designPhotoRepository == null)
                    _designPhotoRepository = new DesignPhotoRepository();
                return _designPhotoRepository;
            }
        }
        public IDesignerPhotoRepository DesignerPhotoRepository
        {
            get
            {
                if (_designerPhotoRepository == null)
                    _designerPhotoRepository = new DesignerPhotoRepository();
                return _designerPhotoRepository;
            }
        }
        public IRoleRepository RoleRepository
        {
            get
            {
                if (_roleRepository == null)
                    _roleRepository = new RoleRepository();
                return _roleRepository;
            }
        }
        #endregion

        #region IDisposable Implementation
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool dispose)
        {
            if (dispose)
            {
                if (_designRepository != null)
                {
                    _designRepository = null;
                }
                if (_designViewRepository != null)
                {
                    _designViewRepository = null;
                }
                if (_designerRepository != null)
                {
                    _designerRepository = null;
                }
                if (_accountRepository != null)
                {
                    _accountRepository = null;
                }
                if (_categoryRepository != null)
                {
                    _categoryRepository = null;
                }
                if (_styleRepository != null)
                {
                    _styleRepository = null;
                }
                if (_photoRepository != null)
                {
                    _photoRepository = null;
                }
                if (_designerDesignRepository != null)
                {
                    _designerDesignRepository = null;
                }
                if (_designPhotoRepository != null)
                {
                    _designPhotoRepository = null;
                }
                if (_designerPhotoRepository != null)
                {
                    _designerPhotoRepository = null;
                }
                if (_roleRepository != null)
                {
                    _roleRepository = null;
                }
                if (_instance != null)
                {
                    _instance = null;
                }
            }
        }

        ~RepositoryContext()
        {
            Dispose(false);
        }
        #endregion       
    }
}
