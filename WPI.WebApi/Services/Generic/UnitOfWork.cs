using WPI.WebApi.Data;
using WPI.WebApi.Services.IRepository;
using WPI.WebApi.Services.Repository;

namespace WPI.WebApi.Services.Generic
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IProductCategoriesRepository ProductCategory { get; private set; }
      

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            ProductCategory = new ProductCategoriesRepository(_context);          
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
