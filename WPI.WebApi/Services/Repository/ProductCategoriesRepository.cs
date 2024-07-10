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
        public ProductCategoriesRepository(ApplicationDbContext context, IMapper mapper): base(context,mapper)
        {          
        }        
    }
}
