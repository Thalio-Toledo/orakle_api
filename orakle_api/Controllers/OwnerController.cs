using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using orakle_api.Entities;
using orakle_api.services;
using System.Net;

namespace orakle_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class OwnerController : ControllerBase
    {
        private OwnerService _service;

        public OwnerController(OwnerService service)
        {
            _service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var res = await _service.GetAll();
            return Ok(res);
        }

        [HttpGet("FindById/{id}")]
        public async Task<IActionResult> FindById(Guid id)
        {
            var res = await _service.FindById(id);
            if (res is null)
                return StatusCode(500, "Error to find Owner");
            return Ok(res);
        }

        [ProducesResponseType<bool>((int)HttpStatusCode.Created)]
        [HttpPost]
        public async Task<IActionResult> Create(Owner owner)
        {
            var res = await _service.Create(owner);
            return Ok(res);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Owner owner)
        {
            var res = await _service.Update(owner);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var res = await _service.Delete(id);

            return Ok(res);
        }
    }
}
