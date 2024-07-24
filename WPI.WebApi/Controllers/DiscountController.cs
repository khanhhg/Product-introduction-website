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
    public class DiscountController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DiscountController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _unitOfWork.DiscountRepos.GetAll());
        }
        [HttpGet]
        [Route("GetById/{Id}")]
        public IActionResult GetById(int Id)
        {
            return Ok(_unitOfWork.DiscountRepos.GetById(Id));
        }
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Post(DiscountDto DiscountDto)
        {
            var objDiscount = _mapper.Map<Discount>(DiscountDto);
            var result = await _unitOfWork.DiscountRepos.Add(objDiscount);
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
        public IActionResult Put(DiscountDto DiscountDto)
        {
            var objDiscount = _mapper.Map<Discount>(DiscountDto);
            objDiscount.Modified_at = DateTime.Now;
            _unitOfWork.DiscountRepos.Update(objDiscount);
            _unitOfWork.Save();
            return Ok("Update Success");
        }
        [HttpDelete]
        [Route("Delete")]
        public JsonResult Delete(int id)
        {
            var objDiscount = _unitOfWork.DiscountRepos.GetById(id);
            _unitOfWork.DiscountRepos.Remove(objDiscount);
            _unitOfWork.Save();
            return new JsonResult("Delete Success");
        }
    }
}
