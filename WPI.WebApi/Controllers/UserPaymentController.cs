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
    public class UserPaymentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserPaymentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _unitOfWork.UserPaymentRepos.GetAll());
        }
        [HttpGet]
        [Route("GetById/{Id}")]
        public IActionResult GetById(int Id)
        {
            return Ok(_unitOfWork.UserPaymentRepos.GetById(Id));
        }
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Post(UserPaymentDto UserPaymentDto)
        {
            var objUserPayment = _mapper.Map<UserPayment>(UserPaymentDto);
            var result = await _unitOfWork.UserPaymentRepos.Add(objUserPayment);
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
        public IActionResult Put(UserPaymentDto UserPaymentDto)
        {
            var objUserPayment = _mapper.Map<UserPayment>(UserPaymentDto);           
            _unitOfWork.UserPaymentRepos.Update(objUserPayment);
            _unitOfWork.Save();
            return Ok("Update Success");
        }
        [HttpDelete]
        [Route("Delete")]
        public JsonResult Delete(int id)
        {
            var objUserPayment = _unitOfWork.UserPaymentRepos.GetById(id);
            _unitOfWork.UserPaymentRepos.Remove(objUserPayment);
            _unitOfWork.Save();
            return new JsonResult("Delete Success");
        }
    }
}
