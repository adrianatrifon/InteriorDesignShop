using System;


namespace UMT360.InteriorDesignWebApp.Repository.Core
{
    public class RepositoryContext : IDisposable
    {
        #region Members
        private static RepositoryContext _instance;
        private ColorRepository _colorRepository;
        private MaterialRepository _materialRepository;
        private BrandRepository _brandRepository;
        #endregion

        #region Constructors
        public RepositoryContext()
        {
            _instance = this;
        }       
        #endregion

        #region Properties
        public RepositoryContext Current
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
        public  ColorRepository ColorRepository
        {
            get
            {
                if (_colorRepository == null)
                    _colorRepository = new ColorRepository();
                return _colorRepository;
            }
        }
        public  MaterialRepository MaterialRepository
        {
            get
            {
                if (_materialRepository == null)
                    _materialRepository = new MaterialRepository();
                return _materialRepository;
            }
        }
        public  BrandRepository BrandRepository
        {
            get
            {
                if (_brandRepository == null)
                    _brandRepository = new BrandRepository();
                return _brandRepository;
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
                if (_colorRepository != null)
                {
                    _colorRepository = null;
                }
                if (_materialRepository != null)
                {
                    _materialRepository = null;
                }
                if (_brandRepository != null)
                {
                    _brandRepository = null;
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
