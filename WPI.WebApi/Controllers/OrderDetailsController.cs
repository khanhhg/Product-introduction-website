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
    public class OrderDetailsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public OrderDetailsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _unitOfWork.OrderDetailsRepos.GetAll());
        }
        [HttpGet]
        [Route("GetById/{Id}")]
        public IActionResult GetById(int Id)
        {
            return Ok(_unitOfWork.OrderDetailsRepos.GetById(Id));
        }
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Post(OrderDetailsDto OrderDetailsDto)
        {
            var objOrderDetails = _mapper.Map<OrderDetails>(OrderDetailsDto);
            var result = await _unitOfWork.OrderDetailsRepos.Add(objOrderDetails);
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
        public IActionResult Put(OrderDetailsDto OrderDetailsDto)
        {
            var objOrderDetails = _mapper.Map<OrderDetails>(OrderDetailsDto);
            objOrderDetails.Modified_at = DateTime.Now;
            _unitOfWork.OrderDetailsRepos.Update(objOrderDetails);
            _unitOfWork.Save();
            return Ok("Update Success");
        }
        [HttpDelete]
        [Route("Delete")]
        public JsonResult Delete(int id)
        {
            var objOrderDetails = _unitOfWork.OrderDetailsRepos.GetById(id);
            _unitOfWork.OrderDetailsRepos.Remove(objOrderDetails);
            _unitOfWork.Save();
            return new JsonResult("Delete Success");
        }
    }
}
