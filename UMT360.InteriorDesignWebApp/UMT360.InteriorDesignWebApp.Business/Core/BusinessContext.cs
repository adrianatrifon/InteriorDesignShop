using System;
using UMT360.InteriorDesignWebApp.RepositoryAbstraction.Core;
using UMT360.InteriorDesignWebApp.RepositoryFactory;

namespace UMT360.InteriorDesignWebApp.Business.Core
{
    public class BusinessContext:IDisposable
    {
        #region Members
        private static BusinessContext _instance;
        private IRepositoryContext _repositoryContext;
        private AccountBusiness _accountBusiness;
        private DesignerBusiness _designerBusiness;
        private CategoryBusiness _categoryBusiness;
        private StyleBusiness _styleBusiness;
        private DesignerDesignBusiness _designerDesignBusiness;
        private PhotoBusiness _photoBusiness;
        private DesignerPhotoBusiness _designerPhotoBusiness;
        private DesignPhotoBusiness _designPhotoBusiness;
        private DesignBusiness _designBusiness;
        private RoleBusiness _roleBusiness;
        private DesignViewBusiness _designViewBusiness;
        #endregion

        #region Constructors
        public BusinessContext()
        {
            _instance = this;
            _repositoryContext = Getter.GetRepository();
        }
        #endregion

        #region Properties
        internal static BusinessContext Current
        {
            get
            {
                if (_instance == null)
                {
                    throw new Exception("No BusinessContext instance available!");
                }
                return _instance;
            }
        }
        public DesignerBusiness DesignerBusiness
        {
            get
            {
                if (_designerBusiness == null)
                    _designerBusiness = new DesignerBusiness();
                return _designerBusiness;
            }
        }
        public DesignViewBusiness DesignViewBusiness
        {
            get
            {
                if (_designViewBusiness == null)
                    _designViewBusiness = new DesignViewBusiness();
                return _designViewBusiness;
            }
        }
        public AccountBusiness AccountBusiness
        {
            get
            {
                if (_accountBusiness == null)
                    _accountBusiness = new AccountBusiness();
                return _accountBusiness;
            }
        }
        public CategoryBusiness CategoryBusiness
        {
            get
            {
                if (_categoryBusiness == null)
                    _categoryBusiness = new CategoryBusiness();
                return _categoryBusiness;
            }
        }
        public StyleBusiness StyleBusiness
        {
            get
            {
                if (_styleBusiness == null)
                    _styleBusiness = new StyleBusiness();
                return _styleBusiness;
            }
        }
        public DesignerDesignBusiness DesignerDesignBusiness
        {
            get
            {
                if (_designerDesignBusiness == null)
                    _designerDesignBusiness = new DesignerDesignBusiness();
                return _designerDesignBusiness;
            }
        }
        public PhotoBusiness PhotoBusiness
        {
            get
            {
                if (_photoBusiness == null)
                    _photoBusiness = new PhotoBusiness();
                return _photoBusiness;
            }
        }
        public DesignerPhotoBusiness DesignerPhotoBusiness
        {
            get
            {
                if (_designerPhotoBusiness == null)
                    _designerPhotoBusiness = new DesignerPhotoBusiness();
                return _designerPhotoBusiness;
            }
        }
        public DesignPhotoBusiness DesignPhotoBusiness
        {
            get
            {
                if (_designPhotoBusiness == null)
                    _designPhotoBusiness = new DesignPhotoBusiness();
                return _designPhotoBusiness;
            }
        }
        public DesignBusiness DesignBusiness
        {
            get
            {
                if (_designBusiness == null)
                    _designBusiness = new DesignBusiness();
                return _designBusiness;
            }
        }
        public RoleBusiness RoleBusiness
        {
            get
            {
                if (_roleBusiness == null)
                    _roleBusiness = new RoleBusiness();
                return _roleBusiness;
            }
        }

        internal IRepositoryContext RepositoryContext
        {
            get { return _repositoryContext; }
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
                if (_designerBusiness != null)
                {
                    _designerBusiness = null;
                }
                if (_designViewBusiness != null)
                {
                    _designViewBusiness = null;
                }
                if (_accountBusiness != null)
                {
                    _accountBusiness = null;
                }
                if (_categoryBusiness != null)
                {
                    _categoryBusiness = null;
                }
                if (_styleBusiness != null)
                {
                    _styleBusiness = null;
                }
                if (_designerDesignBusiness != null)
                {
                    _designerDesignBusiness = null;
                }
                if (_photoBusiness != null)
                {
                    _photoBusiness = null;
                }
                if (_designerPhotoBusiness != null)
                {
                    _designerPhotoBusiness = null;
                }
                if (_designPhotoBusiness != null)
                {
                    _designPhotoBusiness = null;
                }
                if (_designBusiness != null)
                {
                    _designBusiness = null;
                }
                if (_roleBusiness != null)
                {
                    _roleBusiness = null;
                }
                if (_repositoryContext != null)
                {
                    _repositoryContext.Dispose();
                    _repositoryContext = null;
                }

                if (_instance != null)
                {
                    _instance = null;
                }
            }
        }

        ~BusinessContext()
        {
            Dispose(false);
        }
        #endregion       
    }
}
