using System;
using UMT360.InteriorDesignWebApp.RepositoryAbstraction.Core;

namespace UMT360.InteriorDesignWebApp.Business.Core
{
    public class BusinessContext:IDisposable
    {
        #region Members
        private static BusinessContext _instance;
        private IRepositoryContext _repositoryContext;
        private ColorBusiness _colorBusiness;
        private MaterialBusiness _materialBusiness;
        private AccountBusiness _accountBusiness;
        private BrandBusiness _brandBusiness;
        private CategoryBusiness _categoryBusiness;
        private CityBusiness _cityBusiness;
        private CountryBusiness _countryBusiness;
        private CountyBusiness _countyBusiness;
        private CurrencyBusiness _currencyBusiness;
        private OrderProductBusiness _orderProductBusiness;
        private OrderBusiness _orderBusiness;
        private PaymentOptionBusiness _paymentOptionBusiness;
        private PersonBusiness _personBusiness;
        private PhotoBusiness _photoBusiness;
        private ProductColorBusiness _productColorBusiness;
        private ProductMaterialBusiness _productMaterialBusiness;
        private ProductPhotoBusiness _productPhotoBusiness;
        private ProductPromotionBusiness _productPromotionBusiness;
        private ProductBusiness _productBusiness;
        private PromotionBusiness _promotionBusiness;
        private RoleBusiness _roleBusiness;
        #endregion

        #region Constructors
        public BusinessContext()
        {
            _instance = this;
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
        public ColorBusiness ColorBusiness
        {
            get
            {
                if (_colorBusiness == null)
                    _colorBusiness = new ColorBusiness();
                return _colorBusiness;
            }
        }
        public MaterialBusiness MaterialBusiness
        {
            get
            {
                if (_materialBusiness == null)
                    _materialBusiness = new MaterialBusiness();
                return _materialBusiness;
            }
        }
        public BrandBusiness BrandBusiness
        {
            get
            {
                if (_brandBusiness == null)
                    _brandBusiness = new BrandBusiness();
                return _brandBusiness;
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
        public CityBusiness CityBusiness
        {
            get
            {
                if (_cityBusiness == null)
                    _cityBusiness = new CityBusiness();
                return _cityBusiness;
            }
        }
        public CountryBusiness CountryBusiness
        {
            get
            {
                if (_countryBusiness == null)
                    _countryBusiness = new CountryBusiness();
                return _countryBusiness;
            }
        }
        public CountyBusiness CountyBusiness
        {
            get
            {
                if (_countyBusiness == null)
                    _countyBusiness = new CountyBusiness();
                return _countyBusiness;
            }
        }

        public CurrencyBusiness CurrencyBusiness
        {
            get
            {
                if (_currencyBusiness == null)
                    _currencyBusiness = new CurrencyBusiness();
                return _currencyBusiness;
            }
        }
        public OrderProductBusiness OrderProductBusiness
        {
            get
            {
                if (_orderProductBusiness == null)
                    _orderProductBusiness = new OrderProductBusiness();
                return _orderProductBusiness;
            }
        }
        public OrderBusiness OrderBusiness
        {
            get
            {
                if (_orderBusiness == null)
                    _orderBusiness = new OrderBusiness();
                return _orderBusiness;
            }
        }
        public PaymentOptionBusiness PaymentOptionBusiness
        {
            get
            {
                if (_paymentOptionBusiness == null)
                    _paymentOptionBusiness = new PaymentOptionBusiness();
                return _paymentOptionBusiness;
            }
        }
        public PersonBusiness PersonBusiness
        {
            get
            {
                if (_personBusiness == null)
                    _personBusiness = new PersonBusiness();
                return _personBusiness;
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
        public ProductColorBusiness ProductColorBusiness
        {
            get
            {
                if (_productColorBusiness == null)
                    _productColorBusiness = new ProductColorBusiness();
                return _productColorBusiness;
            }
        }
        public ProductMaterialBusiness ProductMaterialBusiness
        {
            get
            {
                if (_productMaterialBusiness == null)
                    _productMaterialBusiness = new ProductMaterialBusiness();
                return _productMaterialBusiness;
            }
        }
        public ProductPhotoBusiness ProductPhotoBusiness
        {
            get
            {
                if (_productPhotoBusiness == null)
                    _productPhotoBusiness = new ProductPhotoBusiness();
                return _productPhotoBusiness;
            }
        }
        public ProductPromotionBusiness ProductPromotionBusiness
        {
            get
            {
                if (_productPromotionBusiness == null)
                    _productPromotionBusiness = new ProductPromotionBusiness();
                return _productPromotionBusiness;
            }
        }
        public ProductBusiness ProductBusiness
        {
            get
            {
                if (_productBusiness == null)
                    _productBusiness = new ProductBusiness();
                return _productBusiness;
            }
        }
        public PromotionBusiness PromotionBusiness
        {
            get
            {
                if (_promotionBusiness == null)
                    _promotionBusiness = new PromotionBusiness();
                return _promotionBusiness;
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
                if (_colorBusiness != null)
                {
                    _colorBusiness = null;
                }
                if (_materialBusiness != null)
                {
                    _materialBusiness = null;
                }
                if (_brandBusiness != null)
                {
                    _brandBusiness = null;
                }
                if (_accountBusiness != null)
                {
                    _accountBusiness = null;
                }
                if (_categoryBusiness != null)
                {
                    _categoryBusiness = null;
                }
                if (_cityBusiness != null)
                {
                    _cityBusiness = null;
                }
                if (_countryBusiness != null)
                {
                    _countryBusiness = null;
                }
                if (_countyBusiness != null)
                {
                    _countyBusiness = null;
                }
                if (_currencyBusiness != null)
                {
                    _currencyBusiness = null;
                }
                if (_orderProductBusiness != null)
                {
                    _orderProductBusiness = null;
                }
                if (_orderBusiness != null)
                {
                    _orderBusiness = null;
                }
                if (_paymentOptionBusiness != null)
                {
                    _paymentOptionBusiness = null;
                }
                if (_personBusiness != null)
                {
                    _personBusiness = null;
                }
                if (_photoBusiness != null)
                {
                    _photoBusiness = null;
                }
                if (_productColorBusiness != null)
                {
                    _productColorBusiness = null;
                }
                if (_productMaterialBusiness != null)
                {
                    _productMaterialBusiness = null;
                }
                if (_productPhotoBusiness != null)
                {
                    _productPhotoBusiness = null;
                }
                if (_productPromotionBusiness != null)
                {
                    _productPromotionBusiness = null;
                }
                if (_productBusiness != null)
                {
                    _productBusiness = null;
                }
                if (_promotionBusiness != null)
                {
                    _promotionBusiness = null;
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
