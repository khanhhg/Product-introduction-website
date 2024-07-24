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
    public class OrderItemsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public OrderItemsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _unitOfWork.OrderItemsRepos.GetAll());
        }
        [HttpGet]
        [Route("GetById/{Id}")]
        public IActionResult GetById(int Id)
        {
            return Ok(_unitOfWork.OrderItemsRepos.GetById(Id));
        }
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Post(OrderItemsDto OrderItemsDto)
        {
            var objOrderItems = _mapper.Map<OrderItems>(OrderItemsDto);
            var result = await _unitOfWork.OrderItemsRepos.Add(objOrderItems);
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
        public IActionResult Put(OrderItemsDto OrderItemsDto)
        {
            var objOrderItems = _mapper.Map<OrderItems>(OrderItemsDto);
            objOrderItems.Modified_at = DateTime.Now;
            _unitOfWork.OrderItemsRepos.Update(objOrderItems);
            _unitOfWork.Save();
            return Ok("Update Success");
        }
        [HttpDelete]
        [Route("Delete")]
        public JsonResult Delete(int id)
        {
            var objOrderItems = _unitOfWork.OrderItemsRepos.GetById(id);
            _unitOfWork.OrderItemsRepos.Remove(objOrderItems);
            _unitOfWork.Save();
            return new JsonResult("Delete Success");
        }
    }
}
