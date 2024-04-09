using System.Linq.Expressions;

namespace WPI.WebApi.Services.Generic
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);
        Task<IEnumerable<T>> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        Task<T> Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Update(T entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }

}
