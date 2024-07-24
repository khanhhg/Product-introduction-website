using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WPI.WebApi.Data.Models.Dto;
using WPI.WebApi.Data.Models.EF;
using WPI.WebApi.Services.Generic;

namespace WPI.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductInventoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductInventoryController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _unitOfWork.ProductInventoryRepos.GetAll());
        }
        [HttpGet]
        [Route("GetById/{Id}")]
        public IActionResult GetById(int Id)
        {
            return Ok(_unitOfWork.ProductInventoryRepos.GetById(Id));
        }
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Post(ProductInventoryDto ProductInventoryDto)
        {
            var objProductInventory = _mapper.Map<ProductInventory>(ProductInventoryDto);
            var result = await _unitOfWork.ProductInventoryRepos.Add(objProductInventory);
            _unitOfWork.Save();
            if (result.Id == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred");
            }
            else
            {
                return Ok("Create success");
            }
        }
        [HttpPut]
        [Route("Update")]
        public IActionResult Put(ProductInventoryDto ProductInventoryDto)
        {
            var objProductInventory = _mapper.Map<ProductInventory>(ProductInventoryDto);
            objProductInventory.Modified_at = DateTime.Now;
            _unitOfWork.ProductInventoryRepos.Update(objProductInventory);
            _unitOfWork.Save();
            return Ok("Update Success");
        }
        [HttpDelete]
        [Route("Delete")]
        public JsonResult Delete(int id)
        {
            var objProductInventory = _unitOfWork.ProductInventoryRepos.GetById(id);
            _unitOfWork.ProductInventoryRepos.Remove(objProductInventory);
            _unitOfWork.Save();
            return new JsonResult("Delete Success");
        }
    }
}
