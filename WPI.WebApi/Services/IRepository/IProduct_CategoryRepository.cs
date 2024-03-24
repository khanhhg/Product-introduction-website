using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WPI.WebApi.Data.Models;

namespace WPI.WebApi.Services.IRepository
{
    public interface IProduct_CategoryRepository
    {
        Task<IEnumerable<Product_Category>> GetProduct_Category();
        Task<Product_Category> GetProduct_CategoryByID(int ID);
        Task<Product_Category> InsertProduct_Category(Product_Category objProduct_Category);
        Task<Product_Category> UpdateProduct_Category(Product_Category objProduct_Category);
        bool DeleteProduct_Category(int ID);
    }
}
