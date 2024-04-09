using WPI.WebApi.Services.IRepository;

namespace WPI.WebApi.Services.Generic
{
    public interface IUnitOfWork : IDisposable
    {
        IProductCategoriesRepository ProductCategory { get; }     
        int Save();
    }
}
