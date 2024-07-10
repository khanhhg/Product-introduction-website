using AutoMapper;
using WPI.WebApi.Data.Models.EF;
using WPI.WebApi.Data;
using WPI.WebApi.Services.Generic;
using WPI.WebApi.Services.IRepository;

namespace WPI.WebApi.Services.Repository
{
    public class UserProfileRepository : GenericRepository<UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
