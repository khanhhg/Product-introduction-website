using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WPI.WebApi.Data;
using WPI.WebApi.Data.Models.EF;
using WPI.WebApi.Services.Generic;
using WPI.WebApi.Services.IRepository;

namespace WPI.WebApi.Services.Repository
{
    public class ProductCategoriesRepository : GenericRepository<ProductCategory>, IProductCategoriesRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductCategoriesRepository(ApplicationDbContext context): base(context)
        {
            _context = context ??
                throw new ArgumentNullException(nameof(context));         
        }        
    }
}
