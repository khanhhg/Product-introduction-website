using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WPI.WebApi.Data;
using WPI.WebApi.Data.Models.EF;

namespace WPI.WebApi.Services.Repository
{
    public class ProductCategoryRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ProductCategoryRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context ??
                throw new ArgumentNullException(nameof(context));
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductCategory>> GetProductCategory()
        {
            return await _context.ProductCategory.ToListAsync();
        }
        public async Task<ProductCategory> GetProductCategoryByID(int ID)
        {
            return await _context.ProductCategory.FindAsync(ID);
        }
        public async Task<ProductCategory> InsertProductCategory(ProductCategory objProduct_Category)
        {
          
            _context.ProductCategory.Add(objProduct_Category);
            await _context.SaveChangesAsync();
            return objProduct_Category;
        }
        public async Task<ProductCategory> UpdateProductCategory(ProductCategory ProductCategory)
        {
          
            _context.Entry(ProductCategory).State = EntityState.Modified;

            var obj = _context.ProductCategory.Where(x => x.Id == 1).FirstOrDefault();
            await _context.SaveChangesAsync();
            return ProductCategory;
        }
        public bool DeleteProductCategory(int ID)
        {
            bool result = false;
            var objProduct_Category = _context.ProductCategory.Find(ID);
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
