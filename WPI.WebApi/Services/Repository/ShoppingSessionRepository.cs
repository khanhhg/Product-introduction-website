using AutoMapper;
using WPI.WebApi.Data;
using WPI.WebApi.Data.Models.EF;
using WPI.WebApi.Services.Generic;
using WPI.WebApi.Services.IRepository;

namespace WPI.WebApi.Services.Repository
{
    public class ShoppingSessionRepository : GenericRepository<ShoppingSession> , IShoppingSessionRepository
    {
        public ShoppingSessionRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
