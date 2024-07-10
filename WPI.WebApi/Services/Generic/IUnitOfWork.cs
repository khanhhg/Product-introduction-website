using WPI.WebApi.Services.IRepository;

namespace WPI.WebApi.Services.Generic
{
    public interface IUnitOfWork : IDisposable
    {
        ICartItemRepository CartItemRepos { get; }
        IDiscountRepository DiscountRepos { get; }
        IOrderDetailsRepository OrderDetailsRepos { get; }
        IOrderItemsRepository OrderItemsRepos { get; }
        IPaymentDetailsRepository PaymentDetailsRepos { get; }
        IProductCategoriesRepository ProductCategoriesRepos { get; }
        IProductInventoryRepository ProductInventoryRepos { get; }
        IProductRepository ProductRepos { get; }
        IShoppingSessionRepository ShoppingSessionRepos { get; }
        IUserPaymentRepository UserPaymentRepos { get; }
        IUserProfileRepository UserProfileRepos { get; }
        int Save();
    }
}
