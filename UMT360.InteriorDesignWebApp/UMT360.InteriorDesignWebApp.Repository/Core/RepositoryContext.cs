using System;
using UMT360.InteriorDesignWebApp.RepositoryAbstraction;
using UMT360.InteriorDesignWebApp.RepositoryAbstraction.Core;

namespace UMT360.InteriorDesignWebApp.Repository.Core
{
    public class RepositoryContext :IRepositoryContext
    {
        #region Members
        private static IRepositoryContext _instance;
        private IColorRepository _colorRepository;
        private IMaterialRepository _materialRepository;
        private IAccountRepository _accountRepository;
        private IBrandRepository _brandRepository;
        private ICategoryRepository _categoryRepository;
        private ICityRepository _cityRepository;
        private ICountryRepository _countryRepository;
        private ICountyRepository _countyRepository;
        private ICurrencyRepository _currencyRepository;
        private IOrderProductRepository _orderProductRepository;
        private IOrderRepository _orderRepository;
        private IPaymentOptionRepository _paymentOptionRepository;
        private IPersonRepository _personRepository;
        private IPhotoRepository _photoRepository;
        private IProductColorRepository _productColorRepository;
        private IProductMaterialRepository _productMaterialRepository;
        private IProductPhotoRepository _productPhotoRepository;
        private IProductPromotionRepository _productPromotionRepository;
        private IProductRepository _productRepository;
        private IPromotionRepository _promotionRepository;
        private IRoleRepository _roleRepository;
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
        public IColorRepository ColorRepository
        {
            get
            {
                if (_colorRepository == null)
                    _colorRepository = new ColorRepository();
                return _colorRepository;
            }
        }
        public IMaterialRepository MaterialRepository
        {
            get
            {
                if (_materialRepository == null)
                    _materialRepository = new MaterialRepository();
                return _materialRepository;
            }
        }
        public IBrandRepository BrandRepository
        {
            get
            {
                if (_brandRepository == null)
                    _brandRepository = new BrandRepository();
                return _brandRepository;
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
        public ICityRepository CityRepository
        {
            get
            {
                if (_cityRepository == null)
                    _cityRepository = new CityRepository();
                return _cityRepository;
            }
        }
        public ICountryRepository CountryRepository
        {
            get
            {
                if (_countryRepository == null)
                    _countryRepository = new CountryRepository();
                return _countryRepository;
            }
        }
        public ICountyRepository CountyRepository
        {
            get
            {
                if (_countyRepository == null)
                    _countyRepository = new CountyRepository();
                return _countyRepository;
            }
        }

        public ICurrencyRepository CurrencyRepository
        {
            get
            {
                if (_currencyRepository == null)
                    _currencyRepository = new CurrencyRepository();
                return _currencyRepository;
            }
        }
        public IOrderProductRepository OrderProductRepository
        {
            get
            {
                if (_orderProductRepository == null)
                    _orderProductRepository = new OrderProductRepository();
                return _orderProductRepository;
            }
        }
        public IOrderRepository OrderRepository
        {
            get
            {
                if (_orderRepository == null)
                    _orderRepository = new OrderRepository();
                return _orderRepository;
            }
        }
        public IPaymentOptionRepository PaymentOptionRepository
        {
            get
            {
                if (_paymentOptionRepository == null)
                    _paymentOptionRepository = new PaymentOptionRepository();
                return _paymentOptionRepository;
            }
        }
        public IPersonRepository PersonRepository
        {
            get
            {
                if (_personRepository == null)
                    _personRepository = new PersonRepository();
                return _personRepository;
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
        public IProductColorRepository ProductColorRepository
        {
            get
            {
                if (_productColorRepository == null)
                    _productColorRepository = new ProductColorRepository();
                return _productColorRepository;
            }
        }
        public IProductMaterialRepository ProductMaterialRepository
        {
            get
            {
                if (_productMaterialRepository == null)
                    _productMaterialRepository = new ProductMaterialRepository();
                return _productMaterialRepository;
            }
        }
        public IProductPhotoRepository ProductPhotoRepository
        {
            get
            {
                if (_productPhotoRepository == null)
                    _productPhotoRepository = new ProductPhotoRepository();
                return _productPhotoRepository;
            }
        }
        public IProductPromotionRepository ProductPromotionRepository
        {
            get
            {
                if (_productPromotionRepository == null)
                    _productPromotionRepository = new ProductPromotionRepository();
                return _productPromotionRepository;
            }
        }
        public IProductRepository ProductRepository
        {
            get
            {
                if (_productRepository == null)
                    _productRepository = new ProductRepository();
                return _productRepository;
            }
        }
        public IPromotionRepository PromotionRepository
        {
            get
            {
                if (_promotionRepository == null)
                    _promotionRepository = new PromotionRepository();
                return _promotionRepository;
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
                if (_accountRepository != null)
                {
                    _accountRepository = null;
                }
                if (_categoryRepository != null)
                {
                    _categoryRepository = null;
                }
                if (_cityRepository != null)
                {
                    _cityRepository = null;
                }
                if (_countryRepository != null)
                {
                    _countryRepository = null;
                }
                if (_countyRepository != null)
                {
                    _countyRepository = null;
                }
                if (_currencyRepository != null)
                {
                    _currencyRepository = null;
                }
                if (_orderProductRepository != null)
                {
                    _orderProductRepository = null;
                }
                if (_orderRepository != null)
                {
                    _orderRepository = null;
                }
                if (_paymentOptionRepository != null)
                {
                    _paymentOptionRepository = null;
                }
                if (_personRepository != null)
                {
                    _personRepository = null;
                }
                if (_photoRepository != null)
                {
                    _photoRepository = null;
                }
                if (_productColorRepository != null)
                {
                    _productColorRepository = null;
                }
                if (_productMaterialRepository != null)
                {
                    _productMaterialRepository = null;
                }
                if (_productPhotoRepository != null)
                {
                    _productPhotoRepository = null;
                }
                if (_productPromotionRepository != null)
                {
                    _productPromotionRepository = null;
                }
                if (_productRepository != null)
                {
                    _productRepository = null;
                }
                if (_promotionRepository != null)
                {
                    _promotionRepository = null;
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
