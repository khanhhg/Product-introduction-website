using AutoMapper;
using WPI.WebApi.Data.Models.Dto;
using WPI.WebApi.Data.Models.EF;

namespace WPI.WebApi.Data.Models
{
    public class AppMapperProfile : Profile
    {
        public AppMapperProfile()
        {
            CreateMap<ProductCategoryDto, ProductCategory>();
            CreateMap<ProductInventoryDto, ProductInventory>();
        }
    }
}
