using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WPI.WebApi.Data.Models.EF;

namespace WPI.WebApi.Services.IRepository
{
    public interface IProductCategoryRepository
    {
        Task<IEnumerable<ProductCategory>> GetProductCategory();
        Task<ProductCategory> GetProductCategoryByID(int ID);
        Task<ProductCategory> InsertProductCategory(ProductCategory objProduct_Category);
        Task<ProductCategory> UpdateProductCategory(ProductCategory objProduct_Category);
        bool DeleteProductCategory(int ID);
    }
}
