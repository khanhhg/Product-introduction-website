using AutoMapper;
using WPI.WebApi.Data;
using WPI.WebApi.Services.IRepository;
using WPI.WebApi.Services.Repository;

namespace WPI.WebApi.Services.Generic
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ICartItemRepository CartItemRepos { get; private set; }
        public IDiscountRepository DiscountRepos { get; private set; }
        public IOrderDetailsRepository OrderDetailsRepos { get; private set; }
        public IOrderItemsRepository OrderItemsRepos { get; private set; }
        public IPaymentDetailsRepository PaymentDetailsRepos { get; private set; }
        public IProductCategoriesRepository ProductCategoriesRepos { get; private set; }
        public IProductInventoryRepository ProductInventoryRepos { get; private set; }
        public IProductRepository ProductRepos { get; private set; }
        public IShoppingSessionRepository ShoppingSessionRepos { get; private set; }
        public IUserPaymentRepository UserPaymentRepos { get; private set; }
        public IUserProfileRepository UserProfileRepos { get; private set; }

        public UnitOfWork(ApplicationDbContext context,  IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            CartItemRepos = new CartItemRepository(_context, _mapper);  
            DiscountRepos = new DiscountRepository(_context, _mapper);
            OrderDetailsRepos = new OrderDetailsRepository(_context, _mapper);
            OrderItemsRepos = new OrderItemsRepository(_context, _mapper);
            PaymentDetailsRepos = new PaymentDetailsRepository(_context, _mapper);
            ProductCategoriesRepos = new ProductCategoriesRepository(_context, _mapper);
            ProductInventoryRepos = new ProductInventoryRepository(_context, _mapper);   
            ProductRepos = new ProductRepository(_context, _mapper);
            ShoppingSessionRepos = new ShoppingSessionRepository(_context, _mapper);
            UserPaymentRepos = new UserPaymentRepository(_context, _mapper);
            UserProfileRepos = new UserProfileRepository(_context, _mapper);    
        }




        public int Save()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }   
    }
}
