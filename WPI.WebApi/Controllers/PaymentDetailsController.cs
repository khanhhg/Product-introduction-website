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
    public class PaymentDetailsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PaymentDetailsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _unitOfWork.PaymentDetailsRepos.GetAll());
        }
        [HttpGet]
        [Route("GetById/{Id}")]
        public IActionResult GetById(int Id)
        {
            return Ok(_unitOfWork.PaymentDetailsRepos.GetById(Id));
        }
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Post(PaymentDetailsDto PaymentDetailsDto)
        {
            var objPaymentDetails = _mapper.Map<PaymentDetails>(PaymentDetailsDto);
            var result = await _unitOfWork.PaymentDetailsRepos.Add(objPaymentDetails);
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
        public IActionResult Put(PaymentDetailsDto PaymentDetailsDto)
        {
            var objPaymentDetails = _mapper.Map<PaymentDetails>(PaymentDetailsDto);
            objPaymentDetails.Modified_at = DateTime.Now;
            _unitOfWork.PaymentDetailsRepos.Update(objPaymentDetails);
            _unitOfWork.Save();
            return Ok("Update Success");
        }
        [HttpDelete]
        [Route("Delete")]
        public JsonResult Delete(int id)
        {
            var objPaymentDetails = _unitOfWork.PaymentDetailsRepos.GetById(id);
            _unitOfWork.PaymentDetailsRepos.Remove(objPaymentDetails);
            _unitOfWork.Save();
            return new JsonResult("Delete Success");
        }
    }
}
