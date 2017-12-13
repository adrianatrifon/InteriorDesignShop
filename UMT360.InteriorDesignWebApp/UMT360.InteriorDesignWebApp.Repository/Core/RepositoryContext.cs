using System;


namespace UMT360.InteriorDesignWebApp.Repository.Core
{
    public class RepositoryContext : IDisposable
    {
        #region Members
        private static RepositoryContext _instance;
        private ColorRepository _colorRepository;
        private MaterialRepository _materialRepository;
        private AccountRepository _accountRepository;
        private BrandRepository _brandRepository;
        private CategoryRepository _categoryRepository;
        private CityRepository _cityRepository;
        private CountryRepository _countryRepository;
        private CountyRepository _countyRepository;
        private CurrencyRepository _currencyRepository;
        private OrderProductRepository _orderProductRepository;
        private OrderRepository _orderRepository;
        private PaymentOptionRepository _paymentOptionRepository;
        private PersonRepository _personRepository;
        private PhotoRepository _photoRepository;
        private ProductColorRepository _productColorRepository;
        private ProductMaterialRepository _productMaterialRepository;
        private ProductPhotoRepository _productPhotoRepository;
        private ProductPromotionRepository _productPromotionRepository;
        private ProductRepository _productRepository;
        private PromotionRepository _promotionRepository;
        private RoleRepository _roleRepository;
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
        public ColorRepository ColorRepository
        {
            get
            {
                if (_colorRepository == null)
                    _colorRepository = new ColorRepository();
                return _colorRepository;
            }
        }
        public MaterialRepository MaterialRepository
        {
            get
            {
                if (_materialRepository == null)
                    _materialRepository = new MaterialRepository();
                return _materialRepository;
            }
        }
        public BrandRepository BrandRepository
        {
            get
            {
                if (_brandRepository == null)
                    _brandRepository = new BrandRepository();
                return _brandRepository;
            }
        }
        private AccountRepository AccountRepository
        {
            get
            {
                if (_accountRepository == null)
                    _accountRepository = new AccountRepository();
                return _accountRepository;
            }
        }
        private CategoryRepository CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                    _categoryRepository = new CategoryRepository();
                return _categoryRepository;
            }
        }
        private CityRepository CityRepository
        {
            get
            {
                if (_cityRepository == null)
                    _cityRepository = new CityRepository();
                return _cityRepository;
            }
        }
        private CountryRepository CountryRepository
        {
            get
            {
                if (_countryRepository == null)
                    _countryRepository = new CountryRepository();
                return _countryRepository;
            }
        }
        private CountyRepository CountyRepository
        {
            get
            {
                if (_countyRepository == null)
                    _countyRepository = new CountyRepository();
                return _countyRepository;
            }
        }
        private CurrencyRepository CurrencyRepository
        {
            get
            {
                if (_currencyRepository == null)
                    _currencyRepository = new CurrencyRepository();
                return _currencyRepository;
            }
        }
        private OrderProductRepository OrderProductRepository
        {
            get
            {
                if (_orderProductRepository == null)
                    _orderProductRepository = new OrderProductRepository();
                return _orderProductRepository;
            }
        }
        private OrderRepository OrderRepository
        {
            get
            {
                if (_orderRepository == null)
                    _orderRepository = new OrderRepository();
                return _orderRepository;
            }
        }
        private PaymentOptionRepository PaymentOptionRepository
        {
            get
            {
                if (_paymentOptionRepository == null)
                    _paymentOptionRepository = new PaymentOptionRepository();
                return _paymentOptionRepository;
            }
        }
        private PersonRepository PersonRepository
        {
            get
            {
                if (_personRepository == null)
                    _personRepository = new PersonRepository();
                return _personRepository;
            }
        }
        private PhotoRepository PhotoRepository
        {
            get
            {
                if (_photoRepository == null)
                    _photoRepository = new PhotoRepository();
                return _photoRepository;
            }
        }
        private ProductColorRepository ProductColorRepository
        {
            get
            {
                if (_productColorRepository == null)
                    _productColorRepository = new ProductColorRepository();
                return _productColorRepository;
            }
        }
        private ProductMaterialRepository ProductMaterialRepository
        {
            get
            {
                if (_productMaterialRepository == null)
                    _productMaterialRepository = new ProductMaterialRepository();
                return _productMaterialRepository;
            }
        }
        private ProductPhotoRepository ProductPhotoRepository
        {
            get
            {
                if (_productPhotoRepository == null)
                    _productPhotoRepository = new ProductPhotoRepository();
                return _productPhotoRepository;
            }
        }
        private ProductPromotionRepository ProductPromotionRepository
        {
            get
            {
                if (_productPromotionRepository == null)
                    _productPromotionRepository = new ProductPromotionRepository();
                return _productPromotionRepository;
            }
        }
        private ProductRepository ProductRepository
        {
            get
            {
                if (_productRepository == null)
                    _productRepository = new ProductRepository();
                return _productRepository;
            }
        }
        private PromotionRepository PromotionRepository
        {
            get
            {
                if (_promotionRepository == null)
                    _promotionRepository = new PromotionRepository();
                return _promotionRepository;
            }
        }
        private RoleRepository RoleRepository
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
            }
        }

        ~RepositoryContext()
        {
            Dispose(false);
        }
        #endregion       
    }
}
