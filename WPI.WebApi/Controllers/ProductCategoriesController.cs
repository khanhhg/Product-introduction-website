using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WPI.WebApi.Data.Models.Dto;
using WPI.WebApi.Data.Models.EF;
using WPI.WebApi.Services.Generic;

namespace WPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductCategoriesController(IUnitOfWork unitOfWork, IMapper mapper )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
           var lstProductCategory =  await _unitOfWork.ProductCategory.GetAll();
            return Ok(lstProductCategory);
        }
        [HttpGet]
        [Route("GetById/{Id}")]
        public IActionResult GetById(int Id)
        {
            var objProductCategory =  _unitOfWork.ProductCategory.GetById(Id);
            return Ok(objProductCategory);
        }
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add(ProductCategoryDto objDto)
        {
            var objProductCategory = _mapper.Map<ProductCategory>(objDto);
            var result = await _unitOfWork.ProductCategory.Add(objProductCategory);
            if(result.Id ==0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Đã xảy ra lỗi");
            }
            else
            {
                return Ok(result);
            }
           
        }
        [HttpPut]
        [Route("Update")]
        public IActionResult Put(ProductCategoryDto objDto)
        {
            var objProductCategory = _mapper.Map<ProductCategory>(objDto);
           _unitOfWork.ProductCategory.Update(objProductCategory);
            return Ok("Update success");
        }
        [HttpDelete]       
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            var objProductCategory = _unitOfWork.ProductCategory.GetById(id);
            _unitOfWork.ProductCategory.Remove(objProductCategory);
            return new JsonResult("Delete success");
        }
    }
}
