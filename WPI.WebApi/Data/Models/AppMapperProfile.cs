using AutoMapper;
using WPI.WebApi.Data.Models.Dto;
using WPI.WebApi.Data.Models.EF;

namespace WPI.WebApi.Data.Models
{
    public class AppMapperProfile : Profile
    {
        public AppMapperProfile()
        {
            CreateMap<CartItem, CartItemDto>();
            CreateMap<CartItemDto, CartItem>();

            CreateMap<Discount, DiscountDto>();
            CreateMap<DiscountDto, Discount>();

            CreateMap<OrderDetails, OrderDetailsDto>();
            CreateMap<OrderDetailsDto, OrderDetails>();

            CreateMap<OrderItems, OrderItemsDto>();
            CreateMap<OrderItemsDto, OrderItems>();

            CreateMap<PaymentDetails, PaymentDetailsDto>();
            CreateMap<PaymentDetailsDto, PaymentDetails>();

            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

            CreateMap<ProductCategory, ProductCategoryDto>();
            CreateMap<ProductCategoryDto, ProductCategory>();

            CreateMap<ProductInventory, ProductInventoryDto>();
            CreateMap<ProductInventoryDto, ProductInventory>();

            CreateMap<ShoppingSession, ShoppingSessionDto>();
            CreateMap<ShoppingSessionDto, ShoppingSession>();

            CreateMap<UserPayment, UserPaymentDto>();
            CreateMap<UserPaymentDto, UserPayment>();

            CreateMap<UserProfile, UserProfileDto>();
            CreateMap<UserProfileDto, UserProfile>();
        }
    }
}
