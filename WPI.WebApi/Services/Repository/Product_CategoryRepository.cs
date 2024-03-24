using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WPI.WebApi.Data.Models;

namespace WPI.WebApi.Services.Repository
{
    public class Product_CategoryRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public Product_CategoryRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context ??
                throw new ArgumentNullException(nameof(context));
            _mapper = mapper;
        }
        public async Task<IEnumerable<Product_Category>> GetProduct_Category()
        {
            return await _context.Product_Category.ToListAsync();
        }
        public async Task<Product_Category> GetProduct_CategoryByID(int ID)
        {
            return await _context.Product_Category.FindAsync(ID);
        }
        public async Task<Product_Category> InsertProduct_Category(Product_Category objProduct_Category)
        {
          
            _context.Product_Category.Add(objProduct_Category);
            await _context.SaveChangesAsync();
            return objProduct_Category;
        }
        public async Task<Product_Category> UpdateProduct_Category(Product_Category Product_Category)
        {
          
            _context.Entry(Product_Category).State = EntityState.Modified;

            var obj = _context.Product_Category.Where(x => x.Id == 1).FirstOrDefault();
            await _context.SaveChangesAsync();
            return Product_Category;
        }
        public bool DeleteProduct_Category(int ID)
        {
            bool result = false;
            var objProduct_Category = _context.Product_Category.Find(ID);
            if (objProduct_Category != null)
            {
                _context.Entry(objProduct_Category).State = EntityState.Deleted;
                _context.SaveChanges();
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
    }
}
