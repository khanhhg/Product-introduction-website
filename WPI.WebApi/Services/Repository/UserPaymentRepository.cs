using AutoMapper;
using WPI.WebApi.Data;
using WPI.WebApi.Data.Models.EF;
using WPI.WebApi.Services.Generic;
using WPI.WebApi.Services.IRepository;

namespace WPI.WebApi.Services.Repository
{
    public class UserPaymentRepository :GenericRepository<UserPayment> ,IUserPaymentRepository
    {
        public UserPaymentRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
