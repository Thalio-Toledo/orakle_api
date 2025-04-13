using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using orakle_api.DTOs;
using orakle_api.Entities;
using orakle_api.Filters;
using orakle_api.services;
using System.Net;

namespace orakle_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ArtefactController : ControllerBase
    {
        private ArtefactService _service;

        public ArtefactController(ArtefactService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //var res = await _service.GetAll();
            return Ok("Olá");
        }

        [HttpGet("GetByOwnerId/{OwnerId}")]
        public async Task<IActionResult> GetByOwnerId(Guid OwnerId)
        {
            var res = await _service.GetByOwnerId(OwnerId);
            return Ok(res);
        }

        [AllowAnonymous]
        [HttpGet("External/GetByFilter")]
        public async Task<IActionResult> ExternalGetByFilter([FromQuery] ArtefactFilter filter)
        {
            var res = await _service.GetByFilter(filter);
            return Ok(res);
        }
       
        [HttpGet("GetByFilter")]
        public async Task<IActionResult> GetByFilter([FromQuery] ArtefactFilter filter)
        {
            var res = await _service.GetByFilter(filter);
            return Ok(res);
        }

        [AllowAnonymous]
        [HttpGet("FindById/{ArtefactId}")]
        public async Task<IActionResult> FindById(Guid ArtefactId)
        {
            var res = await _service.FindById(ArtefactId);
            return Ok(res);
        }

        [HttpGet("GetByTitle/{title}")]
        public async Task<IActionResult> GetByTitle(string title)
        {
           var res = await _service.GetByTitle(title);
            return Ok(res);
        }

        [ProducesResponseType<bool>((int)HttpStatusCode.Created)]
        [HttpPost]
        public async Task<IActionResult> Create(ArtefactCreateDTO dto)
        {
            var res = await _service.Create(dto);
            if (res is null)
                return StatusCode(500, "Error to create Artefact!");

            return Ok(res);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ArtefactUpdateDTO dto)
        {
            var res = await _service.Update(dto);
            if (res is null)
                return StatusCode(500, "Error to update Artefact!");
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
