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
    public class ShoppingSessionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ShoppingSessionController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _unitOfWork.ShoppingSessionRepos.GetAll());
        }
        [HttpGet]
        [Route("GetById/{Id}")]
        public IActionResult GetById(int Id)
        {
            return Ok(_unitOfWork.ShoppingSessionRepos.GetById(Id));
        }
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Post(ShoppingSessionDto ShoppingSessionDto)
        {
            var objShoppingSession = _mapper.Map<ShoppingSession>(ShoppingSessionDto);
            var result = await _unitOfWork.ShoppingSessionRepos.Add(objShoppingSession);
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
        public IActionResult Put(ShoppingSessionDto ShoppingSessionDto)
        {
            var objShoppingSession = _mapper.Map<ShoppingSession>(ShoppingSessionDto);
            objShoppingSession.Modified_at = DateTime.Now;
            _unitOfWork.ShoppingSessionRepos.Update(objShoppingSession);
            _unitOfWork.Save();
            return Ok("Update Success");
        }
        [HttpDelete]
        [Route("Delete")]
        public JsonResult Delete(int id)
        {
            var objShoppingSession = _unitOfWork.ShoppingSessionRepos.GetById(id);
            _unitOfWork.ShoppingSessionRepos.Remove(objShoppingSession);
            _unitOfWork.Save();
            return new JsonResult("Delete Success");
        }
    }
}
