using System;

namespace UMT360.InteriorDesignWebApp.RepositoryAbstraction.Core
{
    public interface IRepositoryContext : IDisposable
    {
        IColorRepository ColorRepository { get; }
        IMaterialRepository MaterialRepository { get; }
        IBrandRepository BrandRepository { get; }
        IAccountRepository AccountRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        ICityRepository CityRepository { get; }
        ICountryRepository CountryRepository { get; }
        ICountyRepository CountyRepository { get; }
        ICurrencyRepository CurrencyRepository { get; }
        IOrderProductRepository OrderProductRepository { get; }
        IOrderRepository OrderRepository { get; }
        IPaymentOptionRepository PaymentOptionRepository { get; }
        IPersonRepository PersonRepository { get; }
        IPhotoRepository PhotoRepository { get; }
        IProductColorRepository ProductColorRepository { get; }
        IProductMaterialRepository ProductMaterialRepository { get; }
        IProductPhotoRepository ProductPhotoRepository { get; }
        IProductPromotionRepository ProductPromotionRepository { get; }
        IProductRepository ProductRepository { get; }
        IPromotionRepository PromotionRepository { get; }
        IRoleRepository RoleRepository { get; }
    }
}
