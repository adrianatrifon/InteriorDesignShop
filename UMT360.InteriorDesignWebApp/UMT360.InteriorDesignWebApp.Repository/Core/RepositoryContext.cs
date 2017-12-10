using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMT360.InteriorDesignWebApp.Repository.Core
{
    public class RepositoryContext:IDisposable
    {
        #region Members
        private static ColorRepository _colorRepository;
        private static MaterialRepository _materialRepository;
        private static BrandRepository _brandRepository;

        #endregion
        #region Properties
        public static ColorRepository ColorRepository
        {
            get
            {
                if (_colorRepository == null)
                    _colorRepository = new ColorRepository();
                return _colorRepository;
            }
        }
        public static MaterialRepository MaterialRepository
        {
            get
            {
                if (_materialRepository == null)
                    _materialRepository = new MaterialRepository();
                return _materialRepository;
            }
        }
        public static BrandRepository BrandRepository
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
                    //_connection.Dispose();
                    _colorRepository = null;
                }

                if (_materialRepository != null)
                {
                    //_connection.Dispose();
                    _materialRepository = null;
                }
                if (_brandRepository != null)
                {
                    //_connection.Dispose();
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
